using eCourses.Model;
using eCourses.WinUI.Forms.Categories_and_Subcategories;
using eCourses.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourses.WinUI.Forms.Subcategories
{
    public partial class SubcategoryList : UserControl
    {
        private readonly APIService subcategoryService = new APIService("Subcategory");
        public SubcategoryList()
        {
            InitializeComponent();
        }

        private async void SubcategoryList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
            var result = await subcategoryService.Get<List<MSubcategory>>(null);

            dgvSubcategories.AutoGenerateColumns = false;
            dgvSubcategories.ReadOnly = true;
            dgvSubcategories.DataSource = result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new SubategoryAdd());
        }

       

        private async  void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvSubcategories.CurrentRow != null)
            {
                bool result = false;
                int ID = Convert.ToInt32(dgvSubcategories.CurrentRow.Cells["SubcategoryID"].Value);

                if (MessageBox.Show("Do you really want to delete this subcategory?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    result = await subcategoryService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted subcategory successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new SubcategoryList());
            }
        }
    }
}
