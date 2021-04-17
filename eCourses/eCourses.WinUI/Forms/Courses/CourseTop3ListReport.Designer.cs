
namespace eCourses.WinUI.Forms.Courses
{
    partial class CourseTop3ListReport
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
            this.GetTop3Courses_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Top3UsersWithMostCoursePurchases_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GetTop3Courses_ResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Top3UsersWithMostCoursePurchases_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GetTop3Courses_ResultBindingSource
            // 
            this.GetTop3Courses_ResultBindingSource.DataSource = typeof(eCourses.WinUI.Reports.DataForReports.GetTop3Courses_Result);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.GetTop3Courses_ResultBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eCourses.WinUI.Reports.CoursesTop3Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(33, 46);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(685, 365);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // Top3UsersWithMostCoursePurchases_ResultBindingSource
            // 
            this.Top3UsersWithMostCoursePurchases_ResultBindingSource.DataSource = typeof(eCourses.WinUI.Reports.DataForReports.Top3UsersWithMostCoursePurchases_Result);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(645, 417);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 33);
            this.btnBack.TabIndex = 99;
            this.btnBack.Text = "Back ";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // CourseTop3ListReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CourseTop3ListReport";
            this.Size = new System.Drawing.Size(739, 476);
            ((System.ComponentModel.ISupportInitialize)(this.GetTop3Courses_ResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Top3UsersWithMostCoursePurchases_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GetTop3Courses_ResultBindingSource;
        private System.Windows.Forms.BindingSource Top3UsersWithMostCoursePurchases_ResultBindingSource;
        private System.Windows.Forms.Button btnBack;
    }
}
