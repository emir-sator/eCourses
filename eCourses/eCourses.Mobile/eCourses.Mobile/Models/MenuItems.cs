using System;
using System.Collections.Generic;
using System.Text;

namespace eCourses.Mobile.Models
{
    public enum MenuType
    {
        SearchCourse,
        MyCourses,
        Transactions,
        Account,
        Logout
    }
    public class MenuItems
    {
        public MenuType ID { get; set; }
        public string Title { get; set; }
    }
}
