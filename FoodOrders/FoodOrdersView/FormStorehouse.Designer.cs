namespace FoodOrdersView
{
    partial class FormStorehouse
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxResponsible = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelResponsible = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.Component,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(22, 97);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(343, 287);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ColumnId";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // Component
            // 
            this.Component.HeaderText = "Блюдо";
            this.Component.Name = "Component";
            this.Component.Width = 200;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(153, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(155, 20);
            this.textBoxName.TabIndex = 21;
            // 
            // textBoxResponsible
            // 
            this.textBoxResponsible.Location = new System.Drawing.Point(153, 54);
            this.textBoxResponsible.Name = "textBoxResponsible";
            this.textBoxResponsible.Size = new System.Drawing.Size(155, 20);
            this.textBoxResponsible.TabIndex = 22;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(45, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(96, 13);
            this.labelName.TabIndex = 23;
            this.labelName.Text = "Название склада";
            // 
            // labelResponsible
            // 
            this.labelResponsible.AutoSize = true;
            this.labelResponsible.Location = new System.Drawing.Point(45, 57);
            this.labelResponsible.Name = "labelResponsible";
            this.labelResponsible.Size = new System.Drawing.Size(86, 13);
            this.labelResponsible.TabIndex = 24;
            this.labelResponsible.Text = "Ответственный";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(96, 408);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(203, 408);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormStorehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 460);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelResponsible);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxResponsible);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormStorehouse";
            this.Text = "Добавление склада";
            this.Load += new System.EventHandler(this.FormSetStorehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxResponsible;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelResponsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}