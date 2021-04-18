using eCourses.Mobile.Helpers;
using eCourses.Model;
using eCourses.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.Transactions
{
    public class TransactionsVM:BaseVM
    {
        private readonly APIService transactionService = new APIService("Transaction");
        private readonly APIService userService = new APIService("User");
        private readonly APIService courseService = new APIService("Course");
        public ObservableCollection<MTransaction> TransactionList { get; set; } = new ObservableCollection<MTransaction>();

        public ICommand InitCommand { get; set; }

        public TransactionsVM()
        {
            InitCommand = new Command(async () => await Init());
        }


        DateTime? _from = DateTime.Now;
        public DateTime From
        {
            get { return (DateTime)_from; }
            set
            {
                SetProperty(ref _from, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }

        DateTime? _to = DateTime.Now;
        public DateTime To
        {
            get { return (DateTime)_to; }
            set
            {
                SetProperty(ref _to, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }

        public async Task Init()
        {
            var UserID = SignedInUser.User.UserID;
            var req = new TransactionSearchRequest
            {
                UserID = UserID,
                From = _from,
                To = _to
            };
            TransactionList.Clear();
            var list = await transactionService.Get<List<MTransaction>>(req);
            var user = await userService.GetById<MUser>(UserID);
            
            if (list.Count() != 0)
            {
                foreach (var x in list)
                {
                    var course = await courseService.GetById<MCourse>(x.CourseID);
                    if (x.UserID == user.UserID)
                    {
                        x.CourseName = course.Name;
                        x.TransactionDateString=x.TransactionDate.ToString("yyyy/MM/dd");
                        TransactionList.Add(x);
                    }
                }
            }
        }


    }
}
