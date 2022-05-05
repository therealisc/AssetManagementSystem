using AssetManagement.DesktopUI.Services;
using AssetManagement.DesktopUI.Stores;
using AssetManagement.DesktopUI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AssetManagement.Library.DataAccess;
using AssetManagement.DesktopUI.Services.AuthentificationServices;
using Microsoft.AspNet.Identity;

namespace AssetManagement.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<AccountStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<INavigationService>(CreateLoginNavigationService);
            services.AddTransient<LoginViewModel>(CreateLoginViewModel); //transient pentru avea mereu o noua instanta
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddTransient<HomeViewModel>();
            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);

            services.AddTransient<SqlDataAccess>();
            services.AddTransient<UserData>();
            services.AddTransient<AuthentificationService>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();

            services.AddSingleton(config);
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            LayoutNavigationService<HomeViewModel> navigationService = new(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());

            return new LoginViewModel(
                serviceProvider.GetRequiredService<AccountStore>(),
                navigationService,
                serviceProvider.GetRequiredService<AuthentificationService>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                serviceProvider.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(serviceProvider),
                null,
                CreateLoginNavigationService(serviceProvider));
        }
    }
}
