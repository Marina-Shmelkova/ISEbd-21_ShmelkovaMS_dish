
namespace FoodOrdersView
{
    partial class FormMails
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
            this.buttonPageFive = new System.Windows.Forms.Button();
            this.buttonPageFour = new System.Windows.Forms.Button();
            this.buttonPageThree = new System.Windows.Forms.Button();
            this.buttonPageTwo = new System.Windows.Forms.Button();
            this.buttonPageOne = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(7, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(542, 301);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonPageFive
            // 
            this.buttonPageFive.Location = new System.Drawing.Point(345, 319);
            this.buttonPageFive.Name = "buttonPageFive";
            this.buttonPageFive.Size = new System.Drawing.Size(40, 23);
            this.buttonPageFive.TabIndex = 13;
            this.buttonPageFive.Text = "5";
            this.buttonPageFive.UseVisualStyleBackColor = true;
            this.buttonPageFive.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPageFour
            // 
            this.buttonPageFour.Location = new System.Drawing.Point(287, 319);
            this.buttonPageFour.Name = "buttonPageFour";
            this.buttonPageFour.Size = new System.Drawing.Size(40, 23);
            this.buttonPageFour.TabIndex = 12;
            this.buttonPageFour.Text = "4";
            this.buttonPageFour.UseVisualStyleBackColor = true;
            this.buttonPageFour.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPageThree
            // 
            this.buttonPageThree.Location = new System.Drawing.Point(230, 319);
            this.buttonPageThree.Name = "buttonPageThree";
            this.buttonPageThree.Size = new System.Drawing.Size(40, 23);
            this.buttonPageThree.TabIndex = 11;
            this.buttonPageThree.Text = "3";
            this.buttonPageThree.UseVisualStyleBackColor = true;
            this.buttonPageThree.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPageTwo
            // 
            this.buttonPageTwo.Location = new System.Drawing.Point(178, 319);
            this.buttonPageTwo.Name = "buttonPageTwo";
            this.buttonPageTwo.Size = new System.Drawing.Size(36, 23);
            this.buttonPageTwo.TabIndex = 10;
            this.buttonPageTwo.Text = "2";
            this.buttonPageTwo.UseVisualStyleBackColor = true;
            this.buttonPageTwo.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPageOne
            // 
            this.buttonPageOne.Location = new System.Drawing.Point(134, 319);
            this.buttonPageOne.Name = "buttonPageOne";
            this.buttonPageOne.Size = new System.Drawing.Size(38, 23);
            this.buttonPageOne.TabIndex = 9;
            this.buttonPageOne.Text = "1";
            this.buttonPageOne.UseVisualStyleBackColor = true;
            this.buttonPageOne.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(24, 319);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(414, 319);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 14;
            this.buttonNext.Text = "Вперед";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // FormMails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 369);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPageFive);
            this.Controls.Add(this.buttonPageFour);
            this.Controls.Add(this.buttonPageThree);
            this.Controls.Add(this.buttonPageTwo);
            this.Controls.Add(this.buttonPageOne);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMails";
            this.Text = "Письма";
            this.Load += new System.EventHandler(this.FormMails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonPageFive;
        private System.Windows.Forms.Button buttonPageFour;
        private System.Windows.Forms.Button buttonPageThree;
        private System.Windows.Forms.Button buttonPageTwo;
        private System.Windows.Forms.Button buttonPageOne;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNext;
    }
}