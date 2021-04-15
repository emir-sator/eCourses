
namespace eCourses.WinUI.Forms.Courses
{
    partial class CourseReport
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
            this.MCourseListVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MCourseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MCourseListVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MCourseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MCourseListVMBindingSource
            // 
            this.MCourseListVMBindingSource.DataSource = typeof(eCourses.Model.ViewModels.CourseListVM);
            // 
            // MCourseBindingSource
            // 
            this.MCourseBindingSource.DataSource = typeof(eCourses.Model.MCourse);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(618, 401);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 33);
            this.btnBack.TabIndex = 59;
            this.btnBack.Text = "Back to list";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsCourses";
            reportDataSource1.Value = this.MCourseListVMBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eCourses.WinUI.Reports.CourseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(49, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(642, 354);
            this.reportViewer1.TabIndex = 60;
            
            // 
            // CourseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnBack);
            this.Name = "CourseReport";
            this.Size = new System.Drawing.Size(746, 487);
            this.Load += new System.EventHandler(this.CourseReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MCourseListVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MCourseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource MCourseBindingSource;
        private System.Windows.Forms.BindingSource MCourseListVMBindingSource;
    }
}
