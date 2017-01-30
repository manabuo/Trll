using Prism.Mvvm;
using Prism.Navigation;
using Trll.Core.Entities;
using Trll.Core.Storage;

namespace Trll.Mobile.ViewModels
{
    public class BoardViewModel : BindableBase, INavigationAware
    {
        private int _id;
        private readonly IRepository<Board> _boardRepository;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;

        public BoardViewModel(IRepository<Board> boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        { }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Id = (int)parameters["boardId"];
            var board = _boardRepository.ById(Id);
            Name = board.Name;
        }
    }
}