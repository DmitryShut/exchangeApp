namespace ExchangeApp
{
    partial class AdminView
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
            System.Windows.Forms.TabControl tabControl1;
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.addButton = new System.Windows.Forms.Button();
            this.purchaseLimitBox = new System.Windows.Forms.TextBox();
            this.sellLimitBox = new System.Windows.Forms.TextBox();
            this.sellRateBox = new System.Windows.Forms.TextBox();
            this.purchaseRateBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.currenciesView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.filter = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.operationsView = new System.Windows.Forms.DataGridView();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.currenciesView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.operationsView)).BeginInit();
            this.SuspendLayout();
            tabControl1.Controls.Add(this.tabPage1);
            tabControl1.Controls.Add(this.tabPage3);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(933, 519);
            tabControl1.TabIndex = 0;
            this.tabPage1.Controls.Add(this.addButton);
            this.tabPage1.Controls.Add(this.purchaseLimitBox);
            this.tabPage1.Controls.Add(this.sellLimitBox);
            this.tabPage1.Controls.Add(this.sellRateBox);
            this.tabPage1.Controls.Add(this.purchaseRateBox);
            this.tabPage1.Controls.Add(this.nameBox);
            this.tabPage1.Controls.Add(this.currenciesView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(925, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Валюты";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.addButton.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(369, 453);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(80, 21);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddNewCurrency);
            this.purchaseLimitBox.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.purchaseLimitBox.Location = new System.Drawing.Point(231, 453);
            this.purchaseLimitBox.Name = "purchaseLimitBox";
            this.purchaseLimitBox.Size = new System.Drawing.Size(63, 23);
            this.purchaseLimitBox.TabIndex = 5;
            this.sellLimitBox.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.sellLimitBox.Location = new System.Drawing.Point(300, 453);
            this.sellLimitBox.Name = "sellLimitBox";
            this.sellLimitBox.Size = new System.Drawing.Size(63, 23);
            this.sellLimitBox.TabIndex = 4;
            this.sellRateBox.Location = new System.Drawing.Point(162, 453);
            this.sellRateBox.Name = "sellRateBox";
            this.sellRateBox.Size = new System.Drawing.Size(63, 23);
            this.sellRateBox.TabIndex = 3;
            this.purchaseRateBox.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.purchaseRateBox.Location = new System.Drawing.Point(93, 453);
            this.purchaseRateBox.Name = "purchaseRateBox";
            this.purchaseRateBox.Size = new System.Drawing.Size(63, 23);
            this.purchaseRateBox.TabIndex = 2;
            this.nameBox.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.nameBox.Location = new System.Drawing.Point(24, 453);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(63, 23);
            this.nameBox.TabIndex = 1;
            this.currenciesView.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currenciesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currenciesView.Location = new System.Drawing.Point(3, 3);
            this.currenciesView.Name = "currenciesView";
            this.currenciesView.Size = new System.Drawing.Size(919, 485);
            this.currenciesView.TabIndex = 0;
            this.tabPage3.Controls.Add(this.filter);
            this.tabPage3.Controls.Add(this.filterTextBox);
            this.tabPage3.Controls.Add(this.operationsView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(925, 493);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "История операций";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.filter.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.filter.Location = new System.Drawing.Point(855, 470);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(59, 23);
            this.filter.TabIndex = 2;
            this.filter.Text = "filter";
            this.filter.UseVisualStyleBackColor = true;
            this.filter.Click += new System.EventHandler(this.Filter);
            this.filterTextBox.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.filterTextBox.Location = new System.Drawing.Point(0, 470);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(849, 23);
            this.filterTextBox.TabIndex = 1;
            this.operationsView.AllowUserToAddRows = false;
            this.operationsView.AllowUserToDeleteRows = false;
            this.operationsView.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operationsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsView.Location = new System.Drawing.Point(3, 3);
            this.operationsView.Name = "operationsView";
            this.operationsView.ReadOnly = true;
            this.operationsView.Size = new System.Drawing.Size(919, 487);
            this.operationsView.TabIndex = 0;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(tabControl1);
            this.Name = "AdminView";
            this.Text = "Обменный пункт(Админстратор)";
            this.Load += new System.EventHandler(this.SetUp);
            tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.currenciesView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.operationsView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView operationsView;
        private System.Windows.Forms.DataGridView currenciesView;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox purchaseRateBox;
        private System.Windows.Forms.TextBox sellRateBox;
        private System.Windows.Forms.TextBox sellLimitBox;
        private System.Windows.Forms.TextBox purchaseLimitBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Button filter;
    }
}