namespace Accounts.UI
{
    partial class frmProcessWiseCosting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbxProductionType = new MetroFramework.Controls.MetroComboBox();
            this.lblDepartment = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkApplyDateFilter = new MetroFramework.Controls.MetroCheckBox();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.pnlDate = new MetroFramework.Controls.MetroPanel();
            this.EndDate = new MetroFramework.Controls.MetroDateTime();
            this.btnLoadbyFilter = new MetroFramework.Controls.MetroButton();
            this.StartDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.grdMaterialsInput = new System.Windows.Forms.DataGridView();
            this.grpMaterials = new System.Windows.Forms.GroupBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtSearchIssuedMaterials = new MetroFramework.Controls.MetroTextBox();
            this.grpLabourCosting = new System.Windows.Forms.GroupBox();
            this.grdOutPut = new System.Windows.Forms.DataGridView();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtSearchLabour = new MetroFramework.Controls.MetroTextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutPutItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutPutUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutPutTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialsCosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterialsInput)).BeginInit();
            this.grpMaterials.SuspendLayout();
            this.grpLabourCosting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutPut)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxProductionType
            // 
            this.cbxProductionType.FormattingEnabled = true;
            this.cbxProductionType.ItemHeight = 23;
            this.cbxProductionType.Location = new System.Drawing.Point(147, 77);
            this.cbxProductionType.Name = "cbxProductionType";
            this.cbxProductionType.Size = new System.Drawing.Size(207, 29);
            this.cbxProductionType.TabIndex = 30;
            this.cbxProductionType.UseSelectable = true;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDepartment.Location = new System.Drawing.Point(26, 78);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(116, 19);
            this.lblDepartment.TabIndex = 31;
            this.lblDepartment.Text = "Production Type :";
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(14, 51);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(997, 23);
            this.metroLabel2.TabIndex = 32;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "---";
            // 
            // chkApplyDateFilter
            // 
            this.chkApplyDateFilter.AutoSize = true;
            this.chkApplyDateFilter.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkApplyDateFilter.Location = new System.Drawing.Point(460, 84);
            this.chkApplyDateFilter.Name = "chkApplyDateFilter";
            this.chkApplyDateFilter.Size = new System.Drawing.Size(127, 19);
            this.chkApplyDateFilter.TabIndex = 36;
            this.chkApplyDateFilter.Text = "Apply Date Filter";
            this.chkApplyDateFilter.UseSelectable = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(364, 80);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 23);
            this.btnLoad.TabIndex = 35;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDate.Controls.Add(this.EndDate);
            this.pnlDate.Controls.Add(this.btnLoadbyFilter);
            this.pnlDate.Controls.Add(this.StartDate);
            this.pnlDate.Controls.Add(this.metroLabel4);
            this.pnlDate.Controls.Add(this.metroLabel5);
            this.pnlDate.Enabled = false;
            this.pnlDate.HorizontalScrollbarBarColor = true;
            this.pnlDate.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlDate.HorizontalScrollbarSize = 10;
            this.pnlDate.Location = new System.Drawing.Point(14, 134);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(999, 50);
            this.pnlDate.TabIndex = 38;
            this.pnlDate.VerticalScrollbarBarColor = true;
            this.pnlDate.VerticalScrollbarHighlightOnWheel = false;
            this.pnlDate.VerticalScrollbarSize = 10;
            // 
            // EndDate
            // 
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate.Location = new System.Drawing.Point(352, 9);
            this.EndDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(160, 29);
            this.EndDate.TabIndex = 15;
            // 
            // btnLoadbyFilter
            // 
            this.btnLoadbyFilter.Location = new System.Drawing.Point(524, 9);
            this.btnLoadbyFilter.Name = "btnLoadbyFilter";
            this.btnLoadbyFilter.Size = new System.Drawing.Size(137, 27);
            this.btnLoadbyFilter.TabIndex = 10;
            this.btnLoadbyFilter.Text = "Load By Date Filter";
            this.btnLoadbyFilter.UseSelectable = true;
            this.btnLoadbyFilter.Click += new System.EventHandler(this.btnLoadbyFilter_Click);
            // 
            // StartDate
            // 
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(103, 9);
            this.StartDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(150, 29);
            this.StartDate.TabIndex = 14;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(268, 13);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(74, 19);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "To Period :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(9, 13);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(88, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Start Period :";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(12, 113);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(1001, 23);
            this.metroLabel3.TabIndex = 37;
            this.metroLabel3.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "----";
            // 
            // grdMaterialsInput
            // 
            this.grdMaterialsInput.AllowUserToAddRows = false;
            this.grdMaterialsInput.AllowUserToDeleteRows = false;
            this.grdMaterialsInput.AllowUserToResizeColumns = false;
            this.grdMaterialsInput.AllowUserToResizeRows = false;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.Beige;
            this.grdMaterialsInput.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.grdMaterialsInput.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMaterialsInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.grdMaterialsInput.ColumnHeadersHeight = 26;
            this.grdMaterialsInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemName,
            this.colUnits,
            this.colMaterialsCosting});
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMaterialsInput.DefaultCellStyle = dataGridViewCellStyle37;
            this.grdMaterialsInput.EnableHeadersVisualStyles = false;
            this.grdMaterialsInput.Location = new System.Drawing.Point(23, 243);
            this.grdMaterialsInput.MultiSelect = false;
            this.grdMaterialsInput.Name = "grdMaterialsInput";
            this.grdMaterialsInput.ReadOnly = true;
            this.grdMaterialsInput.RowHeadersVisible = false;
            this.grdMaterialsInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdMaterialsInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdMaterialsInput.Size = new System.Drawing.Size(504, 362);
            this.grdMaterialsInput.TabIndex = 39;
            // 
            // grpMaterials
            // 
            this.grpMaterials.Controls.Add(this.metroLabel6);
            this.grpMaterials.Controls.Add(this.txtSearchIssuedMaterials);
            this.grpMaterials.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMaterials.Location = new System.Drawing.Point(14, 190);
            this.grpMaterials.Name = "grpMaterials";
            this.grpMaterials.Size = new System.Drawing.Size(526, 421);
            this.grpMaterials.TabIndex = 40;
            this.grpMaterials.TabStop = false;
            this.grpMaterials.Text = "Materials Costing";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(11, 25);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(116, 19);
            this.metroLabel6.TabIndex = 1;
            this.metroLabel6.Text = "Search Materials :";
            // 
            // txtSearchIssuedMaterials
            // 
            // 
            // 
            // 
            this.txtSearchIssuedMaterials.CustomButton.Image = null;
            this.txtSearchIssuedMaterials.CustomButton.Location = new System.Drawing.Point(254, 1);
            this.txtSearchIssuedMaterials.CustomButton.Name = "";
            this.txtSearchIssuedMaterials.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearchIssuedMaterials.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearchIssuedMaterials.CustomButton.TabIndex = 1;
            this.txtSearchIssuedMaterials.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearchIssuedMaterials.CustomButton.UseSelectable = true;
            this.txtSearchIssuedMaterials.CustomButton.Visible = false;
            this.txtSearchIssuedMaterials.Lines = new string[0];
            this.txtSearchIssuedMaterials.Location = new System.Drawing.Point(130, 24);
            this.txtSearchIssuedMaterials.MaxLength = 32767;
            this.txtSearchIssuedMaterials.Name = "txtSearchIssuedMaterials";
            this.txtSearchIssuedMaterials.PasswordChar = '\0';
            this.txtSearchIssuedMaterials.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearchIssuedMaterials.SelectedText = "";
            this.txtSearchIssuedMaterials.SelectionLength = 0;
            this.txtSearchIssuedMaterials.SelectionStart = 0;
            this.txtSearchIssuedMaterials.ShortcutsEnabled = true;
            this.txtSearchIssuedMaterials.Size = new System.Drawing.Size(276, 23);
            this.txtSearchIssuedMaterials.TabIndex = 0;
            this.txtSearchIssuedMaterials.UseSelectable = true;
            this.txtSearchIssuedMaterials.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearchIssuedMaterials.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearchIssuedMaterials.TextChanged += new System.EventHandler(this.txtSearchIssuedMaterials_TextChanged);
            // 
            // grpLabourCosting
            // 
            this.grpLabourCosting.Controls.Add(this.grdOutPut);
            this.grpLabourCosting.Controls.Add(this.metroLabel7);
            this.grpLabourCosting.Controls.Add(this.txtSearchLabour);
            this.grpLabourCosting.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLabourCosting.Location = new System.Drawing.Point(544, 190);
            this.grpLabourCosting.Name = "grpLabourCosting";
            this.grpLabourCosting.Size = new System.Drawing.Size(467, 421);
            this.grpLabourCosting.TabIndex = 40;
            this.grpLabourCosting.TabStop = false;
            this.grpLabourCosting.Text = "Labour Costing";
            // 
            // grdOutPut
            // 
            this.grdOutPut.AllowUserToAddRows = false;
            this.grdOutPut.AllowUserToDeleteRows = false;
            this.grdOutPut.AllowUserToResizeColumns = false;
            this.grdOutPut.AllowUserToResizeRows = false;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.BackColor = System.Drawing.Color.Beige;
            this.grdOutPut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle38;
            this.grdOutPut.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOutPut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.grdOutPut.ColumnHeadersHeight = 26;
            this.grdOutPut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOutPutItems,
            this.colOutPutUnits,
            this.colOutPutTotalAmount});
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOutPut.DefaultCellStyle = dataGridViewCellStyle42;
            this.grdOutPut.EnableHeadersVisualStyles = false;
            this.grdOutPut.Location = new System.Drawing.Point(17, 53);
            this.grdOutPut.MultiSelect = false;
            this.grdOutPut.Name = "grdOutPut";
            this.grdOutPut.ReadOnly = true;
            this.grdOutPut.RowHeadersVisible = false;
            this.grdOutPut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdOutPut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdOutPut.Size = new System.Drawing.Size(444, 362);
            this.grdOutPut.TabIndex = 39;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(16, 24);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(103, 19);
            this.metroLabel7.TabIndex = 1;
            this.metroLabel7.Text = "Search Labour :";
            // 
            // txtSearchLabour
            // 
            // 
            // 
            // 
            this.txtSearchLabour.CustomButton.Image = null;
            this.txtSearchLabour.CustomButton.Location = new System.Drawing.Point(254, 1);
            this.txtSearchLabour.CustomButton.Name = "";
            this.txtSearchLabour.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearchLabour.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearchLabour.CustomButton.TabIndex = 1;
            this.txtSearchLabour.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearchLabour.CustomButton.UseSelectable = true;
            this.txtSearchLabour.CustomButton.Visible = false;
            this.txtSearchLabour.Lines = new string[0];
            this.txtSearchLabour.Location = new System.Drawing.Point(120, 21);
            this.txtSearchLabour.MaxLength = 32767;
            this.txtSearchLabour.Name = "txtSearchLabour";
            this.txtSearchLabour.PasswordChar = '\0';
            this.txtSearchLabour.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearchLabour.SelectedText = "";
            this.txtSearchLabour.SelectionLength = 0;
            this.txtSearchLabour.SelectionStart = 0;
            this.txtSearchLabour.ShortcutsEnabled = true;
            this.txtSearchLabour.Size = new System.Drawing.Size(276, 23);
            this.txtSearchLabour.TabIndex = 0;
            this.txtSearchLabour.UseSelectable = true;
            this.txtSearchLabour.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearchLabour.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearchLabour.TextChanged += new System.EventHandler(this.txtSearchInputWork_TextChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle43.Format = "d";
            dataGridViewCellStyle43.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle43;
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ItemName";
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle44;
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Units";
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle45;
            this.dataGridViewTextBoxColumn3.HeaderText = "Units";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Date";
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle46.Format = "d";
            dataGridViewCellStyle46.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle46;
            this.dataGridViewTextBoxColumn5.HeaderText = "Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ItemName";
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle47;
            this.dataGridViewTextBoxColumn6.HeaderText = "Description";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Units";
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle48;
            this.dataGridViewTextBoxColumn7.HeaderText = "Units";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // colOutPutItems
            // 
            this.colOutPutItems.DataPropertyName = "ItemName";
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colOutPutItems.DefaultCellStyle = dataGridViewCellStyle40;
            this.colOutPutItems.HeaderText = "Description";
            this.colOutPutItems.Name = "colOutPutItems";
            this.colOutPutItems.ReadOnly = true;
            this.colOutPutItems.Width = 250;
            // 
            // colOutPutUnits
            // 
            this.colOutPutUnits.DataPropertyName = "Qty";
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colOutPutUnits.DefaultCellStyle = dataGridViewCellStyle41;
            this.colOutPutUnits.HeaderText = "Units";
            this.colOutPutUnits.Name = "colOutPutUnits";
            this.colOutPutUnits.ReadOnly = true;
            this.colOutPutUnits.Width = 80;
            // 
            // colOutPutTotalAmount
            // 
            this.colOutPutTotalAmount.DataPropertyName = "Amount";
            this.colOutPutTotalAmount.HeaderText = "Cost";
            this.colOutPutTotalAmount.Name = "colOutPutTotalAmount";
            this.colOutPutTotalAmount.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle35;
            this.colItemName.HeaderText = "Description";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 300;
            // 
            // colUnits
            // 
            this.colUnits.DataPropertyName = "Qty";
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUnits.DefaultCellStyle = dataGridViewCellStyle36;
            this.colUnits.HeaderText = "Units";
            this.colUnits.Name = "colUnits";
            this.colUnits.ReadOnly = true;
            // 
            // colMaterialsCosting
            // 
            this.colMaterialsCosting.HeaderText = "Costing";
            this.colMaterialsCosting.Name = "colMaterialsCosting";
            this.colMaterialsCosting.ReadOnly = true;
            // 
            // frmProcessWiseCosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 618);
            this.Controls.Add(this.grdMaterialsInput);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.chkApplyDateFilter);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cbxProductionType);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.grpLabourCosting);
            this.Controls.Add(this.grpMaterials);
            this.Name = "frmProcessWiseCosting";
            this.Text = "Process Wise Costing";
            this.Load += new System.EventHandler(this.frmProcessWiseCosting_Load);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterialsInput)).EndInit();
            this.grpMaterials.ResumeLayout(false);
            this.grpMaterials.PerformLayout();
            this.grpLabourCosting.ResumeLayout(false);
            this.grpLabourCosting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutPut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cbxProductionType;
        private MetroFramework.Controls.MetroLabel lblDepartment;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox chkApplyDateFilter;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroPanel pnlDate;
        private MetroFramework.Controls.MetroDateTime EndDate;
        private MetroFramework.Controls.MetroButton btnLoadbyFilter;
        private MetroFramework.Controls.MetroDateTime StartDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DataGridView grdMaterialsInput;
        private System.Windows.Forms.GroupBox grpMaterials;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtSearchIssuedMaterials;
        private System.Windows.Forms.GroupBox grpLabourCosting;
        private System.Windows.Forms.DataGridView grdOutPut;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtSearchLabour;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialsCosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutPutItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutPutUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutPutTotalAmount;
    }
}