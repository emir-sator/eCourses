using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using Xamarin.Forms;

namespace eCourses.Mobile.Converters
{
    public class UserConverter: IValueConverter
    {
   

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var user = value as MUser;
                return user.FirstName + " " + user.LastName;
            }
            return null;
        }

   

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
