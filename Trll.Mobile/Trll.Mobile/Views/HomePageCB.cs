using Prism.Commands;
using Trll.Mobile.Behaviors;
using Trll.Mobile.Presenters;
using Trll.Mobile.ViewModels;
using Xamarin.Forms;

namespace Trll.Mobile.Views
{
    public class HomePageCB : ContentPage
    {
        public HomePageCB()
        {
            BindingContext = new HomePageViewModel();

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Label().Tap(
                                label => label.SetBinding<HomePageViewModel>(Label.TextProperty, model => model.Name)),
                            new Button {Text = "Search"},
                            new Button {Text = "Notifications"},
                            new Button {Text = "Menu"},
                        }
                    },
                    new ListView
                    {
                        IsGroupingEnabled = true,
                        GroupDisplayBinding = Binding.Create<TeamPresenter>(team => team.TeamName),
                        ItemTemplate = new DataTemplate(() => new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    new BoxView
                                    {
                                        Color = Color.Accent
                                    },
                                    new Label().Tap(
                                        l => l.SetBinding<BoardPresenter>(Label.TextProperty, b => b.BoardName))
                                }
                            }
                        }),
                        Behaviors =
                        {
                            new ListViewSelectedItemBehavior()
                                .Tap(behavior => behavior
                                    .SetBinding<HomePageViewModel>(
                                        ListViewSelectedItemBehavior.CommandProperty,
                                        model => model.BoardSelected))
                        }
                    }.Tap(view => view.SetBinding<HomePageViewModel>(ListView.ItemsSourceProperty, model => model.Teams)),
                }
            };
        }
    }
}