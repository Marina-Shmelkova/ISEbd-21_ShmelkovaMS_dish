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

namespace FoodOrdersView
{
    public partial class FormMails : Form
    {
        private int pageNumber = 1;
        private readonly MailLogic logic;
        public FormMails(MailLogic logic)
        {
            this.logic = logic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
            textBox.Text = pageNumber.ToString();
        }
        private void LoadData()
        {
            var list = logic.Read(new MessageInfoBindingModel
            {
                PageNumber = pageNumber
            });
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                textBox.Text = pageNumber.ToString();
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
            }

            LoadData();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            int stringsCountOnPage = logic.Read(new MessageInfoBindingModel
            {
                PageNumber = pageNumber + 1
            }).Count;

            if (stringsCountOnPage != 0)
            {
                pageNumber++;
                LoadData();
            }
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox.Text != "")
                {
                    int pageNumberValue = Convert.ToInt32(textBox.Text);

                    if (pageNumberValue < 1)
                    {
                        throw new Exception();
                    }

                    int stringsCountOnPage = logic.Read(new MessageInfoBindingModel
                    {
                        PageNumber = pageNumberValue
                    }).Count;

                    if (stringsCountOnPage == 0)
                    {
                        throw new Exception();
                    }

                    pageNumber = pageNumberValue;
                    LoadData();
                }
            }
            catch (Exception)
            {
                textBox.Text = pageNumber.ToString();
            }
        }
    }
}
