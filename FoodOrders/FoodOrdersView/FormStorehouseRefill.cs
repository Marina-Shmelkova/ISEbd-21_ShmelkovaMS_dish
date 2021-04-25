using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersDatabaseImplement.Implements;
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
    public partial class FormStorehouseRefill : Form
    {
       
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private StorehouseLogic _houseLogic;
        public int ComponentId { get { return Convert.ToInt32(comboBoxComponent.SelectedValue); } set { comboBoxComponent.SelectedValue = value; } }
        public int StorehouseId { get { return Convert.ToInt32(comboBoxName.SelectedValue); } set { comboBoxName.SelectedValue = value; } }
        public int Count { get { return Convert.ToInt32(textBoxCount.Text); } set { textBoxCount.Text = value.ToString(); } }
        StorehouseBindingModel bm = new StorehouseBindingModel();
        public string ComponentName { get { return comboBoxComponent.Text; } }
        public FormStorehouseRefill(ComponentLogic logicC, StorehouseLogic logicS)
        {
            InitializeComponent();
            _houseLogic = logicS;
            List<ComponentViewModel> listComponent = logicC.Read(null);
            List<StorehouseViewModel> listStorehouse = logicS.Read(null);
            if (listComponent != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = listComponent;
                comboBoxComponent.SelectedItem = null;
            }
            if (listStorehouse != null)
            {
                comboBoxName.DisplayMember = "StorehouseName";
                comboBoxName.ValueMember = "Id";
                comboBoxName.DataSource = listStorehouse;
                comboBoxName.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите блюдо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxName.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _houseLogic.Restocking(new StorehouseBindingModel
            {
                Id = StorehouseId
            }, StorehouseId, ComponentId, Count);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
