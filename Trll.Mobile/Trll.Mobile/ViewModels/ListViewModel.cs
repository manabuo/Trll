using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using Trll.Core;
using Trll.Core.Entities;
using Trll.Mobile.Views;
using Xamarin.Forms;

namespace Trll.Mobile.ViewModels
{
    public class ListViewModel : BindableBase
    {
        private List _list;
        private readonly INavigationService _navigationService;

        public ListViewModel(
            List list,
            INavigationService navigationService)
        {
            List = list;
            _navigationService = navigationService;
        }

        public List List
        {
            get { return _list; }
            set
            {
                SetProperty(ref _list, value);
                OnPropertyChanged(nameof(Cards));
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Name => List.Name;

        public ObservableCollection<CardViewModel> Cards => _list.Cards
            .Select(card => new CardViewModel(card))
            .Then(models => new ObservableCollection<CardViewModel>(models));

        public ICommand CardSelected => new Command<CardViewModel>(async card =>
        {
            await _navigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(CardPage)}", new NavigationParameters
            {
                ["card"] = card.Card
            });
        });

    }
}