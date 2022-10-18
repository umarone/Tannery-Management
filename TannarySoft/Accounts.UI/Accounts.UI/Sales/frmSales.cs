using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmSales : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        frmReports frmReport;
        frmCustomerDiscount frmcustomerdiscounts;
        public decimal OldValue { get; set; }
        public Int64 InvoiceNo { get; set; }
        public Int64 SampleNo { get; set; }
        public bool IsSampleSale { get; set; }
        public Guid IdVoucher = Guid.Empty;
        public Guid IdSampleVoucher = Guid.Empty;
        public Guid CustomerTransactionId { get; set; }
        public Guid SalesTransactionId { get; set; }
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        public bool IsImport { get; set; }
        bool IsNewInvoice;
        decimal CostOfGoodsSoldAmount = 0;
        public string VoucherType { get; set; }
        string CommandType = "", StockSearchType;
        string LinkAccountNo, CustomerAccountNo, SalesAccountNo, MakerAccountNo;
        List<PurchaseDetailEL> ListToUpdateStock = null;
        List<PurchaseDetailEL> ListToCheck = null;
        decimal MRP = 0;
        #endregion
        #region Form Constructor And Load Method
        public frmSales()
        {
            InitializeComponent();
        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.metrolSalesTab.SelectedIndex = 0;
            FillData();
            FillNaturalAccounts(string.Empty);
            cbxSeller.SelectedIndex = 1;
            cbxSaleType.SelectedIndex = 1;
            CustEditBox.Focus();
            CheckModulePermissions();
            CreateAndInitializeFooterRow();
            if (IsSampleSale)
            {
                txtSampleNo.Text = SampleNo.ToString();
                //txtSampleNo.Visible = true;
                //txtSampleNo.Enabled = false;
                //lblSampleNo.Visible = true;
                FillSampleVoucher();
            }
            //ResizeColumns(0);
            //if (IsImport)
            //{
            //    this.Text = "Import Sales";

            //    lblVAT.Visible = false;
            //    txtVat.Visible = false;
            //    lblVATAmount.Visible = false;
            //    txtVatAmount.Visible = false;
            //}
            //else
            //{
            //    this.Text = "Local Sales";

            //    lblVAT.Visible = true;
            //    txtVat.Visible = true;
            //    lblVATAmount.Visible = true;
            //    txtVatAmount.Visible = true;
            //}
        }
        #endregion
        private void CheckModulePermissions()
        {
            List<UserModulesPermissionsEL> PermissionsList = UserPermissions.GetUserModulePermissionsByUserAndModuleId(Operations.UserID);
            if (PermissionsList != null && PermissionsList.Count > 0)
            {
                if (PermissionsList[0].Saving == true)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                if (PermissionsList[0].Deleting == true)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                if (PermissionsList[0].Printing == true)
                {
                    btnPrint.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
                }
                if (PermissionsList[0].Posting == true)
                {
                    btnSave.Enabled = true;
                    chkPosted.Checked = true;
                    chkPosted.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = false;
                    chkPosted.Checked = false;
                    chkPosted.Enabled = true;
                }
            }
            //else
            //{
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //    chkPosted.Checked = true;
            //    chkPosted.Enabled = true;
            //}
        }
        private void CreateAndInitializeFooterRow()
        {
            txtDebit.Enabled = false;
            txtDebit.TextAlign = HorizontalAlignment.Left;
            txtDebit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCellLocation = DgvSalesAccounts.GetCellDisplayRectangle(7, -1, true).X;

            txtDebit.Width = DgvSalesAccounts.Columns[6].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtDebit.Location = new Point(hostCellLocation, DgvSalesAccounts.Height - txtDebit.Height);

            DgvSalesAccounts.Controls.Add(txtDebit);

            txtDebit.BringToFront();

            txtCredit.Enabled = false;
            txtCredit.TextAlign = HorizontalAlignment.Left;
            txtCredit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCreditCellLocation = DgvSalesAccounts.GetCellDisplayRectangle(8, -1, true).X;
            txtCredit.Width = DgvSalesAccounts.Columns[7].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtCredit.Location = new Point(hostCreditCellLocation, DgvSalesAccounts.Height - txtCredit.Height);

            DgvSalesAccounts.Controls.Add(txtCredit);

            txtCredit.BringToFront();
        }
        private void FillData()
        {
            var manager = new VoucherBLL();
            InvEditBox.Text = manager.GetMaxVoucherNumber("SaleInvoiceVoucher", Operations.IdCompany);
        }
        private void FillSampleVoucher()
        {
            var Manager = new VoucherBLL();
            var SalesManager = new SalesDetailBLL();
            var SamplesManager = new SampleDetailBLL();
            VoucherType = "SampleVoucher";
            List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, SampleNo);
            if (list.Count > 0)
            {
                //IdVoucher = list[0].IdVoucher;
                VDate.Value = list[0].Date;
                txtDescription.Text = list[0].Description;
                txtSaleMemoNo.Text = Validation.GetSafeString(list[0].DemandNo);
                txtGatePass.Text = Validation.GetSafeString(list[0].OutWardGatePassNo);
                if (list[0].Posted)
                {
                    if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        chkPosted.Enabled = false;
                    }
                    chkPosted.Checked = list[0].Posted;
                    lblStatuMessage.Text = "Posted Voucher ...";
                    lblStatuMessage.ForeColor = Color.Red;
                }
                else
                {
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                }

                //List<TransactionsEL> listTransactions = Manager.GetTransactions(Validation.GetSafeLong(InvSampleBox.Text), "SaleInvoiceVoucher", Operations.IdCompany);

                //if (listTransactions.Count > 0)
                //{
                //    TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Credit != 0);
                //    if (oelSalesTransaction != null)
                //    {
                //        //SalesEditBox.Text = oelSalesTransaction.AccountNo.ToString();
                //        cbxEmployees.SelectedValue = oelSalesTransaction.AccountNo;
                //        EmpEditCode.Text = oelSalesTransaction.AccountNo.ToString();
                //        SalesTransactionId = oelSalesTransaction.TransactionID;
                //    }
                //}


                //FillEmployee(ListCustomer[0].SubAccountNo);

                List<VoucherDetailEL> CustomerSamplesList = SamplesManager.GetSampleWithSampleNumber(SampleNo, Operations.IdCompany);
                if (CustomerSamplesList.Count > 0)
                {
                    FillEmployee(CustomerSamplesList[0].SubAccountNo, "");

                    List<PersonsEL> ListCustomer = Manager.GetSampleCustomer(SampleNo, list[0].AccountNo.ToString(), "SampleVoucher", Operations.IdCompany);
                    if (ListCustomer.Count > 0)
                    {
                        CustEditBox.Text = Validation.GetSafeString(ListCustomer[0].AccountNo);
                        //txtCustomerName.Text = ListCustomer[0].PersonName;
                        //txtSaleMemoNo.Text = ListCustomer[0].MemoSaleNo.ToString();                            
                        txtContact.Text = ListCustomer[0].Contact;
                        txtNTN.Text = ListCustomer[0].NTN;
                        txtAddress.Text = ListCustomer[0].Address;
                    }

                    FillSamplesTransaction(CustomerSamplesList, ListCustomer[0].Balance);
                }
            }
            else
            {
                ClearControl();
                MessageBox.Show("Voucher Number Not Found ...");
            }



        }
        private void FillSamplesTransaction(List<VoucherDetailEL> CustomerSamplesList, decimal Amount)
        {
            var manager = new ItemsBLL();

            if (DgvSaleInvoice.Rows.Count > 0)
            {
                DgvSaleInvoice.Rows.Clear();
            }
            for (int i = 0; i < CustomerSamplesList.Count; i++)
            {
                DgvSaleInvoice.Rows.Add();
                DgvSaleInvoice.Rows[i].Cells[0].Value = CustomerSamplesList[i].IdVoucherDetail;
                DgvSaleInvoice.Rows[i].Cells[1].Value = CustomerSamplesList[i].IdAccount;
                DgvSaleInvoice.Rows[i].Cells[2].Value = CustomerSamplesList[i].ItemNo;
                DgvSaleInvoice.Rows[i].Cells[3].Value = CustomerSamplesList[i].ItemName; //manager.GetItemByAccount(Validation.GetSafeLong(Salelist[i].ItemNo), Operations.IdCompany).ItemName;
                DgvSaleInvoice.Rows[i].Cells[4].Value = CustomerSamplesList[i].PackingSize;
                DgvSaleInvoice.Rows[i].Cells[5].Value = CustomerSamplesList[i].BatchNo;
                DgvSaleInvoice.Rows[i].Cells[6].Value = CustomerSamplesList[i].Discription;
                DgvSaleInvoice.Rows[i].Cells[7].Value = CustomerSamplesList[i].UnitPrice;
                DgvSaleInvoice.Rows[i].Cells[8].Value = CustomerSamplesList[i].Units;
                DgvSaleInvoice.Rows[i].Cells[9].Value = CustomerSamplesList[i].Units * Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells[7].Value);
                DgvSaleInvoice.Rows[i].Cells[10].Value = DgvSaleInvoice.Rows[i].Cells[9].Value;  //CustomerSamplesList[i].Discount;
            }
            txtTotalAmount.Text = Amount.ToString();
        }
        private void FillNaturalAccounts(string SaleAccount)
        {
            if (SaleAccount == "")
            {
                var manager = new AccountsBLL();
                List<AccountsEL> list = manager.GetAccountsByType("Net SALES", Operations.IdCompany);
                if (list.Count > 0)
                {

                    list.Insert(0, new AccountsEL() { AccountNo = "0", AccountName = "Select Sales Account" });

                    cbxNaturalAccounts.DataSource = list;
                    cbxNaturalAccounts.DisplayMember = "AccountName";
                    cbxNaturalAccounts.ValueMember = "AccountNo";

                    cbxNaturalAccounts.SelectedIndex = 1;

                }
            }
            else
            {
                cbxNaturalAccounts.SelectedValue = SaleAccount;
            }
        }
        private void CustEditBox_ButtonClick(object sender, EventArgs e)
        {
            CommandType = "Persons";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void EmpEditCode_ButtonClick(object sender, EventArgs e)
        {
            CommandType = "Employees";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (CommandType == "Persons")
            {
                var manager = new PersonsBLL();
                //List<PersonsEL> list = manager.VerifyAccount("Customers/Suppliers", oelChartOfAccount.AccountNo);
                List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                if (list.Count > 0)
                {
                    CustomerAccountNo = oelAccount.AccountNo;
                    CustEditBox.Text = oelAccount.AccountName;
                    txtContact.Text = list[0].Contact;
                    txtNTN.Text = list[0].NTN;
                    txtAddress.Text = list[0].Address;
                    lblStatuMessage.Text = "";
                }
                else
                {
                    CustomerAccountNo = oelAccount.AccountNo;
                    CustEditBox.Text = oelAccount.AccountName;
                }
            }
            else if (CommandType == "Employees")
            {
                MakerAccountNo = oelAccount.AccountNo;               
            }
            else if (CommandType == "DgvSales")
            {
                DgvSalesAccounts.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                DgvSalesAccounts.CurrentRow.Cells["colLinkAccount"].Value = oelAccount.LinkAccountNo;
                DgvSalesAccounts.CurrentRow.Cells["colIdAccount"].Value = oelAccount.IdAccount;
                DgvSalesAccounts.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
            }
            else if (CommandType == "Makers")
            {
                DgvSaleInvoice.CurrentRow.Cells["colMakerAccountNo"].Value = oelAccount.AccountNo;
                DgvSaleInvoice.CurrentRow.Cells["colmakerAccountName"].Value = oelAccount.AccountName;
            }
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            List<ItemsEL> ClosingQty = null;
            var manager = new ItemsBLL();
            DgvSaleInvoice.RefreshEdit();
            List<ItemsEL> listpriceAndSize = manager.GetItemPriceAndSizeByCode(Validation.GetSafeLong(oelItems.AccountNo), Operations.IdCompany);
            if (cbxSaleType.SelectedIndex == 1)
            {
                ClosingQty = manager.GetTanneryItemClosingStock(Operations.IdCompany, oelItems.IdItem);
            }
            else if (cbxSaleType.SelectedIndex == 2)
            {
                if (cbxVehicles.Text != "Select Vehicle")
                {
                    ClosingQty = manager.GetRawLeatherItemClosingStock(Operations.IdCompany, oelItems.IdItem, cbxVehicles.Text);
                }
                else
                {
                    MessageBox.Show("Please Select Vehicle No For Sale");
                    return;
                }
            }
            if (StockSearchType == "Items")
            {
                if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.ItemNo).Count > 0)
                {
                    lblStatuMessage.Text = "";
                    DgvSaleInvoice.CurrentRow.Cells["colItemNo"].Value = oelItems.ItemNo;
                    DgvSaleInvoice.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                    DgvSaleInvoice.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                    DgvSaleInvoice.CurrentRow.Cells["colPackingSize"].Value = oelItems.PackingSize;

                    if (cbxSaleType.SelectedIndex == 1 || cbxSaleType.SelectedIndex == 2)
                    {
                        if (ClosingQty.Count > 0)
                        {
                            DgvSaleInvoice.CurrentRow.Cells["colCurrentStock"].Value = ClosingQty[0].Qty;
                        }
                        else
                        {
                            DgvSaleInvoice.CurrentRow.Cells["colCurrentStock"].Value = 0;
                        }
                    }
                    else
                    {
                        DgvSaleInvoice.CurrentRow.Cells["colCurrentStock"].Value = 0;
                    }

                    //DgvSaleInvoice.CurrentRow.Cells["colBatchNo"].Value = oelItems.BatchNo;
                    //DgvSaleInvoice.CurrentRow.Cells["colExpiry"].Value = oelItems.Expiry;
                    //DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value = listpriceAndSize[0].UnitPrice; //manager.GetItemPriceByCode(oelItems.AccountNo, Operations.IdCompany).ToString();
                    //DgvSaleInvoice.CurrentRow.Cells["colQty"].Selected = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                {
                    lblStatuMessage.Text = "Wrong Account For Sale";
                }
            }
            else if (StockSearchType == "Articles")
            {
                DgvSaleInvoice.CurrentRow.Cells["colIdArticle"].Value = oelItems.IdItem;
                DgvSaleInvoice.CurrentRow.Cells["colArticleDescription"].Value = oelItems.ItemName;
            }
        }
        private void DgvSaleInvoice_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if(DgvSaleInvoice.CurrentRow.Cells["colItemName"].Value != null)
                {
                    if (MRP != 0)
                    {
                        DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value = MRP;
                    }
                    else
                    {
                        var manager = new ItemsBLL();
                        List<ItemsEL> listpriceAndSize = manager.GetItemPriceAndSizeByCode(Validation.GetSafeLong(DgvSaleInvoice.CurrentRow.Cells["colItemNo"].Value), Operations.IdCompany);
                        MRP = listpriceAndSize[0].MRP;
                    }
                }
                //DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisAmount"].Value = Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value);  
            }
            //else if (e.ColumnIndex == 11)
            //{
            //    //DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value;
            //    DgvSaleInvoice.EndEdit();
            //    DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisAmount"].Value = (Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) * (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value))) * (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisc"].Value)) / 100;
            //    //if (DgvSaleInvoice.Columns[e.ColumnIndex].Name == "colDiscountAmount")
            //    //{
            //    //    for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            //    //    {
            //    //        OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colDiscountAmount"].Value);
            //    //    }
            //    //    txtTotalAmount.Text = OldValue.ToString();                    
            //    //    OldValue = 0;
            //    //}
            //    //for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            //    //{
            //    //    OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
            //    //}
            //    //txtTotalAmount.Text = OldValue.ToString();
            //    //OldValue = 0;

            //    //DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisAmount"].Value) * Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value);  
            //}
            //else if (e.ColumnIndex == 12)
            //{
            //    DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) * (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value))) - Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisAmount"].Value); 
            //}
            else if (e.ColumnIndex == 11)
            {
                DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) *
                    Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            }
            else if (e.ColumnIndex == 12)
            {
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
                }
                txtTotalAmount.Text = OldValue.ToString();
                //if (IsImport)
                //{
                //    txtVat.Text = "0";
                //    txtVatAmount.Text = "0";                    
                //}
                //else
                //{
                //    txtVat.Text = ((Validation.GetSafeDecimal(txtTotalAmount.Text) * 5) / 100).ToString();
                //    txtVatAmount.Text = (Validation.GetSafeDecimal(txtTotalAmount.Text) + Validation.GetSafeDecimal(txtVat.Text)).ToString();
                //}
                OldValue = 0;
                //if (Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdBuild"].Value) == 0)
                //{
                //    txtDescription.AppendText(DgvSaleInvoice.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[5].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[7].Value.ToString() + " Units" + "@" + DgvSaleInvoice.Rows[e.RowIndex].Cells[9].Value.ToString() + Environment.NewLine);
                //    DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdBuild"].Value = 1;
                //}
            }
            //txtDescription.Lines.FirstOrDefault().Remove(0);
            //else if (e.ColumnIndex == 8)
            //{
            //    for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            //    {
            //        OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colDisAmount"].Value);
            //    }
            //    txtTotalAmount.Text = OldValue.ToString();
            //    OldValue = 0;
            //}
        }
        private void DgvSaleInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                //var manager = new ItemsBLL();
                //DgvSaleInvoice.Rows[e.RowIndex].Cells["colCurrentStock"].Value = manager.GetItemCurrentTotalQuantity(Validation.GetSafeGuid(DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdItem"].Value)
                //    , Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colPackingSize"].Value), 
                //    Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colBatchNo"].Value), Operations.IdCompany); 
            }
            else if (e.ColumnIndex == 10)
            {
                if (cbxSaleType.SelectedIndex != 3)
                {
                    if (Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) >
                        Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colCurrentStock"].Value))
                    {
                        MessageBox.Show("Quantity is Exceeding Than Current Stock");
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value = "";
                        return;
                    }
                }
                //try
                //{
                //    var manager = new ItemsBLL();
                //    //Int64 TotalQuantity = manager.GetItemTotalQuantity(Validation.GetSafeGuid(DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdItem"].Value), Operations.IdCompany);
                //    Int64 TotalQuantity = manager.GetDateWiseItemTotalQuantity(Validation.GetSafeGuid(DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdItem"].Value), Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colPackingSize"].Value), Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colBatchNo"].Value), VDate.Value, Operations.IdCompany);
                //    if (TotalQuantity < 0 || TotalQuantity == 0)
                //    {
                //        if (MessageBox.Show("Quantity Not Available for the Product '" + DgvSaleInvoice.Rows[e.RowIndex].Cells["colItemName"].Value + "' for the Voucher No : '" + InvEditBox.Text + "' Dated : " + VDate.Value.ToShortDateString() + Environment.NewLine + "Do You Want To Continue ?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                //        {
                //            DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value = string.Empty;
                //            return;
                //        }
                //        else
                //        {
                //            DgvSaleInvoice.CurrentRow.Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value) * Validation.GetSafeLong(DgvSaleInvoice.CurrentRow.Cells[e.ColumnIndex].Value);
                //        }
                //    }
                //    else if (Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > TotalQuantity)
                //    {
                //        if (MessageBox.Show("Quantity Exceeds Stock Limit" + Environment.NewLine + "Do You Want To Continue ?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                //        {
                //            DgvSaleInvoice.CurrentCell.Selected = true;
                //            DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value = string.Empty;
                //            return;
                //        }
                //        else
                //        {
                //            DgvSaleInvoice.CurrentRow.Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value) * Validation.GetSafeLong(DgvSaleInvoice.CurrentRow.Cells[e.ColumnIndex].Value);
                //        }
                //    }
                //    else
                //    {
                //        DgvSaleInvoice.CurrentRow.Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value) * Validation.GetSafeLong(DgvSaleInvoice.CurrentRow.Cells[e.ColumnIndex].Value);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Problem Occured While Getting Stock Quantity Information...");
                //}
            }
            else if (e.ColumnIndex == 11)
            {
                DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) *
                    Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            }
            else if (e.ColumnIndex == 12)
            {
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
                }
                txtTotalAmount.Text = OldValue.ToString();
                OldValue = 0;
            }           
        }
        private bool ValidateRows()
        {
            bool Status = true;
            if (DgvSaleInvoice.Rows.Count > 1)
            {
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    if (DgvSaleInvoice.Rows[i].Cells["colItemNo"].Value == null)
                    {
                        Status = false;
                    }
                    else if (DgvSaleInvoice.Rows[i].Cells["colIdItem"].Value == null)
                    {
                        Status = false;
                    }
                    else if (DgvSaleInvoice.Rows[i].Cells["colQty"].Value == null)
                    {
                        Status = false;
                    }
                }
            }
            else if (DgvSaleInvoice.Rows.Count == 1)
            {
                Status = false;
            }
            return Status;
        }
        private bool ValidateControls()
        {
            if (CustEditBox.Text == string.Empty)
            {
                lblStatuMessage.Text = "Customer Name Missing...";
                return false;
            }
            if (CustomerAccountNo == string.Empty)
            {
                lblStatuMessage.Text = "Customer Account Missing...";
                return false;
            }
            if (SalesAccountNo == string.Empty)
            {
                lblStatuMessage.Text = "Sales Account Missing...";
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<VoucherDetailEL> oelSaleCollection = new List<VoucherDetailEL>();
            //List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelCostOfSalesCollection = new List<VoucherDetailEL>();
            ListToUpdateStock = new List<PurchaseDetailEL>();
            ListToCheck = new List<PurchaseDetailEL>();
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    #region Voucher Entry
                    /// Add Voucher...
                    VouchersEL oelVoucher = new VouchersEL();
                    if (IdVoucher == Guid.Empty)
                    {
                        oelVoucher.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelVoucher.IdVoucher = IdVoucher;
                    }
                    oelVoucher.IdCompany = Operations.IdCompany;
                    oelVoucher.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                    oelVoucher.SampleNo = Validation.GetSafeLong(txtSampleNo.Text);
                    oelVoucher.IdUser = Operations.UserID;
                    oelVoucher.Date = VDate.Value;
                    oelVoucher.AccountNo = CustomerAccountNo;
                    oelVoucher.LinkAccountNo = LinkAccountNo;
                    oelVoucher.SubAccountNo = MakerAccountNo == null ? "" : MakerAccountNo;
                    oelVoucher.Description = txtDescription.Text;
                    oelVoucher.VehicalNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelVoucher.MemoSaleNo = Validation.GetSafeLong(txtSaleMemoNo.Text == "" ? "0" : txtSaleMemoNo.Text);
                    oelVoucher.OutWardGatePassNo = Validation.GetSafeString(txtGatePass.Text);
                    oelVoucher.Amount = Validation.GetSafeDecimal(txtTotalAmount.Text);
                    if (cbxSeller.SelectedIndex == 0 || cbxSeller.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select Seller ....");
                        return;
                    }
                    else
                    {
                        oelVoucher.Seller = cbxSeller.SelectedIndex;
                    }
                    if (cbxSaleType.SelectedIndex == 0 || cbxSaleType.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select Sale Type ....");
                        return;
                    }
                    else
                    {
                        oelVoucher.SaleType = cbxSaleType.SelectedIndex;
                    }
                    // oelVoucher.VAT = Validation.GetSafeDecimal(txtVat.Text);
                    //oelVoucher.VATAmount = Validation.GetSafeDecimal(txtVatAmount.Text);
                    oelVoucher.Transactiondays = Validation.GetSafeLong(txtCreditDays.Text);
                    oelVoucher.IsImport = IsImport;
                    oelVoucher.IsRecieved = false;
                    //oelVoucher.Discount = Validation.GetSafeDecimal(txtDiscount.Text  == "" ? "0" : txtDiscount.Text);
                    //oelVoucher.TotalDiscount = Validation.GetSafeDecimal(txtTotalDiscount.Text == "" ? "0" : txtTotalDiscount.Text);
                    //oelVoucher.NetSaleAmount = Validation.GetSafeDecimal(txtNetSale.Text);
                    oelVoucher.Posted = chkPosted.Checked;
                    #endregion
                    #region Add Items In Sales Detail
                    for (int j = 0; j < DgvSaleInvoice.Rows.Count - 1; j++)
                    {
                        //SaleDetailEL oelSaleDetail = new SaleDetailEL();
                        VoucherDetailEL oelSaleDetail = new VoucherDetailEL();

                        if (DgvSaleInvoice.Rows[j].Cells["colSale"].Value != null)
                        {
                            oelSaleDetail.IdVoucherDetail = Validation.GetSafeGuid(DgvSaleInvoice.Rows[j].Cells["colSale"].Value);
                            oelSaleDetail.IsNew = false;
                        }
                        else
                        {
                            oelSaleDetail.IdVoucherDetail = Guid.NewGuid();
                            oelSaleDetail.IsNew = true;
                        }
                        oelSaleDetail.Seq = j + 1;

                        oelSaleDetail.IdVoucher = oelVoucher.IdVoucher;
                        oelSaleDetail.IdItem = Validation.GetSafeGuid(DgvSaleInvoice.Rows[j].Cells["colIdItem"].Value);
                        oelSaleDetail.IdArticle = Validation.GetSafeGuid(DgvSaleInvoice.Rows[j].Cells["colIdArticle"].Value);
                        oelSaleDetail.PackingSize = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colPackingSize"].Value);
                        if (Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colMakerAccountNo"].Value) == "")
                            oelSaleDetail.AccountNo = "-1";
                        else
                        {
                            oelSaleDetail.AccountNo = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colMakerAccountNo"].Value);
                        }
                        //oelSaleDetail.BatchNo = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colBatchNo"].Value);
                        //oelSaleDetail.Expiry = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colExpiry"].Value);             
                        oelSaleDetail.CurrentStock = Validation.GetSafeLong(DgvSaleInvoice.Rows[j].Cells["colCurrentStock"].Value);
                        oelSaleDetail.TotalCartons = 0;//Validation.GetSafeLong(DgvSaleInvoice.Rows[j].Cells["colCartons"].Value);
                        oelSaleDetail.Discription = "N/A"; //Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colNarration"].Value);
                        oelSaleDetail.ItemNo = DgvSaleInvoice.Rows[j].Cells["colItemNo"].Value.ToString();
                        oelSaleDetail.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        //if (DgvSaleInvoice.Rows[i].Cells["colRemarks"].Value == null)
                        //{
                        //    oelTransaction.Description = "";
                        //}
                        //else
                        //{
                        //    oelTransaction.Description = DgvSaleInvoice.Rows[i].Cells["colRemarks"].Value.ToString();
                        //}

                        oelSaleDetail.Units = Validation.GetSafeInteger(DgvSaleInvoice.Rows[j].Cells["colQty"].Value);
                        // oelTransaction.Credit = Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colDiscountAmount"].Value);
                        //oelTransaction.Credit = CalculateCost(oelTransaction.AccountNo, DgvSaleInvoice.Rows[i]);
                        //oelSaleDetail.Amount = Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colDiscountAmount"].Value);
                        oelSaleDetail.Amount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colAmount"].Value);
                        oelSaleDetail.Discount = 0;
                        oelSaleDetail.DiscountAmount = 0;
                        //oelSaleDetail.Amount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colDiscountAmount"].Value);

                        oelSaleDetail.UnitPrice = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colUnitPrice"].Value);
                        oelSaleCollection.Add(oelSaleDetail);
                    }
                    #endregion
                    #region Add Customer In Transactions

                    TransactionsEL oelCustomerTransaction = new TransactionsEL();
                    if (CustomerTransactionId != Guid.Empty)
                    {
                        oelCustomerTransaction.TransactionID = CustomerTransactionId;
                        oelCustomerTransaction.IsNew = false;
                    }
                    else
                    {
                        oelCustomerTransaction.TransactionID = Guid.NewGuid();
                        oelCustomerTransaction.IsNew = true;
                    }
                    oelCustomerTransaction.IdCompany = Operations.IdCompany;
                    oelCustomerTransaction.AccountNo = CustomerAccountNo;
                    oelCustomerTransaction.LinkAccountNo = "";
                    oelCustomerTransaction.SubAccountNo = "";
                    oelCustomerTransaction.Date = VDate.Value;
                    oelCustomerTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelCustomerTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                    oelCustomerTransaction.VoucherType = "SaleInvoiceVoucher";
                    oelCustomerTransaction.AdjustmentType = -1;
                    oelCustomerTransaction.SettlementType = "Sale To Customer";
                    oelCustomerTransaction.Description = txtDescription.Text;//BuildRemarks(); 
                    //if (IsImport)
                    {
                        oelCustomerTransaction.Debit = Validation.GetSafeDecimal(txtTotalAmount.Text);
                    }
                    ///else
                    {
                        //oelCustomerTransaction.Debit = Validation.GetSafeDecimal(txtVatAmount.Text);
                    }
                    oelCustomerTransaction.Credit = 0;
                    oelCustomerTransaction.TransactionType = "Dr";

                    //if (txtCashReceipt.Text == string.Empty)
                    //{
                    //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    //}
                    //else
                    //{
                    //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtCashReceipt.Text);
                    //}
                    oelCustomerTransaction.Posted = chkPosted.Checked;
                    oelTransactionCollection.Add(oelCustomerTransaction);
                    #endregion
                    #region Add Sales Account In Transactions
                    /// Add Sales Account...
                    TransactionsEL oelSaleTransaction = new TransactionsEL();
                    if (SalesTransactionId != Guid.Empty)
                    {
                        oelSaleTransaction.TransactionID = SalesTransactionId;
                        oelSaleTransaction.IsNew = false;
                    }
                    else
                    {
                        oelSaleTransaction.TransactionID = Guid.NewGuid();
                        oelSaleTransaction.IsNew = true;
                    }
                    oelSaleTransaction.IdCompany = Operations.IdCompany;
                    //oelSaleTransaction.AccountNo = Validation.GetSafeLong(SalesEditBox.Text);
                    oelSaleTransaction.AccountNo = SalesAccountNo;
                    oelSaleTransaction.LinkAccountNo = LinkAccountNo;
                    oelSaleTransaction.SubAccountNo = "";
                    oelSaleTransaction.Date = VDate.Value;
                    oelSaleTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelSaleTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                    oelSaleTransaction.VoucherType = "SaleInvoiceVoucher";
                    oelSaleTransaction.AdjustmentType = -1;
                    oelSaleTransaction.SettlementType = "Sale To Customer";
                    oelSaleTransaction.Description = oelCustomerTransaction.Description; //txtDescription.Text;
                    oelSaleTransaction.Debit = 0;
                    //if (IsImport)
                    {
                        oelSaleTransaction.Credit = Validation.GetSafeDecimal(txtTotalAmount.Text);
                        oelSaleTransaction.TransactionType = "Cr";
                    }
                    //else
                    {
                        //oelSaleTransaction.Credit = Validation.GetSafeDecimal(txtVatAmount.Text);
                    }
                    //if (txtCashReceipt.Text == string.Empty)
                    //{
                    //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    //}
                    //else
                    //{
                    //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtCashReceipt.Text);
                    //}
                    oelSaleTransaction.Posted = chkPosted.Checked;
                    oelTransactionCollection.Add(oelSaleTransaction);
                    #endregion region
                    #region Add Cost of Sales Transactions
                    for (int j = 0; j < DgvSalesAccounts.Rows.Count - 1; j++)
                    {
                        VoucherDetailEL oelVoucherDetail = new VoucherDetailEL();
                        TransactionsEL oelCostofSalesTransaction = new TransactionsEL();
                        oelVoucherDetail.IdVoucher = oelVoucher.IdVoucher;
                        oelCostofSalesTransaction.IdVoucher = oelVoucher.IdVoucher;
                        if (DgvSalesAccounts.Rows[j].Cells["ColIdDetailVoucher"].Value != null)
                        {
                            oelVoucherDetail.IdVoucherDetail = new Guid(DgvSalesAccounts.Rows[j].Cells["ColIdDetailVoucher"].Value.ToString());
                            oelVoucherDetail.IsNew = false;
                            oelCostofSalesTransaction.TransactionID = oelVoucherDetail.IdVoucherDetail.Value; //Validation.GetSafeGuid(DgvPurchases.Rows[i].Cells["ColTransaction"].Value);
                            oelCostofSalesTransaction.IsNew = false;
                        }
                        else
                        {
                            oelVoucherDetail.IdVoucherDetail = Guid.NewGuid();
                            oelVoucherDetail.IsNew = true;
                            oelCostofSalesTransaction.TransactionID = oelVoucherDetail.IdVoucherDetail.Value;
                            oelCostofSalesTransaction.IsNew = true;

                        }
                        oelVoucherDetail.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        oelCostofSalesTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        oelCostofSalesTransaction.IdCompany = Operations.IdCompany;
                        if (DgvSalesAccounts.Rows[j].Cells["colDescription"].Value == null)
                        {
                            oelVoucherDetail.Description = "N/A";
                        }
                        else
                        {
                            oelVoucherDetail.Description = DgvSalesAccounts.Rows[j].Cells["colDescription"].Value.ToString();
                        }
                        oelVoucherDetail.Seq = j + 1;
                        oelVoucherDetail.Units = 0;
                        oelVoucherDetail.IdAccount = Validation.GetSafeGuid(DgvSalesAccounts.Rows[j].Cells["colIdAccount"].Value);
                        oelVoucherDetail.AccountNo = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colAccountNo"].Value);
                        oelVoucherDetail.LinkAccountNo = "";
                        if (oelVoucherDetail.Debit != 0)
                        {
                            oelVoucherDetail.LinkAccountNo = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colLinkAccount"].Value);
                        }
                        oelVoucherDetail.Debit = Validation.GetSafeDecimal(DgvSalesAccounts.Rows[j].Cells["colDebit"].Value);
                        oelVoucherDetail.Credit = Validation.GetSafeDecimal(DgvSalesAccounts.Rows[j].Cells["colCredit"].Value);
                        oelCostofSalesTransaction.AccountNo = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colAccountNo"].Value);
                        oelCostofSalesTransaction.LinkAccountNo = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colLinkAccount"].Value);
                        oelCostofSalesTransaction.SubAccountNo = "0";
                        oelCostofSalesTransaction.Date = VDate.Value;
                        oelCostofSalesTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        oelCostofSalesTransaction.VoucherType = "SaleInvoiceVoucher/Sub";
                        oelCostofSalesTransaction.Description = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colDescription"].Value);
                        oelCostofSalesTransaction.Debit = Validation.GetSafeDecimal(DgvSalesAccounts.Rows[j].Cells["colDebit"].Value);
                        oelCostofSalesTransaction.Credit = Validation.GetSafeDecimal(DgvSalesAccounts.Rows[j].Cells["colCredit"].Value);

                        if (DgvSalesAccounts.Rows[j].Cells["colDebit"].Value != null && Validation.GetSafeLong(DgvSalesAccounts.Rows[j].Cells["colDebit"].Value) > 0)
                        {
                            oelCostofSalesTransaction.TransactionType = "Dr";
                        }
                        if (DgvSalesAccounts.Rows[j].Cells["colCredit"].Value != null && Validation.GetSafeLong(DgvSalesAccounts.Rows[j].Cells["colCredit"].Value) > 0)
                        {
                            oelCostofSalesTransaction.TransactionType = "Cr";
                        }
                        oelCostofSalesTransaction.Posted = chkPosted.Checked;

                        oelCostOfSalesCollection.Add(oelVoucherDetail);
                        oelTransactionCollection.Add(oelCostofSalesTransaction);

                    }
                    #endregion
                    #region Comments
                    //    if (CashEditBox.Text == string.Empty)
                    //    {
                    //        lblStatuMessage.Text = "Choose Cash Account :";
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        TransactionsEL oeCashTransaction = new TransactionsEL();
                    //        oeCashTransaction.TransactionID = Guid.NewGuid();
                    //        oeCashTransaction.AccountNo = CashEditBox.Text;
                    //        oeCashTransaction.Date = VDate.Value;
                    //        oeCashTransaction.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                    //        oeCashTransaction.VoucherType = "SaleInvoiceVoucher";
                    //        oeCashTransaction.Description = txtDescription.Text;
                    //        oeCashTransaction.Amount = Convert.ToDecimal(txtCashReceipt.Text);
                    //        oelTransactionCollection.Add(oeCashTransaction);            
                    //    }
                    //}
                    // Add Sales
                    //if (SalesEditBox.Text == string.Empty)
                    //{
                    //    lblStatuMessage.Text = "Choose Sales Account";
                    //    return;
                    //}
                    //else
                    //{
                    //    TransactionsEL oeSalesTransaction = new TransactionsEL();
                    //    oeSalesTransaction.AccountNo = SalesEditBox.Text;
                    //    oeSalesTransaction.TransactionID = Guid.NewGuid();
                    //    oeSalesTransaction.Date = VDate.Value;
                    //    oeSalesTransaction.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                    //    oeSalesTransaction.VoucherType = "SaleInvoiceVoucher";
                    //    oeSalesTransaction.Description = txtDescription.Text;
                    //    oeSalesTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    //    oelTransactionCollection.Add(oeSalesTransaction);
                    //}
                    // Add Cost Of Goods Sold
                    //if (CostOfGoodSoldEditBox.Text == string.Empty)
                    //{
                    //    lblStatuMessage.Text = "Choose Cost Of Goods Sold Accounts";
                    //    return;
                    //}
                    //else
                    //{
                    //    TransactionsEL CostofGoodsTransaction = new TransactionsEL();
                    //    CostofGoodsTransaction.TransactionID = Guid.NewGuid();
                    //    CostofGoodsTransaction.AccountNo = CostOfGoodSoldEditBox.Text;
                    //    CostofGoodsTransaction.Date = VDate.Value;
                    //    CostofGoodsTransaction.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                    //    CostofGoodsTransaction.VoucherType = "SaleInvoiceVoucher";
                    //    CostofGoodsTransaction.Description = txtDescription.Text;
                    //    CostofGoodsTransaction.Amount = CostOfGoodsSoldAmount;
                    //    oelTransactionCollection.Add(CostofGoodsTransaction);

                    //}            
                    #endregion
                    #region Saving Code
                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new SalesHeadBLL(); // SalesVoucherBLL();
                        //if (manager.InsertSales(oelVoucher, oelSaleCollection, oelTransactionCollection, oelStockReceiptCollection) == true)
                        var VManager = new VoucherBLL();
                        if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(InvEditBox.Text), "SaleInvoiceVoucher") == false)
                        {
                            if (manager.InsertSales(oelVoucher, oelSaleCollection, oelCostOfSalesCollection, oelTransactionCollection) == true)
                            {
                                //manager.UpdateStockitems(oelTransactionCollection, "Add");
                                lblStatuMessage.Text = "Sales Transaction Successfully...";
                                if (IsSampleSale)
                                {
                                    manager.UpdateSamplesHeadForSales(IdSampleVoucher, true);
                                }
                                ClearControl();
                                FillData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Voucher No Already Exists ; Plz Change Voucher No :");
                        }
                    }
                    else
                    {
                        var manager = new SalesHeadBLL(); // SalesVoucherBLL();
                        //if (manager.UpdateSales(oelVoucher, oelSaleCollection, oelTransactionCollection, oelStockReceiptCollection) == true)
                        if (manager.UpdateSales(oelVoucher, oelSaleCollection, oelCostOfSalesCollection, oelTransactionCollection) == true)
                        {
                            //manager.UpdateStockitems(oelTransactionCollection, "Add");
                            lblStatuMessage.Text = "Sales Transaction Successfully...";
                            if (IsSampleSale)
                            {
                                manager.UpdateSamplesHeadForSales(IdSampleVoucher, true);
                            }
                            ClearControl();
                            FillData();
                        }
                    }
                    #endregion
                }
                else
                {
                    lblStatuMessage.Text = "Customer Missing...";
                    lblStatuMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                lblStatuMessage.Text = "InComplete Entry";
                lblStatuMessage.ForeColor = Color.Red;
            }
        }
        private string BuildRemarks()
        {
            string Remarks = "";
            string First = txtDescription.Text + "*";
            for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            {
                Remarks += DgvSaleInvoice.Rows[i].Cells[3].Value.ToString() + " "
                    + DgvSaleInvoice.Rows[i].Cells[4].Value.ToString() + DgvSaleInvoice.Rows[i].Cells[7].Value.ToString() +
                     " @" + DgvSaleInvoice.Rows[i].Cells[8].Value.ToString() + "*";
            }
            First += Remarks;
            return First;
        }
        private void ClearControl()
        {
            DgvSaleInvoice.Rows.Clear();
            cbxSeller.SelectedIndex = 0;
            cbxSaleType.SelectedIndex = 0;
            IdVoucher = Guid.Empty;
            IdSampleVoucher = Guid.Empty;
            InvEditBox.Enabled = true;
            if (IsSampleSale)
            {
                txtSampleNo.Text = string.Empty;
                IsSampleSale = false;
            }
            //txtDescription.Text = string.Empty;
            InvoiceNo = 0;
            SampleNo = 0;
            txtSaleMemoNo.Text = string.Empty;
            lblStatuMessage.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            //txtVat.Text = string.Empty;
            //txtVatAmount.Text = string.Empty;
            txtCreditDays.Text = string.Empty;
            //txtDiscount.Text = string.Empty;
            //txtTotalDiscount.Text = string.Empty;
            //txtNetSale.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtNTN.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtGatePass.Text = string.Empty;
            CustEditBox.Text = string.Empty;

            //txtCashReceipt.Text = string.Empty;
            CustomerTransactionId = Guid.Empty;
            SalesTransactionId = Guid.Empty;
            cbxNaturalAccounts.SelectedIndex = 0;
            CustomerAccountNo = string.Empty;
            SalesAccountNo = string.Empty;
            MakerAccountNo = string.Empty;
            SalesEditBox.Text = string.Empty;


            IsNewInvoice = true;
            CustEditBox.Text = string.Empty;
            ListToUpdateStock = null;
            ListToCheck = null;
            CostOfGoodsSoldAmount = 0;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            CustEditBox.Focus();
            cbxNaturalAccounts.SelectedIndex = 1;
            cbxSeller.SelectedIndex = 1;
            cbxSaleType.SelectedIndex = 1;
        }
        private decimal CalculateCost(string ItemNo, DataGridViewRow Row)
        {
            Int64 qty = 0;
            Int64 remaining = 0;
            decimal Amount = 0;
            var manager = new ItemsBLL();
            // List<StockReceiptEL> list = manager.GetStockByItemNo(Row.Cells["colItem"].Value.ToString());
            List<PurchaseDetailEL> list = manager.GetStockByItemNo(Row.Cells["colItemNo"].Value.ToString());
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    PurchaseDetailEL oelPurchaseDetail = new PurchaseDetailEL();
                    PurchaseDetailEL oelPurchaseCheck = new PurchaseDetailEL();

                    qty = item.RemainingUnits;
                    //if (Convert.ToInt64(Row.Cells["colQty"].Value) == item.Units)
                    if (Convert.ToInt64(Row.Cells["colQty"].Value) == item.RemainingUnits)
                    {
                        if (remaining > 0)
                        {
                            remaining += qty;
                            oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                            if (qty > remaining)
                            {
                                oelPurchaseDetail.RemainingUnits = qty - remaining;
                            }
                            else
                            {
                                oelPurchaseDetail.RemainingUnits = remaining - qty;
                                Amount = Amount + (qty - oelPurchaseDetail.RemainingUnits) * (item.Amount / oelPurchaseDetail.RemainingUnits);
                            }
                            oelPurchaseDetail.Amount = item.Amount;
                            //Amount = Amount + (item.RemainingUnits - oelPurchaseDetail.Units) * (item.Amount / item.RemainingUnits);
                            //Amount = Amount + (qty - oelPurchaseDetail.RemainingUnits) * (item.Units / oelPurchaseDetail.RemainingUnits);
                            ListToUpdateStock.Add(oelPurchaseDetail);
                            remaining = 0;
                            break;
                        }
                        else
                        {
                            oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                            //oelPurchaseDetail.RemainingUnits = qty - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseDetail.RemainingUnits = qty - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseCheck.RemainingUnits = item.RemainingUnits;
                            oelPurchaseDetail.Amount = item.Amount;
                            //Amount = Amount + (oelPurchaseDetail.RemainingUnits) * (item.Amount / item.RemainingUnits);
                            Amount = Amount + (qty * item.UnitPrice);
                            oelPurchaseCheck.Amount = Amount;
                            ListToCheck.Add(oelPurchaseCheck);
                            ListToUpdateStock.Add(oelPurchaseDetail);

                            break;
                        }
                    }
                    else if (item.RemainingUnits > Convert.ToInt64(Row.Cells["colQty"].Value))
                    {
                        if (remaining > 0)
                        {
                            remaining += qty;
                            oelPurchaseDetail.RemainingUnits = remaining - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                            oelPurchaseDetail.Amount = item.Amount;
                            oelPurchaseCheck.RemainingUnits = item.RemainingUnits - oelPurchaseDetail.RemainingUnits;
                            Amount = Amount + (item.RemainingUnits - oelPurchaseDetail.RemainingUnits) * (item.Amount / item.Units);
                            oelPurchaseCheck.Amount = Amount;
                            ListToCheck.Add(oelPurchaseCheck);
                            ListToUpdateStock.Add(oelPurchaseDetail);
                            remaining = 0;
                            break;
                        }
                        else
                        {
                            oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                            //oelPurchaseDetail.RemainingUnits = qty - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseDetail.RemainingUnits = qty - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseDetail.Amount = item.Amount;
                            oelPurchaseCheck.RemainingUnits = item.RemainingUnits;
                            // Amount = Amount + (oelPurchaseDetail.RemainingUnits) * (item.Amount / item.RemainingUnits);
                            Amount = Amount + (Convert.ToInt64(Row.Cells["colQty"].Value)) * (item.Amount / item.Units);
                            oelPurchaseCheck.Amount = Amount;
                            ListToCheck.Add(oelPurchaseCheck);
                            ListToUpdateStock.Add(oelPurchaseDetail);
                            break;
                        }
                    }
                    else if (item.RemainingUnits < Convert.ToInt64(Row.Cells["colQty"].Value))
                    {
                        remaining += qty;
                        if (remaining < Convert.ToInt64(Row.Cells["colQty"].Value))
                        {
                            oelPurchaseDetail.RemainingUnits = item.RemainingUnits - qty;
                            Amount = Amount + (remaining) * (item.Amount / item.RemainingUnits);
                        }
                        else if (remaining == Convert.ToInt64(Row.Cells["colQty"].Value))
                        {
                            oelPurchaseDetail.RemainingUnits = item.RemainingUnits - qty;
                            //Amount = Amount + (Convert.ToInt64(Row.Cells["colQty"].Value)) * (item.Amount / item.RemainingUnits);
                            Amount = Amount + (qty * item.UnitPrice);
                        }
                        else if (remaining > Convert.ToInt64(Row.Cells["colQty"].Value))
                        {
                            oelPurchaseDetail.RemainingUnits = remaining - Convert.ToInt64(Row.Cells["colQty"].Value);
                            Amount = Amount + (Convert.ToInt64(Row.Cells["colQty"].Value) - qty) * (item.Amount / item.RemainingUnits);
                        }
                        oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                        oelPurchaseCheck.RemainingUnits = item.RemainingUnits;
                        oelPurchaseDetail.Amount = item.Amount;
                        // Amount = Amount + (oelPurchaseDetail.RemainingUnits) * (item.Amount / item.RemainingUnits);
                        //Amount = Amount +  (item.Amount / item.RemainingUnits);
                        oelPurchaseCheck.Amount = Amount;
                        ListToUpdateStock.Add(oelPurchaseDetail);
                        ListToCheck.Add(oelPurchaseCheck);
                        if (ListToCheck.Sum(x => x.RemainingUnits) == Convert.ToInt64(Row.Cells["colQty"].Value))
                        {
                            remaining = 0;
                            break;
                        }
                    }
                }
            }
            return Amount;
        }
        private void CashEditBox_ClickButton(object sender, EventArgs e)
        {
            CommandType = "Cash";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void SalesEditBox_ButtonClick(object sender, EventArgs e)
        {
            CommandType = "Sales";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void CostOfGoodSoldEditBox_ClickButton(object sender, EventArgs e)
        {
            CommandType = "CostOfGoodsSold";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InvEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = "SaleInvoiceVoucher";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            var manager = new SalesDetailBLL();
            if (oelVoucher != null)
            {
                InvoiceNo = oelVoucher.VoucherNo;
                InvEditBox.Text = oelVoucher.VoucherNo.ToString();
                IdVoucher = oelVoucher.IdVoucher;

                IsNewInvoice = false;

                FillVoucher();
            }
        }
        private void InvEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher();
                }
            }
            else
                e.Handled = true;
        }
        private void FillVoucher()
        {
            var Manager = new VoucherBLL();
            var SalesManager = new SalesDetailBLL();
            VoucherType = "SaleInvoiceVoucher";
            if (InvEditBox.Text != string.Empty)
            {
                List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(InvEditBox.Text));
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VDate.Value = list[0].Date;
                    InvEditBox.Enabled = false;
                    txtDescription.Text = list[0].Description;
                    txtSaleMemoNo.Text = list[0].MemoSaleNo.ToString();
                    txtGatePass.Text = list[0].OutWardGatePassNo;
                    txtSampleNo.Text = list[0].SampleNo.ToString();
                    txtCreditDays.Text = list[0].Transactiondays.ToString();
                    cbxSeller.SelectedIndex = list[0].Seller;
                    cbxSaleType.SelectedIndex = list[0].SaleType;
                    //ResizeColumns(cbxSaleType.SelectedIndex);
                    if (list[0].SubAccountNo != null && list[0].SubAccountNo != "")
                    {
                        FillEmployee(list[0].SubAccountNo, list[0].PersonName);
                    }
                    if (list[0].Posted)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                            chkPosted.Enabled = false;
                        }
                        chkPosted.Checked = list[0].Posted;
                        lblStatuMessage.Text = "Posted Voucher ...";
                        lblStatuMessage.ForeColor = Color.Red;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    if (!string.IsNullOrEmpty(list[0].VehicalNo))
                    {
                        cbxVehicles.Visible = true;
                        cbxVehicles.SelectedIndex = cbxVehicles.Items.IndexOf(list[0].VehicalNo);
                    }
                    else
                    {
                        cbxVehicles.Visible = false;
                    }
                    List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "SaleInvoiceVoucher", Operations.IdCompany);

                    if (listTransactions.Count > 0)
                    {
                        TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Credit != 0);
                        if (oelSalesTransaction != null)
                        {
                            //SalesEditBox.Text = oelSalesTransaction.AccountNo.ToString();
                            FillNaturalAccounts(oelSalesTransaction.AccountNo.ToString());
                            cbxNaturalAccounts.SelectedValue = oelSalesTransaction.AccountNo.ToString();
                            SalesTransactionId = oelSalesTransaction.TransactionID;
                        }
                    }
                    List<TransactionsEL> listSalesExpense = Manager.GetTransactions(IdVoucher, "SaleInvoiceVoucher/Sub", Operations.IdCompany);
                    if (listSalesExpense.Count > 0)
                    {
                        FillSalesExpenses(listSalesExpense);
                    }
                    else
                    {
                        DgvSaleInvoice.Rows.Clear();
                    }
                    List<PersonsEL> ListCustomer = Manager.GetSaleCustomer(IdVoucher, list[0].AccountNo, Operations.IdCompany);
                    if (ListCustomer.Count > 0)
                    {
                        CustEditBox.Text = ListCustomer[0].PersonName;
                        CustomerAccountNo = ListCustomer[0].AccountNo;
                        CustomerTransactionId = ListCustomer[0].PAccountId;
                        txtContact.Text = ListCustomer[0].Contact;
                        txtNTN.Text = ListCustomer[0].NTN;
                        txtAddress.Text = ListCustomer[0].Address;
                    }

                    List<VoucherDetailEL> SalesList = SalesManager.GetSaleWithInvoiceNumber(Validation.GetSafeLong(InvEditBox.Text), Operations.IdCompany);
                    FillSalesTransaction(SalesList, ListCustomer[0].Balance);
                }
                else
                {
                    ClearControl();
                    MessageBox.Show("Voucher Number Not Found ...");
                }
            }


        }
        private void FillEmployee(string EmpCode, string MakerName)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", EmpCode);
            if (list.Count > 0)
            {
                MakerAccountNo = EmpCode;
            }
            else
            {
                MakerAccountNo = EmpCode;
            }
        }
        private void FillSalesTransaction(List<VoucherDetailEL> Salelist, decimal Amount)
        {
            var manager = new ItemsBLL();

            if (DgvSaleInvoice.Rows.Count > 0)
            {
                DgvSaleInvoice.Rows.Clear();
            }
            for (int i = 0; i < Salelist.Count; i++)
            {
                DgvSaleInvoice.Rows.Add();
                DgvSaleInvoice.Rows[i].Cells[0].Value = Salelist[i].IdVoucherDetail;
                DgvSaleInvoice.Rows[i].Cells[1].Value = Salelist[i].IdItem;
                DgvSaleInvoice.Rows[i].Cells[2].Value = Salelist[i].IdArticle;
                DgvSaleInvoice.Rows[i].Cells[3].Value = Salelist[i].AccountNo;
                DgvSaleInvoice.Rows[i].Cells[4].Value = Salelist[i].ItemNo;
                DgvSaleInvoice.Rows[i].Cells[5].Value = Salelist[i].ItemName; //manager.GetItemByAccount(Validation.GetSafeLong(Salelist[i].ItemNo), Operations.IdCompany).ItemName;
                DgvSaleInvoice.Rows[i].Cells[6].Value = Salelist[i].ArticleName;
                DgvSaleInvoice.Rows[i].Cells[7].Value = Salelist[i].AccountName;
                DgvSaleInvoice.Rows[i].Cells[8].Value = Salelist[i].PackingSize;
                DgvSaleInvoice.Rows[i].Cells[9].Value = Salelist[i].CurrentStock;

                DgvSaleInvoice.Rows[i].Cells[10].Value = Salelist[i].Units;
                DgvSaleInvoice.Rows[i].Cells[11].Value = Salelist[i].UnitPrice;
                DgvSaleInvoice.Rows[i].Cells[12].Value = Salelist[i].Amount;
                //if (Salelist[i].Discount > 0)
                //{
                //    DgvSaleInvoice.Rows[i].Cells[9].Value = Salelist[i].Discount;
                //    DgvSaleInvoice.Rows[i].Cells[10].Value = Convert.ToDecimal(Salelist[i].Units * Salelist[i].UnitPrice) - (Convert.ToDecimal(Salelist[i].Units * Salelist[i].UnitPrice) * Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells[9].Value) / 100);

                //}
                //else
                //{
                //    DgvSaleInvoice.Rows[i].Cells[9].Value = Salelist[i].Discount;
                //    DgvSaleInvoice.Rows[i].Cells[10].Value = DgvSaleInvoice.Rows[i].Cells[8].Value;
                //}
                //DgvSaleInvoice.Rows[i].Cells[9].Value = Salelist[i].Description;
                ////DgvSaleInvoice.Rows[i].Cells[3].Value = List[i].
            }
            txtTotalAmount.Text = Amount.ToString();
        }
        private void FillSalesExpenses(List<TransactionsEL> List)
        {
            if (DgvSalesAccounts.Rows.Count > 0)
            {
                DgvSalesAccounts.Rows.Clear();
            }
            for (int i = 0; i < List.Count; i++)
            {
                DgvSalesAccounts.Rows.Add();
                DgvSalesAccounts.Rows[i].Cells[0].Value = List[i].TransactionID;
                DgvSalesAccounts.Rows[i].Cells[1].Value = List[i].TransactionID;
                DgvSalesAccounts.Rows[i].Cells[2].Value = List[i].IdAccount;
                DgvSalesAccounts.Rows[i].Cells[3].Value = List[i].AccountNo;
                DgvSalesAccounts.Rows[i].Cells[4].Value = List[i].LinkAccountNo;
                DgvSalesAccounts.Rows[i].Cells[5].Value = List[i].AccountName;
                DgvSalesAccounts.Rows[i].Cells[6].Value = List[i].Description;
                DgvSalesAccounts.Rows[i].Cells[7].Value = List[i].Debit;
                DgvSalesAccounts.Rows[i].Cells[8].Value = List[i].Credit;
            }
            txtDebit.Text = List.Sum(x => x.Debit).ToString();
            txtCredit.Text = List.Sum(x => x.Credit).ToString();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReport = new frmReports();
            frmReport.VoucherNo = Convert.ToInt64(InvEditBox.Text);
            if (ChkPrintWithoutWarranty.Checked)
                frmReport.IsWithoutWarranty = true;
            else
                frmReport.IsWithoutWarranty = false;
            //frmReport.MdiParent = this;
            frmReport.ShowDialog();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new SalesHeadBLL(); //SalesVoucherBLL();
            if (MessageBox.Show("Are You Sure To Delete...", "Deleting Sale", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (manager.CheckSales(Operations.IdCompany, Validation.GetSafeLong(InvEditBox.Text)))
                {
                    if (manager.DeleteSale(IdVoucher, Validation.GetSafeLong(InvEditBox.Text), "SaleInvoiceVoucher", Operations.IdCompany))
                    {
                        lblStatuMessage.Text = "Sales Deleted And Stock Roll Back";
                        FillData();
                        ClearControl();
                    }
                }
                else
                {
                    MessageBox.Show("Delete With Out Sales ?");
                }
            }
        }
        //private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        if (txtTotalAmount.Text != string.Empty)
        //        {
        //            if (txtDiscount.Text != string.Empty)
        //            {
        //                if (txtDiscount.Text != "0" || txtDiscount.Text != string.Empty)
        //                {
        //                    //txtTotalDiscount.Text = (Convert.ToDecimal(txtTotalAmount.Text) * (Convert.ToDecimal(txtDiscount.Text) / 100)).ToString();
        //                    txtTotalDiscount.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtDiscount.Text)).ToString();
        //                    //txtNetSale.Text = (Convert.ToDecimal(txtTotalAmount.Text) - ((Convert.ToDecimal(txtTotalAmount.Text)) * (Convert.ToDecimal(txtDiscount.Text)) / 100)).ToString();
        //                    txtNetSale.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtDiscount.Text)).ToString();
        //                }
        //                else
        //                {
        //                    txtNetSale.Text = txtTotalAmount.Text;
        //                }
        //            }
        //            else
        //            {
        //                txtNetSale.Text = txtTotalAmount.Text;
        //            }
        //        }
        //        e.Handled = true;
        //        ProcessTabKey(true);

        //    }
        //    else
        //    {

        //    }
        //}
        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //txtNetSale.Text = txtTotalAmount.Text;
                e.Handled = true;
                ProcessTabKey(true);
            }

        }
        private void frmSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                FillData();
                ClearControl();
                if (DgvSaleInvoice.Rows.Count > 0)
                {
                    DgvSaleInvoice.Rows.Clear();
                }
            }
        }
        private void DgvSaleInvoice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvSaleInvoice.CurrentCellAddress.X == 5)
            {
                TextBox txtItemName = e.Control as TextBox;
                if (txtItemName != null)
                {
                    txtItemName.KeyPress -= new KeyPressEventHandler(txtItemName_KeyPress);
                    txtItemName.KeyPress += new KeyPressEventHandler(txtItemName_KeyPress);
                }
            }
            else if (DgvSaleInvoice.CurrentCellAddress.X == 6)
            {
                TextBox txtArticleName = e.Control as TextBox;
                if (txtArticleName != null)
                {
                    txtArticleName.KeyPress -= new KeyPressEventHandler(txtArticleName_KeyPress);
                    txtArticleName.KeyPress += new KeyPressEventHandler(txtArticleName_KeyPress);
                }
            }
            else if (DgvSaleInvoice.CurrentCellAddress.X == 7)
            {
                TextBox txtMakerInfo = e.Control as TextBox;
                if (txtMakerInfo != null)
                {
                    txtMakerInfo.KeyPress -= new KeyPressEventHandler(txtMakerInfo_KeyPress);
                    txtMakerInfo.KeyPress += new KeyPressEventHandler(txtMakerInfo_KeyPress);
                }
            }
        }

        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvSaleInvoice.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockSearchType = "Items";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchType = "SaleInvoiceVoucher";
                    if (cbxSeller.SelectedIndex == 0 || cbxSeller.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please First Select Seller...");
                        return;
                    }
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.Boss = cbxSeller.SelectedIndex;
                    frmstockAccounts.SaleType = cbxSaleType.SelectedIndex;
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        void txtArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvSaleInvoice.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockSearchType = "Articles";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchType = "SaleInvoiceVoucher";
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.Boss = cbxSeller.SelectedIndex;
                    frmstockAccounts.SaleType = cbxSaleType.SelectedIndex;
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        void txtMakerInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvSaleInvoice.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmAccount = new frmFindAccounts();
                    CommandType = "Makers";
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        private void cbxNaturalAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNaturalAccounts.SelectedIndex > 0)
            {
                var manager = new AccountsBLL();
                SalesAccountNo = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
                List<AccountsEL> list = manager.GetAccount(Validation.GetSafeString(cbxNaturalAccounts.SelectedValue), Operations.IdCompany);
                if (list.Count > 0)
                {
                    LinkAccountNo = list[0].LinkAccountNo;
                }
            }
        }
        private void cbxNaturalAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DgvSaleInvoice.Focus();
            }
        }
        private void btnNewVoucher_Click(object sender, EventArgs e)
        {
            ClearControl();
            FillData();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            long NextVoucherNo = Convert.ToInt64(InvEditBox.Text);
            NextVoucherNo += 1;
            InvEditBox.Text = NextVoucherNo.ToString();
            FillVoucher();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(InvEditBox.Text);
            PreviousVoucherNo -= 1;
            InvEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher();
        }
        private void DgvSaleInvoice_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //txtDescription.Text = DgvSaleInvoice.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[5].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[7].Value.ToString() + " Units " + " @" + DgvSaleInvoice.Rows[e.RowIndex].Cells[9].Value.ToString() + Environment.NewLine;
        }
        private void CustEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txt.Name == "CustEditBox")
                    {
                        cbxNaturalAccounts.Focus();
                        cbxNaturalAccounts.DroppedDown = true;
                    }
                }
                else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    if (txt.Name == "CustEditBox")
                    {
                        CommandType = "Persons";
                    }
                    else
                        CommandType = "Employees";
                    e.Handled = true;
                    frmAccount = new frmFindAccounts();
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.ShowDialog();

                }
                else
                    e.Handled = false;
            }
        }
        private void EmpEditCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    cbxNaturalAccounts.Focus();
                    cbxNaturalAccounts.DroppedDown = true;
                }
                else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    if (txt.Name == "EmpEditCode")
                    {
                        CommandType = "Employees"; 
                    }
                    else
                        CommandType = "Persons";
                    e.Handled = true;
                    frmAccount = new frmFindAccounts();
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.ShowDialog();

                }
                else
                    e.Handled = false;
            }
        }
        #region Purchases Grid Code and Events
        private void DgvSalesAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvSalesAccounts.Columns[e.ColumnIndex].Name == "colDebit")
            {

                for (int i = 0; i < DgvSalesAccounts.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvSalesAccounts.Rows[i].Cells["colDebit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtDebit.Text = OldValue.ToString();
                OldValue = 0;

            }
            else if (DgvSalesAccounts.Columns[e.ColumnIndex].Name == "colCredit")
            {
                for (int i = 0; i < DgvSalesAccounts.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvSalesAccounts.Rows[i].Cells["colCredit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtCredit.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private void DgvSalesAccounts_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvSalesAccounts.Columns[e.ColumnIndex].Name == "colDebit")
            {
                if (DgvSalesAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvSalesAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            else if (DgvSalesAccounts.Columns[e.ColumnIndex].Name == "colCredit")
            {
                if (DgvSalesAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvSalesAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }
        private void DgvSalesAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvSalesAccounts.CurrentCellAddress.X == 5)
            {
                TextBox txtAccountName = e.Control as TextBox;
                if (txtAccountName != null)
                {
                    txtAccountName.KeyPress -= new KeyPressEventHandler(txtAccountName_KeyPress);
                    txtAccountName.KeyPress += new KeyPressEventHandler(txtAccountName_KeyPress);
                }
            }
        }
        void txtAccountName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvSalesAccounts.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmAccount = new frmFindAccounts();
                    CommandType = "DgvSales";
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        private void cbxSaleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSaleType.SelectedIndex == 2)
            {
                FillVehicles();
                cbxVehicles.Visible = true;
            }
            else
            {
                if (cbxVehicles.Items.Count > 0)
                {
                    cbxVehicles.Items.Clear();
                    cbxVehicles.Visible = false;
                }
                else
                    cbxVehicles.Visible = false;
            }
        }
        private void FillVehicles()
        {
            var manager = new VoucherBLL();
            List<VouchersEL> lstVehicles = manager.GetAllVehicles(Operations.IdCompany);
            if (lstVehicles.Count > 0)
            {
                //if (cbxVehicles.Items.Count > 0)
                //{
                //    cbxVehicles.Items.Clear();
                //}                
                lstVehicles.Insert(0, new VouchersEL() { VehicalNo = "Select Vehicle" });
                for (int i = 0; i < lstVehicles.Count; i++)
                {
                    cbxVehicles.Items.Insert(i, lstVehicles[i].VehicalNo);
                }
                cbxVehicles.SelectedIndex = 0;
            }
            else
            {
                cbxVehicles.Items.Clear();
            }
        }
        private void ResizeColumns(int SaleType)
        {
            if (SaleType == 2 || SaleType == 3)
            {
                DgvSaleInvoice.Columns["colCurrentStock"].Width = 125;
                DgvSaleInvoice.Columns["colQty"].Width = 125;
            }
            else
            {
                DgvSaleInvoice.Columns["colCurrentStock"].Width = 165;
                DgvSaleInvoice.Columns["colQty"].Width = 165;
            }
        }
        private void CustEditBox_Click(object sender, EventArgs e)
        {

        }
    }
}
