using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Stores;
using AssetManagement.DesktopUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AssetManagement.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()

                .AddSingleton<ViewModelLocator>()
                .AddSingleton<NavigationStore>()

                .AddSingleton<INavigationService>(s => CreateLoginNavigationService(s))


                .AddTransient<LoginViewModel>()

                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainWindowViewModel>()
                })

                .BuildServiceProvider()
                );
        }


        // x:Name must be added in App.xaml in order to override OnStartup() method and have ViewModelLocator working
        protected override void OnStartup(StartupEventArgs e) 
        {
            INavigationService initialNavigationService = Ioc.Default.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = Ioc.Default.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }



        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        //private LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        //{

        //}
    }
}
