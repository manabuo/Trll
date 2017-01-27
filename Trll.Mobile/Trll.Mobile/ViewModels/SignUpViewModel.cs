using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Trll.Mobile.Views;

namespace Trll.Mobile.ViewModels
{
    public class SignUpViewModel : BindableBase
    {
		private string _name;
		private string _email;
		private string _password;
        private readonly INavigationService _navigationService;

        public SignUpViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}
		public string Email
		{
			get { return _email; }
			set { SetProperty(ref _email, value); }
		}
		public string Password
		{
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

        public DelegateCommand Cancel => DelegateCommand.FromAsyncHandler(async () =>
            await _navigationService.GoBackAsync());

        public DelegateCommand Create => DelegateCommand.FromAsyncHandler(async () =>
            await _navigationService.NavigateAsync(nameof(Boards)));
    }
}