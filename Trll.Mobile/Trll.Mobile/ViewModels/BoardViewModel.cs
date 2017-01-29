using Prism.Mvvm;
using Prism.Navigation;

namespace Trll.Mobile.ViewModels
{
    public class BoardViewModel : BindableBase, INavigationAware
    {
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Id = (int) parameters["boardId"];
        }

        public int Id { get; set; }
    }
}