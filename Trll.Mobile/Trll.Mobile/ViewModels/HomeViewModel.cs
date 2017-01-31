using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using Trll.Core;
using Trll.Core.Entities;
using Trll.Core.Services;
using Trll.Mobile.Presenters;
using Trll.Mobile.Views;
using Xamarin.Forms;

namespace Trll.Mobile.ViewModels
{
    public class HomeViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IOrganizationService _organizationService;
        private readonly IUserProfileService _userProfileService;

        private UserProfile _currentUserProfile;
        private ObservableCollection<Organization> _organizations;

        public HomeViewModel(
            INavigationService navigationService,
            IOrganizationService organizationService,
            IUserProfileService userProfileService)
        {
            _navigationService = navigationService;
            _organizationService = organizationService;
            _userProfileService = userProfileService;
        }

        public string FullName => CurrentUserProfile?.FullName ?? string.Empty;

        public UserProfile CurrentUserProfile
        {
            get { return _currentUserProfile; }
            set
            {
                SetProperty(ref _currentUserProfile, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        public ObservableCollection<Organization> Organizations
        {
            get { return _organizations; }
            set { SetProperty(ref _organizations, value); }
        }

        public ICommand BoardSelected => new Command<Board>(async board =>
        {
            await _navigationService.NavigateAsync(nameof(BoardPage), new NavigationParameters
            {
                ["board"] = board
            });
        });

        public void OnNavigatedFrom(NavigationParameters parameters)
        { }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            Organizations = await _organizationService
                .GetOrganizationsForCurrentUser()
                .ThenAsync(o => new ObservableCollection<Organization>(o));

            CurrentUserProfile = await _userProfileService.GetCurrentUserAsync();
        }
    }
}