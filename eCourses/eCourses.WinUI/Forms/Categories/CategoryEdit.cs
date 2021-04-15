using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Helper;
using eCourses.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourses.WinUI.Forms.Categories
{
    public partial class CategoryEdit : UserControl
    {
        private APIService categoryService = new APIService("Category");
        private readonly int _ID;
        public CategoryEdit(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private async void CategoryEdit_Load(object sender, EventArgs e)
        {
            var category = await categoryService.GetById<MCategory>(_ID);
            txtName.Text = category.Name;
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CategoryList());
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var user = await categoryService.GetById<MCategory>(_ID);
            if (ValidateChildren())
            {
               
                var request = new CategoryUpsertRequest
                {
                    Name=txtName.Text
                  
                };

                await categoryService.Update<MCategory>(_ID, request);
                MessageBox.Show("Category have been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new CategoryList());
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtName, null);
            }
        }
    }
}
