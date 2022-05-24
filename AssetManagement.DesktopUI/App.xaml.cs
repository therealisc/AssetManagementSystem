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
            services.AddTransient<AccountViewModel>();
            services.AddTransient<ClasificationCodesViewModel>();
            services.AddTransient<DocumentsViewModel>(CreateDocumentsViewModel);
            services.AddTransient<SuppliersViewModel>();
            services.AddTransient<ClientsViewModel>();
            services.AddTransient<UsersViewModel>();
            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);

            services.AddTransient<SqlDataAccess>();
            services.AddTransient<UserData>();
            services.AddTransient<ClasificationCodeData>();
            services.AddTransient<SupplierData>();
            services.AddTransient<DocumentData>();
            services.AddTransient<ClientData>();
            services.AddTransient<AuthentificationService>();
            services.AddTransient<UsersMappingService>();

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

        private INavigationService CreateClasificationCodesNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ClasificationCodesViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ClasificationCodesViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateDocumentsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<DocumentsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<DocumentsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateSuppliersNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<SuppliersViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<SuppliersViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateClientsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ClientsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ClientsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateUsersNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<UsersViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<UsersViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                serviceProvider.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(serviceProvider),
                CreateClasificationCodesNavigationService(serviceProvider),
                CreateDocumentsNavigationService(serviceProvider),
                CreateSuppliersNavigationService(serviceProvider),
                CreateClientsNavigationService(serviceProvider),
                CreateUsersNavigationService(serviceProvider),
                CreateAccountNavigationService(serviceProvider),
                CreateLoginNavigationService(serviceProvider));
        }

        private DocumentsViewModel CreateDocumentsViewModel(IServiceProvider serviceProvider)
        {
            return new DocumentsViewModel(
                CreateSuppliersNavigationService(serviceProvider), 
                serviceProvider.GetRequiredService<SupplierData>(),
                serviceProvider.GetRequiredService<DocumentData>());
        }
    }
}
