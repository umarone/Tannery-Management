namespace Accounts.UI
{
    partial class frmTotalStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExcelExport = new MetroFramework.Controls.MetroTile();
            this.btnLoad = new MetroFramework.Controls.MetroTile();
            this.chkByCategory = new MetroFramework.Controls.MetroCheckBox();
            this.CbxCategories = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkDate = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.EndDate = new MetroFramework.Controls.MetroDateTime();
            this.StartDate = new MetroFramework.Controls.MetroDateTime();
            this.grdTotalStock = new System.Windows.Forms.DataGridView();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchasesIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchasesReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTanneryUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtsearch = new MetroFramework.Controls.MetroTextBox();
            this.lblSearch = new MetroFramework.Controls.MetroLabel();
            this.CbxTrading = new MetroFramework.Controls.MetroComboBox();
            this.chkByTrading = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.ActiveControl = null;
            this.btnExcelExport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExcelExport.Location = new System.Drawing.Point(325, 115);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(106, 39);
            this.btnExcelExport.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnExcelExport.TabIndex = 9;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcelExport.UseCustomBackColor = true;
            this.btnExcelExport.UseSelectable = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.ActiveControl = null;
            this.btnLoad.BackColor = System.Drawing.Color.DarkCyan;
            this.btnLoad.Location = new System.Drawing.Point(325, 74);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(106, 39);
            this.btnLoad.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoad.UseCustomBackColor = true;
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkByCategory
            // 
            this.chkByCategory.AutoSize = true;
            this.chkByCategory.Location = new System.Drawing.Point(1011, 63);
            this.chkByCategory.Name = "chkByCategory";
            this.chkByCategory.Size = new System.Drawing.Size(119, 15);
            this.chkByCategory.TabIndex = 13;
            this.chkByCategory.Text = "By Category Stock";
            this.chkByCategory.UseSelectable = true;
            this.chkByCategory.Visible = false;
            this.chkByCategory.CheckedChanged += new System.EventHandler(this.chkByCategory_CheckedChanged);
            // 
            // CbxCategories
            // 
            this.CbxCategories.FormattingEnabled = true;
            this.CbxCategories.ItemHeight = 23;
            this.CbxCategories.Location = new System.Drawing.Point(95, 79);
            this.CbxCategories.Name = "CbxCategories";
            this.CbxCategories.Size = new System.Drawing.Size(217, 29);
            this.CbxCategories.TabIndex = 10;
            this.CbxCategories.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(595, 18);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 19);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "To Period :";
            this.metroLabel2.Visible = false;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(883, 21);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(90, 15);
            this.chkDate.TabIndex = 9;
            this.chkDate.Text = "Exclude Date";
            this.chkDate.UseSelectable = true;
            this.chkDate.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(333, 21);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Start Period : ";
            this.metroLabel1.Visible = false;
            // 
            // EndDate
            // 
            this.EndDate.Location = new System.Drawing.Point(674, 14);
            this.EndDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(198, 29);
            this.EndDate.TabIndex = 10;
            this.EndDate.Visible = false;
            // 
            // StartDate
            // 
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(425, 16);
            this.StartDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(168, 29);
            this.StartDate.TabIndex = 9;
            this.StartDate.Visible = false;
            // 
            // grdTotalStock
            // 
            this.grdTotalStock.AllowUserToAddRows = false;
            this.grdTotalStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdTotalStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTotalStock.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTotalStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTotalStock.ColumnHeadersHeight = 27;
            this.grdTotalStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colPackingSize,
            this.colOpening,
            this.colCuttingQuantity,
            this.colPurchasesIn,
            this.colPurchasesReturn,
            this.colSales,
            this.colReturns,
            this.colTanneryUsed,
            this.colClosing,
            this.colStockBalance});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTotalStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdTotalStock.EnableHeadersVisualStyles = false;
            this.grdTotalStock.Location = new System.Drawing.Point(1, 161);
            this.grdTotalStock.Name = "grdTotalStock";
            this.grdTotalStock.ReadOnly = true;
            this.grdTotalStock.RowHeadersVisible = false;
            this.grdTotalStock.Size = new System.Drawing.Size(1256, 334);
            this.grdTotalStock.TabIndex = 8;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAccountName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAccountName.HeaderText = "Product Discription";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 140;
            // 
            // colPackingSize
            // 
            this.colPackingSize.DataPropertyName = "PackingSize";
            this.colPackingSize.HeaderText = "Packing Size";
            this.colPackingSize.Name = "colPackingSize";
            this.colPackingSize.ReadOnly = true;
            this.colPackingSize.Width = 60;
            // 
            // colOpening
            // 
            this.colOpening.DataPropertyName = "Opening";
            this.colOpening.HeaderText = "Opening";
            this.colOpening.Name = "colOpening";
            this.colOpening.ReadOnly = true;
            this.colOpening.Width = 80;
            // 
            // colCuttingQuantity
            // 
            this.colCuttingQuantity.DataPropertyName = "CuttingQuantity";
            this.colCuttingQuantity.HeaderText = "Cutting Qty";
            this.colCuttingQuantity.Name = "colCuttingQuantity";
            this.colCuttingQuantity.ReadOnly = true;
            this.colCuttingQuantity.Width = 90;
            // 
            // colPurchasesIn
            // 
            this.colPurchasesIn.DataPropertyName = "Purchases";
            this.colPurchasesIn.HeaderText = "Purchases In";
            this.colPurchasesIn.Name = "colPurchasesIn";
            this.colPurchasesIn.ReadOnly = true;
            // 
            // colPurchasesReturn
            // 
            this.colPurchasesReturn.DataPropertyName = "PurchasesReturn";
            this.colPurchasesReturn.HeaderText = "Pur Return";
            this.colPurchasesReturn.Name = "colPurchasesReturn";
            this.colPurchasesReturn.ReadOnly = true;
            // 
            // colSales
            // 
            this.colSales.DataPropertyName = "Sales";
            this.colSales.HeaderText = "Sold Out";
            this.colSales.Name = "colSales";
            this.colSales.ReadOnly = true;
            // 
            // colReturns
            // 
            this.colReturns.DataPropertyName = "SoldIn";
            this.colReturns.HeaderText = "Sold Return";
            this.colReturns.Name = "colReturns";
            this.colReturns.ReadOnly = true;
            // 
            // colTanneryUsed
            // 
            this.colTanneryUsed.DataPropertyName = "TanneryUsed";
            this.colTanneryUsed.HeaderText = "Tannery Used";
            this.colTanneryUsed.Name = "colTanneryUsed";
            this.colTanneryUsed.ReadOnly = true;
            // 
            // colClosing
            // 
            this.colClosing.DataPropertyName = "Closing";
            this.colClosing.HeaderText = "Closing Stock";
            this.colClosing.Name = "colClosing";
            this.colClosing.ReadOnly = true;
            // 
            // colStockBalance
            // 
            this.colStockBalance.DataPropertyName = "Amount";
            this.colStockBalance.HeaderText = "Balance";
            this.colStockBalance.Name = "colStockBalance";
            this.colStockBalance.ReadOnly = true;
            // 
            // txtsearch
            // 
            // 
            // 
            // 
            this.txtsearch.CustomButton.Image = null;
            this.txtsearch.CustomButton.Location = new System.Drawing.Point(195, 1);
            this.txtsearch.CustomButton.Name = "";
            this.txtsearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtsearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtsearch.CustomButton.TabIndex = 1;
            this.txtsearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtsearch.CustomButton.UseSelectable = true;
            this.txtsearch.CustomButton.Visible = false;
            this.txtsearch.Lines = new string[0];
            this.txtsearch.Location = new System.Drawing.Point(95, 121);
            this.txtsearch.MaxLength = 32767;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PromptText = "Search Here";
            this.txtsearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtsearch.SelectedText = "";
            this.txtsearch.SelectionLength = 0;
            this.txtsearch.SelectionStart = 0;
            this.txtsearch.ShortcutsEnabled = true;
            this.txtsearch.Size = new System.Drawing.Size(217, 23);
            this.txtsearch.TabIndex = 11;
            this.txtsearch.UseSelectable = true;
            this.txtsearch.WaterMark = "Search Here";
            this.txtsearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtsearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 121);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(90, 19);
            this.lblSearch.TabIndex = 12;
            this.lblSearch.Text = "Search Stock :";
            // 
            // CbxTrading
            // 
            this.CbxTrading.FormattingEnabled = true;
            this.CbxTrading.ItemHeight = 23;
            this.CbxTrading.Location = new System.Drawing.Point(1110, 16);
            this.CbxTrading.Name = "CbxTrading";
            this.CbxTrading.Size = new System.Drawing.Size(130, 29);
            this.CbxTrading.TabIndex = 10;
            this.CbxTrading.UseSelectable = true;
            this.CbxTrading.Visible = false;
            // 
            // chkByTrading
            // 
            this.chkByTrading.AutoSize = true;
            this.chkByTrading.Location = new System.Drawing.Point(981, 23);
            this.chkByTrading.Name = "chkByTrading";
            this.chkByTrading.Size = new System.Drawing.Size(123, 15);
            this.chkByTrading.TabIndex = 13;
            this.chkByTrading.Text = "By Company Stock";
            this.chkByTrading.UseSelectable = true;
            this.chkByTrading.Visible = false;
            this.chkByTrading.CheckedChanged += new System.EventHandler(this.chkByTrading_CheckedChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(9, 84);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(70, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Category :";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AccountName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Discription";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PackingSize";
            this.dataGridViewTextBoxColumn2.HeaderText = "Packing Size";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Opening";
            this.dataGridViewTextBoxColumn3.HeaderText = "Opening";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Purchases";
            this.dataGridViewTextBoxColumn4.HeaderText = "Purchases In";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PurchasesReturn";
            this.dataGridViewTextBoxColumn5.HeaderText = "Pur Return";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Sales";
            this.dataGridViewTextBoxColumn6.HeaderText = "Sold Out";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SoldIn";
            this.dataGridViewTextBoxColumn7.HeaderText = "Sold Return";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "RubberingIn";
            this.dataGridViewTextBoxColumn8.HeaderText = "Rubbering Out";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "RubberingIn";
            this.dataGridViewTextBoxColumn9.HeaderText = "Rubbering In";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 90;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ProductionOut";
            this.dataGridViewTextBoxColumn10.HeaderText = "Production Out";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 110;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ProductionIn";
            this.dataGridViewTextBoxColumn11.HeaderText = "Production In";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 95;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Closing";
            this.dataGridViewTextBoxColumn12.HeaderText = "Closing Stock";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn13.HeaderText = "Balance";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn14.HeaderText = "Balance";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // frmTotalStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 511);
            this.Controls.Add(this.chkByCategory);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.chkByTrading);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.CbxCategories);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.CbxTrading);
            this.Controls.Add(this.EndDate);
            this.Controls.Add(this.StartDate);
            this.Controls.Add(this.grdTotalStock);
            this.Name = "frmTotalStock";
            this.Text = "Feroz Sons Stock Analysis";
            this.Load += new System.EventHandler(this.frmTotalStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTotalStock;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox chkDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime EndDate;
        private MetroFramework.Controls.MetroDateTime StartDate;
        private MetroFramework.Controls.MetroTile btnExcelExport;
        private MetroFramework.Controls.MetroTile btnLoad;
        private MetroFramework.Controls.MetroComboBox CbxCategories;
        private MetroFramework.Controls.MetroTextBox txtsearch;
        private MetroFramework.Controls.MetroLabel lblSearch;
        private MetroFramework.Controls.MetroCheckBox chkByCategory;
        private MetroFramework.Controls.MetroComboBox CbxTrading;
        private MetroFramework.Controls.MetroCheckBox chkByTrading;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpening;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchasesIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchasesReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturns;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanneryUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockBalance;
    }
}