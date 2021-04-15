using eCourses.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourses.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<MenuItems> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            menuItems = new List<MenuItems>
            {
                new MenuItems {ID = MenuType.SearchCourse, Title="Search course" },
                new MenuItems {ID = MenuType.MyCourses, Title="My courses" },
                new MenuItems {ID = MenuType.Transactions, Title="Transactions" },
                new MenuItems {ID = MenuType.Account, Title="Account" },
                new MenuItems {ID = MenuType.Logout, Title="Logout" }
            };
            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var ID = (int)((MenuItems)e.SelectedItem).ID;
                await RootPage.NavigateFromMenu(ID);
            };
        }
    }
}