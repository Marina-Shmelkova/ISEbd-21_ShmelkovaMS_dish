namespace AbstractShopView
{
	partial class FormMain
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
			this.buttonCreateOrder = new System.Windows.Forms.Button();
			this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
			this.buttonOrderReady = new System.Windows.Forms.Button();
			this.buttonPayOrder = new System.Windows.Forms.Button();
			this.buttonRef = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.блюдаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.наборыБлюдToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCreateOrder
			// 
			this.buttonCreateOrder.Location = new System.Drawing.Point(588, 46);
			this.buttonCreateOrder.Name = "buttonCreateOrder";
			this.buttonCreateOrder.Size = new System.Drawing.Size(134, 23);
			this.buttonCreateOrder.TabIndex = 0;
			this.buttonCreateOrder.Text = "Создать заказ";
			this.buttonCreateOrder.UseVisualStyleBackColor = true;
			// 
			// buttonTakeOrderInWork
			// 
			this.buttonTakeOrderInWork.Location = new System.Drawing.Point(588, 119);
			this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
			this.buttonTakeOrderInWork.Size = new System.Drawing.Size(134, 23);
			this.buttonTakeOrderInWork.TabIndex = 1;
			this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
			this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
			// 
			// buttonOrderReady
			// 
			this.buttonOrderReady.Location = new System.Drawing.Point(588, 196);
			this.buttonOrderReady.Name = "buttonOrderReady";
			this.buttonOrderReady.Size = new System.Drawing.Size(134, 23);
			this.buttonOrderReady.TabIndex = 2;
			this.buttonOrderReady.Text = "Заказ готов";
			this.buttonOrderReady.UseVisualStyleBackColor = true;
			// 
			// buttonPayOrder
			// 
			this.buttonPayOrder.Location = new System.Drawing.Point(588, 268);
			this.buttonPayOrder.Name = "buttonPayOrder";
			this.buttonPayOrder.Size = new System.Drawing.Size(134, 23);
			this.buttonPayOrder.TabIndex = 3;
			this.buttonPayOrder.Text = "Заказ оплачен";
			this.buttonPayOrder.UseVisualStyleBackColor = true;
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(588, 354);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(134, 23);
			this.buttonRef.TabIndex = 4;
			this.buttonRef.Text = "Обновить список";
			this.buttonRef.UseVisualStyleBackColor = true;
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(12, 27);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(546, 387);
			this.dataGridView.TabIndex = 5;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// справочникToolStripMenuItem
			// 
			this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.блюдаToolStripMenuItem,
            this.наборыБлюдToolStripMenuItem});
			this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
			this.справочникToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.справочникToolStripMenuItem.Text = "Справочники";
			// 
			// блюдаToolStripMenuItem
			// 
			this.блюдаToolStripMenuItem.Name = "блюдаToolStripMenuItem";
			this.блюдаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.блюдаToolStripMenuItem.Text = "Блюда";
			// 
			// наборыБлюдToolStripMenuItem
			// 
			this.наборыБлюдToolStripMenuItem.Name = "наборыБлюдToolStripMenuItem";
			this.наборыБлюдToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.наборыБлюдToolStripMenuItem.Text = "Наборы блюд";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonPayOrder);
			this.Controls.Add(this.buttonOrderReady);
			this.Controls.Add(this.buttonTakeOrderInWork);
			this.Controls.Add(this.buttonCreateOrder);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormMain";
			this.Text = "FormMain";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCreateOrder;
		private System.Windows.Forms.Button buttonTakeOrderInWork;
		private System.Windows.Forms.Button buttonOrderReady;
		private System.Windows.Forms.Button buttonPayOrder;
		private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem блюдаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem наборыБлюдToolStripMenuItem;
	}
}