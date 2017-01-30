using System.Collections.Generic;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using Trll.Mobile.Presenters;
using Trll.Mobile.Views;
using Xamarin.Forms;

namespace Trll.Mobile.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string Name => "Maximo";

        public ICommand BoardSelected => new Command<BoardPresenter>(async presenter =>
        {
            await _navigationService.NavigateAsync(nameof(Board), new NavigationParameters
            {
                ["boardId"] = presenter.Id
            });
        });



        public IEnumerable<TeamPresenter> Teams => new List<TeamPresenter>
        {
            new TeamPresenter
            {
                TeamName = "Personal",
                TeamBoards = new List<BoardPresenter>
                {
                    new BoardPresenter
                    {
                        Id = 1,
                        BoardName = "Shopping list"
                    },
                    new BoardPresenter
                    {
                        Id = 2,
                        BoardName = "Car maintenance"
                    },new BoardPresenter
                    {
                        Id = 3,
                        BoardName = "Shopping list"
                    }
                }
            },
            new TeamPresenter
            {
                TeamName = "Work",
                TeamBoards = new List<BoardPresenter>
                {
                    new BoardPresenter
                    {
                        Id = 4,
                        BoardName = "Tasks"
                    },
                    new BoardPresenter
                    {
                        Id = 5,
                        BoardName = "asd"
                    },
                    new BoardPresenter
                    {
                        Id = 6,
                        BoardName = "qwe"
                    }
                }
            },
        };

    }
}