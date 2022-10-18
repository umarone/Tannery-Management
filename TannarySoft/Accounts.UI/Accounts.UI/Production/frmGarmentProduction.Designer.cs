namespace Accounts.UI
{
    partial class frmGarmentProduction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProductionDate = new MetroFramework.Controls.MetroDateTime();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.ProductionTab = new MetroFramework.Controls.MetroTabControl();
            this.mTabCutting = new MetroFramework.Controls.MetroTabPage();
            this.grdCutting = new Accounts.UI.TabDataGrid();
            this.btnCuttingSave = new MetroFramework.Controls.MetroTile();
            this.btnCuttingClose = new MetroFramework.Controls.MetroTile();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdCuttingMaterialUsed = new Accounts.UI.TabDataGrid();
            this.colCuttingIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingMaterialIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingMaterialDate = new Accounts.UI.CalendarColumn();
            this.colCuttingMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingMaterialUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingMaterialUsedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingMaterialDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdCuttingWastage = new Accounts.UI.TabDataGrid();
            this.colCuttingIdWastage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingWastageIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingWastageDate = new Accounts.UI.CalendarColumn();
            this.colCuttingWastageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingWastageUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingWastageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingWastageDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mTabStitching = new MetroFramework.Controls.MetroTabPage();
            this.grdStitching = new Accounts.UI.TabDataGrid();
            this.grdStitchingMaterials = new Accounts.UI.TabDataGrid();
            this.colStitchingIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingMaterialIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingMaterialDate = new Accounts.UI.CalendarColumn();
            this.colStitchingMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingMaterialUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingMaterialDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingMaterialQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingMaterialDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSplittingClose = new MetroFramework.Controls.MetroTile();
            this.btnStitchingSave = new MetroFramework.Controls.MetroTile();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.mTabFedo = new MetroFramework.Controls.MetroTabPage();
            this.grdFeedoSaftey = new Accounts.UI.TabDataGrid();
            this.grdFeedoMaterials = new Accounts.UI.TabDataGrid();
            this.colFeedoIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoMaterialIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoMaterialDate = new Accounts.UI.CalendarColumn();
            this.colFeedoMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoMaterialUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoMaterialDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoMaterialUsedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoMaterialDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnFeedoSave = new MetroFramework.Controls.MetroTile();
            this.btnRetrimmingClose = new MetroFramework.Controls.MetroTile();
            this.mTabBarTake = new MetroFramework.Controls.MetroTabPage();
            this.btnBartakeSave = new MetroFramework.Controls.MetroTile();
            this.btnShavingClose = new MetroFramework.Controls.MetroTile();
            this.grdBartake = new Accounts.UI.TabDataGrid();
            this.grdBartakeMaterials = new Accounts.UI.TabDataGrid();
            this.colBartakeIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeMaterialIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeMaterialDate = new Accounts.UI.CalendarColumn();
            this.colBartakeMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeMaterialUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeMaterialDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeMaterialQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeMaterialDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mTabThread = new MetroFramework.Controls.MetroTabPage();
            this.grdThreading = new Accounts.UI.TabDataGrid();
            this.mTabInspection = new MetroFramework.Controls.MetroTabPage();
            this.grdInspection = new Accounts.UI.TabDataGrid();
            this.mTabPress = new MetroFramework.Controls.MetroTabPage();
            this.grdPress = new Accounts.UI.TabDataGrid();
            this.mTabPacking = new MetroFramework.Controls.MetroTabPage();
            this.grdPacking = new Accounts.UI.TabDataGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPackingSave = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.grdPackingMaterials = new Accounts.UI.TabDataGrid();
            this.colPackingIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingMaterialIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingMaterialDate = new Accounts.UI.CalendarColumn();
            this.colPackingMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingMaterialUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingMaterialDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingMaterialQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingMaterialDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mTabExpenses = new MetroFramework.Controls.MetroTabPage();
            this.btnOverHeadsSave = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.grdMiscCost = new Accounts.UI.TabDataGrid();
            this.colIdDetailCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostDate = new Accounts.UI.CalendarColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbxCustomerPOS = new System.Windows.Forms.ComboBox();
            this.colIdCutting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsCuttingPosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingDate = new Accounts.UI.CalendarColumn();
            this.colCuttingVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingClotheName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingColors = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCuttingSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCuttingType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCuttingClotheQuality = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCuttingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingMeters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCuttingPosting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdStitching = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsStitchingPosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingDate = new Accounts.UI.CalendarColumn();
            this.colStitchingVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStitchingType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStitchingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStitchingDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colStitchingPost = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdFeedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsFeedoPosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoDate = new Accounts.UI.CalendarColumn();
            this.colFeedoVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoWorkType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFeedoBrandType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFeedoSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFeedoQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedoDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colFeedoPosting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdBartake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsBartakePosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeDate = new Accounts.UI.CalendarColumn();
            this.colBartakeVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeFinishedGoods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeWorkType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBartakeOrderType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBartakeSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBartakeQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeRates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBartakeDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBartakePosting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdThreading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingIsPosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingWorkDate = new Accounts.UI.CalendarColumn();
            this.colThreadingVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingOrderType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colThreadingSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colThreadingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadingDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colThreadingPosting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdIspection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionIsPosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionWorkingDate = new Accounts.UI.CalendarColumn();
            this.colInspectionVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionOrderType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInspectionSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInspectionQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionPassQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRejectedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colInspectionPosting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdPress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressIsPosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressWorkDate = new Accounts.UI.CalendarColumn();
            this.colPressVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressOrderType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPressSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPressQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressReadyUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressRejection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressRates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPressDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPressPosting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdPacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingIsPosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingWorkDate = new Accounts.UI.CalendarColumn();
            this.colPackingVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingOrderType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPackingSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPackingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingRates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPackingPosting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProductionTab.SuspendLayout();
            this.mTabCutting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCutting)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCuttingMaterialUsed)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCuttingWastage)).BeginInit();
            this.mTabStitching.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStitching)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStitchingMaterials)).BeginInit();
            this.mTabFedo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeedoSaftey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeedoMaterials)).BeginInit();
            this.mTabBarTake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBartake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBartakeMaterials)).BeginInit();
            this.mTabThread.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdThreading)).BeginInit();
            this.mTabInspection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInspection)).BeginInit();
            this.mTabPress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPress)).BeginInit();
            this.mTabPacking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPacking)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPackingMaterials)).BeginInit();
            this.mTabExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiscCost)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductionDate
            // 
            this.ProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ProductionDate.Location = new System.Drawing.Point(328, 21);
            this.ProductionDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.ProductionDate.Name = "ProductionDate";
            this.ProductionDate.Size = new System.Drawing.Size(146, 29);
            this.ProductionDate.TabIndex = 26;
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(117, 24);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.PromptText = "Production No.";
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(151, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 25;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMark = "Production No.";
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.VEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VEditBox_KeyPress);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(6, 24);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(105, 19);
            this.lblVoucherNo.TabIndex = 23;
            this.lblVoucherNo.Text = "Production No :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(277, 26);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 19);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Date :";
            // 
            // ProductionTab
            // 
            this.ProductionTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.ProductionTab.Controls.Add(this.mTabCutting);
            this.ProductionTab.Controls.Add(this.mTabStitching);
            this.ProductionTab.Controls.Add(this.mTabFedo);
            this.ProductionTab.Controls.Add(this.mTabBarTake);
            this.ProductionTab.Controls.Add(this.mTabThread);
            this.ProductionTab.Controls.Add(this.mTabInspection);
            this.ProductionTab.Controls.Add(this.mTabPress);
            this.ProductionTab.Controls.Add(this.mTabPacking);
            this.ProductionTab.Controls.Add(this.mTabExpenses);
            this.ProductionTab.Location = new System.Drawing.Point(6, 85);
            this.ProductionTab.Name = "ProductionTab";
            this.ProductionTab.SelectedIndex = 7;
            this.ProductionTab.Size = new System.Drawing.Size(1233, 671);
            this.ProductionTab.Style = MetroFramework.MetroColorStyle.Green;
            this.ProductionTab.TabIndex = 27;
            this.ProductionTab.UseSelectable = true;
            this.ProductionTab.SelectedIndexChanged += new System.EventHandler(this.ProductionTab_SelectedIndexChanged);
            // 
            // mTabCutting
            // 
            this.mTabCutting.Controls.Add(this.grdCutting);
            this.mTabCutting.Controls.Add(this.btnCuttingSave);
            this.mTabCutting.Controls.Add(this.btnCuttingClose);
            this.mTabCutting.Controls.Add(this.groupBox1);
            this.mTabCutting.Controls.Add(this.groupBox2);
            this.mTabCutting.HorizontalScrollbarBarColor = true;
            this.mTabCutting.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabCutting.HorizontalScrollbarSize = 10;
            this.mTabCutting.Location = new System.Drawing.Point(4, 41);
            this.mTabCutting.Name = "mTabCutting";
            this.mTabCutting.Size = new System.Drawing.Size(1225, 626);
            this.mTabCutting.TabIndex = 0;
            this.mTabCutting.Text = "Cutting";
            this.mTabCutting.VerticalScrollbarBarColor = true;
            this.mTabCutting.VerticalScrollbarHighlightOnWheel = false;
            this.mTabCutting.VerticalScrollbarSize = 10;
            // 
            // grdCutting
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCutting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCutting.ColumnHeadersHeight = 28;
            this.grdCutting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCutting,
            this.colIsCuttingPosting,
            this.colCuttingIdItem,
            this.colCuttingIdVoucher,
            this.colCuttingAccountNo,
            this.colCuttingAccountType,
            this.colCuttingDate,
            this.colCuttingVendorName,
            this.colCuttingClotheName,
            this.colCuttingColors,
            this.colCuttingSizes,
            this.colCuttingType,
            this.colCuttingClotheQuality,
            this.colCuttingQty,
            this.colCuttingMeters,
            this.colCuttingRate,
            this.colCuttingAmount,
            this.colCuttingDelete,
            this.colCuttingPosting});
            this.grdCutting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCutting.EnableHeadersVisualStyles = false;
            this.grdCutting.Location = new System.Drawing.Point(0, 3);
            this.grdCutting.MultiSelect = false;
            this.grdCutting.Name = "grdCutting";
            this.grdCutting.RowHeadersVisible = false;
            this.grdCutting.Size = new System.Drawing.Size(1222, 320);
            this.grdCutting.TabIndex = 2;
            this.grdCutting.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCutting_CellClick);
            this.grdCutting.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCutting_CellEndEdit);
            this.grdCutting.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCutting_CellEnter);
            this.grdCutting.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCutting_CellFormatting);
            this.grdCutting.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdCutting_EditingControlShowing);
            // 
            // btnCuttingSave
            // 
            this.btnCuttingSave.ActiveControl = null;
            this.btnCuttingSave.Location = new System.Drawing.Point(1018, 569);
            this.btnCuttingSave.Name = "btnCuttingSave";
            this.btnCuttingSave.Size = new System.Drawing.Size(101, 46);
            this.btnCuttingSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnCuttingSave.TabIndex = 7;
            this.btnCuttingSave.Text = "Save";
            this.btnCuttingSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCuttingSave.UseSelectable = true;
            this.btnCuttingSave.Visible = false;
            this.btnCuttingSave.Click += new System.EventHandler(this.btnCuttingSave_Click);
            // 
            // btnCuttingClose
            // 
            this.btnCuttingClose.ActiveControl = null;
            this.btnCuttingClose.Location = new System.Drawing.Point(1122, 569);
            this.btnCuttingClose.Name = "btnCuttingClose";
            this.btnCuttingClose.Size = new System.Drawing.Size(101, 46);
            this.btnCuttingClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnCuttingClose.TabIndex = 8;
            this.btnCuttingClose.Text = "Close";
            this.btnCuttingClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCuttingClose.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdCuttingMaterialUsed);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-2, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 235);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Material Usage";
            // 
            // grdCuttingMaterialUsed
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCuttingMaterialUsed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCuttingMaterialUsed.ColumnHeadersHeight = 28;
            this.grdCuttingMaterialUsed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCuttingIdMaterial,
            this.colCuttingMaterialIdItem,
            this.colCuttingMaterialDate,
            this.colCuttingMaterialName,
            this.colCuttingMaterialUOM,
            this.colCuttingMaterialUsedQty,
            this.colCuttingMaterialDelete});
            this.grdCuttingMaterialUsed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCuttingMaterialUsed.EnableHeadersVisualStyles = false;
            this.grdCuttingMaterialUsed.Location = new System.Drawing.Point(6, 24);
            this.grdCuttingMaterialUsed.MultiSelect = false;
            this.grdCuttingMaterialUsed.Name = "grdCuttingMaterialUsed";
            this.grdCuttingMaterialUsed.RowHeadersVisible = false;
            this.grdCuttingMaterialUsed.Size = new System.Drawing.Size(599, 207);
            this.grdCuttingMaterialUsed.TabIndex = 2;
            this.grdCuttingMaterialUsed.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdCuttingMaterialUsed_EditingControlShowing);
            // 
            // colCuttingIdMaterial
            // 
            this.colCuttingIdMaterial.HeaderText = "IdMaterial";
            this.colCuttingIdMaterial.Name = "colCuttingIdMaterial";
            this.colCuttingIdMaterial.Visible = false;
            // 
            // colCuttingMaterialIdItem
            // 
            this.colCuttingMaterialIdItem.HeaderText = "IdItem";
            this.colCuttingMaterialIdItem.Name = "colCuttingMaterialIdItem";
            this.colCuttingMaterialIdItem.Visible = false;
            // 
            // colCuttingMaterialDate
            // 
            this.colCuttingMaterialDate.HeaderText = "Date";
            this.colCuttingMaterialDate.Name = "colCuttingMaterialDate";
            this.colCuttingMaterialDate.Width = 85;
            // 
            // colCuttingMaterialName
            // 
            this.colCuttingMaterialName.HeaderText = "Material Name";
            this.colCuttingMaterialName.Name = "colCuttingMaterialName";
            this.colCuttingMaterialName.Width = 200;
            // 
            // colCuttingMaterialUOM
            // 
            this.colCuttingMaterialUOM.HeaderText = "UOM";
            this.colCuttingMaterialUOM.Name = "colCuttingMaterialUOM";
            // 
            // colCuttingMaterialUsedQty
            // 
            this.colCuttingMaterialUsedQty.HeaderText = "Used Quantity";
            this.colCuttingMaterialUsedQty.Name = "colCuttingMaterialUsedQty";
            this.colCuttingMaterialUsedQty.Width = 120;
            // 
            // colCuttingMaterialDelete
            // 
            this.colCuttingMaterialDelete.HeaderText = "Delete";
            this.colCuttingMaterialDelete.Name = "colCuttingMaterialDelete";
            this.colCuttingMaterialDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCuttingMaterialDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCuttingMaterialDelete.Width = 90;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdCuttingWastage);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(609, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 235);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wastage";
            // 
            // grdCuttingWastage
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCuttingWastage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCuttingWastage.ColumnHeadersHeight = 28;
            this.grdCuttingWastage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCuttingIdWastage,
            this.colCuttingWastageIdItem,
            this.colCuttingWastageDate,
            this.colCuttingWastageName,
            this.colCuttingWastageUOM,
            this.colCuttingWastageQuantity,
            this.colCuttingWastageDelete});
            this.grdCuttingWastage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCuttingWastage.EnableHeadersVisualStyles = false;
            this.grdCuttingWastage.Location = new System.Drawing.Point(6, 23);
            this.grdCuttingWastage.MultiSelect = false;
            this.grdCuttingWastage.Name = "grdCuttingWastage";
            this.grdCuttingWastage.RowHeadersVisible = false;
            this.grdCuttingWastage.Size = new System.Drawing.Size(609, 208);
            this.grdCuttingWastage.TabIndex = 2;
            this.grdCuttingWastage.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdCuttingWastage_EditingControlShowing);
            // 
            // colCuttingIdWastage
            // 
            this.colCuttingIdWastage.HeaderText = "IdMaterial";
            this.colCuttingIdWastage.Name = "colCuttingIdWastage";
            this.colCuttingIdWastage.Visible = false;
            // 
            // colCuttingWastageIdItem
            // 
            this.colCuttingWastageIdItem.HeaderText = "IdItem";
            this.colCuttingWastageIdItem.Name = "colCuttingWastageIdItem";
            this.colCuttingWastageIdItem.Visible = false;
            // 
            // colCuttingWastageDate
            // 
            this.colCuttingWastageDate.HeaderText = "Date";
            this.colCuttingWastageDate.Name = "colCuttingWastageDate";
            this.colCuttingWastageDate.Width = 85;
            // 
            // colCuttingWastageName
            // 
            this.colCuttingWastageName.HeaderText = "Wastage Name";
            this.colCuttingWastageName.Name = "colCuttingWastageName";
            this.colCuttingWastageName.Width = 200;
            // 
            // colCuttingWastageUOM
            // 
            this.colCuttingWastageUOM.HeaderText = "UOM";
            this.colCuttingWastageUOM.Name = "colCuttingWastageUOM";
            // 
            // colCuttingWastageQuantity
            // 
            this.colCuttingWastageQuantity.HeaderText = "Wastage Quantity";
            this.colCuttingWastageQuantity.Name = "colCuttingWastageQuantity";
            this.colCuttingWastageQuantity.Width = 120;
            // 
            // colCuttingWastageDelete
            // 
            this.colCuttingWastageDelete.HeaderText = "Delete";
            this.colCuttingWastageDelete.Name = "colCuttingWastageDelete";
            this.colCuttingWastageDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCuttingWastageDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCuttingWastageDelete.Width = 90;
            // 
            // mTabStitching
            // 
            this.mTabStitching.Controls.Add(this.grdStitching);
            this.mTabStitching.Controls.Add(this.grdStitchingMaterials);
            this.mTabStitching.Controls.Add(this.btnSplittingClose);
            this.mTabStitching.Controls.Add(this.btnStitchingSave);
            this.mTabStitching.Controls.Add(this.groupBox5);
            this.mTabStitching.HorizontalScrollbarBarColor = true;
            this.mTabStitching.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabStitching.HorizontalScrollbarSize = 10;
            this.mTabStitching.Location = new System.Drawing.Point(4, 41);
            this.mTabStitching.Name = "mTabStitching";
            this.mTabStitching.Size = new System.Drawing.Size(1225, 626);
            this.mTabStitching.TabIndex = 1;
            this.mTabStitching.Text = "Stitching";
            this.mTabStitching.VerticalScrollbarBarColor = true;
            this.mTabStitching.VerticalScrollbarHighlightOnWheel = false;
            this.mTabStitching.VerticalScrollbarSize = 10;
            // 
            // grdStitching
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStitching.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdStitching.ColumnHeadersHeight = 28;
            this.grdStitching.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdStitching,
            this.colIsStitchingPosting,
            this.colStitchingIdVoucher,
            this.colStitchingAccountNo,
            this.colStitchingAccountType,
            this.colStitchingDate,
            this.colStitchingVendorName,
            this.colStitchingDescription,
            this.colStitchingSizes,
            this.colStitchingType,
            this.colStitchingQuantity,
            this.colStitchingRate,
            this.colStitchingAmount,
            this.colStitchingDelete,
            this.colStitchingPost});
            this.grdStitching.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdStitching.EnableHeadersVisualStyles = false;
            this.grdStitching.Location = new System.Drawing.Point(0, 14);
            this.grdStitching.Name = "grdStitching";
            this.grdStitching.RowHeadersVisible = false;
            this.grdStitching.Size = new System.Drawing.Size(1175, 299);
            this.grdStitching.TabIndex = 2;
            this.grdStitching.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStitching_CellClick);
            this.grdStitching.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStitching_CellEndEdit);
            this.grdStitching.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStitching_CellEnter);
            this.grdStitching.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdStitching_CellFormatting);
            this.grdStitching.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdStitching_EditingControlShowing);
            // 
            // grdStitchingMaterials
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStitchingMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdStitchingMaterials.ColumnHeadersHeight = 28;
            this.grdStitchingMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStitchingIdMaterial,
            this.colStitchingMaterialIdItem,
            this.colStitchingMaterialDate,
            this.colStitchingMaterialName,
            this.colStitchingMaterialUOM,
            this.colStitchingMaterialDescription,
            this.colStitchingMaterialQuantity,
            this.colStitchingMaterialDelete});
            this.grdStitchingMaterials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdStitchingMaterials.EnableHeadersVisualStyles = false;
            this.grdStitchingMaterials.Location = new System.Drawing.Point(3, 340);
            this.grdStitchingMaterials.MultiSelect = false;
            this.grdStitchingMaterials.Name = "grdStitchingMaterials";
            this.grdStitchingMaterials.RowHeadersVisible = false;
            this.grdStitchingMaterials.Size = new System.Drawing.Size(1159, 208);
            this.grdStitchingMaterials.TabIndex = 11;
            this.grdStitchingMaterials.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdStitchingMaterials_EditingControlShowing);
            // 
            // colStitchingIdMaterial
            // 
            this.colStitchingIdMaterial.HeaderText = "IdMaterial";
            this.colStitchingIdMaterial.Name = "colStitchingIdMaterial";
            this.colStitchingIdMaterial.Visible = false;
            // 
            // colStitchingMaterialIdItem
            // 
            this.colStitchingMaterialIdItem.HeaderText = "IdItem";
            this.colStitchingMaterialIdItem.Name = "colStitchingMaterialIdItem";
            this.colStitchingMaterialIdItem.Visible = false;
            // 
            // colStitchingMaterialDate
            // 
            this.colStitchingMaterialDate.HeaderText = "Material Date";
            this.colStitchingMaterialDate.Name = "colStitchingMaterialDate";
            this.colStitchingMaterialDate.Width = 200;
            // 
            // colStitchingMaterialName
            // 
            this.colStitchingMaterialName.HeaderText = "Material Name";
            this.colStitchingMaterialName.Name = "colStitchingMaterialName";
            this.colStitchingMaterialName.Width = 350;
            // 
            // colStitchingMaterialUOM
            // 
            this.colStitchingMaterialUOM.HeaderText = "UOM";
            this.colStitchingMaterialUOM.Name = "colStitchingMaterialUOM";
            // 
            // colStitchingMaterialDescription
            // 
            this.colStitchingMaterialDescription.HeaderText = "Description";
            this.colStitchingMaterialDescription.Name = "colStitchingMaterialDescription";
            this.colStitchingMaterialDescription.Width = 250;
            // 
            // colStitchingMaterialQuantity
            // 
            this.colStitchingMaterialQuantity.HeaderText = "Used Quantity";
            this.colStitchingMaterialQuantity.Name = "colStitchingMaterialQuantity";
            this.colStitchingMaterialQuantity.Width = 120;
            // 
            // colStitchingMaterialDelete
            // 
            this.colStitchingMaterialDelete.HeaderText = "Delete";
            this.colStitchingMaterialDelete.Name = "colStitchingMaterialDelete";
            this.colStitchingMaterialDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStitchingMaterialDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colStitchingMaterialDelete.Width = 120;
            // 
            // btnSplittingClose
            // 
            this.btnSplittingClose.ActiveControl = null;
            this.btnSplittingClose.Location = new System.Drawing.Point(141, 562);
            this.btnSplittingClose.Name = "btnSplittingClose";
            this.btnSplittingClose.Size = new System.Drawing.Size(142, 50);
            this.btnSplittingClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSplittingClose.TabIndex = 10;
            this.btnSplittingClose.Text = "Close";
            this.btnSplittingClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSplittingClose.UseSelectable = true;
            // 
            // btnStitchingSave
            // 
            this.btnStitchingSave.ActiveControl = null;
            this.btnStitchingSave.Location = new System.Drawing.Point(3, 562);
            this.btnStitchingSave.Name = "btnStitchingSave";
            this.btnStitchingSave.Size = new System.Drawing.Size(137, 50);
            this.btnStitchingSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnStitchingSave.TabIndex = 9;
            this.btnStitchingSave.Text = "Save";
            this.btnStitchingSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStitchingSave.UseSelectable = true;
            this.btnStitchingSave.Visible = false;
            this.btnStitchingSave.Click += new System.EventHandler(this.btnStitchingSave_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(0, 319);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1175, 237);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Material Usage";
            // 
            // mTabFedo
            // 
            this.mTabFedo.Controls.Add(this.grdFeedoSaftey);
            this.mTabFedo.Controls.Add(this.grdFeedoMaterials);
            this.mTabFedo.Controls.Add(this.btnFeedoSave);
            this.mTabFedo.Controls.Add(this.btnRetrimmingClose);
            this.mTabFedo.HorizontalScrollbarBarColor = true;
            this.mTabFedo.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabFedo.HorizontalScrollbarSize = 10;
            this.mTabFedo.Location = new System.Drawing.Point(4, 41);
            this.mTabFedo.Name = "mTabFedo";
            this.mTabFedo.Size = new System.Drawing.Size(1225, 626);
            this.mTabFedo.TabIndex = 2;
            this.mTabFedo.Text = "Feedo / Saftey";
            this.mTabFedo.VerticalScrollbarBarColor = true;
            this.mTabFedo.VerticalScrollbarHighlightOnWheel = false;
            this.mTabFedo.VerticalScrollbarSize = 10;
            // 
            // grdFeedoSaftey
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFeedoSaftey.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdFeedoSaftey.ColumnHeadersHeight = 28;
            this.grdFeedoSaftey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdFeedo,
            this.colIsFeedoPosting,
            this.colFeedoIdVoucher,
            this.colFeedoAccountNo,
            this.colFeedoAccountType,
            this.colFeedoDate,
            this.colFeedoVendorName,
            this.colFeedoWorkType,
            this.colFeedoBrandType,
            this.colFeedoSizes,
            this.colFeedoQuantity,
            this.colFeedoRate,
            this.colFeedoAmount,
            this.colFeedoDelete,
            this.colFeedoPosting});
            this.grdFeedoSaftey.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdFeedoSaftey.EnableHeadersVisualStyles = false;
            this.grdFeedoSaftey.Location = new System.Drawing.Point(1, 11);
            this.grdFeedoSaftey.Name = "grdFeedoSaftey";
            this.grdFeedoSaftey.RowHeadersVisible = false;
            this.grdFeedoSaftey.Size = new System.Drawing.Size(1171, 342);
            this.grdFeedoSaftey.TabIndex = 2;
            this.grdFeedoSaftey.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFeedoSaftey_CellClick);
            this.grdFeedoSaftey.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFeedoSaftey_CellEndEdit);
            this.grdFeedoSaftey.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFeedoSaftey_CellEnter);
            this.grdFeedoSaftey.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdFeedoSaftey_CellFormatting);
            this.grdFeedoSaftey.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFeedoSaftey_CellLeave);
            this.grdFeedoSaftey.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdFeedoSaftey_EditingControlShowing);
            // 
            // grdFeedoMaterials
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFeedoMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdFeedoMaterials.ColumnHeadersHeight = 28;
            this.grdFeedoMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFeedoIdMaterial,
            this.colFeedoMaterialIdItem,
            this.colFeedoMaterialDate,
            this.colFeedoMaterialName,
            this.colFeedoMaterialUOM,
            this.colFeedoMaterialDescription,
            this.colFeedoMaterialUsedQuantity,
            this.colFeedoMaterialDelete});
            this.grdFeedoMaterials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdFeedoMaterials.EnableHeadersVisualStyles = false;
            this.grdFeedoMaterials.Location = new System.Drawing.Point(3, 361);
            this.grdFeedoMaterials.MultiSelect = false;
            this.grdFeedoMaterials.Name = "grdFeedoMaterials";
            this.grdFeedoMaterials.RowHeadersVisible = false;
            this.grdFeedoMaterials.Size = new System.Drawing.Size(1169, 208);
            this.grdFeedoMaterials.TabIndex = 12;
            this.grdFeedoMaterials.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdFeedoMaterials_EditingControlShowing);
            // 
            // colFeedoIdMaterial
            // 
            this.colFeedoIdMaterial.HeaderText = "IdMaterial";
            this.colFeedoIdMaterial.Name = "colFeedoIdMaterial";
            this.colFeedoIdMaterial.Visible = false;
            // 
            // colFeedoMaterialIdItem
            // 
            this.colFeedoMaterialIdItem.HeaderText = "IdItem";
            this.colFeedoMaterialIdItem.Name = "colFeedoMaterialIdItem";
            this.colFeedoMaterialIdItem.Visible = false;
            // 
            // colFeedoMaterialDate
            // 
            this.colFeedoMaterialDate.HeaderText = "Material Date";
            this.colFeedoMaterialDate.Name = "colFeedoMaterialDate";
            this.colFeedoMaterialDate.Width = 200;
            // 
            // colFeedoMaterialName
            // 
            this.colFeedoMaterialName.HeaderText = "Material Name";
            this.colFeedoMaterialName.Name = "colFeedoMaterialName";
            this.colFeedoMaterialName.Width = 300;
            // 
            // colFeedoMaterialUOM
            // 
            this.colFeedoMaterialUOM.HeaderText = "UOM";
            this.colFeedoMaterialUOM.Name = "colFeedoMaterialUOM";
            // 
            // colFeedoMaterialDescription
            // 
            this.colFeedoMaterialDescription.HeaderText = "Description";
            this.colFeedoMaterialDescription.Name = "colFeedoMaterialDescription";
            this.colFeedoMaterialDescription.Width = 250;
            // 
            // colFeedoMaterialUsedQuantity
            // 
            this.colFeedoMaterialUsedQuantity.HeaderText = "Used Quantity";
            this.colFeedoMaterialUsedQuantity.Name = "colFeedoMaterialUsedQuantity";
            this.colFeedoMaterialUsedQuantity.Width = 200;
            // 
            // colFeedoMaterialDelete
            // 
            this.colFeedoMaterialDelete.HeaderText = "Delete";
            this.colFeedoMaterialDelete.Name = "colFeedoMaterialDelete";
            this.colFeedoMaterialDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFeedoMaterialDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnFeedoSave
            // 
            this.btnFeedoSave.ActiveControl = null;
            this.btnFeedoSave.Location = new System.Drawing.Point(3, 575);
            this.btnFeedoSave.Name = "btnFeedoSave";
            this.btnFeedoSave.Size = new System.Drawing.Size(101, 40);
            this.btnFeedoSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnFeedoSave.TabIndex = 9;
            this.btnFeedoSave.Text = "Save";
            this.btnFeedoSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFeedoSave.UseSelectable = true;
            this.btnFeedoSave.Visible = false;
            this.btnFeedoSave.Click += new System.EventHandler(this.btnFeedoSave_Click);
            // 
            // btnRetrimmingClose
            // 
            this.btnRetrimmingClose.ActiveControl = null;
            this.btnRetrimmingClose.Location = new System.Drawing.Point(107, 575);
            this.btnRetrimmingClose.Name = "btnRetrimmingClose";
            this.btnRetrimmingClose.Size = new System.Drawing.Size(101, 40);
            this.btnRetrimmingClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnRetrimmingClose.TabIndex = 10;
            this.btnRetrimmingClose.Text = "Close";
            this.btnRetrimmingClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRetrimmingClose.UseSelectable = true;
            // 
            // mTabBarTake
            // 
            this.mTabBarTake.Controls.Add(this.btnBartakeSave);
            this.mTabBarTake.Controls.Add(this.btnShavingClose);
            this.mTabBarTake.Controls.Add(this.grdBartake);
            this.mTabBarTake.Controls.Add(this.grdBartakeMaterials);
            this.mTabBarTake.Controls.Add(this.groupBox3);
            this.mTabBarTake.HorizontalScrollbarBarColor = true;
            this.mTabBarTake.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabBarTake.HorizontalScrollbarSize = 10;
            this.mTabBarTake.Location = new System.Drawing.Point(4, 41);
            this.mTabBarTake.Name = "mTabBarTake";
            this.mTabBarTake.Size = new System.Drawing.Size(1225, 626);
            this.mTabBarTake.TabIndex = 3;
            this.mTabBarTake.Text = "Bartake / Kaaj / Buttons";
            this.mTabBarTake.VerticalScrollbarBarColor = true;
            this.mTabBarTake.VerticalScrollbarHighlightOnWheel = false;
            this.mTabBarTake.VerticalScrollbarSize = 10;
            // 
            // btnBartakeSave
            // 
            this.btnBartakeSave.ActiveControl = null;
            this.btnBartakeSave.Location = new System.Drawing.Point(963, 552);
            this.btnBartakeSave.Name = "btnBartakeSave";
            this.btnBartakeSave.Size = new System.Drawing.Size(101, 50);
            this.btnBartakeSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnBartakeSave.TabIndex = 9;
            this.btnBartakeSave.Text = "Save";
            this.btnBartakeSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBartakeSave.UseSelectable = true;
            this.btnBartakeSave.Visible = false;
            this.btnBartakeSave.Click += new System.EventHandler(this.btnBartakeSave_Click);
            // 
            // btnShavingClose
            // 
            this.btnShavingClose.ActiveControl = null;
            this.btnShavingClose.Location = new System.Drawing.Point(1067, 552);
            this.btnShavingClose.Name = "btnShavingClose";
            this.btnShavingClose.Size = new System.Drawing.Size(101, 50);
            this.btnShavingClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnShavingClose.TabIndex = 10;
            this.btnShavingClose.Text = "Close";
            this.btnShavingClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShavingClose.UseSelectable = true;
            // 
            // grdBartake
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBartake.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdBartake.ColumnHeadersHeight = 28;
            this.grdBartake.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdBartake,
            this.colBartakeIdItem,
            this.colIsBartakePosting,
            this.colBartakeIdVoucher,
            this.colBartakeAccountNo,
            this.colBartakeAccountType,
            this.colBartakeDate,
            this.colBartakeVendorName,
            this.colBartakeFinishedGoods,
            this.colBartakeWorkType,
            this.colBartakeOrderType,
            this.colBartakeSizes,
            this.colBartakeQuantity,
            this.colBartakeRates,
            this.colBartakeAmount,
            this.colBartakeDelete,
            this.colBartakePosting});
            this.grdBartake.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdBartake.EnableHeadersVisualStyles = false;
            this.grdBartake.Location = new System.Drawing.Point(0, 14);
            this.grdBartake.Name = "grdBartake";
            this.grdBartake.RowHeadersVisible = false;
            this.grdBartake.Size = new System.Drawing.Size(1177, 296);
            this.grdBartake.TabIndex = 2;
            this.grdBartake.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBartake_CellClick);
            this.grdBartake.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBartake_CellEndEdit);
            this.grdBartake.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBartake_CellEnter);
            this.grdBartake.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdBartake_CellFormatting);
            this.grdBartake.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBartake_CellLeave);
            this.grdBartake.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdBartake_EditingControlShowing);
            // 
            // grdBartakeMaterials
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBartakeMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdBartakeMaterials.ColumnHeadersHeight = 28;
            this.grdBartakeMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBartakeIdMaterial,
            this.colBartakeMaterialIdItem,
            this.colBartakeMaterialDate,
            this.colBartakeMaterialName,
            this.colBartakeMaterialUOM,
            this.colBartakeMaterialDescription,
            this.colBartakeMaterialQuantity,
            this.colBartakeMaterialDelete});
            this.grdBartakeMaterials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdBartakeMaterials.EnableHeadersVisualStyles = false;
            this.grdBartakeMaterials.Location = new System.Drawing.Point(0, 339);
            this.grdBartakeMaterials.MultiSelect = false;
            this.grdBartakeMaterials.Name = "grdBartakeMaterials";
            this.grdBartakeMaterials.RowHeadersVisible = false;
            this.grdBartakeMaterials.Size = new System.Drawing.Size(1174, 208);
            this.grdBartakeMaterials.TabIndex = 13;
            this.grdBartakeMaterials.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdBartakeMaterials_EditingControlShowing);
            // 
            // colBartakeIdMaterial
            // 
            this.colBartakeIdMaterial.HeaderText = "IdMaterial";
            this.colBartakeIdMaterial.Name = "colBartakeIdMaterial";
            this.colBartakeIdMaterial.Visible = false;
            // 
            // colBartakeMaterialIdItem
            // 
            this.colBartakeMaterialIdItem.HeaderText = "IdItem";
            this.colBartakeMaterialIdItem.Name = "colBartakeMaterialIdItem";
            this.colBartakeMaterialIdItem.Visible = false;
            // 
            // colBartakeMaterialDate
            // 
            this.colBartakeMaterialDate.HeaderText = "Material Date";
            this.colBartakeMaterialDate.Name = "colBartakeMaterialDate";
            this.colBartakeMaterialDate.Width = 150;
            // 
            // colBartakeMaterialName
            // 
            this.colBartakeMaterialName.HeaderText = "Material Name";
            this.colBartakeMaterialName.Name = "colBartakeMaterialName";
            this.colBartakeMaterialName.Width = 300;
            // 
            // colBartakeMaterialUOM
            // 
            this.colBartakeMaterialUOM.HeaderText = "UOM";
            this.colBartakeMaterialUOM.Name = "colBartakeMaterialUOM";
            this.colBartakeMaterialUOM.Width = 200;
            // 
            // colBartakeMaterialDescription
            // 
            this.colBartakeMaterialDescription.HeaderText = "Description";
            this.colBartakeMaterialDescription.Name = "colBartakeMaterialDescription";
            this.colBartakeMaterialDescription.Width = 200;
            // 
            // colBartakeMaterialQuantity
            // 
            this.colBartakeMaterialQuantity.HeaderText = "Used Quantity";
            this.colBartakeMaterialQuantity.Name = "colBartakeMaterialQuantity";
            this.colBartakeMaterialQuantity.Width = 200;
            // 
            // colBartakeMaterialDelete
            // 
            this.colBartakeMaterialDelete.HeaderText = "Delete";
            this.colBartakeMaterialDelete.Name = "colBartakeMaterialDelete";
            this.colBartakeMaterialDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBartakeMaterialDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox3
            // 
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1177, 292);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Material Usage";
            // 
            // mTabThread
            // 
            this.mTabThread.Controls.Add(this.grdThreading);
            this.mTabThread.HorizontalScrollbarBarColor = true;
            this.mTabThread.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabThread.HorizontalScrollbarSize = 10;
            this.mTabThread.Location = new System.Drawing.Point(4, 41);
            this.mTabThread.Name = "mTabThread";
            this.mTabThread.Size = new System.Drawing.Size(1225, 626);
            this.mTabThread.TabIndex = 4;
            this.mTabThread.Text = "Threading";
            this.mTabThread.VerticalScrollbarBarColor = true;
            this.mTabThread.VerticalScrollbarHighlightOnWheel = false;
            this.mTabThread.VerticalScrollbarSize = 10;
            // 
            // grdThreading
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdThreading.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdThreading.ColumnHeadersHeight = 28;
            this.grdThreading.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdThreading,
            this.colThreadingIsPosting,
            this.colThreadingIdVoucher,
            this.colThreadingAccountNo,
            this.colThreadingAccountType,
            this.colThreadingWorkDate,
            this.colThreadingVendorName,
            this.colThreadingOrderType,
            this.colThreadingSizes,
            this.colThreadingQuantity,
            this.colThreadingRate,
            this.colThreadingAmount,
            this.colThreadingDelete,
            this.colThreadingPosting});
            this.grdThreading.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdThreading.EnableHeadersVisualStyles = false;
            this.grdThreading.Location = new System.Drawing.Point(3, 3);
            this.grdThreading.Name = "grdThreading";
            this.grdThreading.RowHeadersVisible = false;
            this.grdThreading.Size = new System.Drawing.Size(1177, 561);
            this.grdThreading.TabIndex = 3;
            this.grdThreading.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdThreading_CellClick);
            this.grdThreading.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdThreading_CellEndEdit);
            this.grdThreading.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdThreading_CellEnter);
            this.grdThreading.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdThreading_CellFormatting);
            this.grdThreading.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdThreading_CellLeave);
            this.grdThreading.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdThreading_EditingControlShowing);
            // 
            // mTabInspection
            // 
            this.mTabInspection.Controls.Add(this.grdInspection);
            this.mTabInspection.HorizontalScrollbarBarColor = true;
            this.mTabInspection.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabInspection.HorizontalScrollbarSize = 10;
            this.mTabInspection.Location = new System.Drawing.Point(4, 41);
            this.mTabInspection.Name = "mTabInspection";
            this.mTabInspection.Size = new System.Drawing.Size(1225, 626);
            this.mTabInspection.TabIndex = 5;
            this.mTabInspection.Text = "Checking / Inspection";
            this.mTabInspection.VerticalScrollbarBarColor = true;
            this.mTabInspection.VerticalScrollbarHighlightOnWheel = false;
            this.mTabInspection.VerticalScrollbarSize = 10;
            // 
            // grdInspection
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInspection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grdInspection.ColumnHeadersHeight = 28;
            this.grdInspection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdIspection,
            this.colInspectionIsPosting,
            this.colInspectionIdVoucher,
            this.colInspectionAccountNo,
            this.colInspectionAccountType,
            this.colInspectionWorkingDate,
            this.colInspectionVendorName,
            this.colInspectionOrderType,
            this.colInspectionSizes,
            this.colInspectionQuantity,
            this.colInspectionPassQuantity,
            this.colInspectionRejectedQuantity,
            this.colInspectionRate,
            this.colInspectionAmount,
            this.colInspectionDelete,
            this.colInspectionPosting});
            this.grdInspection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdInspection.EnableHeadersVisualStyles = false;
            this.grdInspection.Location = new System.Drawing.Point(3, 3);
            this.grdInspection.Name = "grdInspection";
            this.grdInspection.RowHeadersVisible = false;
            this.grdInspection.Size = new System.Drawing.Size(1181, 583);
            this.grdInspection.TabIndex = 4;
            this.grdInspection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInspection_CellClick);
            this.grdInspection.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInspection_CellEndEdit);
            this.grdInspection.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInspection_CellEnter);
            this.grdInspection.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdInspection_CellFormatting);
            this.grdInspection.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInspection_CellLeave);
            this.grdInspection.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdInspection_EditingControlShowing);
            // 
            // mTabPress
            // 
            this.mTabPress.Controls.Add(this.grdPress);
            this.mTabPress.HorizontalScrollbarBarColor = true;
            this.mTabPress.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabPress.HorizontalScrollbarSize = 10;
            this.mTabPress.Location = new System.Drawing.Point(4, 41);
            this.mTabPress.Name = "mTabPress";
            this.mTabPress.Size = new System.Drawing.Size(1225, 626);
            this.mTabPress.TabIndex = 6;
            this.mTabPress.Text = "Press";
            this.mTabPress.VerticalScrollbarBarColor = true;
            this.mTabPress.VerticalScrollbarHighlightOnWheel = false;
            this.mTabPress.VerticalScrollbarSize = 10;
            // 
            // grdPress
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPress.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.grdPress.ColumnHeadersHeight = 28;
            this.grdPress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPress,
            this.colPressIsPosting,
            this.colPressIdVoucher,
            this.colPressAccountNo,
            this.colPressAccountType,
            this.colPressWorkDate,
            this.colPressVendorName,
            this.colPressOrderType,
            this.colPressSizes,
            this.colPressQuantity,
            this.colPressReadyUnits,
            this.colPressRejection,
            this.colPressRates,
            this.colPressAmount,
            this.colPressDelete,
            this.colPressPosting});
            this.grdPress.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdPress.EnableHeadersVisualStyles = false;
            this.grdPress.Location = new System.Drawing.Point(3, 3);
            this.grdPress.Name = "grdPress";
            this.grdPress.RowHeadersVisible = false;
            this.grdPress.Size = new System.Drawing.Size(1206, 595);
            this.grdPress.TabIndex = 5;
            this.grdPress.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPress_CellClick);
            this.grdPress.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPress_CellEndEdit);
            this.grdPress.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPress_CellEnter);
            this.grdPress.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdPress_CellFormatting);
            this.grdPress.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPress_CellLeave);
            this.grdPress.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdPress_EditingControlShowing);
            // 
            // mTabPacking
            // 
            this.mTabPacking.Controls.Add(this.grdPacking);
            this.mTabPacking.Controls.Add(this.groupBox4);
            this.mTabPacking.HorizontalScrollbarBarColor = true;
            this.mTabPacking.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabPacking.HorizontalScrollbarSize = 10;
            this.mTabPacking.Location = new System.Drawing.Point(4, 41);
            this.mTabPacking.Name = "mTabPacking";
            this.mTabPacking.Size = new System.Drawing.Size(1225, 626);
            this.mTabPacking.TabIndex = 7;
            this.mTabPacking.Text = "Packing";
            this.mTabPacking.VerticalScrollbarBarColor = true;
            this.mTabPacking.VerticalScrollbarHighlightOnWheel = false;
            this.mTabPacking.VerticalScrollbarSize = 10;
            // 
            // grdPacking
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPacking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.grdPacking.ColumnHeadersHeight = 28;
            this.grdPacking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPacking,
            this.colPackingIdItem,
            this.colPackingIsPosting,
            this.colPackingIdVoucher,
            this.colPackingAccountNo,
            this.colPackingAccountType,
            this.colPackingWorkDate,
            this.colPackingVendorName,
            this.colPackingArticleName,
            this.colPackingOrderType,
            this.colPackingSizes,
            this.colPackingQuantity,
            this.colPackingRates,
            this.colPackingAmount,
            this.colPackingDelete,
            this.colPackingPosting});
            this.grdPacking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdPacking.EnableHeadersVisualStyles = false;
            this.grdPacking.Location = new System.Drawing.Point(3, 3);
            this.grdPacking.Name = "grdPacking";
            this.grdPacking.RowHeadersVisible = false;
            this.grdPacking.Size = new System.Drawing.Size(1161, 299);
            this.grdPacking.TabIndex = 4;
            this.grdPacking.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPacking_CellClick);
            this.grdPacking.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPacking_CellEndEdit);
            this.grdPacking.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPacking_CellEnter);
            this.grdPacking.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdPacking_CellFormatting);
            this.grdPacking.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPacking_CellLeave);
            this.grdPacking.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdPacking_EditingControlShowing);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPackingSave);
            this.groupBox4.Controls.Add(this.metroTile2);
            this.groupBox4.Controls.Add(this.grdPackingMaterials);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 307);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1161, 301);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Material Usage";
            // 
            // btnPackingSave
            // 
            this.btnPackingSave.ActiveControl = null;
            this.btnPackingSave.Location = new System.Drawing.Point(790, 238);
            this.btnPackingSave.Name = "btnPackingSave";
            this.btnPackingSave.Size = new System.Drawing.Size(185, 50);
            this.btnPackingSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPackingSave.TabIndex = 15;
            this.btnPackingSave.Text = "Save";
            this.btnPackingSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPackingSave.UseSelectable = true;
            this.btnPackingSave.Visible = false;
            this.btnPackingSave.Click += new System.EventHandler(this.btnPackingSave_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(976, 238);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(173, 50);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile2.TabIndex = 16;
            this.metroTile2.Text = "Close";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTile2.UseSelectable = true;
            // 
            // grdPackingMaterials
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPackingMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.grdPackingMaterials.ColumnHeadersHeight = 28;
            this.grdPackingMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPackingIdMaterial,
            this.colPackingMaterialIdItem,
            this.colPackingMaterialDate,
            this.colPackingMaterialName,
            this.colPackingMaterialUOM,
            this.colPackingMaterialDescription,
            this.colPackingMaterialQuantity,
            this.colPackingMaterialDelete});
            this.grdPackingMaterials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdPackingMaterials.EnableHeadersVisualStyles = false;
            this.grdPackingMaterials.Location = new System.Drawing.Point(6, 24);
            this.grdPackingMaterials.MultiSelect = false;
            this.grdPackingMaterials.Name = "grdPackingMaterials";
            this.grdPackingMaterials.RowHeadersVisible = false;
            this.grdPackingMaterials.Size = new System.Drawing.Size(1143, 208);
            this.grdPackingMaterials.TabIndex = 14;
            this.grdPackingMaterials.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdPackingMaterials_EditingControlShowing);
            // 
            // colPackingIdMaterial
            // 
            this.colPackingIdMaterial.HeaderText = "IdMaterial";
            this.colPackingIdMaterial.Name = "colPackingIdMaterial";
            this.colPackingIdMaterial.Visible = false;
            // 
            // colPackingMaterialIdItem
            // 
            this.colPackingMaterialIdItem.HeaderText = "IdItem";
            this.colPackingMaterialIdItem.Name = "colPackingMaterialIdItem";
            this.colPackingMaterialIdItem.Visible = false;
            // 
            // colPackingMaterialDate
            // 
            this.colPackingMaterialDate.HeaderText = "Material Date";
            this.colPackingMaterialDate.Name = "colPackingMaterialDate";
            this.colPackingMaterialDate.Width = 200;
            // 
            // colPackingMaterialName
            // 
            this.colPackingMaterialName.HeaderText = "Material Name";
            this.colPackingMaterialName.Name = "colPackingMaterialName";
            this.colPackingMaterialName.Width = 300;
            // 
            // colPackingMaterialUOM
            // 
            this.colPackingMaterialUOM.HeaderText = "UOM";
            this.colPackingMaterialUOM.Name = "colPackingMaterialUOM";
            this.colPackingMaterialUOM.Width = 150;
            // 
            // colPackingMaterialDescription
            // 
            this.colPackingMaterialDescription.HeaderText = "Description";
            this.colPackingMaterialDescription.Name = "colPackingMaterialDescription";
            this.colPackingMaterialDescription.Width = 200;
            // 
            // colPackingMaterialQuantity
            // 
            this.colPackingMaterialQuantity.HeaderText = "Used Quantity";
            this.colPackingMaterialQuantity.Name = "colPackingMaterialQuantity";
            this.colPackingMaterialQuantity.Width = 200;
            // 
            // colPackingMaterialDelete
            // 
            this.colPackingMaterialDelete.HeaderText = "Delete";
            this.colPackingMaterialDelete.Name = "colPackingMaterialDelete";
            this.colPackingMaterialDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackingMaterialDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPackingMaterialDelete.Width = 90;
            // 
            // mTabExpenses
            // 
            this.mTabExpenses.Controls.Add(this.btnOverHeadsSave);
            this.mTabExpenses.Controls.Add(this.metroTile4);
            this.mTabExpenses.Controls.Add(this.grdMiscCost);
            this.mTabExpenses.HorizontalScrollbarBarColor = true;
            this.mTabExpenses.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabExpenses.HorizontalScrollbarSize = 10;
            this.mTabExpenses.Location = new System.Drawing.Point(4, 41);
            this.mTabExpenses.Name = "mTabExpenses";
            this.mTabExpenses.Size = new System.Drawing.Size(1225, 626);
            this.mTabExpenses.TabIndex = 8;
            this.mTabExpenses.Text = "Over Heads";
            this.mTabExpenses.VerticalScrollbarBarColor = true;
            this.mTabExpenses.VerticalScrollbarHighlightOnWheel = false;
            this.mTabExpenses.VerticalScrollbarSize = 10;
            // 
            // btnOverHeadsSave
            // 
            this.btnOverHeadsSave.ActiveControl = null;
            this.btnOverHeadsSave.Location = new System.Drawing.Point(896, 492);
            this.btnOverHeadsSave.Name = "btnOverHeadsSave";
            this.btnOverHeadsSave.Size = new System.Drawing.Size(157, 50);
            this.btnOverHeadsSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnOverHeadsSave.TabIndex = 16;
            this.btnOverHeadsSave.Text = "Save";
            this.btnOverHeadsSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOverHeadsSave.UseSelectable = true;
            this.btnOverHeadsSave.Click += new System.EventHandler(this.btnOverHeadsSave_Click);
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Location = new System.Drawing.Point(1054, 492);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(155, 50);
            this.metroTile4.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile4.TabIndex = 17;
            this.metroTile4.Text = "Close";
            this.metroTile4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTile4.UseSelectable = true;
            // 
            // grdMiscCost
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMiscCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.grdMiscCost.ColumnHeadersHeight = 28;
            this.grdMiscCost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdDetailCost,
            this.colAccountNo,
            this.colCostDate,
            this.colAccountName,
            this.colCostDescription,
            this.colCost,
            this.colCostDelete});
            this.grdMiscCost.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdMiscCost.EnableHeadersVisualStyles = false;
            this.grdMiscCost.Location = new System.Drawing.Point(3, 15);
            this.grdMiscCost.MultiSelect = false;
            this.grdMiscCost.Name = "grdMiscCost";
            this.grdMiscCost.RowHeadersVisible = false;
            this.grdMiscCost.Size = new System.Drawing.Size(1206, 471);
            this.grdMiscCost.TabIndex = 15;
            this.grdMiscCost.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdMiscCost_CellFormatting);
            this.grdMiscCost.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdMiscCost_EditingControlShowing);
            // 
            // colIdDetailCost
            // 
            this.colIdDetailCost.HeaderText = "IdDetailCost";
            this.colIdDetailCost.Name = "colIdDetailCost";
            this.colIdDetailCost.Visible = false;
            // 
            // colAccountNo
            // 
            this.colAccountNo.HeaderText = "AccountNo";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.Visible = false;
            // 
            // colCostDate
            // 
            this.colCostDate.HeaderText = "Date";
            this.colCostDate.Name = "colCostDate";
            this.colCostDate.Width = 150;
            // 
            // colAccountName
            // 
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Width = 300;
            // 
            // colCostDescription
            // 
            this.colCostDescription.HeaderText = "Description";
            this.colCostDescription.Name = "colCostDescription";
            this.colCostDescription.Width = 400;
            // 
            // colCost
            // 
            this.colCost.HeaderText = "Cost / Expense";
            this.colCost.Name = "colCost";
            this.colCost.Width = 200;
            // 
            // colCostDelete
            // 
            this.colCostDelete.HeaderText = "....";
            this.colCostDelete.Name = "colCostDelete";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(6, 53);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(93, 19);
            this.metroLabel1.TabIndex = 23;
            this.metroLabel1.Text = "Cutomer PO :";
            // 
            // cbxCustomerPOS
            // 
            this.cbxCustomerPOS.FormattingEnabled = true;
            this.cbxCustomerPOS.Location = new System.Drawing.Point(117, 58);
            this.cbxCustomerPOS.Name = "cbxCustomerPOS";
            this.cbxCustomerPOS.Size = new System.Drawing.Size(151, 21);
            this.cbxCustomerPOS.TabIndex = 33;
            // 
            // colIdCutting
            // 
            this.colIdCutting.HeaderText = "IdCutting";
            this.colIdCutting.Name = "colIdCutting";
            this.colIdCutting.Visible = false;
            // 
            // colIsCuttingPosting
            // 
            this.colIsCuttingPosting.HeaderText = "Posting";
            this.colIsCuttingPosting.Name = "colIsCuttingPosting";
            this.colIsCuttingPosting.Visible = false;
            // 
            // colCuttingIdItem
            // 
            this.colCuttingIdItem.HeaderText = "IdItem";
            this.colCuttingIdItem.Name = "colCuttingIdItem";
            this.colCuttingIdItem.Visible = false;
            // 
            // colCuttingIdVoucher
            // 
            this.colCuttingIdVoucher.HeaderText = "IdVoucher";
            this.colCuttingIdVoucher.Name = "colCuttingIdVoucher";
            this.colCuttingIdVoucher.Visible = false;
            // 
            // colCuttingAccountNo
            // 
            this.colCuttingAccountNo.HeaderText = "AccountNo";
            this.colCuttingAccountNo.Name = "colCuttingAccountNo";
            this.colCuttingAccountNo.Visible = false;
            // 
            // colCuttingAccountType
            // 
            this.colCuttingAccountType.HeaderText = "AccountTyp";
            this.colCuttingAccountType.Name = "colCuttingAccountType";
            this.colCuttingAccountType.Visible = false;
            // 
            // colCuttingDate
            // 
            this.colCuttingDate.HeaderText = "Cutting Date";
            this.colCuttingDate.Name = "colCuttingDate";
            this.colCuttingDate.Width = 85;
            // 
            // colCuttingVendorName
            // 
            this.colCuttingVendorName.HeaderText = "Vendor Name";
            this.colCuttingVendorName.Name = "colCuttingVendorName";
            this.colCuttingVendorName.Width = 120;
            // 
            // colCuttingClotheName
            // 
            this.colCuttingClotheName.HeaderText = "Cutting Clothe";
            this.colCuttingClotheName.Name = "colCuttingClotheName";
            this.colCuttingClotheName.Width = 120;
            // 
            // colCuttingColors
            // 
            this.colCuttingColors.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colCuttingColors.HeaderText = "Colors";
            this.colCuttingColors.Name = "colCuttingColors";
            this.colCuttingColors.Width = 85;
            // 
            // colCuttingSizes
            // 
            this.colCuttingSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colCuttingSizes.HeaderText = "Sizes";
            this.colCuttingSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colCuttingSizes.Name = "colCuttingSizes";
            this.colCuttingSizes.Width = 85;
            // 
            // colCuttingType
            // 
            this.colCuttingType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colCuttingType.HeaderText = "Type";
            this.colCuttingType.Items.AddRange(new object[] {
            "",
            "Cover All",
            "Pant & Shirt"});
            this.colCuttingType.Name = "colCuttingType";
            this.colCuttingType.Width = 90;
            // 
            // colCuttingClotheQuality
            // 
            this.colCuttingClotheQuality.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colCuttingClotheQuality.HeaderText = "Quality";
            this.colCuttingClotheQuality.Items.AddRange(new object[] {
            "",
            "Fresh",
            "Cut Pieces",
            "B Grade"});
            this.colCuttingClotheQuality.Name = "colCuttingClotheQuality";
            this.colCuttingClotheQuality.Width = 90;
            // 
            // colCuttingQty
            // 
            this.colCuttingQty.HeaderText = "Qty";
            this.colCuttingQty.Name = "colCuttingQty";
            this.colCuttingQty.Width = 90;
            // 
            // colCuttingMeters
            // 
            this.colCuttingMeters.HeaderText = "Meters";
            this.colCuttingMeters.Name = "colCuttingMeters";
            this.colCuttingMeters.Width = 85;
            // 
            // colCuttingRate
            // 
            this.colCuttingRate.HeaderText = "Rate";
            this.colCuttingRate.Name = "colCuttingRate";
            this.colCuttingRate.Width = 90;
            // 
            // colCuttingAmount
            // 
            this.colCuttingAmount.HeaderText = "Amount";
            this.colCuttingAmount.Name = "colCuttingAmount";
            this.colCuttingAmount.Width = 90;
            // 
            // colCuttingDelete
            // 
            this.colCuttingDelete.HeaderText = "Delete";
            this.colCuttingDelete.Name = "colCuttingDelete";
            this.colCuttingDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCuttingDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCuttingDelete.Width = 90;
            // 
            // colCuttingPosting
            // 
            this.colCuttingPosting.HeaderText = "...";
            this.colCuttingPosting.Name = "colCuttingPosting";
            this.colCuttingPosting.Text = "Posting";
            this.colCuttingPosting.Width = 90;
            // 
            // colIdStitching
            // 
            this.colIdStitching.HeaderText = "IdStitching";
            this.colIdStitching.Name = "colIdStitching";
            this.colIdStitching.Visible = false;
            // 
            // colIsStitchingPosting
            // 
            this.colIsStitchingPosting.HeaderText = "Posting";
            this.colIsStitchingPosting.Name = "colIsStitchingPosting";
            this.colIsStitchingPosting.Visible = false;
            // 
            // colStitchingIdVoucher
            // 
            this.colStitchingIdVoucher.HeaderText = "IdVoucher";
            this.colStitchingIdVoucher.Name = "colStitchingIdVoucher";
            this.colStitchingIdVoucher.Visible = false;
            // 
            // colStitchingAccountNo
            // 
            this.colStitchingAccountNo.HeaderText = "AccountNo";
            this.colStitchingAccountNo.Name = "colStitchingAccountNo";
            this.colStitchingAccountNo.Visible = false;
            // 
            // colStitchingAccountType
            // 
            this.colStitchingAccountType.HeaderText = "AccountType";
            this.colStitchingAccountType.Name = "colStitchingAccountType";
            this.colStitchingAccountType.Visible = false;
            // 
            // colStitchingDate
            // 
            this.colStitchingDate.FillWeight = 85F;
            this.colStitchingDate.HeaderText = "Stitching Date";
            this.colStitchingDate.Name = "colStitchingDate";
            this.colStitchingDate.Width = 85;
            // 
            // colStitchingVendorName
            // 
            this.colStitchingVendorName.HeaderText = "Vendor Name";
            this.colStitchingVendorName.Name = "colStitchingVendorName";
            this.colStitchingVendorName.Width = 160;
            // 
            // colStitchingDescription
            // 
            this.colStitchingDescription.HeaderText = "Description";
            this.colStitchingDescription.Name = "colStitchingDescription";
            this.colStitchingDescription.Width = 180;
            // 
            // colStitchingSizes
            // 
            this.colStitchingSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colStitchingSizes.HeaderText = "Sizes";
            this.colStitchingSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colStitchingSizes.Name = "colStitchingSizes";
            // 
            // colStitchingType
            // 
            this.colStitchingType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colStitchingType.HeaderText = "Type";
            this.colStitchingType.Items.AddRange(new object[] {
            "",
            "Cover All",
            "Pant & Shirt"});
            this.colStitchingType.Name = "colStitchingType";
            // 
            // colStitchingQuantity
            // 
            this.colStitchingQuantity.HeaderText = "Quantity";
            this.colStitchingQuantity.Name = "colStitchingQuantity";
            this.colStitchingQuantity.Width = 85;
            // 
            // colStitchingRate
            // 
            this.colStitchingRate.HeaderText = "Rate";
            this.colStitchingRate.Name = "colStitchingRate";
            this.colStitchingRate.Width = 85;
            // 
            // colStitchingAmount
            // 
            this.colStitchingAmount.HeaderText = "Amount";
            this.colStitchingAmount.Name = "colStitchingAmount";
            this.colStitchingAmount.Width = 90;
            // 
            // colStitchingDelete
            // 
            this.colStitchingDelete.HeaderText = "Delete";
            this.colStitchingDelete.Name = "colStitchingDelete";
            this.colStitchingDelete.Width = 85;
            // 
            // colStitchingPost
            // 
            this.colStitchingPost.HeaderText = "Posting";
            this.colStitchingPost.Name = "colStitchingPost";
            this.colStitchingPost.Width = 85;
            // 
            // colIdFeedo
            // 
            this.colIdFeedo.HeaderText = "IdFeedoSaftey";
            this.colIdFeedo.Name = "colIdFeedo";
            this.colIdFeedo.Visible = false;
            // 
            // colIsFeedoPosting
            // 
            this.colIsFeedoPosting.HeaderText = "Posting";
            this.colIsFeedoPosting.Name = "colIsFeedoPosting";
            this.colIsFeedoPosting.Visible = false;
            // 
            // colFeedoIdVoucher
            // 
            this.colFeedoIdVoucher.HeaderText = "IdVoucher";
            this.colFeedoIdVoucher.Name = "colFeedoIdVoucher";
            this.colFeedoIdVoucher.Visible = false;
            // 
            // colFeedoAccountNo
            // 
            this.colFeedoAccountNo.HeaderText = "AccountNo";
            this.colFeedoAccountNo.Name = "colFeedoAccountNo";
            this.colFeedoAccountNo.Visible = false;
            // 
            // colFeedoAccountType
            // 
            this.colFeedoAccountType.HeaderText = "AccountType";
            this.colFeedoAccountType.Name = "colFeedoAccountType";
            this.colFeedoAccountType.Visible = false;
            // 
            // colFeedoDate
            // 
            this.colFeedoDate.HeaderText = "Work Date";
            this.colFeedoDate.Name = "colFeedoDate";
            this.colFeedoDate.Width = 110;
            // 
            // colFeedoVendorName
            // 
            this.colFeedoVendorName.HeaderText = "Vendor Name";
            this.colFeedoVendorName.Name = "colFeedoVendorName";
            this.colFeedoVendorName.Width = 180;
            // 
            // colFeedoWorkType
            // 
            this.colFeedoWorkType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colFeedoWorkType.HeaderText = "WorkType";
            this.colFeedoWorkType.Items.AddRange(new object[] {
            "",
            "Feedo",
            "Saftey"});
            this.colFeedoWorkType.Name = "colFeedoWorkType";
            // 
            // colFeedoBrandType
            // 
            this.colFeedoBrandType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colFeedoBrandType.HeaderText = "Type";
            this.colFeedoBrandType.Items.AddRange(new object[] {
            "",
            "Cover All",
            "Pant & Shirt"});
            this.colFeedoBrandType.Name = "colFeedoBrandType";
            this.colFeedoBrandType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFeedoBrandType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colFeedoSizes
            // 
            this.colFeedoSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colFeedoSizes.HeaderText = "Feedo Sizes";
            this.colFeedoSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colFeedoSizes.Name = "colFeedoSizes";
            this.colFeedoSizes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFeedoSizes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colFeedoQuantity
            // 
            this.colFeedoQuantity.HeaderText = "Quantity";
            this.colFeedoQuantity.Name = "colFeedoQuantity";
            // 
            // colFeedoRate
            // 
            this.colFeedoRate.HeaderText = "Rate";
            this.colFeedoRate.Name = "colFeedoRate";
            this.colFeedoRate.Width = 90;
            // 
            // colFeedoAmount
            // 
            this.colFeedoAmount.HeaderText = "Amount";
            this.colFeedoAmount.Name = "colFeedoAmount";
            // 
            // colFeedoDelete
            // 
            this.colFeedoDelete.HeaderText = "Delete";
            this.colFeedoDelete.Name = "colFeedoDelete";
            this.colFeedoDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFeedoDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colFeedoPosting
            // 
            this.colFeedoPosting.HeaderText = "Posting";
            this.colFeedoPosting.Name = "colFeedoPosting";
            // 
            // colIdBartake
            // 
            this.colIdBartake.HeaderText = "Id Bartake";
            this.colIdBartake.Name = "colIdBartake";
            this.colIdBartake.Visible = false;
            // 
            // colBartakeIdItem
            // 
            this.colBartakeIdItem.HeaderText = "IdItem";
            this.colBartakeIdItem.Name = "colBartakeIdItem";
            this.colBartakeIdItem.Visible = false;
            // 
            // colIsBartakePosting
            // 
            this.colIsBartakePosting.HeaderText = "Posting";
            this.colIsBartakePosting.Name = "colIsBartakePosting";
            this.colIsBartakePosting.Visible = false;
            // 
            // colBartakeIdVoucher
            // 
            this.colBartakeIdVoucher.HeaderText = "IdVoucher";
            this.colBartakeIdVoucher.Name = "colBartakeIdVoucher";
            this.colBartakeIdVoucher.Visible = false;
            // 
            // colBartakeAccountNo
            // 
            this.colBartakeAccountNo.HeaderText = "AccountNo";
            this.colBartakeAccountNo.Name = "colBartakeAccountNo";
            this.colBartakeAccountNo.Visible = false;
            // 
            // colBartakeAccountType
            // 
            this.colBartakeAccountType.HeaderText = "AccountType";
            this.colBartakeAccountType.Name = "colBartakeAccountType";
            this.colBartakeAccountType.Visible = false;
            // 
            // colBartakeDate
            // 
            this.colBartakeDate.HeaderText = "Work Date";
            this.colBartakeDate.Name = "colBartakeDate";
            // 
            // colBartakeVendorName
            // 
            this.colBartakeVendorName.HeaderText = "Vendor Name";
            this.colBartakeVendorName.Name = "colBartakeVendorName";
            this.colBartakeVendorName.Width = 150;
            // 
            // colBartakeFinishedGoods
            // 
            this.colBartakeFinishedGoods.HeaderText = "Finished Good";
            this.colBartakeFinishedGoods.Name = "colBartakeFinishedGoods";
            this.colBartakeFinishedGoods.Width = 130;
            // 
            // colBartakeWorkType
            // 
            this.colBartakeWorkType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colBartakeWorkType.HeaderText = "Work Type";
            this.colBartakeWorkType.Items.AddRange(new object[] {
            "",
            "Bartake",
            "Kaaj",
            "Buttons"});
            this.colBartakeWorkType.Name = "colBartakeWorkType";
            // 
            // colBartakeOrderType
            // 
            this.colBartakeOrderType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colBartakeOrderType.HeaderText = "Order Type";
            this.colBartakeOrderType.Items.AddRange(new object[] {
            "",
            "Cover All",
            "Pant & Shirt"});
            this.colBartakeOrderType.Name = "colBartakeOrderType";
            this.colBartakeOrderType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBartakeOrderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colBartakeSizes
            // 
            this.colBartakeSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colBartakeSizes.HeaderText = "Sizes";
            this.colBartakeSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colBartakeSizes.Name = "colBartakeSizes";
            // 
            // colBartakeQuantity
            // 
            this.colBartakeQuantity.HeaderText = "Quantity";
            this.colBartakeQuantity.Name = "colBartakeQuantity";
            this.colBartakeQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBartakeQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBartakeRates
            // 
            this.colBartakeRates.HeaderText = "Rates";
            this.colBartakeRates.Name = "colBartakeRates";
            this.colBartakeRates.Width = 90;
            // 
            // colBartakeAmount
            // 
            this.colBartakeAmount.HeaderText = "Amount";
            this.colBartakeAmount.Name = "colBartakeAmount";
            // 
            // colBartakeDelete
            // 
            this.colBartakeDelete.HeaderText = "Delete...";
            this.colBartakeDelete.Name = "colBartakeDelete";
            // 
            // colBartakePosting
            // 
            this.colBartakePosting.HeaderText = "Posting";
            this.colBartakePosting.Name = "colBartakePosting";
            // 
            // colIdThreading
            // 
            this.colIdThreading.HeaderText = "Id Threading";
            this.colIdThreading.Name = "colIdThreading";
            this.colIdThreading.Visible = false;
            // 
            // colThreadingIsPosting
            // 
            this.colThreadingIsPosting.HeaderText = "Posting";
            this.colThreadingIsPosting.Name = "colThreadingIsPosting";
            this.colThreadingIsPosting.Visible = false;
            // 
            // colThreadingIdVoucher
            // 
            this.colThreadingIdVoucher.HeaderText = "IdVoucher";
            this.colThreadingIdVoucher.Name = "colThreadingIdVoucher";
            this.colThreadingIdVoucher.Visible = false;
            // 
            // colThreadingAccountNo
            // 
            this.colThreadingAccountNo.HeaderText = "AccountNo";
            this.colThreadingAccountNo.Name = "colThreadingAccountNo";
            this.colThreadingAccountNo.Visible = false;
            // 
            // colThreadingAccountType
            // 
            this.colThreadingAccountType.HeaderText = "AccountType";
            this.colThreadingAccountType.Name = "colThreadingAccountType";
            this.colThreadingAccountType.Visible = false;
            // 
            // colThreadingWorkDate
            // 
            this.colThreadingWorkDate.HeaderText = "Work Date";
            this.colThreadingWorkDate.Name = "colThreadingWorkDate";
            // 
            // colThreadingVendorName
            // 
            this.colThreadingVendorName.HeaderText = "Vendor Name";
            this.colThreadingVendorName.Name = "colThreadingVendorName";
            this.colThreadingVendorName.Width = 180;
            // 
            // colThreadingOrderType
            // 
            this.colThreadingOrderType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colThreadingOrderType.HeaderText = "Order Type";
            this.colThreadingOrderType.Items.AddRange(new object[] {
            "",
            "Cover All",
            "Pant & Shirt"});
            this.colThreadingOrderType.Name = "colThreadingOrderType";
            this.colThreadingOrderType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colThreadingOrderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colThreadingSizes
            // 
            this.colThreadingSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colThreadingSizes.HeaderText = "Sizes";
            this.colThreadingSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colThreadingSizes.Name = "colThreadingSizes";
            // 
            // colThreadingQuantity
            // 
            this.colThreadingQuantity.HeaderText = "Quantity";
            this.colThreadingQuantity.Name = "colThreadingQuantity";
            this.colThreadingQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colThreadingQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colThreadingRate
            // 
            this.colThreadingRate.HeaderText = "Rates";
            this.colThreadingRate.Name = "colThreadingRate";
            this.colThreadingRate.Width = 90;
            // 
            // colThreadingAmount
            // 
            this.colThreadingAmount.HeaderText = "Amount";
            this.colThreadingAmount.Name = "colThreadingAmount";
            // 
            // colThreadingDelete
            // 
            this.colThreadingDelete.HeaderText = "Delete...";
            this.colThreadingDelete.Name = "colThreadingDelete";
            // 
            // colThreadingPosting
            // 
            this.colThreadingPosting.HeaderText = "Posting";
            this.colThreadingPosting.Name = "colThreadingPosting";
            // 
            // colIdIspection
            // 
            this.colIdIspection.HeaderText = "Id Inspection";
            this.colIdIspection.Name = "colIdIspection";
            this.colIdIspection.Visible = false;
            // 
            // colInspectionIsPosting
            // 
            this.colInspectionIsPosting.HeaderText = "Posting";
            this.colInspectionIsPosting.Name = "colInspectionIsPosting";
            this.colInspectionIsPosting.Visible = false;
            // 
            // colInspectionIdVoucher
            // 
            this.colInspectionIdVoucher.HeaderText = "IdVoucher";
            this.colInspectionIdVoucher.Name = "colInspectionIdVoucher";
            this.colInspectionIdVoucher.Visible = false;
            // 
            // colInspectionAccountNo
            // 
            this.colInspectionAccountNo.HeaderText = "AccountNo";
            this.colInspectionAccountNo.Name = "colInspectionAccountNo";
            this.colInspectionAccountNo.Visible = false;
            // 
            // colInspectionAccountType
            // 
            this.colInspectionAccountType.HeaderText = "AccountType";
            this.colInspectionAccountType.Name = "colInspectionAccountType";
            this.colInspectionAccountType.Visible = false;
            // 
            // colInspectionWorkingDate
            // 
            this.colInspectionWorkingDate.HeaderText = "Work Date";
            this.colInspectionWorkingDate.Name = "colInspectionWorkingDate";
            // 
            // colInspectionVendorName
            // 
            this.colInspectionVendorName.HeaderText = "Vendor Name";
            this.colInspectionVendorName.Name = "colInspectionVendorName";
            this.colInspectionVendorName.Width = 180;
            // 
            // colInspectionOrderType
            // 
            this.colInspectionOrderType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colInspectionOrderType.HeaderText = "Order Type";
            this.colInspectionOrderType.Items.AddRange(new object[] {
            "",
            "Cover All",
            "Pant & Shirt"});
            this.colInspectionOrderType.Name = "colInspectionOrderType";
            this.colInspectionOrderType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInspectionOrderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colInspectionSizes
            // 
            this.colInspectionSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colInspectionSizes.HeaderText = "Sizes";
            this.colInspectionSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colInspectionSizes.Name = "colInspectionSizes";
            // 
            // colInspectionQuantity
            // 
            this.colInspectionQuantity.HeaderText = "Quantity";
            this.colInspectionQuantity.Name = "colInspectionQuantity";
            this.colInspectionQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInspectionQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colInspectionPassQuantity
            // 
            this.colInspectionPassQuantity.HeaderText = "Ready For Press";
            this.colInspectionPassQuantity.Name = "colInspectionPassQuantity";
            // 
            // colInspectionRejectedQuantity
            // 
            this.colInspectionRejectedQuantity.HeaderText = "Rejection";
            this.colInspectionRejectedQuantity.Name = "colInspectionRejectedQuantity";
            // 
            // colInspectionRate
            // 
            this.colInspectionRate.HeaderText = "Rates";
            this.colInspectionRate.Name = "colInspectionRate";
            this.colInspectionRate.Width = 90;
            // 
            // colInspectionAmount
            // 
            this.colInspectionAmount.HeaderText = "Amount";
            this.colInspectionAmount.Name = "colInspectionAmount";
            // 
            // colInspectionDelete
            // 
            this.colInspectionDelete.HeaderText = "Delete...";
            this.colInspectionDelete.Name = "colInspectionDelete";
            // 
            // colInspectionPosting
            // 
            this.colInspectionPosting.HeaderText = "Posting";
            this.colInspectionPosting.Name = "colInspectionPosting";
            // 
            // colIdPress
            // 
            this.colIdPress.HeaderText = "Id Press";
            this.colIdPress.Name = "colIdPress";
            this.colIdPress.Visible = false;
            // 
            // colPressIsPosting
            // 
            this.colPressIsPosting.HeaderText = "Posting";
            this.colPressIsPosting.Name = "colPressIsPosting";
            this.colPressIsPosting.Visible = false;
            // 
            // colPressIdVoucher
            // 
            this.colPressIdVoucher.HeaderText = "IdVoucher";
            this.colPressIdVoucher.Name = "colPressIdVoucher";
            this.colPressIdVoucher.Visible = false;
            // 
            // colPressAccountNo
            // 
            this.colPressAccountNo.HeaderText = "AccountNo";
            this.colPressAccountNo.Name = "colPressAccountNo";
            this.colPressAccountNo.Visible = false;
            // 
            // colPressAccountType
            // 
            this.colPressAccountType.HeaderText = "AccountType";
            this.colPressAccountType.Name = "colPressAccountType";
            this.colPressAccountType.Visible = false;
            // 
            // colPressWorkDate
            // 
            this.colPressWorkDate.HeaderText = "Work Date";
            this.colPressWorkDate.Name = "colPressWorkDate";
            // 
            // colPressVendorName
            // 
            this.colPressVendorName.HeaderText = "Vendor Name";
            this.colPressVendorName.Name = "colPressVendorName";
            this.colPressVendorName.Width = 180;
            // 
            // colPressOrderType
            // 
            this.colPressOrderType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPressOrderType.HeaderText = "Order Type";
            this.colPressOrderType.Items.AddRange(new object[] {
            "",
            "Cover All",
            "Pant & Shirt"});
            this.colPressOrderType.Name = "colPressOrderType";
            this.colPressOrderType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPressOrderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPressSizes
            // 
            this.colPressSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPressSizes.HeaderText = "Sizes";
            this.colPressSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colPressSizes.Name = "colPressSizes";
            // 
            // colPressQuantity
            // 
            this.colPressQuantity.HeaderText = "Quantity";
            this.colPressQuantity.Name = "colPressQuantity";
            this.colPressQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPressQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPressReadyUnits
            // 
            this.colPressReadyUnits.HeaderText = "Ready For Packing";
            this.colPressReadyUnits.Name = "colPressReadyUnits";
            this.colPressReadyUnits.Width = 120;
            // 
            // colPressRejection
            // 
            this.colPressRejection.HeaderText = "Rejection";
            this.colPressRejection.Name = "colPressRejection";
            // 
            // colPressRates
            // 
            this.colPressRates.HeaderText = "Rates";
            this.colPressRates.Name = "colPressRates";
            this.colPressRates.Width = 90;
            // 
            // colPressAmount
            // 
            this.colPressAmount.HeaderText = "Amount";
            this.colPressAmount.Name = "colPressAmount";
            // 
            // colPressDelete
            // 
            this.colPressDelete.HeaderText = "Delete...";
            this.colPressDelete.Name = "colPressDelete";
            // 
            // colPressPosting
            // 
            this.colPressPosting.HeaderText = "Posting";
            this.colPressPosting.Name = "colPressPosting";
            // 
            // colIdPacking
            // 
            this.colIdPacking.HeaderText = "Id Packing";
            this.colIdPacking.Name = "colIdPacking";
            this.colIdPacking.Visible = false;
            // 
            // colPackingIdItem
            // 
            this.colPackingIdItem.HeaderText = "IdItem";
            this.colPackingIdItem.Name = "colPackingIdItem";
            this.colPackingIdItem.Visible = false;
            // 
            // colPackingIsPosting
            // 
            this.colPackingIsPosting.HeaderText = "Posting";
            this.colPackingIsPosting.Name = "colPackingIsPosting";
            this.colPackingIsPosting.Visible = false;
            // 
            // colPackingIdVoucher
            // 
            this.colPackingIdVoucher.HeaderText = "IdVoucher";
            this.colPackingIdVoucher.Name = "colPackingIdVoucher";
            this.colPackingIdVoucher.Visible = false;
            // 
            // colPackingAccountNo
            // 
            this.colPackingAccountNo.HeaderText = "AccountNo";
            this.colPackingAccountNo.Name = "colPackingAccountNo";
            this.colPackingAccountNo.Visible = false;
            // 
            // colPackingAccountType
            // 
            this.colPackingAccountType.HeaderText = "AccountType";
            this.colPackingAccountType.Name = "colPackingAccountType";
            this.colPackingAccountType.Visible = false;
            // 
            // colPackingWorkDate
            // 
            this.colPackingWorkDate.HeaderText = "Work Date";
            this.colPackingWorkDate.Name = "colPackingWorkDate";
            // 
            // colPackingVendorName
            // 
            this.colPackingVendorName.HeaderText = "Vendor Name";
            this.colPackingVendorName.Name = "colPackingVendorName";
            this.colPackingVendorName.Width = 180;
            // 
            // colPackingArticleName
            // 
            this.colPackingArticleName.HeaderText = "Article Name";
            this.colPackingArticleName.Name = "colPackingArticleName";
            this.colPackingArticleName.Width = 150;
            // 
            // colPackingOrderType
            // 
            this.colPackingOrderType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPackingOrderType.HeaderText = "Order Type";
            this.colPackingOrderType.Items.AddRange(new object[] {
            "",
            "Cover All",
            "Pant & Shirt"});
            this.colPackingOrderType.Name = "colPackingOrderType";
            this.colPackingOrderType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackingOrderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPackingSizes
            // 
            this.colPackingSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPackingSizes.HeaderText = "Sizes";
            this.colPackingSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colPackingSizes.Name = "colPackingSizes";
            // 
            // colPackingQuantity
            // 
            this.colPackingQuantity.HeaderText = "Quantity";
            this.colPackingQuantity.Name = "colPackingQuantity";
            this.colPackingQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackingQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPackingRates
            // 
            this.colPackingRates.HeaderText = "Rates";
            this.colPackingRates.Name = "colPackingRates";
            this.colPackingRates.Width = 90;
            // 
            // colPackingAmount
            // 
            this.colPackingAmount.HeaderText = "Amount";
            this.colPackingAmount.Name = "colPackingAmount";
            // 
            // colPackingDelete
            // 
            this.colPackingDelete.HeaderText = "Delete...";
            this.colPackingDelete.Name = "colPackingDelete";
            // 
            // colPackingPosting
            // 
            this.colPackingPosting.HeaderText = "Posting";
            this.colPackingPosting.Name = "colPackingPosting";
            // 
            // frmGarmentProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 757);
            this.Controls.Add(this.cbxCustomerPOS);
            this.Controls.Add(this.ProductionTab);
            this.Controls.Add(this.ProductionDate);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.VEditBox);
            this.Controls.Add(this.lblVoucherNo);
            this.Controls.Add(this.lblDate);
            this.DisplayHeader = false;
            this.Name = "frmGarmentProduction";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "frmMainTannery";
            this.Load += new System.EventHandler(this.frmGarmentProduction_Load);
            this.ProductionTab.ResumeLayout(false);
            this.mTabCutting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCutting)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCuttingMaterialUsed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCuttingWastage)).EndInit();
            this.mTabStitching.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStitching)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStitchingMaterials)).EndInit();
            this.mTabFedo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFeedoSaftey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeedoMaterials)).EndInit();
            this.mTabBarTake.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBartake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBartakeMaterials)).EndInit();
            this.mTabThread.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdThreading)).EndInit();
            this.mTabInspection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInspection)).EndInit();
            this.mTabPress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPress)).EndInit();
            this.mTabPacking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPacking)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPackingMaterials)).EndInit();
            this.mTabExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMiscCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime ProductionDate;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroTabControl ProductionTab;
        private MetroFramework.Controls.MetroTabPage mTabCutting;
        private MetroFramework.Controls.MetroTabPage mTabStitching;
        private MetroFramework.Controls.MetroTabPage mTabFedo;
        private MetroFramework.Controls.MetroTabPage mTabBarTake;
        private TabDataGrid grdCutting;
        private TabDataGrid grdStitching;
        private TabDataGrid grdFeedoSaftey;
        private TabDataGrid grdBartake;
        private MetroFramework.Controls.MetroTile btnCuttingSave;
        private MetroFramework.Controls.MetroTile btnCuttingClose;
        private MetroFramework.Controls.MetroTile btnStitchingSave;
        private MetroFramework.Controls.MetroTile btnSplittingClose;
        private MetroFramework.Controls.MetroTile btnFeedoSave;
        private MetroFramework.Controls.MetroTile btnRetrimmingClose;
        private MetroFramework.Controls.MetroTile btnBartakeSave;
        private MetroFramework.Controls.MetroTile btnShavingClose;
        private MetroFramework.Controls.MetroTabPage mTabThread;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private TabDataGrid grdThreading;
        private MetroFramework.Controls.MetroTabPage mTabInspection;
        private TabDataGrid grdInspection;
        private MetroFramework.Controls.MetroTabPage mTabPress;
        private MetroFramework.Controls.MetroTabPage mTabPacking;
        private TabDataGrid grdPacking;
        private TabDataGrid grdPress;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingDate;
        private TabDataGrid grdCuttingMaterialUsed;
        private TabDataGrid grdStitchingMaterials;
        private TabDataGrid grdFeedoMaterials;
        private TabDataGrid grdBartakeMaterials;
        private TabDataGrid grdPackingMaterials;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingDate;
        private MetroFramework.Controls.MetroTabPage mTabExpenses;
        private TabDataGrid grdMiscCost;
        private TabDataGrid grdCuttingWastage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingIdWastage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingWastageIdItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingWastageDate;
        private CalendarColumn colCuttingWastageDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingWastageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingWastageUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingWastageQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colCuttingWastageDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroTile btnPackingSave;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile btnOverHeadsSave;
        private MetroFramework.Controls.MetroTile metroTile4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingIdMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingMaterialIdItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingMaterialDate;
        private CalendarColumn colCuttingMaterialDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingMaterialUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingMaterialUsedQty;
        private System.Windows.Forms.DataGridViewButtonColumn colCuttingMaterialDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingIdMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingMaterialIdItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingMaterialDate;
        private CalendarColumn colStitchingMaterialDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingMaterialUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingMaterialDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingMaterialQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colStitchingMaterialDelete;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDetailCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colCostDate;
        private CalendarColumn colCostDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewButtonColumn colCostDelete;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeDate;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingWorkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoIdMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoMaterialIdItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoMaterialDate;
        private CalendarColumn colFeedoMaterialDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoMaterialUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoMaterialDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoMaterialUsedQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colFeedoMaterialDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeIdMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeMaterialIdItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeMaterialDate;
        private CalendarColumn colBartakeMaterialDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeMaterialUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeMaterialDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeMaterialQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colBartakeMaterialDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingIdMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingMaterialIdItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colPackingMaterialDate;
        private CalendarColumn colPackingMaterialDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingMaterialUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingMaterialDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingMaterialQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colPackingMaterialDelete;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoDate;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionWorkingDate;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colPackingWorkDate;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colPressWorkDate;
        private System.Windows.Forms.ComboBox cbxCustomerPOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCutting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsCuttingPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingAccountType;
        private CalendarColumn colCuttingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingClotheName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCuttingColors;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCuttingSizes;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCuttingType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCuttingClotheQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingMeters;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colCuttingDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colCuttingPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdStitching;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsStitchingPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingAccountType;
        private CalendarColumn colStitchingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStitchingSizes;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStitchingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStitchingAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colStitchingDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colStitchingPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdFeedo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsFeedoPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoAccountType;
        private CalendarColumn colFeedoDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoVendorName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFeedoWorkType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFeedoBrandType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFeedoSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedoAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colFeedoDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colFeedoPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdBartake;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsBartakePosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeAccountType;
        private CalendarColumn colBartakeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeFinishedGoods;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBartakeWorkType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBartakeOrderType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBartakeSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeRates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBartakeAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colBartakeDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colBartakePosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdThreading;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingIsPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingAccountType;
        private CalendarColumn colThreadingWorkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingVendorName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colThreadingOrderType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colThreadingSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadingAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colThreadingDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colThreadingPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdIspection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionIsPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionAccountType;
        private CalendarColumn colInspectionWorkingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionVendorName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInspectionOrderType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInspectionSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionPassQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRejectedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colInspectionDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colInspectionPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressIsPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressAccountType;
        private CalendarColumn colPressWorkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressVendorName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPressOrderType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPressSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressReadyUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressRejection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressRates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPressAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colPressDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colPressPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingIsPosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingAccountType;
        private CalendarColumn colPackingWorkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingArticleName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackingOrderType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackingSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingRates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colPackingDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colPackingPosting;
    }
}