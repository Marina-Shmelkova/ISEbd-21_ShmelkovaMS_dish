
namespace FoodOrdersView
{
    partial class FormImplementer
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
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelTimeToOrder = new System.Windows.Forms.Label();
            this.labelTimeToRest = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.textBoxTimeToOrder = new System.Windows.Forms.TextBox();
            this.textBoxTimeToRest = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(19, 27);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(107, 13);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО Исполнителя:";
            // 
            // labelTimeToOrder
            // 
            this.labelTimeToOrder.AutoSize = true;
            this.labelTimeToOrder.Location = new System.Drawing.Point(35, 74);
            this.labelTimeToOrder.Name = "labelTimeToOrder";
            this.labelTimeToOrder.Size = new System.Drawing.Size(91, 13);
            this.labelTimeToOrder.TabIndex = 1;
            this.labelTimeToOrder.Text = "Время на заказ:";
            // 
            // labelTimeToRest
            // 
            this.labelTimeToRest.AutoSize = true;
            this.labelTimeToRest.Location = new System.Drawing.Point(21, 116);
            this.labelTimeToRest.Name = "labelTimeToRest";
            this.labelTimeToRest.Size = new System.Drawing.Size(105, 13);
            this.labelTimeToRest.TabIndex = 2;
            this.labelTimeToRest.Text = "Время на перерыв:";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(132, 24);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(143, 20);
            this.textBoxFIO.TabIndex = 3;
            // 
            // textBoxTimeToOrder
            // 
            this.textBoxTimeToOrder.Location = new System.Drawing.Point(132, 71);
            this.textBoxTimeToOrder.Name = "textBoxTimeToOrder";
            this.textBoxTimeToOrder.Size = new System.Drawing.Size(143, 20);
            this.textBoxTimeToOrder.TabIndex = 4;
            // 
            // textBoxTimeToRest
            // 
            this.textBoxTimeToRest.Location = new System.Drawing.Point(132, 116);
            this.textBoxTimeToRest.Name = "textBoxTimeToRest";
            this.textBoxTimeToRest.Size = new System.Drawing.Size(143, 20);
            this.textBoxTimeToRest.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(93, 157);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 19;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(200, 157);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 192);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxTimeToRest);
            this.Controls.Add(this.textBoxTimeToOrder);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelTimeToRest);
            this.Controls.Add(this.labelTimeToOrder);
            this.Controls.Add(this.labelFIO);
            this.Name = "FormImplementer";
            this.Text = "Формирование заказа исполнителем";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelTimeToOrder;
        private System.Windows.Forms.Label labelTimeToRest;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.TextBox textBoxTimeToOrder;
        private System.Windows.Forms.TextBox textBoxTimeToRest;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}