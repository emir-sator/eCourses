using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourses.Mobile.Views.MyCourses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCoursesPage : TabbedPage
    {
        public MyCoursesPage()
        {
            InitializeComponent();
        }
    }
}