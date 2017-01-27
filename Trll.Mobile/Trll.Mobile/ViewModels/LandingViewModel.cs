using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Trll.Mobile.ViewModels
{
    public class LandingViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public LandingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SignUp => DelegateCommand.FromAsyncHandler(async () =>
            await _navigationService.NavigateAsync(nameof(Views.SignUp)));

        public DelegateCommand LogIn => DelegateCommand.FromAsyncHandler(async () =>
            await _navigationService.NavigateAsync(nameof(Views.LogIn)));
    }
}

