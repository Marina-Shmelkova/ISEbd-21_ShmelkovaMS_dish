namespace FoodOrdersView
{
    partial class FormDish
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDish = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDish)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.dataGridView);
            this.groupBox.Controls.Add(this.dataGridViewDish);
            this.groupBox.Location = new System.Drawing.Point(23, 77);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(351, 253);
            this.groupBox.TabIndex = 26;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Блюда:";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView.Location = new System.Drawing.Point(6, 18);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(335, 235);
            this.dataGridView.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ColumnId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Название блюда";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Количество";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewDish
            // 
            this.dataGridViewDish.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnCount});
            this.dataGridViewDish.Location = new System.Drawing.Point(6, 18);
            this.dataGridViewDish.Name = "dataGridViewDish";
            this.dataGridViewDish.Size = new System.Drawing.Size(335, 235);
            this.dataGridViewDish.TabIndex = 10;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ColumnId";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Название блюда";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 200;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(394, 253);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 25;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(394, 203);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(75, 23);
            this.buttonUpd.TabIndex = 24;
            this.buttonUpd.Text = "Обновить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(394, 159);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(75, 23);
            this.buttonRef.TabIndex = 23;
            this.buttonRef.Text = "Изменить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(394, 116);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 22;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(154, 32);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 21;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(154, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 20;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(52, 32);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(33, 13);
            this.labelPrice.TabIndex = 19;
            this.labelPrice.Text = "Цена";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(52, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(96, 13);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "Название набора";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(260, 340);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(367, 340);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 375);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "FormDish";
            this.Text = "Наборы";
            this.Load += new System.EventHandler(this.FormSetDish_Load);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDish)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dataGridViewDish;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}