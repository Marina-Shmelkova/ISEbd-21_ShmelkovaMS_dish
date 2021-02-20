namespace FoodOrdersView
{
    partial class FormDishComponent
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
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelDishtCount = new System.Windows.Forms.Label();
            this.labelDishComponents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(110, 36);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(185, 21);
            this.comboBoxComponent.TabIndex = 11;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(110, 69);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(185, 20);
            this.textBoxCount.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(220, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(110, 95);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // labelDishtCount
            // 
            this.labelDishtCount.AutoSize = true;
            this.labelDishtCount.Location = new System.Drawing.Point(12, 69);
            this.labelDishtCount.Name = "labelDishtCount";
            this.labelDishtCount.Size = new System.Drawing.Size(66, 13);
            this.labelDishtCount.TabIndex = 7;
            this.labelDishtCount.Text = "Количество";
            // 
            // labelDishComponents
            // 
            this.labelDishComponents.AutoSize = true;
            this.labelDishComponents.Location = new System.Drawing.Point(12, 36);
            this.labelDishComponents.Name = "labelDishComponents";
            this.labelDishComponents.Size = new System.Drawing.Size(92, 13);
            this.labelDishComponents.TabIndex = 6;
            this.labelDishComponents.Text = "Название блюда";
            // 
            // FormDishComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 151);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelDishtCount);
            this.Controls.Add(this.labelDishComponents);
            this.Name = "FormDishComponent";
            this.Text = "Выбор блюда";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelDishtCount;
        private System.Windows.Forms.Label labelDishComponents;
    }
}