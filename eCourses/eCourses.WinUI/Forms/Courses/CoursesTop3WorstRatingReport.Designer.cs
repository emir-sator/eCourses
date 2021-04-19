
namespace eCourses.WinUI.Forms.Courses
{
    partial class CoursesTop3WorstRatingReport
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
            this.btnBack = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Top3WorstAverageRatingCourses_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Top3WorstAverageRatingCourses_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(572, 426);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 33);
            this.btnBack.TabIndex = 100;
            this.btnBack.Text = "Back ";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.Top3WorstAverageRatingCourses_ResultBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eCourses.WinUI.Reports.Top3WorstRatingCourses.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(94, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(551, 365);
            this.reportViewer1.TabIndex = 99;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // Top3WorstAverageRatingCourses_ResultBindingSource
            // 
            this.Top3WorstAverageRatingCourses_ResultBindingSource.DataSource = typeof(eCourses.WinUI.Reports.DataForReports.Top3WorstAverageRatingCourses_Result);
            // 
            // CoursesTop3WorstRatingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CoursesTop3WorstRatingReport";
            this.Size = new System.Drawing.Size(739, 515);
            ((System.ComponentModel.ISupportInitialize)(this.Top3WorstAverageRatingCourses_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Top3WorstAverageRatingCourses_ResultBindingSource;
    }
}
