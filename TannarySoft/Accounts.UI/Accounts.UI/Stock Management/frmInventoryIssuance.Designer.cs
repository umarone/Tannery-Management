﻿namespace Accounts.UI
{
    partial class frmInventoryIssuance
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatuMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnNewVoucher = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.txtTotalAmount = new MetroFramework.Controls.MetroTextBox();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkPosted = new MetroFramework.Controls.MetroCheckBox();
            this.VDate = new MetroFramework.Controls.MetroDateTime();
            this.txtGatePass = new MetroFramework.Controls.MetroTextBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.InvEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblDescription = new MetroFramework.Controls.MetroLabel();
            this.lblInvoiceNo = new MetroFramework.Controls.MetroLabel();
            this.txtSaleMemoNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.lblMemoNo = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CustEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblAccountNo = new MetroFramework.Controls.MetroLabel();
            this.txtContact = new MetroFramework.Controls.MetroTextBox();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.txtNTN = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DgvSaleInvoice = new Accounts.UI.TabDataGrid();
            this.colIssuanceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSaleInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1060, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatuMessage
            // 
            this.lblStatuMessage.Name = "lblStatuMessage";
            this.lblStatuMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(848, 408);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(100, 19);
            this.metroLabel11.TabIndex = 29;
            this.metroLabel11.Text = "Total Amount :";
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnDelete.Location = new System.Drawing.Point(747, 447);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 40);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.UseCustomBackColor = true;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewVoucher
            // 
            this.btnNewVoucher.ActiveControl = null;
            this.btnNewVoucher.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnNewVoucher.Location = new System.Drawing.Point(512, 447);
            this.btnNewVoucher.Name = "btnNewVoucher";
            this.btnNewVoucher.Size = new System.Drawing.Size(117, 40);
            this.btnNewVoucher.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNewVoucher.TabIndex = 10;
            this.btnNewVoucher.Text = "New Voucher";
            this.btnNewVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNewVoucher.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnNewVoucher.UseCustomBackColor = true;
            this.btnNewVoucher.UseSelectable = true;
            this.btnNewVoucher.UseStyleColors = true;
            this.btnNewVoucher.Click += new System.EventHandler(this.btnNewVoucher_Click);
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnNext.Location = new System.Drawing.Point(394, 447);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(117, 40);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNext.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnNext.UseCustomBackColor = true;
            this.btnNext.UseSelectable = true;
            this.btnNext.UseStyleColors = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnPrevious.Location = new System.Drawing.Point(276, 447);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(117, 40);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrevious.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPrevious.UseCustomBackColor = true;
            this.btnPrevious.UseSelectable = true;
            this.btnPrevious.UseStyleColors = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // txtTotalAmount
            // 
            // 
            // 
            // 
            this.txtTotalAmount.CustomButton.Image = null;
            this.txtTotalAmount.CustomButton.Location = new System.Drawing.Point(123, 1);
            this.txtTotalAmount.CustomButton.Name = "";
            this.txtTotalAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalAmount.CustomButton.TabIndex = 1;
            this.txtTotalAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalAmount.CustomButton.UseSelectable = true;
            this.txtTotalAmount.CustomButton.Visible = false;
            this.txtTotalAmount.Lines = new string[0];
            this.txtTotalAmount.Location = new System.Drawing.Point(952, 407);
            this.txtTotalAmount.MaxLength = 32767;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.PasswordChar = '\0';
            this.txtTotalAmount.PromptText = "Total Invoice Amount";
            this.txtTotalAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalAmount.SelectedText = "";
            this.txtTotalAmount.SelectionLength = 0;
            this.txtTotalAmount.SelectionStart = 0;
            this.txtTotalAmount.ShortcutsEnabled = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(145, 23);
            this.txtTotalAmount.TabIndex = 24;
            this.txtTotalAmount.UseSelectable = true;
            this.txtTotalAmount.WaterMark = "Total Invoice Amount";
            this.txtTotalAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnClose.Location = new System.Drawing.Point(981, 447);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 40);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.UseCustomBackColor = true;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Location = new System.Drawing.Point(630, 447);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 40);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseCustomBackColor = true;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnPrint.Location = new System.Drawing.Point(864, 447);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(116, 40);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.UseCustomBackColor = true;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Snow;
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Controls.Add(this.VDate);
            this.groupBox2.Controls.Add(this.txtGatePass);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Controls.Add(this.InvEditBox);
            this.groupBox2.Controls.Add(this.lblDescription);
            this.groupBox2.Controls.Add(this.lblInvoiceNo);
            this.groupBox2.Controls.Add(this.txtSaleMemoNo);
            this.groupBox2.Controls.Add(this.metroLabel12);
            this.groupBox2.Controls.Add(this.lblMemoNo);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(3, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1089, 97);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock Information";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkPosted);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(887, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(196, 37);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Checked = true;
            this.chkPosted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPosted.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkPosted.ForeColor = System.Drawing.Color.Red;
            this.chkPosted.Location = new System.Drawing.Point(3, 3);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(52, 19);
            this.chkPosted.TabIndex = 5;
            this.chkPosted.Text = "Post";
            this.chkPosted.UseCustomBackColor = true;
            this.chkPosted.UseSelectable = true;
            // 
            // VDate
            // 
            this.VDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VDate.Location = new System.Drawing.Point(279, 21);
            this.VDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.VDate.Name = "VDate";
            this.VDate.Size = new System.Drawing.Size(128, 29);
            this.VDate.TabIndex = 4;
            // 
            // txtGatePass
            // 
            // 
            // 
            // 
            this.txtGatePass.CustomButton.Image = null;
            this.txtGatePass.CustomButton.Location = new System.Drawing.Point(124, 1);
            this.txtGatePass.CustomButton.Name = "";
            this.txtGatePass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGatePass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGatePass.CustomButton.TabIndex = 1;
            this.txtGatePass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGatePass.CustomButton.UseSelectable = true;
            this.txtGatePass.CustomButton.Visible = false;
            this.txtGatePass.Lines = new string[0];
            this.txtGatePass.Location = new System.Drawing.Point(466, 23);
            this.txtGatePass.MaxLength = 32767;
            this.txtGatePass.Name = "txtGatePass";
            this.txtGatePass.PasswordChar = '\0';
            this.txtGatePass.PromptText = "Gate Pass";
            this.txtGatePass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGatePass.SelectedText = "";
            this.txtGatePass.SelectionLength = 0;
            this.txtGatePass.SelectionStart = 0;
            this.txtGatePass.ShortcutsEnabled = true;
            this.txtGatePass.Size = new System.Drawing.Size(146, 23);
            this.txtGatePass.TabIndex = 2;
            this.txtGatePass.UseSelectable = true;
            this.txtGatePass.Visible = false;
            this.txtGatePass.WaterMark = "Gate Pass";
            this.txtGatePass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGatePass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(952, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(97, 54);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(986, 36);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(231, 27);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 19);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = "Date :";
            this.lblDate.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lblDate.UseCustomBackColor = true;
            // 
            // InvEditBox
            // 
            // 
            // 
            // 
            this.InvEditBox.CustomButton.Image = null;
            this.InvEditBox.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.InvEditBox.CustomButton.Name = "";
            this.InvEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.InvEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.InvEditBox.CustomButton.TabIndex = 1;
            this.InvEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.InvEditBox.CustomButton.UseSelectable = true;
            this.InvEditBox.Lines = new string[0];
            this.InvEditBox.Location = new System.Drawing.Point(97, 25);
            this.InvEditBox.MaxLength = 32767;
            this.InvEditBox.Name = "InvEditBox";
            this.InvEditBox.PasswordChar = '\0';
            this.InvEditBox.PromptText = "Issuance No";
            this.InvEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.InvEditBox.SelectedText = "";
            this.InvEditBox.SelectionLength = 0;
            this.InvEditBox.SelectionStart = 0;
            this.InvEditBox.ShortcutsEnabled = true;
            this.InvEditBox.ShowButton = true;
            this.InvEditBox.Size = new System.Drawing.Size(128, 23);
            this.InvEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.InvEditBox.TabIndex = 1;
            this.InvEditBox.UseSelectable = true;
            this.InvEditBox.WaterMark = "Issuance No";
            this.InvEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.InvEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.InvEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.InvEditBox_ButtonClick);
            this.InvEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InvEditBox_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDescription.Location = new System.Drawing.Point(5, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(85, 19);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "Description :";
            this.lblDescription.UseCustomBackColor = true;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblInvoiceNo.Location = new System.Drawing.Point(6, 24);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(90, 19);
            this.lblInvoiceNo.TabIndex = 15;
            this.lblInvoiceNo.Text = "Issuance No :";
            this.lblInvoiceNo.UseCustomBackColor = true;
            // 
            // txtSaleMemoNo
            // 
            // 
            // 
            // 
            this.txtSaleMemoNo.CustomButton.Image = null;
            this.txtSaleMemoNo.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.txtSaleMemoNo.CustomButton.Name = "";
            this.txtSaleMemoNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSaleMemoNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSaleMemoNo.CustomButton.TabIndex = 1;
            this.txtSaleMemoNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSaleMemoNo.CustomButton.UseSelectable = true;
            this.txtSaleMemoNo.CustomButton.Visible = false;
            this.txtSaleMemoNo.Lines = new string[0];
            this.txtSaleMemoNo.Location = new System.Drawing.Point(714, 23);
            this.txtSaleMemoNo.MaxLength = 32767;
            this.txtSaleMemoNo.Name = "txtSaleMemoNo";
            this.txtSaleMemoNo.PasswordChar = '\0';
            this.txtSaleMemoNo.PromptText = "Demand No";
            this.txtSaleMemoNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSaleMemoNo.SelectedText = "";
            this.txtSaleMemoNo.SelectionLength = 0;
            this.txtSaleMemoNo.SelectionStart = 0;
            this.txtSaleMemoNo.ShortcutsEnabled = true;
            this.txtSaleMemoNo.Size = new System.Drawing.Size(138, 23);
            this.txtSaleMemoNo.TabIndex = 2;
            this.txtSaleMemoNo.UseSelectable = true;
            this.txtSaleMemoNo.Visible = false;
            this.txtSaleMemoNo.WaterMark = "Demand No";
            this.txtSaleMemoNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSaleMemoNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(415, 25);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(45, 19);
            this.metroLabel12.TabIndex = 15;
            this.metroLabel12.Text = "OGP :";
            this.metroLabel12.UseCustomBackColor = true;
            this.metroLabel12.Visible = false;
            // 
            // lblMemoNo
            // 
            this.lblMemoNo.AutoSize = true;
            this.lblMemoNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMemoNo.Location = new System.Drawing.Point(618, 25);
            this.lblMemoNo.Name = "lblMemoNo";
            this.lblMemoNo.Size = new System.Drawing.Size(90, 19);
            this.lblMemoNo.TabIndex = 15;
            this.lblMemoNo.Text = "Demand No :";
            this.lblMemoNo.UseCustomBackColor = true;
            this.lblMemoNo.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Snow;
            this.groupBox1.Controls.Add(this.CustEditBox);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Controls.Add(this.txtContact);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtNTN);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1090, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Issuance Employee";
            // 
            // CustEditBox
            // 
            // 
            // 
            // 
            this.CustEditBox.CustomButton.Image = null;
            this.CustEditBox.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.CustEditBox.CustomButton.Name = "";
            this.CustEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustEditBox.CustomButton.TabIndex = 1;
            this.CustEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustEditBox.CustomButton.UseSelectable = true;
            this.CustEditBox.Lines = new string[0];
            this.CustEditBox.Location = new System.Drawing.Point(58, 20);
            this.CustEditBox.MaxLength = 32767;
            this.CustEditBox.Name = "CustEditBox";
            this.CustEditBox.PasswordChar = '\0';
            this.CustEditBox.PromptText = "Account Name Here";
            this.CustEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustEditBox.SelectedText = "";
            this.CustEditBox.SelectionLength = 0;
            this.CustEditBox.SelectionStart = 0;
            this.CustEditBox.ShortcutsEnabled = true;
            this.CustEditBox.ShowButton = true;
            this.CustEditBox.Size = new System.Drawing.Size(228, 23);
            this.CustEditBox.Style = MetroFramework.MetroColorStyle.Red;
            this.CustEditBox.TabIndex = 0;
            this.CustEditBox.UseSelectable = true;
            this.CustEditBox.WaterMark = "Account Name Here";
            this.CustEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.CustEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.CustEditBox_ButtonClick);
            this.CustEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustEditBox_KeyPress);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountNo.Location = new System.Drawing.Point(6, 21);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(52, 19);
            this.lblAccountNo.TabIndex = 15;
            this.lblAccountNo.Text = "Name :";
            this.lblAccountNo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // txtContact
            // 
            // 
            // 
            // 
            this.txtContact.CustomButton.Image = null;
            this.txtContact.CustomButton.Location = new System.Drawing.Point(94, 1);
            this.txtContact.CustomButton.Name = "";
            this.txtContact.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContact.CustomButton.TabIndex = 1;
            this.txtContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContact.CustomButton.UseSelectable = true;
            this.txtContact.CustomButton.Visible = false;
            this.txtContact.Lines = new string[0];
            this.txtContact.Location = new System.Drawing.Point(292, 20);
            this.txtContact.MaxLength = 32767;
            this.txtContact.Name = "txtContact";
            this.txtContact.PasswordChar = '\0';
            this.txtContact.ReadOnly = true;
            this.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContact.SelectedText = "";
            this.txtContact.SelectionLength = 0;
            this.txtContact.SelectionStart = 0;
            this.txtContact.ShortcutsEnabled = true;
            this.txtContact.Size = new System.Drawing.Size(116, 23);
            this.txtContact.TabIndex = 1;
            this.txtContact.UseSelectable = true;
            this.txtContact.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContact.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAddress
            // 
            // 
            // 
            // 
            this.txtAddress.CustomButton.Image = null;
            this.txtAddress.CustomButton.Location = new System.Drawing.Point(536, 1);
            this.txtAddress.CustomButton.Name = "";
            this.txtAddress.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAddress.CustomButton.TabIndex = 1;
            this.txtAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAddress.CustomButton.UseSelectable = true;
            this.txtAddress.CustomButton.Visible = false;
            this.txtAddress.Lines = new string[0];
            this.txtAddress.Location = new System.Drawing.Point(526, 20);
            this.txtAddress.MaxLength = 32767;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.ReadOnly = true;
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAddress.SelectedText = "";
            this.txtAddress.SelectionLength = 0;
            this.txtAddress.SelectionStart = 0;
            this.txtAddress.ShortcutsEnabled = true;
            this.txtAddress.Size = new System.Drawing.Size(558, 23);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.UseSelectable = true;
            this.txtAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtNTN
            // 
            // 
            // 
            // 
            this.txtNTN.CustomButton.Image = null;
            this.txtNTN.CustomButton.Location = new System.Drawing.Point(93, 1);
            this.txtNTN.CustomButton.Name = "";
            this.txtNTN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNTN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNTN.CustomButton.TabIndex = 1;
            this.txtNTN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNTN.CustomButton.UseSelectable = true;
            this.txtNTN.CustomButton.Visible = false;
            this.txtNTN.Lines = new string[0];
            this.txtNTN.Location = new System.Drawing.Point(409, 20);
            this.txtNTN.MaxLength = 32767;
            this.txtNTN.Name = "txtNTN";
            this.txtNTN.PasswordChar = '\0';
            this.txtNTN.ReadOnly = true;
            this.txtNTN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNTN.SelectedText = "";
            this.txtNTN.SelectionLength = 0;
            this.txtNTN.SelectionStart = 0;
            this.txtNTN.ShortcutsEnabled = true;
            this.txtNTN.Size = new System.Drawing.Size(115, 23);
            this.txtNTN.TabIndex = 3;
            this.txtNTN.UseSelectable = true;
            this.txtNTN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNTN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(4, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 155);
            this.panel1.TabIndex = 1;
            // 
            // DgvSaleInvoice
            // 
            this.DgvSaleInvoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.DgvSaleInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSaleInvoice.BackgroundColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSaleInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvSaleInvoice.ColumnHeadersHeight = 25;
            this.DgvSaleInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIssuanceId,
            this.colIdItem,
            this.colItemName,
            this.colPackingSize,
            this.colCurrentStock,
            this.colQty,
            this.colUnitPrice,
            this.colAmount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSaleInvoice.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvSaleInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvSaleInvoice.EnableHeadersVisualStyles = false;
            this.DgvSaleInvoice.Location = new System.Drawing.Point(4, 221);
            this.DgvSaleInvoice.MultiSelect = false;
            this.DgvSaleInvoice.Name = "DgvSaleInvoice";
            this.DgvSaleInvoice.RowHeadersVisible = false;
            this.DgvSaleInvoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvSaleInvoice.Size = new System.Drawing.Size(1093, 171);
            this.DgvSaleInvoice.TabIndex = 2;
            this.DgvSaleInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSaleInvoice_CellEndEdit);
            this.DgvSaleInvoice.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSaleInvoice_CellLeave);
            this.DgvSaleInvoice.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvSaleInvoice_EditingControlShowing);
            // 
            // colIssuanceId
            // 
            this.colIssuanceId.HeaderText = "IssuanceId";
            this.colIssuanceId.Name = "colIssuanceId";
            this.colIssuanceId.Visible = false;
            // 
            // colIdItem
            // 
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            // 
            // colItemName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colItemName.HeaderText = "Product Description";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 500;
            // 
            // colPackingSize
            // 
            this.colPackingSize.HeaderText = "UOM";
            this.colPackingSize.Name = "colPackingSize";
            this.colPackingSize.ReadOnly = true;
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.HeaderText = "Current Stock";
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.ReadOnly = true;
            this.colCurrentStock.Width = 110;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.Width = 110;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "Amount";
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 110;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Net Value";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 150;
            // 
            // frmInventoryIssuance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 546);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNewVoucher);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgvSaleInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmInventoryIssuance";
            this.Text = "General Stock Gate Pass";
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSales_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSaleInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private TabDataGrid DgvSaleInvoice;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnNewVoucher;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTextBox txtTotalAmount;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnPrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroCheckBox chkPosted;
        private MetroFramework.Controls.MetroTextBox txtGatePass;
        private MetroFramework.Controls.MetroDateTime VDate;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroTextBox InvEditBox;
        private MetroFramework.Controls.MetroLabel lblDescription;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel lblInvoiceNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTextBox CustEditBox;
        private MetroFramework.Controls.MetroLabel lblAccountNo;
        private MetroFramework.Controls.MetroTextBox txtContact;
        private MetroFramework.Controls.MetroTextBox txtNTN;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTextBox txtAddress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lblMemoNo;
        private MetroFramework.Controls.MetroTextBox txtSaleMemoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssuanceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}