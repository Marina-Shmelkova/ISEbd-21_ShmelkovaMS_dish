namespace FoodOrdersView
{
    partial class FormComponent
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxComponent = new System.Windows.Forms.TextBox();
            this.labelComponent = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxComponent
            // 
            this.textBoxComponent.Location = new System.Drawing.Point(104, 25);
            this.textBoxComponent.Name = "textBoxComponent";
            this.textBoxComponent.Size = new System.Drawing.Size(156, 20);
            this.textBoxComponent.TabIndex = 7;
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(12, 28);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(60, 13);
            this.labelComponent.TabIndex = 6;
            this.labelComponent.Text = "Название:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(185, 60);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(104, 60);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // FormComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 109);
            this.Controls.Add(this.textBoxComponent);
            this.Controls.Add(this.labelComponent);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "FormComponent";
            this.Text = "Блюдо";
            this.Load += new System.EventHandler(this.FormComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxComponent;
        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}

