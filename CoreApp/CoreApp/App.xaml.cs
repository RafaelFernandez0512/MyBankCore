using CoreApp.Helpers;
using CoreApp.Services;
using CoreApp.ViewModels;
using CoreApp.Views;
using CoreApp.Views.PrincipalView;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoreApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri($"{ConfigPage.MenuMasterDetailPage}{ConfigPage.NavigationPage}{ConfigPage.HomePage}",UriKind.Absolute));
           
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IApiCore>(new ApiCore());
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MenuMasterDetailPage,MenuMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterClientPage,RegisterClientPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterEmployeePage, RegisterEmployeePageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterUserPage, RegisterUserPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<ClientsPage,ClientsPageViewModel>();
            
        }
        
    }
}
