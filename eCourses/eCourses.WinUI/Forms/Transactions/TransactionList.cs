using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourses.WinUI.Forms.Transactions
{
    public partial class TransactionList : UserControl
    {

        private APIService TransactionService = new APIService("Transaction");
        private APIService userService = new APIService("User");
        private APIService courseService = new APIService("Course");

        public TransactionList()
        {
            InitializeComponent();
        }

        private async void TransactionList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
            var result = await TransactionService.Get<List<MTransaction>>(null);
            var users = await userService.Get<List<MUser>>(null);
            var courses = await courseService.Get<List<MCourse>>(null);

            users.Insert(0, new MUser { FullName = "All users" });
            cbUsers.DataSource = users;
            cbUsers.DisplayMember = "FullName";
            cbUsers.ValueMember = "UserID";

            courses.Insert(0, new MCourse { Name = "All courses" });
            cbCourses.DataSource = courses;
            cbCourses.DisplayMember = "Name";
            cbCourses.ValueMember = "CourseID";



            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.DataSource = result;
        }

        private async Task LoadList(TransactionSearchRequest request)
        {
            var result = await TransactionService.Get<List<MTransaction>>(request);
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.DataSource = result;
        }

        private async void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            MUser user;
            user = cbUsers.SelectedItem as MUser;
            var userID = user.UserID;
            if (user.FullName == "All users")
            {
                await LoadList(null);
            }
            else
            {
                var request = new TransactionSearchRequest()
                {
                    UserID = userID
                };
                await LoadList(request);
            }
        }

        private async void cbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

            MCourse course;
            course = cbCourses.SelectedItem as MCourse;
            var courseID = course.CourseID;
            if (course.Name == "All courses")
            {
                await LoadList(null);
            }
            else
            {
                var request = new TransactionSearchRequest()
                {
                    CourseID = courseID
                };
                await LoadList(request);
            }
        }

        private async void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvTransactions.CurrentRow.Cells["TransactionID"].Value);
                if (MessageBox.Show("Do you really want to delete this transaction?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await TransactionService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted transaction successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new TransactionList());
            }
        }
    }
}
