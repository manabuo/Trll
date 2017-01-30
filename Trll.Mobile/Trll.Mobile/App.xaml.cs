using Prism.Unity;
using Trll.Mobile.ViewModels;
using Trll.Mobile.Views;
using Xamarin.Forms;

namespace Trll.Mobile
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(HomePage)}");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LandingPage, LandingViewModel>();
            Container.RegisterTypeForNavigation<LogInPage,LogInViewModel>();
            Container.RegisterTypeForNavigation<SignUpPage, SignUpViewModel>();
            Container.RegisterTypeForNavigation<HomePage, HomeViewModel>();
            Container.RegisterTypeForNavigation<BoardPage, BoardViewModel>();
            Container.RegisterTypeForNavigation<NavigationPage>();
        }
    }
}
