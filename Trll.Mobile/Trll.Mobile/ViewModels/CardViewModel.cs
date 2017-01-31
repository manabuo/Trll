using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using Trll.Core.Entities;

namespace Trll.Mobile.ViewModels
{
    public class CardViewModel : BindableBase, INavigationAware
    {
        private Card _card;

        public CardViewModel(Card card)
        {
            Card = card;
        }

        public Card Card
        {
            get { return _card; }
            set
            {
                SetProperty(ref _card, value);
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(LabelColor));
                OnPropertyChanged(nameof(LabelName));
                OnPropertyChanged(nameof(HasLabel));
                OnPropertyChanged(nameof(HasChecklist));
                OnPropertyChanged(nameof(ChecklistText));
                OnPropertyChanged(nameof(HasComments));
                OnPropertyChanged(nameof(CommentCount));
                OnPropertyChanged(nameof(HasDescription));
                OnPropertyChanged(nameof(HasDue));
                OnPropertyChanged(nameof(Due));
                OnPropertyChanged(nameof(DueColor));
                OnPropertyChanged(nameof(HasAttachments));
                OnPropertyChanged(nameof(AttachmentCount));
                OnPropertyChanged(nameof(Members));
                OnPropertyChanged(nameof(Description));
                OnPropertyChanged(nameof(HasMembers));
            }
        }

        public string Name => Card?.Name;

        public string Description => Card?.Description;

        #region Label
        public bool HasLabel => Card?.Labels?.Any() ?? false;

        public string LabelColor => Card?.Labels
                                        ?.FirstOrDefault()
                                        ?.Color
                                        ?.ToColorCode()
                                    ?? "#FFFFFF";

        public string LabelName => Card?.Labels?.FirstOrDefault()?.Name ?? string.Empty;
        #endregion

        #region Badges

        public bool HasChecklist => Card?.Badges.CheckItems != 0;

        public string ChecklistText => Card == null
            ? null
            : $"{Card.Badges.CheckItemsChecked}/{Card.Badges.CheckItems}";

        public bool HasComments => Card?.Badges.Comments != 0;

        public int CommentCount => Card?.Badges.Comments ?? 0;

        public bool HasDescription => Card?.Badges?.Description ?? false;

        public bool HasDue => Card?.Badges.Due.HasValue ?? false;

        public string Due => Card?.Badges.Due?.ToString();

        public bool DueComplete => Card?.DueComplete ?? false;

        public string DueColor => Card?.Badges.DueComplete ?? false
            ? "#5AAC44"
            : (Card.Due ?? DateTime.Now) > DateTime.Now
                ? "#E2E4E6"
                : "#EC9488";

        public bool HasAttachments => Card?.Badges.Attachments != 0;

        public int AttachmentCount => Card?.Badges.Attachments ?? 0;

        #endregion

        public bool HasMembers => Members.Any();

        public IEnumerable<MemberInfo> Members => Card?.Members ?? Enumerable.Empty<MemberInfo>();

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Card = parameters["card"] as Card;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        { }
    }
}