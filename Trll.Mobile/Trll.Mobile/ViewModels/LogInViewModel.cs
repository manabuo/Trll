using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Trll.Mobile.ViewModels
{
    public class LogInViewModel : BindableBase
    {
        private string _emailOrUsername;

        private string _password;
        private readonly INavigationService _navigationService;

        public LogInViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string EmailOrUsername
        {
            get { return _emailOrUsername; }
            set { SetProperty(ref _emailOrUsername, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand Cancel => DelegateCommand.FromAsyncHandler(async () => await _navigationService.GoBackAsync());
        public DelegateCommand LogIn => DelegateCommand.FromAsyncHandler(async () => await _navigationService.GoBackAsync());
    }
}