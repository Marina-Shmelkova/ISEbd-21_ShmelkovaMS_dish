using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersBusinessLogic.ViewModels;
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
    public partial class FormStorehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly StorehouseLogic logic;
        private int? id;

        private Dictionary<int, (string, int)> houseComponents;
        public FormStorehouse(StorehouseLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormSetStorehouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StorehouseViewModel view = logic.Read(new StorehouseBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.StorehouseName;
                        textBoxResponsible.Text = view.Responsible.ToString();
                        houseComponents = view.StorehouseComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                houseComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (houseComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in houseComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxResponsible.Text))
            {
                MessageBox.Show("Заполните ответственного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new StorehouseBindingModel
                {
                    Id = id,
                    StorehouseName = textBoxName.Text,
                    Responsible = textBoxResponsible.Text,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = houseComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
