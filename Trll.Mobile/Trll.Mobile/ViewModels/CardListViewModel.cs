using System.Collections.Generic;
using Prism.Mvvm;

namespace Trll.Mobile.ViewModels
{
    public class CardListViewModel : BindableBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CardViewModel> Cards { get; set; }
    }
}