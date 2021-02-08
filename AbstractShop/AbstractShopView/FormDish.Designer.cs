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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.labelName = new System.Windows.Forms.Label();
			this.labelPrice = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.dataGridViewDish = new System.Windows.Forms.DataGridView();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRef = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDish)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(327, 345);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(233, 345);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(25, 18);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(86, 13);
			this.labelName.TabIndex = 6;
			this.labelName.Text = "Название бюда";
			// 
			// labelPrice
			// 
			this.labelPrice.AutoSize = true;
			this.labelPrice.Location = new System.Drawing.Point(25, 41);
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Size = new System.Drawing.Size(33, 13);
			this.labelPrice.TabIndex = 7;
			this.labelPrice.Text = "Цена";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(117, 15);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(100, 20);
			this.textBoxName.TabIndex = 8;
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(117, 41);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrice.TabIndex = 9;
			// 
			// dataGridViewDish
			// 
			this.dataGridViewDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnCount});
			this.dataGridViewDish.Location = new System.Drawing.Point(12, 91);
			this.dataGridViewDish.Name = "dataGridViewDish";
			this.dataGridViewDish.Size = new System.Drawing.Size(335, 235);
			this.dataGridViewDish.TabIndex = 10;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(353, 103);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 11;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(353, 146);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(75, 23);
			this.buttonRef.TabIndex = 12;
			this.buttonRef.Text = "Изменить";
			this.buttonRef.UseVisualStyleBackColor = true;
			// 
			// buttonUpd
			// 
			this.buttonUpd.Location = new System.Drawing.Point(353, 188);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(75, 23);
			this.buttonUpd.TabIndex = 13;
			this.buttonUpd.Text = "Обновить";
			this.buttonUpd.UseVisualStyleBackColor = true;
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(353, 231);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(75, 23);
			this.buttonDel.TabIndex = 14;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
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
			// FormDish
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 414);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonUpd);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.dataGridViewDish);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Name = "FormDish";
			this.Text = "Разновидность блюд";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDish)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelPrice;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxPrice;
		private System.Windows.Forms.DataGridView dataGridViewDish;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.Button buttonUpd;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
	}
}