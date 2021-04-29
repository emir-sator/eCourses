using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Forms.Categories;
using eCourses.WinUI.Forms.Subcategories;
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

namespace eCourses.WinUI.Forms.Categories_and_Subcategories
{
    public partial class SubategoryAdd : UserControl
    {
        private APIService subcategoryService = new APIService("Subcategory");
        private APIService categoryService = new APIService("Category");
        public SubategoryAdd()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new SubcategoryList());
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var category = await categoryService.GetById<MCategory>(Convert.ToInt32(cbCategory.SelectedValue));
            
            var request = new SubcategoryUpsertRequest()
            {
                Name = txtName.Text,
                CategoryID=category.CategoryID,
                CategoryName=category.Name
                
                
            };

            await subcategoryService.Insert<MSubcategory>(request);
            MessageBox.Show("Subcategory added successfully", "Success", MessageBoxButtons.OK);
            PanelHelper.SwapPanels(this.Parent, this, new SubcategoryList());
        }

        private async void SubategoryAdd_Load(object sender, EventArgs e)
        {
            var categories = await categoryService.Get<List<MCategory>>(null);
            categories.Insert(0, new MCategory());
            cbCategory.DataSource = categories;
            cbCategory.ValueMember = "CategoryID";
            cbCategory.DisplayMember = "Name";

         
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
        private void cbCategory_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cbCategory.Text))
            {
                MessageBox.Show("Please select a value");
            }
           
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CategoryAddForSubcategory());
        }
    }
}
