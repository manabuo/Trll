using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using Trll.Core;
using Trll.Core.Entities;
using Trll.Core.Services;

namespace Trll.Mobile.ViewModels
{
    public class BoardViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IBoardService _boardService;


        public BoardViewModel(
            IBoardService boardService,
            INavigationService navigationService)
        {
            _boardService = boardService;
            _navigationService = navigationService;
        }

        private Board _board;

        public string Name => Board?.Name;


        public Board Board
        {
            get { return _board; }
            set
            {
                SetProperty(ref _board, value);
                OnPropertyChanged(nameof(Name));
            }
        }

        private ObservableCollection<ListViewModel> _lists;

        public ObservableCollection<ListViewModel> Lists
        {
            get { return _lists; }
            set { SetProperty(ref _lists, value); }
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            Board = parameters["board"] as Board;

            Lists = await _boardService.ListsByBoardIdAsync(_board.Id)
                .ThenAsync(lists => lists.Select(list => new ListViewModel(list, _navigationService)))
                .ThenAsync(lists => new ObservableCollection<ListViewModel>(lists));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        { }
    }
}