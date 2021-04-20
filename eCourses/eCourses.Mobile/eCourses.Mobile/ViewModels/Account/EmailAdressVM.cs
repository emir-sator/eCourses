using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.Account
{
    public class EmailAdressVM:BaseVM
    {
        public Command EmailCommand { get; }

        public MUser User { get; }

        public EmailAdressVM(MUser user)
        {
            User = user;
            EmailCommand = new Command(async () => await ExecuteEmailCommand());
        }

        async Task ExecuteEmailCommand()
        {
            try
            {
                await Email.ComposeAsync(string.Empty, string.Empty, User.Email);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        void ProcessException(Exception ex)
        {
            if (ex != null)
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
