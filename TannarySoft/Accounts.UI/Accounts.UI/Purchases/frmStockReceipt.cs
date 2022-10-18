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
    public partial class frmStockReceipt : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        public decimal OldValue { get; set; }
        public Int64 VoucherNo { get; set; }
        Guid IdVoucher;
        public Guid SupplierTransactionId { get; set; }
        public Guid PurchasesTransactionId { get; set; }
        public string VoucherType { get; set; }
        public string PurchaseType { get; set; }
        string EventCommandName;
        int EventTime = 0;
        string Command = "";
        string LinkAccountNo = "";
        public bool IsImport { get; set; }
        bool IsAccountSelected;
        #endregion
        public frmStockReceipt()
        {
            InitializeComponent();
        }
        private void frmStockReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvStockReceipt.AutoGenerateColumns = false;
            cbxPurchaser.SelectedIndex = 1;
            txtBillNo.Text = "0";
            FillData();
            FillNaturalAccounts(string.Empty);
            CheckModulePermissions();
            CreateAndInitializeFooterRow();
            if (IsImport)
            {
                this.Text = "Import Purchases";
                //lblVAT.Visible = false;
                //txtVat.Visible = false;
                //lblVATAmount.Visible = false;
                //txtVATAmount.Visible = false;
            }
            else
            {
                this.Text = "Local Purchases";
            }
        }
        private void CreateAndInitializeFooterRow()
        {
            txtDebit.Enabled = false;
            txtDebit.TextAlign = HorizontalAlignment.Left;
            txtDebit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCellLocation = DgvPurchases.GetCellDisplayRectangle(9, -1, true).X;

            txtDebit.Width = DgvPurchases.Columns[9].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtDebit.Location = new Point(hostCellLocation, DgvPurchases.Height - txtDebit.Height);

            DgvPurchases.Controls.Add(txtDebit);

            txtDebit.BringToFront();

            txtCredit.Enabled = false;
            txtCredit.TextAlign = HorizontalAlignment.Left;
            txtCredit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCreditCellLocation = DgvPurchases.GetCellDisplayRectangle(10, -1, true).X;
            txtCredit.Width = DgvPurchases.Columns[10].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtCredit.Location = new Point(hostCreditCellLocation, DgvPurchases.Height - txtCredit.Height);

            DgvPurchases.Controls.Add(txtCredit);

            txtCredit.BringToFront();
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
            VEditBox.Text = manager.GetMaxVoucherNumber("StockReceiptVoucher", Operations.IdCompany);
        }
        private void FillVehicle()
        {
            if (IdVoucher == Guid.Empty)
            {
                var manager = new VoucherBLL();
                txtVehicalNo.Text = manager.GetMaxVehicleNumber(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text));
            }
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
            DgvPurchases.Rows.Clear();
            //txtDescription.Text = string.Empty;
            VoucherNo = 0;
            IdVoucher = Guid.Empty;
            VEditBox.Enabled = true;
            txtBillNo.Text = "0";
            txtDescription.Text = string.Empty;
            txtCreditBalance.Text = string.Empty;
            txtVehicalNo.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtDebit.Text = string.Empty;
            txtCredit.Text = string.Empty;
            cbxPurchaseType.SelectedIndex = 0;
            cbxPurchaser.SelectedIndex = 0;
            //txtVat.Text = string.Empty;
            //txtVATAmount.Text = string.Empty;
            SupplierTransactionId = Guid.Empty;


            PurchasesTransactionId = Guid.Empty;
            PurchasesEditBox.Text = string.Empty;
            txtPurchasesAccountName.Text = string.Empty;
            cbxNaturalAccounts.SelectedIndex = 0;

            SEditBox.Text = string.Empty;
            //txtBillNo.Text = string.Empty;
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
            else if (txtPurchasesAccountName.Text == string.Empty)
            {
                lblStatuMessage.Text = "Purchases Account Missing...";
                return false;
            }
            else if (cbxPurchaseType.Text == string.Empty)
            {
                lblStatuMessage.Text = "Purchase Type Is Missing...";
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
                    EventTime = 1;
                    SEditBox.Text = Validation.GetSafeString(oelAccount.AccountNo);
                    //LinkAccountNo = Validation.GetSafeString(oelAccount.AccountNo);
                    EventTime = 0;
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
            else if (EventCommandName == "DgvPurchases")
            {
                DgvPurchases.CurrentRow.Cells["colHeadType"].Value = oelAccount.AccountType;
                DgvPurchases.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                DgvPurchases.CurrentRow.Cells["colLinkAccount"].Value = oelAccount.LinkAccountNo;
                DgvPurchases.CurrentRow.Cells["colIdAccount"].Value = oelAccount.IdAccount;
                DgvPurchases.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
                DgvPurchases.CurrentRow.Cells["colClosingBalance"].Value = new TransactionBLL().GetAccountClosingBalance(oelAccount.AccountNo);
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
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) *
                                                                            Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txtCreditBalance.Text = OldValue.ToString();
                //if (IsImport)
                //{
                //    txtVat.Text = "0";
                //    txtVATAmount.Text = "0";
                //}
                //else
                //{
                //    txtVat.Text = ((Validation.GetSafeDecimal(txtCreditBalance.Text) * 5) / 100).ToString();
                //    txtVATAmount.Text = (Validation.GetSafeDecimal(txtCreditBalance.Text) + Validation.GetSafeDecimal(txtVat.Text)).ToString();
                //}
                OldValue = 0;
            }
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colDisc")
            //{
            //    if (Validation.GetSafeInteger(DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) != 0)
            //    {
            //        DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) * (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value)) / 100;
            //    }
            //    else
            //    {
            //        DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value = "";
            //    }
            //}
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colExpiry")
            //{
            //    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value != null)
            //    {
            //        bool Value = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Contains('/');
            //        if (Value == false)
            //        {
            //            MessageBox.Show("Wrong Expiry Date");
            //            DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //        }
            //        else
            //        {
            //            string[] splitString = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Split('/');
            //            if (splitString.Length == 3)
            //            {
            //                MessageBox.Show("Wrong Expiry Date");
            //                DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //            }
            //            else if (splitString.Length == 2)
            //            {
            //                int Year = Validation.GetSafeInteger(splitString[1]);
            //                int Month = Validation.GetSafeInteger(splitString[0]);
            //                int compareyear = Validation.GetSafeInteger(DateTime.Now.Year.ToString().Substring(2));
            //                int CurrentMonth = Validation.GetSafeInteger(DateTime.Now.Month.ToString());
            //                if (Year == compareyear)
            //                {
            //                    if (Month < CurrentMonth)
            //                    {
            //                        MessageBox.Show("Wrong Expiry Date.. Expiry Month is smaller then current Month");
            //                        DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //                    }
            //                }
            //                else if (Year < compareyear)
            //                {
            //                    MessageBox.Show("Wrong Expiry Date.. Expiry Year is smaller then current year");
            //                    DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //                }
            //            }
            //        }
            //    }
            //}
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
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txtCreditBalance.Text = OldValue.ToString();
                OldValue = 0;
                //if (IsImport)
                //{
                //    txtVat.Text = "0";
                //    txtVATAmount.Text = "0";
                //}
                //else
                //{
                //    txtVat.Text = ((Validation.GetSafeDecimal(txtCreditBalance.Text) * 5) / 100).ToString();
                //    txtVATAmount.Text = (Validation.GetSafeDecimal(txtCreditBalance.Text) + Validation.GetSafeDecimal(txtVat.Text)).ToString();
                //}
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
            List<VoucherDetailEL> oelCostOfSalesCollection = new List<VoucherDetailEL>();
            List<ItemsEL> oelItemsCollection = new List<ItemsEL>();
            string StatusMsg;
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    /// Add Voucher...
                    #region Voucher Head Entries
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
                    oelVoucher.VehicalNo = Validation.GetSafeString(txtVehicalNo.Text);
                    oelVoucher.VehicalType = Validation.GetSafeInteger(cbxVehicalType.SelectedIndex);
                    oelVoucher.Weight = Validation.GetSafeDecimal(txtWeight.Text);
                    oelVoucher.AccountNo = Validation.GetSafeString(SEditBox.Text);
                    oelVoucher.LinkAccountNo = LinkAccountNo;
                    oelVoucher.SubAccountNo = "0";
                    oelVoucher.BillNo = txtBillNo.Text;
                    oelVoucher.Description = Validation.GetSafeString(txtDescription.Text);
                    oelVoucher.Date = VDate.Value;
                    oelVoucher.TotalAmount = Convert.ToDecimal(txtCreditBalance.Text);

                    oelVoucher.PurchaseType = cbxPurchaseType.SelectedIndex;

                    //oelVoucher.VAT = Validation.GetSafeInteger(txtVat.Text);
                    //oelVoucher.VATAmount = Validation.GetSafeDecimal(txtVATAmount.Text);
                    oelVoucher.IsImport = IsImport;
                    if (cbxPurchaser.SelectedIndex == 0 || cbxPurchaser.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select Seller ....");
                        return;
                    }
                    else
                    {
                        oelVoucher.Purchaser = cbxPurchaser.SelectedIndex;
                    }
                    oelVoucher.Posted = chkPosted.Checked;
                    #endregion
                    ///Add Stock Detail 
                    #region Stock Entries
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelPurchaseDetial = new VoucherDetailEL();
                        ItemsEL oelItem = new ItemsEL();
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
                        oelItem.IdItem = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value);
                        //oelPurchaseDetial.ItemNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value);
                        //oelPurchaseDetial.ItemName = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemName"].Value);
                        oelPurchaseDetial.PackingSize = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colpacking"].Value);
                        //oelPurchaseDetial.BatchNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["ColBatch"].Value);
                        //oelPurchaseDetial.Expiry = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colExpiry"].Value);
                        oelPurchaseDetial.Discription = "N/A"; //Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colRemarks"].Value);
                        oelPurchaseDetial.Units = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        //oelPurchaseDetial.Bonus = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colBonus"].Value);
                        oelPurchaseDetial.RemainingUnits = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        oelPurchaseDetial.UnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                        oelItem.CurrentUnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                        oelPurchaseDetial.Discount = 0;//Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDisc"].Value);
                        oelPurchaseDetial.Amount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);

                        oelItemsCollection.Add(oelItem);
                        oelPurchaseDetailCollection.Add(oelPurchaseDetial);
                    }
                    #endregion
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
                    oelSupplierTransaction.IdCompany = Operations.IdCompany;
                    oelSupplierTransaction.AccountNo = Validation.GetSafeString(SEditBox.Text);
                    oelSupplierTransaction.LinkAccountNo = "";
                    oelSupplierTransaction.SubAccountNo = "0";
                    oelSupplierTransaction.Date = VDate.Value;
                    oelSupplierTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelSupplierTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                    oelSupplierTransaction.VoucherType = "StockReceiptVoucher";
                    oelSupplierTransaction.AdjustmentType = -1;
                    oelSupplierTransaction.SettlementType = "Purchases";
                    oelSupplierTransaction.Description = txtDescription.Text;
                    oelSupplierTransaction.Credit = Convert.ToDecimal(txtCreditBalance.Text);
                    oelSupplierTransaction.TransactionType = "Cr";
                    //oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    //if (IsImport)
                    //{
                    //    oelSupplierTransaction.Credit = Convert.ToDecimal(txtCreditBalance.Text);                        
                    //}
                    //else
                    //{
                    //    oelSupplierTransaction.Credit = Convert.ToDecimal(txtVATAmount.Text);
                    //}
                    oelSupplierTransaction.Debit = 0;
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
                    oelPurchaseTransaction.IdCompany = Operations.IdCompany;
                    //oelPurchaseTransaction.AccountNo = Validation.GetSafeLong(PurchasesEditBox.Text);
                    oelPurchaseTransaction.AccountNo = Validation.GetSafeString(txtPurchasesAccountName.Text);
                    oelPurchaseTransaction.LinkAccountNo = LinkAccountNo;
                    oelPurchaseTransaction.SubAccountNo = "0";
                    oelPurchaseTransaction.Date = VDate.Value;
                    oelPurchaseTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelPurchaseTransaction.VoucherType = "StockReceiptVoucher";
                    oelPurchaseTransaction.AdjustmentType = -1;
                    oelSupplierTransaction.SettlementType = "Purchases";
                    oelPurchaseTransaction.Description = txtDescription.Text;
                    oelPurchaseTransaction.Debit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                    oelPurchaseTransaction.TransactionType = "Dr";
                    oelPurchaseTransaction.Credit = 0;
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
                    #region Add Cost of Sales Transactions
                    if (DgvPurchases.Rows.Count > 1)
                    {
                        if (IsCashORbankAccountInvolve())
                        {
                            if (!AccountTransactionStatus(out StatusMsg))
                            {
                                MessageBox.Show(StatusMsg);
                                return;
                            }
                            if (IsTransactionalAccountExceeding(out StatusMsg))
                            {
                                MessageBox.Show(StatusMsg);
                                return;
                            }
                        }
                        for (int j = 0; j < DgvPurchases.Rows.Count - 1; j++)
                        {
                            VoucherDetailEL oelVoucherDetail = new VoucherDetailEL();
                            TransactionsEL oelCostofSalesTransaction = new TransactionsEL();
                            oelVoucherDetail.IdVoucher = oelVoucher.IdVoucher;
                            oelCostofSalesTransaction.IdVoucher = oelVoucher.IdVoucher;
                            if (DgvPurchases.Rows[j].Cells["ColIdDetailVoucher"].Value != null)
                            {
                                oelVoucherDetail.IdVoucherDetail = new Guid(DgvPurchases.Rows[j].Cells["ColIdDetailVoucher"].Value.ToString());
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
                            oelVoucherDetail.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelCostofSalesTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelCostofSalesTransaction.IdCompany = Operations.IdCompany;
                            if (DgvPurchases.Rows[j].Cells["colDescription"].Value == null)
                            {
                                oelVoucherDetail.Description = "N/A";
                            }
                            else
                            {
                                oelVoucherDetail.Description = DgvPurchases.Rows[j].Cells["colDescription"].Value.ToString();
                            }
                            oelVoucherDetail.Seq = j + 1;
                            oelVoucherDetail.Units = 0;
                            oelVoucherDetail.IdAccount = Validation.GetSafeGuid(DgvPurchases.Rows[j].Cells["colIdAccount"].Value);
                            oelVoucherDetail.AccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colAccountNo"].Value);
                            if (oelVoucherDetail.Debit != 0)
                            {
                                oelVoucherDetail.LinkAccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colLinkAccount"].Value);
                            }
                            oelVoucherDetail.Debit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colDebit"].Value);
                            oelVoucherDetail.Credit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colCredit"].Value);
                            if (DgvPurchases.Rows[j].Cells["colDebit"].Value != null && Validation.GetSafeLong(DgvPurchases.Rows[j].Cells["colDebit"].Value) > 0)
                            {
                                oelVoucherDetail.TransactionType = "Dr";
                            }
                            if (DgvPurchases.Rows[j].Cells["colCredit"].Value != null && Validation.GetSafeLong(DgvPurchases.Rows[j].Cells["colCredit"].Value) > 0)
                            {
                                oelVoucherDetail.TransactionType = "Cr";
                            }
                            oelCostofSalesTransaction.AccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colAccountNo"].Value);
                            oelCostofSalesTransaction.LinkAccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colLinkAccount"].Value);
                            oelCostofSalesTransaction.SubAccountNo = "0";
                            oelCostofSalesTransaction.Date = VDate.Value;
                            oelCostofSalesTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelCostofSalesTransaction.VoucherType = "StockReceiptVoucher/Sub";
                            oelCostofSalesTransaction.Description = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colDescription"].Value);
                            oelCostofSalesTransaction.Debit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colDebit"].Value);
                            oelCostofSalesTransaction.Credit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colCredit"].Value);

                            if (oelCostofSalesTransaction.Debit != 0)
                            {
                                oelCostofSalesTransaction.TransactionType = "Dr";
                            }
                            else if (oelCostofSalesTransaction.Credit != 0)
                            {
                                oelCostofSalesTransaction.TransactionType = "Cr";
                            }

                            oelCostofSalesTransaction.Posted = chkPosted.Checked;
                            oelCostofSalesTransaction.AdjustmentType = -1;
                            oelCostofSalesTransaction.SettlementType = "Purchases";

                            oelCostOfSalesCollection.Add(oelVoucherDetail);
                            oelTransactionCollection.Add(oelCostofSalesTransaction);
                        }
                    }
                    #endregion
                    #region Save Code
                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new PurchaseHeadBLL();
                        var VManager = new VoucherBLL();
                        var ItemManager = new ItemsBLL();
                        if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), "StockReceiptVoucher") == false)
                        {

                            EntityoperationInfo infoResult = manager.InsertPurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection, oelCostOfSalesCollection);
                            if (infoResult.IsSuccess)
                            {
                                if (VManager.GetMaxVoucherNumber("StockReceiptVoucher", Operations.IdCompany) == VEditBox.Text)
                                {
                                    ItemManager.UpdateCurrentUnitPrice(oelItemsCollection);
                                }
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
                        var VManager = new VoucherBLL();
                        var ItemManager = new ItemsBLL();
                        EntityoperationInfo infoResult = manager.UpdatePurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection, oelCostOfSalesCollection);
                        if (infoResult.IsSuccess)
                        {
                            if (VManager.GetMaxVoucherNumber("StockReceiptVoucher", Operations.IdCompany) == VEditBox.Text)
                            {
                                ItemManager.UpdateCurrentUnitPrice(oelItemsCollection);
                            }
                            //manager.UpdateStockitems(oelTransactionCollection, "Add");
                            lblStatuMessage.Text = "Stock Receipt Successfully...";
                            ClearControl();
                            FillData();
                        }
                    }
                    #endregion
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
        private bool IsCashORbankAccountInvolve()
        {
            bool HeadStatus = false;
            for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
            {
                if (Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head" ||
                    Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                {
                    HeadStatus = true;
                    break;
                }
                else
                {
                    HeadStatus = false;
                    break;
                }
            }
            return HeadStatus;
        }
        private bool AccountTransactionStatus(out string Message)
        {
            bool TransactionStatus = true;
            Message = "";
            for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
            {
                if (Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head" ||
                    Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                {
                    if (Validation.GetSafeDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value) == 0 || Validation.GetSafeDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value) < 0)
                    {
                        Message = "Cash OR Bank Account Must Be Credited...";
                        TransactionStatus = false;
                    }
                    break;
                }
            }
            return TransactionStatus;
        }
        private bool IsTransactionalAccountExceeding(out string Message)
        {
            bool status = false;
            Message = string.Empty;
            for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
            {
                if (Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head" ||
                    Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                {
                    if (Validation.GetSafeDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value) > Validation.GetSafeDecimal(DgvPurchases.Rows[i].Cells["colClosingBalance"].Value))
                    {
                        Message = "Cash OR Bank Account Is Exceeding Credit Limit With Closing Balance...";
                        status = true;
                        break;
                    }
                }
            }
            return status;
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
            frmfindVouchers.VoucherType = "StockReceiptVoucher";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VoucherNo = oelVoucher.VoucherNo;
            IdVoucher = oelVoucher.IdVoucher;
            VEditBox.Text = oelVoucher.VoucherNo.ToString();
            FillVoucher("Voucher");

        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher("Voucher");
                }
            }
            else
                e.Handled = true;
        }
        private void FillVoucher(string LoadType)
        {
            var Manager = new VoucherBLL();
            List<VouchersEL> list = null;
            VoucherType = "StockReceiptVoucher";
            if (VEditBox.Text != string.Empty)
            {
                #region VoucherHeadInformation
                if (LoadType == "Voucher")
                {
                    list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(VEditBox.Text));
                }
                else
                {
                    list = Manager.GetVouchersByVehicleNumber(Operations.IdCompany, txtVehicalNo.Text);
                }
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VEditBox.Enabled = false;
                    txtBillNo.Text = list[0].BillNo;
                    VDate.Value = list[0].Date;
                    txtDescription.Text = list[0].Description;
                    LinkAccountNo = list[0].LinkAccountNo;
                    cbxPurchaseType.SelectedIndex = list[0].PurchaseType;
                    cbxPurchaser.SelectedIndex = list[0].Purchaser;
                    if (list[0].PurchaseType == 1)
                    {
                        txtVehicalNo.Text = Validation.GetSafeString(list[0].VehicalNo);
                        cbxVehicalType.SelectedIndex = list[0].VehicalType;
                        txtWeight.Text = Validation.GetSafeString(list[0].Weight);
                    }
                    //txtVat.Text = list[0].VAT.ToString();
                    //txtVATAmount.Text = list[0].VATAmount.ToString();
                    if (list[0].Posted)
                    {
                        //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
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
                    #region PurchaseTransactionInformation
                    List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "StockReceiptVoucher", Operations.IdCompany);

                    if (listTransactions.Count > 0)
                    {
                        TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Debit != 0);
                        if (oelSalesTransaction != null)
                        {
                            //PurchasesEditBox.Text = oelSalesTransaction.AccountNo.ToString();
                            //cbxNaturalAccounts.SelectedValue = oelSalesTransaction.AccountNo;
                            FillNaturalAccounts(oelSalesTransaction.AccountNo.ToString());
                            txtPurchasesAccountName.Text = oelSalesTransaction.AccountNo.ToString();
                            //txtPurchasesAccountName.Text = oelSalesTransaction.AccountName;
                            PurchasesTransactionId = oelSalesTransaction.TransactionID;
                        }
                        TransactionsEL oelPurchaseTransaction = listTransactions.Find(x => x.Credit != 0);
                        if (oelPurchaseTransaction != null)
                        {
                            EventTime = 1;
                            SEditBox.Text = Validation.GetSafeString(oelPurchaseTransaction.AccountNo);
                            EventTime = 0;
                            txtSupplierName.Text = oelPurchaseTransaction.AccountName;
                            //txtTotalAmount.Text = oelPurchaseTransaction.Credit.ToString();
                            //    txtSupplierName.Text = listSupplier[0].PersonName;
                            SupplierTransactionId = oelPurchaseTransaction.TransactionID;
                        }

                    }
                    #endregion
                    #region Purchase Expense Information
                    List<TransactionsEL> listPurchasesExpense = Manager.GetTransactions(IdVoucher, "StockReceiptVoucher/Sub", Operations.IdCompany);
                    if (listPurchasesExpense.Count > 0)
                    {
                        FillPurchasesExpenses(listPurchasesExpense);
                    }
                    else
                    {
                        DgvPurchases.Rows.Clear();
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
                    #endregion
                }
                else
                {
                    if (LoadType == "Voucher")
                    {
                        MessageBox.Show("Voucher Number Not Found ...");
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Not Found ...");
                    }
                    ClearControl();
                }
                #endregion
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
                    EventTime = 1;
                    SEditBox.Text = Validation.GetSafeString(oeTransaction.AccountNo);
                    txtCreditBalance.Text = oeTransaction.Credit.ToString();
                    //txtSupplierName.Text = oeTransaction.PersonName;
                    SupplierTransactionId = oeTransaction.TransactionID;
                    //List.RemoveAt(List.FindIndex(x => x.Qty == 0));
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

                    ////txtCreditBalance.Text = List.Sum(x => x.Amount).ToString();
                    txtCreditBalance.Text = List[0].Amount.ToString("0.00");
                    // DgvStockReceipt.DataSource = List;
                    //
                }
            }
        }
        private void FillPurchasesExpenses(List<TransactionsEL> List)
        {
            if (DgvPurchases.Rows.Count > 0)
            {
                DgvPurchases.Rows.Clear();
            }
            for (int i = 0; i < List.Count; i++)
            {
                DgvPurchases.Rows.Add();
                DgvPurchases.Rows[i].Cells[0].Value = List[i].AccountType;
                DgvPurchases.Rows[i].Cells[1].Value = List[i].TransactionID;
                DgvPurchases.Rows[i].Cells[2].Value = List[i].TransactionID;
                DgvPurchases.Rows[i].Cells[3].Value = List[i].IdAccount;
                DgvPurchases.Rows[i].Cells[4].Value = List[i].AccountNo;
                DgvPurchases.Rows[i].Cells[5].Value = List[i].LinkAccountNo;
                DgvPurchases.Rows[i].Cells[6].Value = List[i].AccountName;
                DgvPurchases.Rows[i].Cells[7].Value = List[i].ClosingBalance;
                DgvPurchases.Rows[i].Cells[8].Value = List[i].Description;
                DgvPurchases.Rows[i].Cells[9].Value = List[i].Debit;
                DgvPurchases.Rows[i].Cells[10].Value = List[i].Credit;
            }
            txtDebit.Text = List.Sum(x => x.Debit).ToString();
            txtCredit.Text = List.Sum(x => x.Credit).ToString();
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
            FillVoucher("Voucher");
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
            PreviousVoucherNo -= 1;
            VEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher("Voucher");
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
                    if (EventTime == 0)
                    {
                        EventCommandName = "Persons";
                        e.Handled = true;
                        frmAccount = new frmFindAccounts();
                        frmAccount.SearchText = e.KeyChar.ToString();
                        frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                        frmAccount.ShowDialog();
                    }
                }
                else
                    e.Handled = false;
            }
        }
        private void SEditBox_TextChanged(object sender, EventArgs e)
        {
            //if (EventTime == 0)
            //{

            //    frmAccount = new frmFindAccounts();
            //    frmAccount.SearchText = SEditBox.Text;
            //    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            //    frmAccount.ShowDialog();
            //}
        }
        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DgvStockReceipt.Focus();
            }
        }
        private void cbxNaturalAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBillNo.Focus();
            }
        }
        #region Purchases Grid Code and Events
        private void DgvPurchases_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPurchases.Columns[e.ColumnIndex].Name == "colDebit")
            {

                for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvPurchases.Rows[i].Cells["colDebit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtDebit.Text = OldValue.ToString();
                OldValue = 0;

            }
            else if (DgvPurchases.Columns[e.ColumnIndex].Name == "colCredit")
            {
                for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtCredit.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private void DgvPurchases_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPurchases.Columns[e.ColumnIndex].Name == "colDebit")
            {
                if (DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            else if (DgvPurchases.Columns[e.ColumnIndex].Name == "colCredit")
            {
                if (DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }
        private void DgvPurchases_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvPurchases.CurrentCellAddress.X == 6)
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
            if (DgvPurchases.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmAccount = new frmFindAccounts();
                    EventCommandName = "DgvPurchases";
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
        private void cbxPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPurchaseType.SelectedIndex > 0)
            {
                DgvPurchases.Enabled = true;
            }
            if (cbxPurchaseType.SelectedIndex == 1)
            {
                pnlVehical.Visible = true;
                FillVehicle();
            }
            else
            {
                pnlVehical.Visible = false;
                txtVehicalNo.Text = string.Empty;
            }
        }
        private void btnLoadByVehicleNo_Click(object sender, EventArgs e)
        {
            txtVehicalNo.Enabled = true;
        }
        private void txtVehicalNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher("Vehicle");
                }
            }
            else
                e.Handled = true;
        }
        frmPurchaseOrderPrint frmPrint;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint = new frmPurchaseOrderPrint();
            frmPrint.IdVoucher = IdVoucher;
            frmPrint.PrintType = "";
            frmPrint.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            frmPrint.ShowDialog();
        }
    }
}
