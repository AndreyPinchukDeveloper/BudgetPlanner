using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyManager.Infrastructure.DbContexts;
using MoneyManager.Infrastructure.HostBuilders;
using MoneyManager.Infrastructure.Services;
using MoneyManager.Infrastructure.Services.OperationConflictValidator;
using MoneyManager.Infrastructure.Services.OperationCreator;
using MoneyManager.Infrastructure.Services.OperationProvider;
using MoneyManager.Infrastructure.Stores;
using MoneyManager.Models;
using MoneyManager.View;
using MoneyManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((hostContext, services) =>
                {
                    string connectionString = hostContext.Configuration.GetConnectionString("Default");

                    services.AddSingleton(new MoneyManagerDbContextFactory(connectionString));
                    services.AddSingleton<IOperationProvider, DatabaseOperationProvider>();
                    services.AddSingleton<IOperationCreator, DatabaseOperationCreator>();
                    services.AddSingleton<IOperationConflictValidator, DatabaseOperationConflictValidator>();

                    services.AddTransient<OperationBook>();
                    services.AddSingleton((s) => new AllOperations(s.GetRequiredService<OperationBook>()));

                    services.AddSingleton<AllOperationsStore>();
                    services.AddSingleton<NavigationStore>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        private OperationListingViewModel CreateOperationListingViewModel(IServiceProvider services)
        {
            return OperationListingViewModel.LoadViewModel(
                services.GetRequiredService<AllOperationsStore>(),
                services.GetRequiredService<MyNavigationService<MakeOperationViewModel>>());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MoneyManagerDbContextFactory reservoomDbContextFactory = _host.Services.GetRequiredService<MoneyManagerDbContextFactory>();
            using (MoneyManagerDbContext dbContext = reservoomDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            MyNavigationService<OperationListingViewModel> myNavigationService = _host.Services.GetRequiredService<MyNavigationService<OperationListingViewModel>>();
            myNavigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();//make free ungovernable resources

            base.OnExit(e);
        }
    }
}
