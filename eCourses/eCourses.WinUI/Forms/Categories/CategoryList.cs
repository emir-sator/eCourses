using eCourses.Model;
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

namespace eCourses.WinUI.Forms.Categories
{
    public partial class CategoryList : UserControl
    {
        private readonly APIService categoryService = new APIService("Category");

        public CategoryList()
        {
            InitializeComponent();
        }

        private async void CategoryList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
            var result = await categoryService.Get<List<MCategory>>(null);

            
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.ReadOnly = true;
            dgvCategories.DataSource = result;
            
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CategoryAdd());
            
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvCategories.CurrentRow.Cells["CategoryID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new CategoryEdit(ID));
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvCategories.CurrentRow != null)
            {
                bool result = false;
                int ID = Convert.ToInt32(dgvCategories.CurrentRow.Cells["CategoryID"].Value);

                if (MessageBox.Show("Do you really want to delete this category?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    result = await categoryService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted category successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new CategoryList());
            }
        }
    }
}
