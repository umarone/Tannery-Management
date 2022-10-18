using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;

using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmStockReturn : MetroForm
    {
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        public decimal OldValue { get; set; }
        public Int64 VoucherNo { get; set; }
        string LinkAccountNo = "";
        Guid IdVoucher;
        public Guid SupplierTransactionId { get; set; }
        public Guid PurchasesTransactionId { get; set; }
        public string VoucherType { get; set; }
        public bool IsImport { get; set; }
        string EventCommandName;
        public frmStockReturn()
        {
            InitializeComponent();
        }
        private void frmStockReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvStockReceipt.AutoGenerateColumns = false;
            txtBillNo.Text = "0";
            FillData();
            FillNaturalAccounts(string.Empty);
            CheckModulePermissions();            
        }
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
        private void FillData()
        {
            var manager = new VoucherBLL();
            VEditBox.Text = manager.GetMaxVoucherNumber("PurchaseReturnVoucher", Operations.IdCompany);
        }
        private void FillNaturalAccounts(string AccountNo)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountsByType("Cost of Sales", Operations.IdCompany);
            if (AccountNo == "")
            {
                if (list.Count > 0)
                {
                    cbxNaturalAccounts.DataSource = list;
                    list.Insert(0, new AccountsEL() { AccountNo = "0", AccountName = "" });

                    cbxNaturalAccounts.DisplayMember = "AccountName";
                    cbxNaturalAccounts.ValueMember = "AccountNo";
                }
            }
            else
            {
                cbxNaturalAccounts.SelectedValue = AccountNo;
            }
        }
        private void ClearControl()
        {
            DgvStockReceipt.Rows.Clear();
            //txtDescription.Text = string.Empty;
            VoucherNo = 0;
            IdVoucher = Guid.Empty;
            VEditBox.Enabled = true;
            txtDescription.Text = string.Empty;
            txtCreditBalance.Text = string.Empty;          
            SupplierTransactionId = Guid.Empty;


            PurchasesTransactionId = Guid.Empty;
            PurchasesEditBox.Text = string.Empty;
            txtPurchasesAccountName.Text = string.Empty;
            cbxNaturalAccounts.SelectedIndex = 0;

            SEditBox.Text = string.Empty;
            txtBillNo.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtNTN.Text = string.Empty;
            txtAddress.Text = string.Empty;
            lblStatuMessage.Text = string.Empty;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
            }
        }
        private bool ValidateRows()
        {

            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            {
                if (DgvStockReceipt.Rows[i].Cells["colItemNo"].Value == null)
                {
                    return false;
                }
                else if (DgvStockReceipt.Rows[i].Cells["colQty"].Value == null)
                {
                    return false;
                }
                else if (DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (SEditBox.Text == string.Empty)
            {
                lblStatuMessage.Text = "Supplier Missing...";
                return false;
            }
            else if (txtBillNo.Text == string.Empty)
            {
                lblStatuMessage.Text = "Bill Missing...";
                return false;
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PurchasesEditBox_ButtonClick(object sender, EventArgs e)
        {
            EventCommandName = "Sales";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void SEditBox_ButtonClick(object sender, EventArgs e)
        {
            EventCommandName = "Persons";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (EventCommandName == "Persons")
            {
                //var manager = new PersonsBLL();
                // List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                //if (list.Count > 0)
                {
                    SEditBox.Text = Validation.GetSafeString(oelAccount.AccountNo);
                    txtSupplierName.Text = oelAccount.AccountName;
                    //txtSupplierName.Text = list[0].PersonName;
                    //txtContact.Text = list[0].Contact;
                    //txtNTN.Text = list[0].NTN;
                    //txtAddress.Text = list[0].Address;
                    //lblStatuMessage.Text = "";
                }
                //else
                //{
                //lblStatuMessage.Text = "Please Select Supplier";
                //}
            }
            else
            {
                PurchasesEditBox.Text = oelAccount.AccountNo.ToString();
                txtPurchasesAccountName.Text = oelAccount.AccountName;
            }
        }
        private void DgvStockReceipt_KeyDown(object sender, KeyEventArgs e)
        {
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            var manager = new ItemsBLL();
            if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.ItemNo).Count > 0)
            {
                //for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                //{
                //    if (DgvStockReceipt.Rows[i].Cells["colItemNo"].Value != null)
                //    {
                //        if (oelItems.AccountNo == Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value))
                //        {
                //            lblStatuMessage.Text = "Product Already exists";
                //            return;
                //        }
                //    }
                //}
                lblStatuMessage.Text = "";
                DgvStockReceipt.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                DgvStockReceipt.CurrentRow.Cells["colItemNo"].Value = oelItems.ItemNo;
                DgvStockReceipt.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                DgvStockReceipt.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                //DgvStockReceipt.CurrentRow.Cells["ColBatch"].Value = oelItems.BatchNo;
            }
            else
            {
                lblStatuMessage.Text = "Wrong Account...";
            }
        }
        private void DgvStockReceipt_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    OldValue = Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
            //}
        }
        private void DgvStockReceipt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txtCreditBalance.Text = OldValue.ToString();
                OldValue = 0;
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colDisc")
            {
                if (Validation.GetSafeInteger(DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) != 0)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) * (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value)) / 100;
                }
                else
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value = "";
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colExpiry")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value != null)
                {
                    bool Value = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Contains('/');
                    if (Value == false)
                    {
                        MessageBox.Show("Wrong Expiry Date");
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
                    }
                    else
                    {
                        string[] splitString = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Split('/');
                        if (splitString.Length == 3)
                        {
                            MessageBox.Show("Wrong Expiry Date");
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
                        }
                        else if (splitString.Length == 2)
                        {
                            int Year = Validation.GetSafeInteger(splitString[1]);
                            int currentyear = Validation.GetSafeInteger(DateTime.Now.Year.ToString().Substring(2));
                            if (Year < currentyear)
                            {
                                MessageBox.Show("Wrong Expiry Date.. Expiry Year is smaller then current year");
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
                            }
                        }
                    }
                }
            }
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    decimal value = 0;
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        if (OldValue > Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = OldValue;
            //            txtTotalAmount.Text = (((Convert.ToInt64(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (value))).ToString());
            //        }
            //        else if (OldValue < Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - OldValue;
            //            txtTotalAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + (value)).ToString();
            //        }
            //        DgvStockReceipt.Text = (DgvStockReceipt.Rows.Count - 1).ToString();
            //    }
            //}
        }
        private void DgvStockReceipt_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            {
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txtCreditBalance.Text = OldValue.ToString();               
                OldValue = 0;
            }
            //DgvStockReceipt.EndEdit();
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            //{
            //    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);

            //}

            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            //        {
            //            OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
            //        }
            //        txtTotalAmount.Text = OldValue.ToString();
            //        OldValue = 0;
            //    }
            //}
            //{
            //    Int64 value = 0;
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        if (OldValue > Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = OldValue;
            //            txtTotalAmount.Text = (((Convert.ToInt64(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (value))).ToString());
            //        }
            //        else if (OldValue < Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - OldValue;
            //            txtTotalAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + (value)).ToString();
            //        }
            //        else
            //        {
            //            txtTotalAmount.Text = OldValue.ToString();
            //        }
            //        OldValue = 0;
            //        DgvStockReceipt.Text = (DgvStockReceipt.Rows.Count - 1).ToString();
            //    }
            //}
        }
        private void DgvStockReceipt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    for(int i=0; i<DgvStockReceipt.Rows.Count-1; i++)
            //    {
            //        OldValue += Convert.ToInt32(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
            //    }
            //}
        }
        //private void DgvStockReceipt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        ////    if (DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        ////    {
        ////        if (DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == string.Empty)
        ////        {
        ////            e.Cancel = true;
        ////        }
        ////        else
        ////        {
        ////            e.Cancel = false;
        ////        }
        ////    }
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelPurchaseDetailCollection = new List<VoucherDetailEL>();
            if (ValidateRows())
            {
                if (ValidateControls())
                {
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
                    oelVoucher.IdUser = Operations.UserID;
                    oelVoucher.IdCompany = Operations.IdCompany;
                    oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
                    oelVoucher.AccountNo = Validation.GetSafeString(SEditBox.Text);
                    oelVoucher.LinkAccountNo = LinkAccountNo;
                    oelVoucher.SubAccountNo = "0";
                    oelVoucher.BillNo = txtBillNo.Text;
                    oelVoucher.Date = VDate.Value;
                    oelVoucher.TotalAmount = Convert.ToDecimal(txtCreditBalance.Text);
                    oelVoucher.IsImport = IsImport;
                    oelVoucher.Posted = chkPosted.Checked;

                    ///Add Stock Detail 
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelPurchaseDetial = new VoucherDetailEL();
                        if (DgvStockReceipt.Rows[i].Cells["colStockReceiptID"].Value != null)
                        {
                            //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                            oelPurchaseDetial.IdVoucherDetail = new Guid(DgvStockReceipt.Rows[i].Cells["colStockReceiptID"].Value.ToString());
                            oelPurchaseDetial.IsNew = false;
                        }
                        else
                        {
                            oelPurchaseDetial.IdVoucherDetail = Guid.NewGuid();
                            //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                            oelPurchaseDetial.IsNew = true;
                        }
                        oelPurchaseDetial.Seq = i + 1;
                        oelPurchaseDetial.IdVoucher = oelVoucher.IdVoucher;
                        oelPurchaseDetial.VoucherNo = Convert.ToInt64(VEditBox.Text);
                        oelPurchaseDetial.IdItem = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value);
                        //oelPurchaseDetial.ItemNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value);
                        //oelPurchaseDetial.ItemName = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemName"].Value);
                        oelPurchaseDetial.PackingSize = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colpacking"].Value);
                        //oelPurchaseDetial.BatchNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["ColBatch"].Value);
                        //oelPurchaseDetial.Expiry = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colExpiry"].Value);
                        oelPurchaseDetial.Discription = "N/A"; //Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colRemarks"].Value);
                        oelPurchaseDetial.Units = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        //oelPurchaseDetial.Bonus = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colBonus"].Value);
                        oelPurchaseDetial.RemainingUnits = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        oelPurchaseDetial.UnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                        oelPurchaseDetial.Discount = 0;//Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDisc"].Value);
                        oelPurchaseDetial.Amount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                        oelPurchaseDetailCollection.Add(oelPurchaseDetial);
                    }
                    #region Add Items In Transactions
                    /// Add Items In Transactions
                    //for (int j = 0; j < DgvStockReceipt.Rows.Count - 1; j++)
                    //{
                    //    TransactionsEL oelTransaction = new TransactionsEL();
                    //    if (DgvStockReceipt.Rows[j].Cells["ColTransaction"].Value != null)
                    //    {
                    //        oelTransaction.TransactionID = new Guid(DgvStockReceipt.Rows[j].Cells["ColTransaction"].Value.ToString());
                    //        oelTransaction.IsNew = false;
                    //    }
                    //    else
                    //    {
                    //        oelTransaction.TransactionID = Guid.NewGuid();
                    //        oelTransaction.IsNew = true;
                    //    }
                    //    oelTransaction.IdCompany = Operations.IdCompany;
                    //    oelTransaction.AccountNo = Validation.GetSafeLong(DgvStockReceipt.Rows[j].Cells["colItemNo"].Value);
                    //    oelTransaction.Date = VDate.Value;
                    //    oelTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                    //    oelTransaction.VoucherType = "StockReceiptVoucher";
                    //    if (DgvStockReceipt.Rows[j].Cells["colRemarks"].Value == null)
                    //    {
                    //        oelTransaction.Description = "N/A";
                    //    }
                    //    else
                    //    {
                    //        oelTransaction.Description = DgvStockReceipt.Rows[j].Cells["colRemarks"].Value.ToString();
                    //    }
                    //    //oelTransaction.Debit = Convert.ToInt64(DgvStockReceipt.Rows[j].Cells["colUnitPrice"].Value);
                    //    oelTransaction.Debit = Convert.ToInt64(DgvStockReceipt.Rows[j].Cells["colAmount"].Value);
                    //    oelTransaction.Credit = 0;
                    //    //oelTransaction.Amount = Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                    //    oelTransaction.Qty = Convert.ToInt32(DgvStockReceipt.Rows[j].Cells["colQty"].Value);
                    //    oelTransaction.Posted = chkPosted.Checked;
                    //    oelTransactionCollection.Add(oelTransaction);
                    //}
                    #endregion
                    #region Add Supplier
                    TransactionsEL oelSupplierTransaction = new TransactionsEL();
                    if (SupplierTransactionId != Guid.Empty)
                    {
                        oelSupplierTransaction.TransactionID = SupplierTransactionId;
                        oelSupplierTransaction.IsNew = false;
                    }
                    else
                    {
                        oelSupplierTransaction.TransactionID = Guid.NewGuid();
                        oelSupplierTransaction.IsNew = true;
                    }
                    oelSupplierTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelSupplierTransaction.IdCompany = Operations.IdCompany;
                    oelSupplierTransaction.AccountNo = Validation.GetSafeString(SEditBox.Text);
                    oelSupplierTransaction.LinkAccountNo = "";
                    oelSupplierTransaction.SubAccountNo = "0";
                    oelSupplierTransaction.Date = VDate.Value;
                    oelSupplierTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                    oelSupplierTransaction.VoucherType = "PurchaseReturnVoucher";
                    oelSupplierTransaction.Description = txtDescription.Text;
                    //oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    oelSupplierTransaction.Credit = 0;
                    oelSupplierTransaction.Debit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                    oelSupplierTransaction.TransactionType = "Dr";
                    
                   
                    oelSupplierTransaction.Posted = chkPosted.Checked;
                    oelTransactionCollection.Add(oelSupplierTransaction);
                    #endregion
                    #region Add Purchase Account In Transactions
                    /// Add Purchase Account...
                    TransactionsEL oelPurchaseTransaction = new TransactionsEL();
                    if (PurchasesTransactionId != Guid.Empty)
                    {
                        oelPurchaseTransaction.TransactionID = PurchasesTransactionId;
                        oelPurchaseTransaction.IsNew = false;
                    }
                    else
                    {
                        oelPurchaseTransaction.TransactionID = Guid.NewGuid();
                        oelPurchaseTransaction.IsNew = true;
                    }
                    oelPurchaseTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelPurchaseTransaction.IdCompany = Operations.IdCompany;
                    //oelPurchaseTransaction.AccountNo = Validation.GetSafeLong(PurchasesEditBox.Text);
                    oelPurchaseTransaction.AccountNo = Validation.GetSafeString(txtPurchasesAccountName.Text);
                    oelPurchaseTransaction.LinkAccountNo = LinkAccountNo;
                    oelPurchaseTransaction.SubAccountNo = "0";
                    oelPurchaseTransaction.Date = VDate.Value;
                    oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelPurchaseTransaction.VoucherType = "PurchaseReturnVoucher";
                    oelPurchaseTransaction.Description = txtDescription.Text;
                    oelPurchaseTransaction.Debit = 0;
                    
                    oelPurchaseTransaction.Credit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                    oelPurchaseTransaction.TransactionType = "Cr";
                    //if (txtCashReceipt.Text == string.Empty)
                    //{
                    //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    //}
                    //else
                    //{
                    //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtCashReceipt.Text);
                    //}
                    oelPurchaseTransaction.Posted = chkPosted.Checked;
                    oelTransactionCollection.Add(oelPurchaseTransaction);
                    #endregion region

                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new PurchaseHeadBLL();
                        var VManager = new VoucherBLL();
                        if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), "PurchaseReturnVoucher") == false)
                        {

                            EntityoperationInfo infoResult = manager.InsertPurchasesReturn(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection);
                            if (infoResult.IsSuccess)
                            {
                                //manager.UpdateStockitems(oelTransactionCollection, "Add");
                                lblStatuMessage.Text = "Stock Receipt Successfully...";
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
                        var manager = new PurchaseHeadBLL();
                        EntityoperationInfo infoResult = manager.UpdatePurchasesReturn(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection);
                        if (infoResult.IsSuccess)
                        {
                            //manager.UpdateStockitems(oelTransactionCollection, "Add");
                            lblStatuMessage.Text = "Stock Receipt Successfully...";
                            ClearControl();
                            FillData();
                        }
                    }
                }
                else
                {
                    lblStatuMessage.Text = "Check Values";
                }
            }
            else
            {
                lblStatuMessage.Text = "Incomplete Entry...";
            }
        }
        private void DgvStockReceipt_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DgvStockReceipt.EndEdit();
            //if (!DgvStockReceipt.IsCurrentRowDirty)
            //{
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }
        private void VEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = "PurchaseReturnVoucher";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VoucherNo = oelVoucher.VoucherNo;
            IdVoucher = oelVoucher.IdVoucher;
            VEditBox.Text = oelVoucher.VoucherNo.ToString();
            FillVoucher();

        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
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
            VoucherType = "PurchaseReturnVoucher";
            if (VEditBox.Text != string.Empty)
            {
                List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(VEditBox.Text));
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VEditBox.Enabled = false;
                    txtBillNo.Text = list[0].BillNo;
                    VDate.Value = list[0].Date;
                    txtDescription.Text = list[0].Description;
                    LinkAccountNo = list[0].LinkAccountNo;
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

                    List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "PurchaseReturnVoucher", Operations.IdCompany);

                    if (listTransactions.Count > 0)
                    {
                        TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Credit != 0);
                        if (oelSalesTransaction != null)
                        {
                            //PurchasesEditBox.Text = oelSalesTransaction.AccountNo.ToString();
                            //cbxNaturalAccounts.SelectedValue = oelSalesTransaction.AccountNo;
                            FillNaturalAccounts(oelSalesTransaction.AccountNo.ToString());
                            txtPurchasesAccountName.Text = oelSalesTransaction.AccountNo.ToString();
                            //txtPurchasesAccountName.Text = oelSalesTransaction.AccountName;
                            PurchasesTransactionId = oelSalesTransaction.TransactionID;
                        }
                        TransactionsEL oelPurchaseTransaction = listTransactions.Find(x => x.Debit != 0);
                        if (oelPurchaseTransaction != null)
                        {
                            SEditBox.Text = Validation.GetSafeString(oelPurchaseTransaction.AccountNo);
                            txtSupplierName.Text = oelPurchaseTransaction.AccountName;
                            //txtTotalAmount.Text = oelPurchaseTransaction.Credit.ToString();
                            //    txtSupplierName.Text = listSupplier[0].PersonName;
                            SupplierTransactionId = oelPurchaseTransaction.TransactionID;
                        }

                    }

                    //List<PersonsEL> listSupplier = Manager.GetStockSupplier(list[0].AccountNo, Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
                    //if (listSupplier != null && listSupplier.Count > 0)
                    //{
                    //    SEditBox.Text = Validation.GetSafeString(listSupplier[0].AccountNo);
                    //    //txtTotalAmount.Text = listSupplier[0].Credit.ToString();
                    //    txtSupplierName.Text = listSupplier[0].PersonName;
                    //    SupplierTransactionId = listSupplier[0].PAccountId;
                    //    txtContact.Text = listSupplier[0].Contact;
                    //    txtNTN.Text = listSupplier[0].NTN;
                    //    txtAddress.Text = listSupplier[0].Address;
                    //}

                    List<TransactionsEL> List = Manager.GetTransactionsByVoucherAndType(Operations.IdCompany, list[0].IdVoucher, Validation.GetSafeLong(VEditBox.Text), VoucherType);
                    FillTransactions(List);

                }
                else
                {
                    MessageBox.Show("Voucher Number Not Found ...");
                    ClearControl();
                }
            }


        }
        private void FillTransactions(List<TransactionsEL> List)
        {
            if (DgvStockReceipt.Rows.Count > 0)
            {
                DgvStockReceipt.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {
                TransactionsEL oeTransaction = List.Find(x => x.Qty == 0);
                if (oeTransaction != null)
                {
                    SEditBox.Text = Validation.GetSafeString(oeTransaction.AccountNo);
                    txtCreditBalance.Text = oeTransaction.Credit.ToString();
                    //txtSupplierName.Text = oeTransaction.PersonName;
                    SupplierTransactionId = oeTransaction.TransactionID;
                    List.RemoveAt(List.FindIndex(x => x.Qty == 0));
                }


                for (int i = 0; i < List.Count; i++)
                {
                    DgvStockReceipt.Rows.Add();
                    //DgvStockReceipt.Rows[i].Cells[0].Value = List[i].TransactionID;
                    DgvStockReceipt.Rows[i].Cells[0].Value = List[i].IdDetail;
                    DgvStockReceipt.Rows[i].Cells[1].Value = List[i].IdItem;
                    DgvStockReceipt.Rows[i].Cells[2].Value = List[i].AccountNo;
                    DgvStockReceipt.Rows[i].Cells[3].Value = List[i].AccountName;
                    DgvStockReceipt.Rows[i].Cells[4].Value = List[i].PackingSize;
                    DgvStockReceipt.Rows[i].Cells[5].Value = List[i].Qty;
                    //DgvStockReceipt.Rows[i].Cells[4].Value = List[i].Qty * List[i].Debit;
                    DgvStockReceipt.Rows[i].Cells[6].Value = List[i].unitprice;
                    DgvStockReceipt.Rows[i].Cells[7].Value = List[i].TotalAmount;
                    //if (List[i].Discount == 0)
                    //{
                    //    DgvStockReceipt.Rows[i].Cells[10].Value = "";
                    //}
                    //else
                    //{
                    //    DgvStockReceipt.Rows[i].Cells[10].Value = List[i].Discount;
                    //}
                    //DgvStockReceipt.Rows[i].Cells[11].Value = List[i].TotalAmount; //List[i].Qty * List[i].unitprice;

                    //txtCreditBalance.Text = List.Sum(x => x.Amount).ToString();
                    txtCreditBalance.Text = List[0].Amount.ToString("0.00");
                    // DgvStockReceipt.DataSource = List;
                    //
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelItemTransactionCollection = new List<TransactionsEL>();
            if (VEditBox.Text != string.Empty)
            {
                var manager = new PurchaseHeadBLL(); //PurchaseStockReceiptBLL();
                if (IdVoucher != Guid.Empty)
                {
                    if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (manager.DeleteStock(IdVoucher, Convert.ToInt64(VEditBox.Text), VoucherTypes.StockReceiptVoucher.ToString(), Operations.IdCompany))
                        {
                            MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                            ClearControl();
                            //for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                            //{
                            //    TransactionsEL oelTransaction = new TransactionsEL();
                            //    oelTransaction.AccountNo = Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value);
                            //    oelTransaction.Qty = Convert.ToInt32(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                            //    oelItemTransactionCollection.Add(oelTransaction);
                            //}
                            //if (manager.UpdateStockitems(oelItemTransactionCollection, "Subtract"))
                            //{
                            //    lblStatuMessage.Text = "Voucher Deleted Successfully";
                            //    ClearControl();
                            //}
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select Voucher To Delete....");
                }
            }
        }
        private void frmStockReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                FillData();
                ClearControl();
                if (DgvStockReceipt.Rows.Count > 0)
                {
                    DgvStockReceipt.Rows.Clear();
                }
            }
        }
        private void DgvStockReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.F2)
            //{
            //    if (DgvStockReceipt.CurrentCellAddress.X == 2)
            //    {
            //        checkSender = true;
            //        frmstockAccounts = new frmStockAccounts();
            //        frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            //        frmstockAccounts.ShowDialog(this);
            //    }
            //}
        }
        private void DgvStockReceipt_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 3)
            {
                TextBox txtItemName = e.Control as TextBox;
                if (txtItemName != null)
                {
                    txtItemName.KeyPress -= new KeyPressEventHandler(txtItemName_KeyPress);
                    txtItemName.KeyPress += new KeyPressEventHandler(txtItemName_KeyPress);
                }
            }
        }
        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
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
        private void cbxNaturalAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNaturalAccounts.SelectedIndex > 0)
            {
                var manager = new AccountsBLL();
                txtPurchasesAccountName.Text = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
                List<AccountsEL> list = manager.GetAccount(Validation.GetSafeString(cbxNaturalAccounts.SelectedValue), Operations.IdCompany);
                if (list.Count > 0)
                {
                    LinkAccountNo = list[0].LinkAccountNo;
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            FillData();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            long NextVoucherNo = Convert.ToInt64(VEditBox.Text);
            NextVoucherNo += 1;
            VEditBox.Text = NextVoucherNo.ToString();
            FillVoucher();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
            PreviousVoucherNo -= 1;
            VEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher();
        }

        private void SEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txt.Name == "SEditBox")
                    {
                        cbxNaturalAccounts.Focus();
                        cbxNaturalAccounts.DroppedDown = true;
                    }
                }
                else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    if (txt.Name == "SEditBox")
                    {
                        EventCommandName = "Persons";
                    }
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

        private void cbxNaturalAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBillNo.Focus();
            }
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DgvStockReceipt.Focus();
            }
        }
    }
}
