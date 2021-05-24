
namespace FoodOrdersView
{
    partial class FormReportAllOrders
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportAllOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonPDF = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportAllOrdersViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportAllOrdersViewModelBindingSource
            // 
            this.ReportAllOrdersViewModelBindingSource.DataSource = typeof(FoodOrdersBusinessLogic.ViewModels.ReportAllOrdersViewModel);
            // 
            // reportViewer
            // 
           
            this.reportViewer.LocalReport.ReportEmbeddedResource = "FoodOrdersView.ReportAllOrders.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 12);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(650, 310);
            this.reportViewer.TabIndex = 0;
            // 
            // buttonPDF
            // 
            this.buttonPDF.Location = new System.Drawing.Point(668, 79);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(106, 23);
            this.buttonPDF.TabIndex = 8;
            this.buttonPDF.Text = "В PDF";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.buttonPDF_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(668, 29);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(106, 23);
            this.buttonMake.TabIndex = 7;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // FormReportAllOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 326);
            this.Controls.Add(this.buttonPDF);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormReportAllOrders";
            this.Text = "Отчет по всем заказам";
            ((System.ComponentModel.ISupportInitialize)(this.ReportAllOrdersViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportAllOrdersViewModelBindingSource;
        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.Button buttonMake;
    }
}