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

namespace FoodOrdersView
{
    public partial class FormMails : Form
    {
        private int pageNumber = 1;
        private readonly MailLogic logic;
        private PageViewModel pageViewModel;
        public FormMails(MailLogic logic)
        {
            this.logic = logic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData(int page = 1)
        {
            int pageSize = 10; // Количество элементов на странице

            var list = logic.GetMessagesForPage(new MessageInfoBindingModel
            {
                Page = page,
                PageSize = pageSize
            });
            if (list != null)
            {
                pageViewModel = new PageViewModel(logic.Count(), page, pageSize, list);
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            // отображаем +- 2 страницы
            int pageStart = page < 3 ? 1 : page - 2;
            Button[] buttons = { buttonPageOne, buttonPageTwo, buttonPageThree, buttonPageFour, buttonPageFive };
            for (int i = 0; i < buttons.Length; ++i)
            {
                buttons[i].Show();
                SetButtonPagetext(buttons[i], pageStart + i, pageViewModel.TotalPages);
            }
        }

        private void SetButtonPagetext(Button button, int pageNumber, int totalPages)
        {
            if (pageNumber <= totalPages)
            {
                button.Text = pageNumber.ToString();
            }
            else
            {
                button.Hide();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasNextPage)
            {
                LoadData(pageViewModel.PageNumber + 1);
            }
            else
            {
                MessageBox.Show("Последняя страница", "Ой", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasPreviousPage)
            {
                LoadData(pageViewModel.PageNumber - 1);
            }
            else
            {
                MessageBox.Show("Первая страница", "Ой", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonPage_Click(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(((Button)sender).Text));
        }
    }
}
