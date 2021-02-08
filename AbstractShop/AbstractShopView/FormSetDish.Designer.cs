namespace AbstractShopView
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
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRef = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.dataGridViewDish = new System.Windows.Forms.DataGridView();
			this.DataGridViewTextBoxColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridViewTextBoxColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelName = new System.Windows.Forms.Label();
			this.labelPrice = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDish)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(368, 78);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 6;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(368, 120);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(75, 23);
			this.buttonRef.TabIndex = 7;
			this.buttonRef.Text = "Изменить";
			this.buttonRef.UseVisualStyleBackColor = true;
			// 
			// buttonUpd
			// 
			this.buttonUpd.Location = new System.Drawing.Point(368, 162);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(75, 23);
			this.buttonUpd.TabIndex = 8;
			this.buttonUpd.Text = "Обновить";
			this.buttonUpd.UseVisualStyleBackColor = true;
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(368, 207);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(75, 23);
			this.buttonDel.TabIndex = 9;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			// 
			// dataGridViewDish
			// 
			this.dataGridViewDish.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
			this.dataGridViewDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumnName,
            this.ColumnId,
            this.DataGridViewTextBoxColumnCount});
			this.dataGridViewDish.Location = new System.Drawing.Point(12, 63);
			this.dataGridViewDish.Name = "dataGridViewDish";
			this.dataGridViewDish.Size = new System.Drawing.Size(330, 205);
			this.dataGridViewDish.TabIndex = 10;
			// 
			// DataGridViewTextBoxColumnName
			// 
			this.DataGridViewTextBoxColumnName.HeaderText = "Название блюда";
			this.DataGridViewTextBoxColumnName.Name = "DataGridViewTextBoxColumnName";
			this.DataGridViewTextBoxColumnName.Width = 200;
			// 
			// ColumnId
			// 
			this.ColumnId.HeaderText = "ColumnId";
			this.ColumnId.Name = "ColumnId";
			this.ColumnId.Visible = false;
			// 
			// DataGridViewTextBoxColumnCount
			// 
			this.DataGridViewTextBoxColumnCount.HeaderText = "Количество";
			this.DataGridViewTextBoxColumnCount.Name = "DataGridViewTextBoxColumnCount";
			this.DataGridViewTextBoxColumnCount.Width = 90;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(188, 288);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 11;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(296, 288);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 12;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(12, 9);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(96, 13);
			this.labelName.TabIndex = 13;
			this.labelName.Text = "Название набора";
			// 
			// labelPrice
			// 
			this.labelPrice.AutoSize = true;
			this.labelPrice.Location = new System.Drawing.Point(12, 33);
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Size = new System.Drawing.Size(33, 13);
			this.labelPrice.TabIndex = 14;
			this.labelPrice.Text = "Цена";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(110, 6);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(100, 20);
			this.textBoxName.TabIndex = 15;
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(110, 33);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrice.TabIndex = 16;
			// 
			// FormSetDish
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 363);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.dataGridViewDish);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonUpd);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonAdd);
			this.Name = "FormSetDish";
			this.Text = "Наборы блюд";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDish)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.Button buttonUpd;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.DataGridView dataGridViewDish;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnCount;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelPrice;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxPrice;
	}
}