using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;
using Trll.Core.Entities;
using Xamarin.Forms;

namespace Trll.Mobile.ViewModels
{
    public class CardViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string MemberName => _members?.FirstOrDefault()?.Name;

        public bool HasMembers => Members?.Any() ?? false;

        private DateTime? _dueDate;
        public DateTime? DueDate
        {
            get { return _dueDate; }
            set
            {
                SetProperty(ref _dueDate, value);
                OnPropertyChanged(nameof(HasDueDate));
            }
        }

        public bool HasDueDate => DueDate.HasValue;

        private Color? _labelColor;
        public Color? LabelColor
        {
            get { return _labelColor; }
            set
            {
                SetProperty(ref _labelColor, value);
                OnPropertyChanged(nameof(HasLabel));
            }
        }

        public bool HasLabel => LabelColor.HasValue;

        private bool _hasComments;
        public bool HasComments
        {
            get { return _hasComments; }
            set { SetProperty(ref _hasComments, value); }
        }

        private ObservableCollection<CheckListItem> _checklist;
        public ObservableCollection<CheckListItem> Checklist
        {
            get { return _checklist; }
            set { SetProperty(ref _checklist, value); }
        }

        public bool HasChecklist => Checklist?.Any() ?? false;

        public string ChecklistCount => Checklist != null
            ? $"{Checklist.Count(item => item.Checked)}/{Checklist.Count}"
            : null;


        private ObservableCollection<User> _members;
        public ObservableCollection<User> Members
        {
            get { return _members; }
            set
            {
                SetProperty(ref _members, value);
                OnPropertyChanged(nameof(HasMembers));
                OnPropertyChanged(nameof(MemberName));
            }
        }
    }

}