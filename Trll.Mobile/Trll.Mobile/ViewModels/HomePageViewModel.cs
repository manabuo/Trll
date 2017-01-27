using System.Collections.Generic;
using Prism.Mvvm;
using Trll.Mobile.Presenters;

namespace Trll.Mobile.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
        public string Name => "Maximo";

        public IEnumerable<TeamPresenter> Teams => new List<TeamPresenter>
        {
            new TeamPresenter
            {
                TeamName = "Personal",
                TeamBoards = new List<BoardPresenter>
                {
                    new BoardPresenter
                    {
                        BoardName = "Shopping list"
                    },
                    new BoardPresenter
                    {
                        BoardName = "Car maintenance"
                    },new BoardPresenter
                    {
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
                        BoardName = "Tasks"
                    },
                    new BoardPresenter
                    {
                        BoardName = "asd"
                    },
                    new BoardPresenter
                    {
                        BoardName = "qwe"
                    }
                }
            },
        };

    }
}