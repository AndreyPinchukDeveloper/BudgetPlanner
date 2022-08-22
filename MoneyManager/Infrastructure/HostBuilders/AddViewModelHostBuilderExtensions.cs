using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyManager.Infrastructure.Services;
using MoneyManager.Infrastructure.Stores;
using MoneyManager.ViewModels;
using System;

namespace MoneyManager.Infrastructure.HostBuilders
{
    public static class AddViewModelHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton((s) => CreateOperationListingViewModel(s));
                services.AddTransient<Func<OperationListingViewModel>>((s) => () => s.GetRequiredService<OperationListingViewModel>());
                services.AddSingleton<MyNavigationService<OperationListingViewModel>>();

                services.AddSingleton<MakeOperationViewModel>();
                services.AddTransient<Func<MakeOperationViewModel>>((s) => () => s.GetRequiredService<MakeOperationViewModel>());
                services.AddSingleton<MyNavigationService<MakeOperationViewModel>>();
            });
            return hostBuilder;
        }

        private static OperationListingViewModel CreateOperationListingViewModel(IServiceProvider services)
        {
            return OperationListingViewModel.LoadViewModel(
                services.GetRequiredService<AllOperationsStore>(),
                services.GetRequiredService<MyNavigationService<MakeOperationViewModel>>());
        }
    }
}
