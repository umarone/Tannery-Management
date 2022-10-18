﻿namespace Accounts.UI
{
    partial class frmAccountBalance
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEndPeriod = new MetroFramework.Controls.MetroLabel();
            this.chkIncludeDate = new MetroFramework.Controls.MetroCheckBox();
            this.lblStartDate = new MetroFramework.Controls.MetroLabel();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.btnLoad = new MetroFramework.Controls.MetroTile();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvAccountBalance = new System.Windows.Forms.DataGridView();
            this.col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdOthers = new MetroFramework.Controls.MetroRadioButton();
            this.rdCustomers = new MetroFramework.Controls.MetroRadioButton();
            this.rdSuppliers = new MetroFramework.Controls.MetroRadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.StartBalanceDate = new MetroFramework.Controls.MetroDateTime();
            this.EndBalanceDate = new MetroFramework.Controls.MetroDateTime();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAccountBalance)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblEndPeriod);
            this.panel1.Controls.Add(this.chkIncludeDate);
            this.panel1.Controls.Add(this.lblStartDate);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Location = new System.Drawing.Point(126, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 50);
            this.panel1.TabIndex = 0;
            // 
            // lblEndPeriod
            // 
            this.lblEndPeriod.AutoSize = true;
            this.lblEndPeriod.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblEndPeriod.Location = new System.Drawing.Point(343, 18);
            this.lblEndPeriod.Name = "lblEndPeriod";
            this.lblEndPeriod.Size = new System.Drawing.Size(74, 19);
            this.lblEndPeriod.TabIndex = 12;
            this.lblEndPeriod.Text = "To Period :";
            // 
            // chkIncludeDate
            // 
            this.chkIncludeDate.AutoSize = true;
            this.chkIncludeDate.Location = new System.Drawing.Point(10, 19);
            this.chkIncludeDate.Name = "chkIncludeDate";
            this.chkIncludeDate.Size = new System.Drawing.Size(89, 15);
            this.chkIncludeDate.TabIndex = 10;
            this.chkIncludeDate.Text = "Include Date";
            this.chkIncludeDate.UseSelectable = true;
            this.chkIncludeDate.CheckedChanged += new System.EventHandler(this.chkIncludeDate_CheckedChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblStartDate.Location = new System.Drawing.Point(106, 16);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(88, 19);
            this.lblStartDate.TabIndex = 12;
            this.lblStartDate.Text = "Start Period :";
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrint.Location = new System.Drawing.Point(649, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 35);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.UseCustomBackColor = true;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.ActiveControl = null;
            this.btnLoad.BackColor = System.Drawing.Color.DarkCyan;
            this.btnLoad.Location = new System.Drawing.Point(543, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(105, 35);
            this.btnLoad.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoad.UseCustomBackColor = true;
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvAccountBalance);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(124, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 382);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accounts Balances";
            // 
            // DgvAccountBalance
            // 
            this.DgvAccountBalance.AllowUserToAddRows = false;
            this.DgvAccountBalance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.DgvAccountBalance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAccountBalance.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAccountBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvAccountBalance.ColumnHeadersHeight = 25;
            this.DgvAccountBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col,
            this.colAccountName,
            this.colAccountType,
            this.colBalance,
            this.colUnits});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAccountBalance.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvAccountBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAccountBalance.EnableHeadersVisualStyles = false;
            this.DgvAccountBalance.Location = new System.Drawing.Point(3, 21);
            this.DgvAccountBalance.Name = "DgvAccountBalance";
            this.DgvAccountBalance.ReadOnly = true;
            this.DgvAccountBalance.RowHeadersVisible = false;
            this.DgvAccountBalance.Size = new System.Drawing.Size(753, 358);
            this.DgvAccountBalance.TabIndex = 0;
            // 
            // col
            // 
            this.col.HeaderText = "Acc. #";
            this.col.Name = "col";
            this.col.ReadOnly = true;
            // 
            // colAccountName
            // 
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 200;
            // 
            // colAccountType
            // 
            this.colAccountType.HeaderText = "Account Type";
            this.colAccountType.Name = "colAccountType";
            this.colAccountType.ReadOnly = true;
            this.colAccountType.Width = 150;
            // 
            // colBalance
            // 
            dataGridViewCellStyle3.NullValue = "0";
            this.colBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.colBalance.HeaderText = "Remaining Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            this.colBalance.Width = 150;
            // 
            // colUnits
            // 
            this.colUnits.HeaderText = "Remaining Units";
            this.colUnits.Name = "colUnits";
            this.colUnits.ReadOnly = true;
            this.colUnits.Width = 150;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdOthers);
            this.panel2.Controls.Add(this.rdCustomers);
            this.panel2.Controls.Add(this.rdSuppliers);
            this.panel2.Location = new System.Drawing.Point(2, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 441);
            this.panel2.TabIndex = 7;
            // 
            // rdOthers
            // 
            this.rdOthers.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdOthers.BackColor = System.Drawing.Color.Silver;
            this.rdOthers.Location = new System.Drawing.Point(12, 124);
            this.rdOthers.Name = "rdOthers";
            this.rdOthers.Size = new System.Drawing.Size(90, 33);
            this.rdOthers.Style = MetroFramework.MetroColorStyle.Silver;
            this.rdOthers.TabIndex = 12;
            this.rdOthers.Text = "Others";
            this.rdOthers.UseCustomBackColor = true;
            this.rdOthers.UseSelectable = true;
            this.rdOthers.CheckedChanged += new System.EventHandler(this.rdStock_CheckedChanged);
            // 
            // rdCustomers
            // 
            this.rdCustomers.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdCustomers.BackColor = System.Drawing.Color.Silver;
            this.rdCustomers.Location = new System.Drawing.Point(12, 28);
            this.rdCustomers.Name = "rdCustomers";
            this.rdCustomers.Size = new System.Drawing.Size(90, 33);
            this.rdCustomers.Style = MetroFramework.MetroColorStyle.Silver;
            this.rdCustomers.TabIndex = 12;
            this.rdCustomers.Text = "Recieveables";
            this.rdCustomers.UseCustomBackColor = true;
            this.rdCustomers.UseSelectable = true;
            this.rdCustomers.CheckedChanged += new System.EventHandler(this.rdStock_CheckedChanged);
            // 
            // rdSuppliers
            // 
            this.rdSuppliers.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdSuppliers.BackColor = System.Drawing.Color.Silver;
            this.rdSuppliers.Location = new System.Drawing.Point(12, 76);
            this.rdSuppliers.Name = "rdSuppliers";
            this.rdSuppliers.Size = new System.Drawing.Size(90, 33);
            this.rdSuppliers.Style = MetroFramework.MetroColorStyle.Silver;
            this.rdSuppliers.TabIndex = 12;
            this.rdSuppliers.Text = "Payables";
            this.rdSuppliers.UseCustomBackColor = true;
            this.rdSuppliers.UseSelectable = true;
            this.rdSuppliers.CheckedChanged += new System.EventHandler(this.rdStock_CheckedChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(569, 469);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 30);
            this.lblTotal.TabIndex = 8;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(756, 473);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(0, 21);
            this.lblTotalAmount.TabIndex = 9;
            // 
            // StartBalanceDate
            // 
            this.StartBalanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartBalanceDate.Location = new System.Drawing.Point(324, 78);
            this.StartBalanceDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.StartBalanceDate.Name = "StartBalanceDate";
            this.StartBalanceDate.Size = new System.Drawing.Size(140, 29);
            this.StartBalanceDate.TabIndex = 10;
            // 
            // EndBalanceDate
            // 
            this.EndBalanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndBalanceDate.Location = new System.Drawing.Point(546, 78);
            this.EndBalanceDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.EndBalanceDate.Name = "EndBalanceDate";
            this.EndBalanceDate.Size = new System.Drawing.Size(120, 29);
            this.EndBalanceDate.TabIndex = 11;
            // 
            // frmAccountBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 536);
            this.Controls.Add(this.EndBalanceDate);
            this.Controls.Add(this.StartBalanceDate);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAccountBalance";
            this.Text = "Accounts Balances";
            this.Load += new System.EventHandler(this.frmAccountBalance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAccountBalance)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvAccountBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnits;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private MetroFramework.Controls.MetroTile btnLoad;
        private MetroFramework.Controls.MetroTile btnPrint;
        private MetroFramework.Controls.MetroCheckBox chkIncludeDate;
        private MetroFramework.Controls.MetroDateTime StartBalanceDate;
        private MetroFramework.Controls.MetroDateTime EndBalanceDate;
        private MetroFramework.Controls.MetroRadioButton rdCustomers;
        private MetroFramework.Controls.MetroRadioButton rdSuppliers;
        private MetroFramework.Controls.MetroRadioButton rdOthers;
        private MetroFramework.Controls.MetroLabel lblEndPeriod;
        private MetroFramework.Controls.MetroLabel lblStartDate;
    }
}