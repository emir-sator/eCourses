using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.Account
{
    public class AddProfilePictureVM:BaseVM
    {

        private readonly APIService userService = new APIService("User");
        MUser _user;
        public MUser User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }
      
        public ICommand ChangeImage { get; set; }
        public AddProfilePictureVM()
        {

        }
        public AddProfilePictureVM(MUser user)
        {
            _user = user;
            ChangeImage = new Command(async () => await OnTapped());
        }
        private async Task OnTapped()
        {
            Image = await ImageHelper.UploadImage(Image);
        }
    }
}
