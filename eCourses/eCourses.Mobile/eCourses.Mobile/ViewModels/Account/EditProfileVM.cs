using eCourses.Model;
using eCourses.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.Account
{
    public class EditProfileVM:BaseVM
    {
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
        public ICommand SaveCommand { get; set; }
        public EditProfileVM()
        {

        }
        public EditProfileVM(MUser user)
        {
            Image = user.Image;
            ChangeImage = new Command(async () => await OnTapped());
        }
        private async Task OnTapped()
        {
            Image = await ImageHelper.UploadImage(Image);
        }
        
    }
}
