
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.GetTop3Courses_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Top3UsersWithMostCoursePurchases_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GetTop3Courses_ResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Top3UsersWithMostCoursePurchases_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GetTop3Courses_ResultBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eCourses.WinUI.Reports.CoursesTop3Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(26, 46);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(685, 365);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(598, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Back to homepage";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetTop3Courses_ResultBindingSource
            // 
            this.GetTop3Courses_ResultBindingSource.DataSource = typeof(eCourses.WinUI.Reports.GetTop3Courses_Result);
            // 
            // Top3UsersWithMostCoursePurchases_ResultBindingSource
            // 
            this.Top3UsersWithMostCoursePurchases_ResultBindingSource.DataSource = typeof(eCourses.WinUI.Reports.Top3UsersWithMostCoursePurchases_Result);
            // 
            // CourseTop3ListRepost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CourseTop3ListRepost";
            this.Size = new System.Drawing.Size(739, 476);
            ((System.ComponentModel.ISupportInitialize)(this.GetTop3Courses_ResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Top3UsersWithMostCoursePurchases_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GetTop3Courses_ResultBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource Top3UsersWithMostCoursePurchases_ResultBindingSource;
    }
}
