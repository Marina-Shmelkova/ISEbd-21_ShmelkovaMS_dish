using FoodOrdersBusinessLogic.BindingModels;
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
		private readonly ReportLogic _report;
		public FormMain(OrderLogic orderLogic, ReportLogic report)
		{
			InitializeComponent();
			this._orderLogic = orderLogic;
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
					dataGridView.Rows.Clear();
					foreach (var order in list)
					{
						dataGridView.Rows.Add(new object[] { order.Id, order.DishId, order.DishName, order.Count, order.Sum,
							order.Status,order.DateCreate, order.DateImplement});
					}
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
		private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					_orderLogic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void ButtonOrderReady_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					_orderLogic.FinishOrder(new ChangeStatusBindingModel { OrderId = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
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

        private void блюдаПоНаборамToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormReportDishComponents>();
			form.ShowDialog();
		}

        private void списокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Container.Resolve<FormReportOrders>();
			form.ShowDialog();
		}

		private void списокБлюдToolStripMenuItem_Click(object sender, EventArgs e)
        {
			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_report.SaveComponentsToWordFile(new ReportBindingModel
					{
						FileName =
				   dialog.FileName
					});
					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
				   MessageBoxIcon.Information);
				}
			}
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
    }
}
