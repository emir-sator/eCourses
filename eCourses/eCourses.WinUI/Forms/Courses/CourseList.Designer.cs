
namespace eCourses.WinUI.Forms.Courses
{
    partial class CourseList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseList));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDeleteCourse = new System.Windows.Forms.Button();
            this.btnEditCourse = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbSubcategories = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Courses";
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCourse.Image")));
            this.btnAddCourse.Location = new System.Drawing.Point(568, 67);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(41, 37);
            this.btnAddCourse.TabIndex = 41;
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(323, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 24);
            this.btnSearch.TabIndex = 40;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDeleteCourse
            // 
            this.btnDeleteCourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCourse.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteCourse.Image")));
            this.btnDeleteCourse.Location = new System.Drawing.Point(662, 67);
            this.btnDeleteCourse.Name = "btnDeleteCourse";
            this.btnDeleteCourse.Size = new System.Drawing.Size(41, 37);
            this.btnDeleteCourse.TabIndex = 39;
            this.btnDeleteCourse.UseVisualStyleBackColor = true;
            this.btnDeleteCourse.Click += new System.EventHandler(this.btnDeleteCourse_Click);
            // 
            // btnEditCourse
            // 
            this.btnEditCourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCourse.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCourse.Image")));
            this.btnEditCourse.Location = new System.Drawing.Point(615, 67);
            this.btnEditCourse.Name = "btnEditCourse";
            this.btnEditCourse.Size = new System.Drawing.Size(41, 37);
            this.btnEditCourse.TabIndex = 38;
            this.btnEditCourse.UseVisualStyleBackColor = true;
            this.btnEditCourse.Click += new System.EventHandler(this.btnEditCourse_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSearch.Location = new System.Drawing.Point(42, 80);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(275, 24);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.Text = "Enter a course name ";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseID,
            this.txtName,
            this.Language,
            this.DateCreated,
            this.Price});
            this.dgvCourses.Location = new System.Drawing.Point(42, 119);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.Size = new System.Drawing.Size(661, 276);
            this.dgvCourses.TabIndex = 44;
            // 
            // CourseID
            // 
            this.CourseID.DataPropertyName = "CourseID";
            this.CourseID.HeaderText = "CourseID";
            this.CourseID.Name = "CourseID";
            this.CourseID.ReadOnly = true;
            this.CourseID.Visible = false;
            // 
            // txtName
            // 
            this.txtName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtName.DataPropertyName = "Name";
            this.txtName.HeaderText = "Course name";
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Language
            // 
            this.Language.DataPropertyName = "Language";
            this.Language.HeaderText = "Language";
            this.Language.Name = "Language";
            this.Language.ReadOnly = true;
            // 
            // DateCreated
            // 
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "Created on";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 40;
            // 
            // cbSubcategories
            // 
            this.cbSubcategories.FormattingEnabled = true;
            this.cbSubcategories.Location = new System.Drawing.Point(42, 44);
            this.cbSubcategories.Name = "cbSubcategories";
            this.cbSubcategories.Size = new System.Drawing.Size(129, 21);
            this.cbSubcategories.TabIndex = 45;
            this.cbSubcategories.SelectedIndexChanged += new System.EventHandler(this.cbSubcategories_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(42, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 29);
            this.button1.TabIndex = 46;
            this.button1.Text = "Add video lectures for chosen course";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CourseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.cbSubcategories);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDeleteCourse);
            this.Controls.Add(this.btnEditCourse);
            this.Controls.Add(this.txtSearch);
            this.Name = "CourseList";
            this.Size = new System.Drawing.Size(740, 559);
            this.Load += new System.EventHandler(this.CourseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDeleteCourse;
        private System.Windows.Forms.Button btnEditCourse;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.ComboBox cbSubcategories;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Language;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}
