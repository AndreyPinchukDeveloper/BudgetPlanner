using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinUI = Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BudgetPlanner.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Page
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //ContentFrame.Navigate(typeof(SettingsPage));
                NavigationView.Header = "Settings";
                return;
            }

            var item = args.SelectedItemContainer as WinUI.NavigationViewItem;

            if (item.Tag != null)
            {
                ContentFrame.Navigate(Type.GetType(item.Tag.ToString()), item.Content);
                NavigationView.Header = item.Content;
            }
        }
    }
}
