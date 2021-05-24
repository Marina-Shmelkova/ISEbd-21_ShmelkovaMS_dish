using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Unity;
using FoodOrdersBusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Reflection;

namespace FoodOrdersView
{
    public partial class FormReportAllOrders : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportAllOrders(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void buttonMake_Click(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetOrdersForAllDates");
                List<ReportAllOrdersViewModel> dataSource = (List<ReportAllOrdersViewModel>)method.Invoke(logic, new object[] { });
                ReportDataSource source = new ReportDataSource("DataSetOrders", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveAllOrdersToPdfFile");
                        method.Invoke(logic, new object[] { new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        } });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
