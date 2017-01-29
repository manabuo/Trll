using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Trll.Mobile.Behaviors
{
    public class ListViewSelectedItemBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(ListViewSelectedItemBehavior));

        public ICommand Command
        {
            get
            {
                var command = (ICommand)GetValue(CommandProperty);
                return command;
            }
            set { SetValue(CommandProperty, value); }
        }

        private ListView AssociatedObject { get; set; }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.ItemSelected += OnListViewItemSelected;
            AssociatedObject = bindable;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= OnListViewItemSelected;
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Command?.CanExecute(e.SelectedItem) == true)
                Command.Execute(e.SelectedItem);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}