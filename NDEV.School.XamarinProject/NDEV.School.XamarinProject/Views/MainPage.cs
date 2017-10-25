using NDEV.School.XamarinProject.Views;
using System;

using Xamarin.Forms;

namespace NDEV.School.XamarinProject
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, aboutPage = null;
            Page gameSettingsPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    throw new Exception("This app doesn't support IOS!");
                    /*itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;*/
                default:
                    itemsPage = new ItemsPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };

                    gameSettingsPage = new GameSettingsPage()
                    {
                        Title = "Game settings"
                    };

                    break;
            }

            Children.Add(itemsPage);
            Children.Add(aboutPage);
            Children.Add(gameSettingsPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
