using eCourses.Mobile.Models;
using eCourses.Mobile.Views.Course;
using eCourses.Mobile.Views.Account;
using eCourses.Mobile.Views.MyCourses;
using eCourses.Mobile.Views.SearchCourse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eCourses.Mobile.Views.Transactions;

namespace eCourses.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
        }
        public async Task NavigateFromMenu(int ID)
        {
            if (!MenuPages.ContainsKey(ID))
            {
                switch (ID)
                {
                  
                    case (int)MenuType.SearchCourse:
                        MenuPages.Add(ID, new NavigationPage(new SearchCoursePage()));
                        break;
                    case (int)MenuType.MyCourses:
                        MenuPages.Add(ID, new NavigationPage(new MyCoursesPage()));
                        break;
                    case (int)MenuType.Transactions:
                        MenuPages.Add(ID, new NavigationPage(new TransactionsPage()));
                        break;
                    case (int)MenuType.Account:
                        MenuPages.Add(ID, new NavigationPage(new AccountPage()));
                        break;
                    case (int)MenuType.Logout:
                        MenuPages.Add(ID, new NavigationPage(new LogoutPage()));
                        break;
                }
            }

            var newPage = MenuPages[ID];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
