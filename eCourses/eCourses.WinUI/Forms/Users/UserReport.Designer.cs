
namespace eCourses.WinUI.Forms.Users
{
    partial class UserReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.UserListVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptUsers = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UserListVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MUserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UserListVMBindingSource
            // 
            this.UserListVMBindingSource.DataSource = typeof(eCourses.Model.ViewModels.UserListVM);
            // 
            // rptUsers
            // 
            reportDataSource2.Name = "dsUsers";
            reportDataSource2.Value = this.UserListVMBindingSource;
            this.rptUsers.LocalReport.DataSources.Add(reportDataSource2);
            this.rptUsers.LocalReport.ReportEmbeddedResource = "eCourses.WinUI.Reports.UserReport.rdlc";
            this.rptUsers.Location = new System.Drawing.Point(42, 39);
            this.rptUsers.Name = "rptUsers";
            this.rptUsers.ServerReport.BearerToken = null;
            this.rptUsers.Size = new System.Drawing.Size(646, 365);
            this.rptUsers.TabIndex = 0;
            // 
            // MUserBindingSource
            // 
            this.MUserBindingSource.DataSource = typeof(eCourses.Model.MUser);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(615, 410);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 33);
            this.btnBack.TabIndex = 99;
            this.btnBack.Text = "Back ";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // UserReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.rptUsers);
            this.Name = "UserReport";
            this.Size = new System.Drawing.Size(746, 482);
            this.Load += new System.EventHandler(this.UserReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserListVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MUserBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptUsers;
        private System.Windows.Forms.BindingSource MUserBindingSource;
        private System.Windows.Forms.BindingSource UserListVMBindingSource;
        private System.Windows.Forms.Button btnBack;
    }
}
