﻿using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FoodOrdersView
{
	public partial class FormMain : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }
		private readonly OrderLogic _orderLogic;
		private readonly WorkModeling workModeling;
		private readonly ReportLogic _report;
		public FormMain(OrderLogic orderLogic, ReportLogic report, WorkModeling modeling)
		{
			InitializeComponent();
			this._orderLogic = orderLogic;
			this.workModeling = modeling;
			this._report = report;
		}
		private void FormMain_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			try
			{
				var list = _orderLogic.Read(null);
				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns[0].Visible = false;
					dataGridView.Columns[1].Visible = false;
					dataGridView.Columns[2].Visible = false;
					dataGridView.Columns[3].Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void КомпонентыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormComponents>();
			form.ShowDialog();
		}
		private void ИзделияToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormDishs>();
			form.ShowDialog();
		}
		
		private void ButtonCreateOrder_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormCreateOrder>();
			form.ShowDialog();
			LoadData();
		}
		
		private void ButtonPayOrder_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					_orderLogic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void ButtonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}

        private void списокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormReportOrders>();
			form.ShowDialog();
		}
        private void наборыПоБлюдамToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormReportComponentDish>();
			form.ShowDialog();
		}

		private void списокНаборовToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_report.SaveDishsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		private void пополнениеСкладаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormStorehouseRefill>();
			form.ShowDialog();
		}

        private void списокСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_report.SaveStorehousesToWordFile(new ReportBindingModel
					{
						FileName = dialog.FileName
					});

					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

        private void блюдаПоСкладамToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormReportComponentStorehouse>();
			form.ShowDialog();
		}

        private void списокВсехЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormReportAllOrders>();
			form.ShowDialog();
		}

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormClients>();
			form.ShowDialog();
		}

        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
			workModeling.DoWork();
			LoadData();
		}

        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormImplementers>();
			form.ShowDialog();
		}

        private void письмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormMails>();
			form.ShowDialog();
		}

        private void складыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
				var form = Container.Resolve<FormStorehouses>();
				form.ShowDialog();
		}
    }
}
