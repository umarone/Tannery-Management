﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.BLL;
using Accounts.EL;
using SpreadsheetLight;
using System.Diagnostics;

using MetroFramework.Forms;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmSaleReports : MetroForm
    {
        frmFindAccounts frmaccounts = null;
        frmStockAccounts frmstockAccounts = null;
        public string ReportType { get; set; }
        public frmSaleReports()
        {
            InitializeComponent();
        }
        private void frmSaleReports_Load(object sender, EventArgs e)
        {
            //ddlReportTypes.SelectedIndex = 0;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            GrpProductSale.Visible = false;
            GrpPersonsale.Visible = false;
            pnlPersonSaleDate.Visible = false;
            pnlProductSaleDate.Visible = false;
            pnlReportsGrid.Visible = false;
            RenameControls();
            FillComboDetail();
        }
        private void RenameControls()
        {
            if (ReportType == "Purchase")
            {
                GrpPersonsale.Text = "Supplier Purchase Information";
                GrpProductSale.Text = "Prodcut Purchase";
                this.Text = "Purchase Report";
            }
            else
            {
                GrpPersonsale.Text = "Customer Sale Information";
            }
        }
        private void FillComboDetail()
        {
            if (ReportType == "Sale")
            {
                ddlReportTypes.Items.Insert(0, "Choose");
                ddlReportTypes.Items.Insert(1, "Customer Sale Report");
                ddlReportTypes.Items.Insert(2, "Product Sale Report");
                ddlReportTypes.Items.Insert(3, "Total Stock Report");
                ddlReportTypes.Items.Insert(4, "DateWise Total Stock Report");

                ddlReportTypes.SelectedIndex = 0;
            }
            else
            {
                ddlReportTypes.Items.Insert(0, "Choose");
                ddlReportTypes.Items.Insert(1, "Supplier Purchase Report");
                ddlReportTypes.Items.Insert(2, "Product Purchase Report");
                ddlReportTypes.Items.Insert(3, "Total Stock Report");
                ddlReportTypes.Items.Insert(4, "DateWise Total Stock Report");

                ddlReportTypes.SelectedIndex = 0;
            }
        }
        private void ddlReportTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlPersonSaleDate.Visible = false;
            pnlProductSaleDate.Visible = false;
            pnlDateWiseStock.Visible = false;
            ClearControls();
            if (ddlReportTypes.SelectedIndex == 0)
            {
                GrpProductSale.Visible = false;
                GrpPersonsale.Visible = false;
                pnlDateWiseStock.Visible = false;
            }
            else if (ddlReportTypes.SelectedIndex == 1)
            {                
                GrpPersonsale.Visible = true;

                GrpProductSale.Visible = false;
                pnlReportsGrid.Visible = false;
                pnlDateWiseStock.Visible = false;
            }
            else if (ddlReportTypes.SelectedIndex == 2)
            {
                GrpPersonsale.Visible = false;
                GrpProductSale.Visible = true;

                pnlReportsGrid.Visible = false;
                pnlDateWiseStock.Visible = false;
            }
            else if (ddlReportTypes.SelectedIndex == 3)
            {
                GrpPersonsale.Visible = false;
                GrpProductSale.Visible = false;
                pnlDateWiseStock.Visible = false;

                pnlReportsGrid.Visible = true;
            }
            else if (ddlReportTypes.SelectedIndex == 4)
            {
                GrpPersonsale.Visible = false;
                GrpProductSale.Visible = false;
                
                pnlReportsGrid.Visible = true;
                pnlDateWiseStock.Visible = true;
            }
            ShowAndGridColumns();
        }
        private void PsEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmaccounts = new frmFindAccounts();
            frmaccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmaccounts_ExecuteFindAccountEvent);
            frmaccounts.ShowDialog(this);
        }
        void frmaccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (oelAccount!= null)
            {
                PsEditBox.Text = oelAccount.AccountNo.ToString();
                txtPersonName.Text = oelAccount.AccountName;
            }
        }
        private void PEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmstockAccounts = new frmStockAccounts();
            frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            frmstockAccounts.ShowDialog(this);
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            if (oelItems != null)
            {
                PEditBox.Text = oelItems.ItemNo.ToString();
                txtItemName.Text = oelItems.ItemName;
            }
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSaleDates = sender as CheckBox;
            if (chkSaleDates.Name == "chkPersonDate")
            {
                if (chkSaleDates.Checked)
                {
                    ShowAndHideChildPanels(true, pnlPersonSaleDate);
                }
                else
                {
                    ShowAndHideChildPanels(false, pnlPersonSaleDate);
                }
            }
            else
            {
                if (chkSaleDates.Checked)
                {
                    ShowAndHideChildPanels(true, pnlProductSaleDate);
                }
                else
                {
                    ShowAndHideChildPanels(false, pnlProductSaleDate);
                }
            }
        }
        private void ClearControls()
        {
            PsEditBox.Text = string.Empty;
            PEditBox.Text = string.Empty;
            grdReports.Rows.Clear();
            chkPersonDate.Checked = false;
            chkProductDate.Checked = false;
            txtItemName.Text = string.Empty;
            txtPersonName.Text = string.Empty;

        }
        private void ShowAndHideChildPanels(bool VisibleValue, Panel ParentPanel)
        {
            if (false == VisibleValue && ParentPanel.Name == "pnlPersonSaleDate")
            {
                pnlPersonSaleDate.Visible = false;
            }
            else if (true == VisibleValue && ParentPanel.Name == "pnlPersonSaleDate")
            {
                pnlPersonSaleDate.Visible = true;
            }
            else if (false == VisibleValue && ParentPanel.Name == "pnlProductSaleDate")
            {
                pnlProductSaleDate.Visible = false;
            }
            else if (true == VisibleValue && ParentPanel.Name == "pnlProductSaleDate")
            {
                pnlProductSaleDate.Visible = true;
            }

        }
        private void ShowAndGridColumns()
        {
            if (ddlReportTypes.SelectedIndex == 0)
            {
                
            }
            else if (ddlReportTypes.SelectedIndex == 1)
            {
                grdReports.Columns[1].Visible = true;
                grdReports.Columns[5].Visible = true;
                //grdReports.Columns[2].Visible = true;

                grdReports.Columns[0].Visible = false;  // VoucherNoColumn
                grdReports.Columns[3].Visible = false; // PersonNameColumn
                //grdReports.Columns[5].Visible = false; // unitpricecolumn
            }
            else if (ddlReportTypes.SelectedIndex == 2)
            {
                grdReports.Columns[0].Visible = true;
                grdReports.Columns[3].Visible = true;
                grdReports.Columns[4].Visible = true;
                grdReports.Columns[5].Visible = true;
                grdReports.Columns[6].Visible = true;


                grdReports.Columns[1].Visible = false;
                grdReports.Columns[2].Visible = false;
            }
            else if (ddlReportTypes.SelectedIndex == 3)
            {
                //Setting Columns Visible True
                grdReports.Columns[1].Visible = true;
                grdReports.Columns[2].Visible = true;

                //Setting Columns Visible False
                grdReports.Columns[0].Visible = false;  // VoucherNoColumn
                grdReports.Columns[3].Visible = false; // PersonNameColumn
                grdReports.Columns[4].Visible = true;
                
                grdReports.Columns[5].Visible = false; // PersonNameColumn

                GetBindingListByCode(3, "");
            }
            else if (ddlReportTypes.SelectedIndex == 4)
            {
                grdReports.Columns[1].Visible = true;
                grdReports.Columns[2].Visible = true;

                //Setting Columns Visible False
                grdReports.Columns[0].Visible = false;  // VoucherNoColumn
                grdReports.Columns[3].Visible = false; // PersonNameColumn
                grdReports.Columns[4].Visible = true;

                grdReports.Columns[5].Visible = true; // PersonNameColumn
            }
        }
        private void GetBindingListByCode(short BindingListCode,string AccountNo)
        {
            var SaleManager = new SalesDetailBLL();
            var PurchaseManager = new PurchaseDetailBLL();
            List<SaleDetailEL> listSale = null;
            List<PurchaseDetailEL> listPurchase = null;
            if (BindingListCode == 1 && AccountNo != string.Empty)
            {
                if (ReportType == "Sale")
                {
                    if (chkPersonDate.Checked)
                    {
                        listSale = SaleManager.GetCustomerSaleByDate(Validation.GetSafeLong(AccountNo), Operations.IdCompany, dtPrescriberStart.Value, dtPrescriberEnd.Value);
                    }
                    else
                    {
                        listSale = SaleManager.GetCustomerSale(Validation.GetSafeLong(AccountNo),Operations.IdCompany);
                    }
                }
                else if (ReportType == "Purchase")
                {
                    if (chkPersonDate.Checked)
                    {
                        listPurchase = PurchaseManager.GetSupplierPurchaseByDate(Validation.GetSafeLong(AccountNo), dtPrescriberStart.Value, dtPrescriberEnd.Value,Operations.IdCompany);
                    }
                    else
                    {
                        listPurchase = PurchaseManager.GetSupplierPurchase(Validation.GetSafeLong(AccountNo),Operations.IdCompany);
                    }
                }
            }
            else if (BindingListCode == 2 && AccountNo != string.Empty)
            {
                if (ReportType == "Sale")
                {
                    if (chkProductDate.Checked)
                    {
                        listSale = SaleManager.GetProductDetailSaleByDate(Validation.GetSafeLong(AccountNo), dtProductStart.Value, dtProductEnd.Value,Operations.IdCompany);
                    }
                    else
                    {
                        listSale = SaleManager.GetProductDetailSale(Validation.GetSafeLong(AccountNo),Operations.IdCompany);
                    }
                }
                else if (ReportType == "Purchase")
                {
                    if (chkProductDate.Checked)
                    {
                        listPurchase = PurchaseManager.GetProductDetailPurchaseByDate(Validation.GetSafeLong(AccountNo), dtProductStart.Value, dtProductEnd.Value,Operations.IdCompany);
                    }
                    else
                    {
                        listPurchase = PurchaseManager.GetProductDetailPurchase(Validation.GetSafeLong(AccountNo),Operations.IdCompany);
                    }
                }
            }
            else if (BindingListCode == 3)
            {
                if (ReportType == "Sale")
                {
                    listSale = SaleManager.GetProductsTotalSale(Operations.IdCompany);
                }
                else if (ReportType == "Purchase")
                {
                    listPurchase = PurchaseManager.GetProductsTotalPurchase(Operations.IdCompany);
                }
            }
            else if (BindingListCode == 4)
            {
                if (ReportType == "Sale")
                {
                    listSale = SaleManager.GetProductsTotalSaleByDate(dtStartDateWiseStock.Value,dtEndDateWiseStock.Value,Operations.IdCompany);
                }
                else if (ReportType == "Purchase")
                {
                    listPurchase = PurchaseManager.GetProductsTotalPurchaseByDate(dtStartDateWiseStock.Value,dtEndDateWiseStock.Value,Operations.IdCompany);
                }
            }
            if (listSale != null && listSale.Count > 0)
            {
                BindSaleGridByCode(listSale, BindingListCode);
                pnlReportsGrid.Visible = true;
            
            }
            else if (listPurchase !=null && listPurchase.Count > 0)
            {
                BindPurchaseGridByCode(listPurchase, BindingListCode);
                pnlReportsGrid.Visible = true;
            }
            
        }
        private void BindSaleGridByCode(List<SaleDetailEL> list,short BindingCode)
        {
            if (grdReports.Rows.Count > 0)
            {
                grdReports.Rows.Clear();
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (BindingCode == 1)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[4].Value = list[i].Units;
                    grdReports.Rows[i].Cells[5].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                }
                else if (BindingCode == 2)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[0].Value = list[i].VoucherNo;
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[3].Value = list[i].AccountName;
                    grdReports.Rows[i].Cells[4].Value = list[i].Units;
                    grdReports.Rows[i].Cells[5].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                }
                else if (BindingCode == 3)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[4].Value = list[i].Units;
                    grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                }
                else if (BindingCode == 4)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[4].Value = list[i].Units;
                    grdReports.Rows[i].Cells[5].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                }
            }
        }
        private void BindPurchaseGridByCode(List<PurchaseDetailEL> list, short BindingCode)
        {
            if (grdReports.Rows.Count > 0)
            {
                grdReports.Rows.Clear();
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (BindingCode == 1)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[4].Value = list[i].Units;
                    grdReports.Rows[i].Cells[5].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                }
                else if (BindingCode == 2)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[0].Value = list[i].VoucherNo;
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[3].Value = list[i].AccountName;
                    grdReports.Rows[i].Cells[4].Value = list[i].Units;
                    grdReports.Rows[i].Cells[5].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                }
                else if (BindingCode == 3)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[4].Value = list[i].Units;
                    grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                }
                else if (BindingCode == 4)
                {
                    grdReports.Rows.Add();
                    grdReports.Rows[i].Cells[1].Value = list[i].ItemNo;
                    grdReports.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdReports.Rows[i].Cells[4].Value = list[i].Units;
                    grdReports.Rows[i].Cells[5].Value = list[i].UnitPrice;
                    grdReports.Rows[i].Cells[6].Value = list[i].Amount;
                }
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "btnPersonReport")
            {
                GetBindingListByCode(1,PsEditBox.Text);
            }
            else if (btn.Name == "btnProductReport")
            {
                GetBindingListByCode(2,PEditBox.Text);
            }
            else if (btn.Name == "btnDateWiseStockReport")
            {
                GetBindingListByCode(4, "");
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (grdReports.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdReports.Columns)
                {
                    if (column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                }

                //Add Header Rows....
                dt.Rows.Add();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Rows[0][i] = dt.Columns[i].ColumnName; //"Account Name"; 
                }
                
                // Add Empty Row....
                dt.Rows.Add();
                for (int i = 0; i < grdReports.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count)
                    {
                        dt.Rows[1][i] = "";
                    }
                    else
                    {
                        break;
                    }
                }
                                
                foreach (DataGridViewRow row in grdReports.Rows)
                {
                    dt.Rows.Add();
                    int colindex = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Visible)
                            {
                                //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                                dt.Rows[dt.Rows.Count - 1][colindex] = cell.Value.ToString();
                                colindex++;
                            }
                        }                                                    
                    }
                }

                SLDocument slExcelExport = new SLDocument();


                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    slExcelExport.SetColumnWidth(i, 20);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        slExcelExport.SetCellValue(j + 1, i + 1, dt.Rows[j].ItemArray[i].ToString());
                    }
                }
                slExcelExport.Save();

                Process.Start("Book1.xlsx");


            }
        }

        
        
    }
}
