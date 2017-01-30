using Prism.Unity;
using Trll.Mobile.Views;

namespace Trll.Mobile
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync($"{nameof(RootPage)}/{nameof(HomePage)}");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<Landing>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LogIn>();
            Container.RegisterTypeForNavigation<SignUp>();
            Container.RegisterTypeForNavigation<HomePage>();
            Container.RegisterTypeForNavigation<Board>();
            Container.RegisterTypeForNavigation<RootPage>();
        }
    }
}
