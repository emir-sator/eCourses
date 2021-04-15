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
        public ICommand SaveCommand { get; set; }
        public EditProfileVM()
        {

        }
        public EditProfileVM(MUser user)
        {
            _user = user;

            ChangeImage = new Command(async () => await OnTapped());
            SaveCommand = new Command(async () => await SaveImage());
        }
        private async Task OnTapped()
        {
            Image = await ImageHelper.UploadImage(Image);
        }
        private async Task SaveImage()
        {

            var user = await userService.GetById<MUser>(User.UserID);
            try
            {
                var req = new UserUpsertRequest()
                {
                   
                    Image = image,
                };

                await userService.Update<MUser>(user.UserID,req);

            }
            catch(Exception ex)
            {

            }
        }

    }
}
