using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.BLL;
using Accounts.EL;
using MetroFramework.Forms;
using MetroFramework.Controls;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmStockIssuance : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindBrand frmfindBrand;
        frmPrintMaterialsIssuance frmissuance;
        string EventCommandName;
        string EventStockName;
        int EventTime = 0;
        public Int64 VoucherNo { get; set; }
        public Int32 GPType { get; set; }
        public bool IsOut { get; set; }
        Guid IdVoucher;
        Guid IdArticle = Guid.Empty;
        frmAuthentication frmAuthenticate;
        #endregion
        public frmStockIssuance()
        {
            InitializeComponent();
        }
        private void frmStockIssuance_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.grdProducts.AutoGenerateColumns = false;
            FillData();
            FormLabel();
            LoadGatePassTypes();
            LoadStepsByType();
            ShowHideColumnsOnLoad();
        }
        private void ShowHideColumnsOnLoad()
        {
            if (IsOut && GPType == 1)
            {
                grdProducts.Columns[11].Visible = true;
            }
            else
            {
                grdProducts.Columns[11].Visible = false;
            }
            if (IsOut && GPType == 2)
            {
                lblArticle.Visible = true;
                txtArticle.Visible = true;
                grdProducts.Columns[5].Visible = false;
                grdProducts.Columns[6].Visible = true;
                grdProducts.Columns[7].Visible = false;
            }
            else if (!IsOut && GPType == 2)
            {
                lblArticle.Visible = false;
                txtArticle.Visible = false;
                grdProducts.Columns[5].Visible = true;
                grdProducts.Columns[6].Visible = false;
                grdProducts.Columns[7].Visible = true;
            }
        }

        private void FillData()
        {
            var manager = new ProductionIssuanceHeadBLL();
            int value = 0;
            if (IsOut)
                value = 1;
            else
                value = 2;
            VEditBox.Text = manager.GetMaxVoucherNumber(Operations.IdCompany, value, GPType).ToString();
        }
        private void FormLabel()
        {
            if (GPType == 1 && IsOut)
            {
                this.Text = "Gloves Outward GatePass";
                lblVoucherNo.Text = "OutPass No";
            }
            else if (GPType == 1 && !IsOut)
            {
                this.Text = "Gloves InWard GatePass";
                lblVoucherNo.Text = "InPass No";
            }
            else if (GPType == 2 && IsOut)
            {
                this.Text = "Garments Outward Pass";
            }
            else if (GPType == 2 && !IsOut)
            {
                this.Text = "Garments Inward Pass";
            }
        }
        private void LoadStepsByType()
        {
            if (GPType == 1 && IsOut)
            {
                cbxProductionType.Items.Add("");
                cbxProductionType.Items.Add("Cuff Cutting");
                cbxProductionType.Items.Add("Talli Cutting");
                cbxProductionType.Items.Add("Cuff Printing");
                cbxProductionType.Items.Add("OverLock");
                cbxProductionType.Items.Add("Magzi/Tape");
                cbxProductionType.Items.Add("Stitching");
            }
            else if (GPType == 1 && !IsOut)
            {
                cbxProductionType.Items.Add("");
                cbxProductionType.Items.Add("Cuff Cutting");
                cbxProductionType.Items.Add("Talli Cutting");
                cbxProductionType.Items.Add("Cuff Printing");
                cbxProductionType.Items.Add("OverLock");
                cbxProductionType.Items.Add("Magzi/Tape");
                cbxProductionType.Items.Add("Stitching");
            }
            else if (GPType == 2 && IsOut)
            {
                cbxProductionType.Items.Add("");
                cbxProductionType.Items.Add("Cutting");
                cbxProductionType.Items.Add("Singer Stitching");
                cbxProductionType.Items.Add("Feedo");
                cbxProductionType.Items.Add("Kaj/Buttons");
                cbxProductionType.Items.Add("Bartake");
                cbxProductionType.Items.Add("Threading");
                cbxProductionType.Items.Add("Checking / Inspection");
                cbxProductionType.Items.Add("Press");
                cbxProductionType.Items.Add("Packing");
            }
            else if (GPType == 2 && !IsOut)
            {
                cbxProductionType.Items.Add("");
                cbxProductionType.Items.Add("Cutting");
                cbxProductionType.Items.Add("Singer Stitching");
                cbxProductionType.Items.Add("Feedo");
                cbxProductionType.Items.Add("Kaj/Buttons");
                cbxProductionType.Items.Add("Bartake");
                cbxProductionType.Items.Add("Threading");
                cbxProductionType.Items.Add("Checking / Inspection");
                cbxProductionType.Items.Add("Press");
                cbxProductionType.Items.Add("Packing");
            }
        }
        private void LoadGatePassTypes()
        {
            if (GPType == 1 && IsOut)
            {
                cbxGatePassType.Items.Add("");
                cbxGatePassType.Items.Add("Gloves Maker");
                cbxGatePassType.Items.Add("Rubber Cuff");
                cbxGatePassType.Items.Add("Material Issuance");
                cbxGatePassType.Items.Add("Container OutPass");
                cbxGatePassType.Items.Add("Gloves Repair");
                cbxGatePassType.Items.Add("Repairing and Maintainance");
                cbxGatePassType.Items.Add("General Sales");                
            }
            else if (GPType == 1 && !IsOut)
            {
                cbxGatePassType.Items.Add("");
                cbxGatePassType.Items.Add("Gloves Maker");
                cbxGatePassType.Items.Add("Production Materials");
                cbxGatePassType.Items.Add("Material Return");
                cbxGatePassType.Items.Add("Gloves Repair");
            }
            else if (GPType == 2 && IsOut)
            {
                cbxGatePassType.Items.Add("");
                cbxGatePassType.Items.Add("Garments Maker");
            }
            else if (GPType == 2 && !IsOut)
            {
                cbxGatePassType.Items.Add("");
                cbxGatePassType.Items.Add("Garments Maker");
            }
        }
        //private void FillDepartments()
        //{
        //    var manager = new ProcessesBLL();
        //    List<ProcessesEL> list = manager.GetAllProcesses();
        //    list.Insert(0, new ProcessesEL() { ProcessName = "", IdProcess = Guid.Empty });

        //    cbxProductionType.DataSource = list;
        //    cbxProductionType.DisplayMember = "ProcessName";
        //    cbxProductionType.ValueMember = "IdProcess";
        //}       
        private bool ValidateRows()
        {

            for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
            {
                if (grdProducts.Rows[i].Cells["colQty"].Value == null || Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colQty"].Value) == 0)
                {
                    return false;
                }
                if (cbxProductionType.Text != "Stitching")
                {
                    if (Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colRate"].Value) == 0 && Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value) == 0)
                    {
                        MessageBox.Show("Please Enter Rate For Costing...");
                        return false;
                    }
                }
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (SEditBox.Text == string.Empty)
            {
                MessageBox.Show("Account No Is Missing....");
                return false;
            }
            else if (cbxGatePassType.Text == "")
            {
                MessageBox.Show("Please Select Gate Pass Type :");
                return false;
            }
            else if (cbxProductionType.Text == "")
            {
                MessageBox.Show("Please Select Production Type :");
                return false;
            }
            return true;
        }
        //private void btnSaveCuttingTalli_Click(object sender, EventArgs e)
        //{
        //    List<VoucherDetailEL> oelProductionIssuanceDetailCollection = new List<VoucherDetailEL>();
        //    /// Add Voucher...
        //    #region Voucher Head Entries
        //    VouchersEL oelVoucher = new VouchersEL();
        //    if (IdVoucher == Guid.Empty)
        //    {
        //        oelVoucher.IdVoucher = Guid.NewGuid();
        //    }
        //    else
        //    {
        //        oelVoucher.IdVoucher = IdVoucher;
        //    }
        //    oelVoucher.IdUser = Operations.UserID;
        //    oelVoucher.IdCompany = Operations.IdCompany;
        //    oelVoucher.IdDepartment = Validation.GetSafeGuid(cbxProductionType.SelectedValue);
        //    oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
        //    oelVoucher.AccountNo = Validation.GetSafeString(SEditBox.Text);
        //    oelVoucher.WorkType = false;
        //    oelVoucher.Description = "N/A";
        //    oelVoucher.CreatedDateTime = VDate.Value;
        //    #endregion
        //    ///Add Stock Detail 
        //    #region Stock Entries
        //    for (int i = 0; i < grdCuffing.Rows.Count - 1; i++)
        //    {
        //        VoucherDetailEL oelProductionIssuance = new VoucherDetailEL();
        //        ItemsEL oelItem = new ItemsEL();
        //        if (grdCuffing.Rows[i].Cells["colCuffingId"].Value != null)
        //        {
        //            //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
        //            oelProductionIssuance.IdVoucherDetail = new Guid(grdCuffing.Rows[i].Cells["colCuffingId"].Value.ToString());
        //            oelProductionIssuance.IsNew = false;
        //        }
        //        else
        //        {
        //            oelProductionIssuance.IdVoucherDetail = Guid.NewGuid();
        //            //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
        //            oelProductionIssuance.IsNew = true;
        //        }
        //        oelProductionIssuance.Seq = i + 1;
        //        oelProductionIssuance.IdVoucher = oelVoucher.IdVoucher;
        //        oelProductionIssuance.VoucherNo = Convert.ToInt64(VEditBox.Text);
        //        oelProductionIssuance.IdItem = Validation.GetSafeGuid(grdCuffing.Rows[i].Cells["colcuffingIdItem"].Value);
        //        oelProductionIssuance.PackingSize = Validation.GetSafeString(grdCuffing.Rows[i].Cells["colCuffingPacking"].Value);

        //        oelProductionIssuance.Qty = Validation.GetSafeInteger(grdCuffing.Rows[i].Cells["colCuffingQty"].Value);
        //        oelProductionIssuance.MeterYardQty = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffingMeterYard"].Value);
        //        oelProductionIssuance.BariSize = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colCuffingBariSize"].Value);
        //        oelProductionIssuance.TotalBari = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffingTotalBari"].Value);
        //        oelProductionIssuance.TalliBariWidth = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffingWidth"].Value);
        //        oelProductionIssuance.TalliBariSize = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffTaliBariSize"].Value);
        //        oelProductionIssuance.CalculatedQty = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colCuffingCalculatedQty"].Value);
        //        oelProductionIssuance.TotalCuffs = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colTotalCuffBari"].Value);
        //        oelProductionIssuance.Dozen = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colCuffingDozen"].Value);
        //        oelProductionIssuance.EstimatedQty = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffingEstimated"].Value);
        //        oelProductionIssuanceDetailCollection.Add(oelProductionIssuance);
        //    }
        //    #endregion
        //    #region Insert Values
        //    if (IdVoucher == Guid.Empty)
        //    {
        //        var manager = new ProductionIssuanceHeadBLL();
        //        var VManager = new VoucherBLL();

        //        EntityoperationInfo infoResult = manager.InsertProductionIssuance(oelVoucher, oelProductionIssuanceDetailCollection, false);
        //        if (infoResult.IsSuccess)
        //        {
        //            MessageBox.Show("Inventory Issued Successfully...");
        //            ClearControl();
        //            FillData();
        //        }                
        //        else
        //        {
        //            MessageBox.Show("Problem Occured While Issuance Production Stock :");
        //        }
        //    }
        //    else
        //    {
        //        var manager = new ProductionIssuanceHeadBLL();
        //        var VManager = new VoucherBLL();
        //        var ItemManager = new ItemsBLL();
        //        EntityoperationInfo infoResult = manager.UpdateProductionIssuance(oelVoucher, oelProductionIssuanceDetailCollection, false);
        //        if (infoResult.IsSuccess)
        //        {
        //            MessageBox.Show("Inventory Issuance Updated Successfully...");
        //            ClearControl();
        //            FillData();
        //        }
        //    }
        //    #endregion
        //}
        private void ClearControl()
        {
            grdProducts.Rows.Clear();
            VoucherNo = 0;
            IdVoucher = Guid.Empty;
            VEditBox.Enabled = true;
            cbxGatePassType.SelectedIndex = 0;
            cbxProductionType.SelectedIndex = 0;
            SEditBox.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            txtArticle.Text = string.Empty;
            IdArticle = Guid.Empty;
            grdProducts.Rows.Clear();
        }
        private void SEditBox_Click(object sender, EventArgs e)
        {

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
                        cbxProductionType.Focus();
                        cbxProductionType.DroppedDown = true;
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
                grdProducts.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                grdProducts.CurrentRow.Cells["colLinkAccount"].Value = oelAccount.LinkAccountNo;
                grdProducts.CurrentRow.Cells["colIdAccount"].Value = oelAccount.IdAccount;
                grdProducts.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
            }
        }
        private void grdProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdProducts.CurrentCellAddress.X == 5)
            {
                TextBox txtArticle = e.Control as TextBox;
                if (txtArticle != null)
                {
                    txtArticle.KeyPress -= new KeyPressEventHandler(txtArticle_KeyPress);
                    txtArticle.KeyPress += new KeyPressEventHandler(txtArticle_KeyPress);
                }
            }
            else if (grdProducts.CurrentCellAddress.X == 6)
            {
                TextBox txtItemName = e.Control as TextBox;
                if (txtItemName != null)
                {
                    txtItemName.KeyPress -= new KeyPressEventHandler(txtItemName_KeyPress);
                    txtItemName.KeyPress += new KeyPressEventHandler(txtItemName_KeyPress);
                }
            }
            if (grdProducts.CurrentCellAddress.X == 7)
            {
                TextBox txtBrand = e.Control as TextBox;
                if (txtBrand != null)
                {
                    txtBrand.KeyPress -= new KeyPressEventHandler(txtBrand_KeyPress);
                    txtBrand.KeyPress += new KeyPressEventHandler(txtBrand_KeyPress);
                }
            }
        }
        void txtArticle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdProducts.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventStockName = "ArticleEvent";
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
        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdProducts.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventStockName = "MaterialEvent";
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
        void txtBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdProducts.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmfindBrand = new frmFindBrand();
                    frmfindBrand.SearchBy = "";
                    frmfindBrand.ExecuteFindBrandEvent += new frmFindBrand.FindBrandDelegate(frmfindBrand_ExecuteFindBrandEvent);
                    frmfindBrand.ShowDialog();
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
        void frmfindBrand_ExecuteFindBrandEvent(object Sender, BrandEL oelBrand)
        {
            grdProducts.CurrentRow.Cells["colIdbrand"].Value = oelBrand.IdBrand;
            grdProducts.CurrentRow.Cells["colBrandName"].Value = oelBrand.BrandName;
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            var manager = new ItemsBLL();
            if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
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

                if (EventStockName == "MaterialEvent")
                {
                    grdProducts.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                    grdProducts.CurrentRow.Cells["colItemName"].Value = oelItems.AccountName;
                    grdProducts.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                    LoadItemSizes(oelItems.IdItem);
                }
                else if (EventStockName == "ArticleEvent")
                {
                    grdProducts.CurrentRow.Cells["colIdArticle"].Value = oelItems.IdItem;
                    grdProducts.CurrentRow.Cells["colArticleName"].Value = oelItems.AccountName;
                    grdProducts.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                    LoadItemSizes(oelItems.IdItem);
                }
                else
                {
                    IdArticle = oelItems.IdItem;
                    txtArticle.Text = oelItems.AccountName;
                }
            }
        }
        private void LoadItemSizes(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)grdProducts.CurrentRow.Cells["colSizes"];

                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";

                if (GPType == 1)
                {
                    if(list[1].ItemSize != "")
                    cellO.Value = list[1].IdSize;
                }
            }
        }
        private void ShowHideColumns()
        {
            if (IsOut && GPType == 1)
            {
                lblArticle.Visible = false;
                txtArticle.Visible = false;
                if (cbxProductionType.Text == "Cuff Cutting")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = false;
                }
                else if (cbxProductionType.Text == "Talli Cutting")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = false;
                }
                else if (cbxProductionType.Text == "Cuff Printing")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "OverLock")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "Magzi/Tape")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "Stitching" && cbxGatePassType.Text == "Gloves Repair")
                {
                    grdProducts.Columns[5].Visible = true;
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[7].Visible = false;
                    lblArticle.Visible = false;
                    txtArticle.Visible = false;
                }
                else if (cbxProductionType.Text == "Stitching")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[6].Visible = true;
                    grdProducts.Columns[7].Visible = false;
                    lblArticle.Visible = true;
                    txtArticle.Visible = true;
                }
                else if (cbxProductionType.Text == "Checking / Inspection")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "Packing")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
            }
            else if (!IsOut && GPType == 1)
            {
                if (cbxProductionType.Text == "Cuff Cutting")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[6].Visible = true;
                    grdProducts.Columns[7].Visible = false;
                }
                else if (cbxProductionType.Text == "Talli Cutting")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[6].Visible = true;
                    grdProducts.Columns[7].Visible = false;
                }
                else if (cbxProductionType.Text == "Cuff Printing")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "OverLock")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "Magzi/Tape")
                {
                    grdProducts.Columns[5].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "Stitching")
                {
                    grdProducts.Columns[5].Visible = true;
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "Checking / Inspection")
                {
                    grdProducts.Columns[5].Visible = true;
                    grdProducts.Columns[7].Visible = true;
                }
                else if (cbxProductionType.Text == "Packing")
                {
                    grdProducts.Columns[5].Visible = true;
                    grdProducts.Columns[7].Visible = true;
                }
            }
        }
        private void FillVoucher()
        {
            var manager = new ProductionIssuanceHeadBLL();
            int value = 0;
            if (IsOut)
                value = 1;
            else
                value = 2;
            List<VouchersEL> lstVoucher = manager.GetProductionIssuanceVoucherByNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany, value, GPType);
            if (lstVoucher.Count > 0)
            {
                IdVoucher = lstVoucher[0].IdVoucher;
                cbxProductionType.SelectedIndex = Validation.GetSafeInteger(lstVoucher[0].OperationType);
                cbxGatePassType.Text = lstVoucher[0].GatePassType;
                txtArticle.Text = lstVoucher[0].PoNumber;
                IdArticle = lstVoucher[0].IdArticle;
                txtArticle.Text = lstVoucher[0].ArticleName;
                //cbxInOut.SelectedIndex = lstVoucher[0].ProcessType;
                //if (lstVoucher[0].WorkType == false)
                //{
                //    List<VoucherDetailEL> list = manager.GetProductionStockIssuanceDetailForTalliBariByNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
                //    VDate.Value = list[0].CreatedDateTime.Value;
                //    cbxProductionType.SelectedValue = list[0].IdDepartment;
                //    //cbxInOut.SelectedIndex = list[0].ProcessType;
                //    SEditBox.Text = list[0].AccountNo;
                //    txtSupplierName.Text = list[0].AccountName;
                //    FillIssuanceDetail(list, true);
                //    tabMain.SelectedIndex = 0;
                //}
                //else
                //{
                List<VoucherDetailEL> list = manager.GetProductionStockIssuanceByNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany, value, GPType);
                if (list.Count > 0)
                {
                    VDate.Value = list[0].CreatedDateTime.Value;
                    //cbxProductionType.SelectedValue = list[0].OperationType;
                    SEditBox.Text = list[0].AccountNo;
                    txtSupplierName.Text = list[0].AccountName;
                    FillIssuanceDetail(list, true);
                    tabMain.SelectedIndex = 0;
                    ShowHideColumns();
                }
                else
                {
                    grdProducts.Rows.Clear();
                }
                //}
            }
            else
            {
                MessageBox.Show("Voucher Not Found In Record...");
                ClearControl();
            }

        }
        private void FillIssuanceDetail(List<VoucherDetailEL> list, bool WorkType)
        {
            if (WorkType)
            {
                grdProducts.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdProducts.Rows.Add();
                    grdProducts.Rows[i].Cells["colIdDetail"].Value = list[i].IdVoucherDetail;
                    grdProducts.Rows[i].Cells["colIdItem"].Value = list[i].IdItem;
                    grdProducts.Rows[i].Cells["colIdArticle"].Value = list[i].IdSubArticle;
                    grdProducts.Rows[i].Cells["colArticleName"].Value = list[i].SubArticle;
                    grdProducts.Rows[i].Cells["colIdbrand"].Value = list[i].IdBrand;
                    grdProducts.Rows[i].Cells["colBrandName"].Value = list[i].BrandName;
                    grdProducts.Rows[i].Cells["colItemName"].Value = list[i].ItemName;
                    grdProducts.Rows[i].Cells["colpacking"].Value = list[i].PackingSize;
                    LoadItemSizes(list[i].IdItem);
                    if (grdProducts.Rows[i].Cells["colSizes"].Value != null)
                    {
                        grdProducts.Rows[i].Cells["colSizes"].Value = list[i].IdSize;
                    }                    
                    grdProducts.Rows[i].Cells["colWidth"].Value = list[i].IssuanceWidth;
                    if (GPType == 1)
                    {
                        if (list[i].IssuanceDept == 1)
                        {
                            grdProducts.Rows[i].Cells["colIssuanceDept"].Value = 1;
                        }
                        else if (list[i].IssuanceDept == 2)
                        {
                            grdProducts.Rows[i].Cells["colIssuanceDept"].Value = 2;
                        }
                        else if (list[i].IssuanceDept == 3)
                        {
                            grdProducts.Rows[i].Cells["colIssuanceDept"].Value = 3;
                        }
                        else if (list[i].IssuanceDept == 4)
                        {
                            grdProducts.Rows[i].Cells["colIssuanceDept"].Value = 4;
                        }
                    }
                    grdProducts.Rows[i].Cells["colQty"].Value = list[i].Qty;
                    grdProducts.Rows[i].Cells["colRate"].Value = list[i].UnitPrice;
                    grdProducts.Rows[i].Cells["colAmount"].Value = list[i].Amount.ToString("0.00");
                }
            }
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillVoucher();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grdProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            if (GPType == 1)
            {
                if (e.ColumnIndex == 11)
                {
                    SendKeys.Send("{F4}");
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            FillData();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
            PreviousVoucherNo -= 1;
            VEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            long NextVoucherNo = Convert.ToInt64(VEditBox.Text);
            NextVoucherNo += 1;
            VEditBox.Text = NextVoucherNo.ToString();
            FillVoucher();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new ProductionIssuanceHeadBLL(); //PurchaseStockReceiptBLL();
            if (IdVoucher != Guid.Empty)
            {
                if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Gate Pass", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    if (manager.DeleteGatePass(IdVoucher))
                    {
                        MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                        ClearControl();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Voucher To Delete....");
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmissuance = new frmPrintMaterialsIssuance();
            frmissuance.IssuanceNo = Validation.GetSafeLong(VEditBox.Text);
            if (IsOut)
            {
                frmissuance.IssuanceType = 1;
            }
            else
            {
                frmissuance.IssuanceType = 2;
            }
            frmissuance.ProductionType = GPType;
            frmissuance.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<VoucherDetailEL> oelProductionIssuanceDetailCollection = new List<VoucherDetailEL>();
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
                oelVoucher.IdArticle = IdArticle;
                oelVoucher.IdCompany = Operations.IdCompany;
                oelVoucher.IdDepartment = Validation.GetSafeGuid(cbxProductionType.SelectedValue);
                oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
                oelVoucher.AccountNo = Validation.GetSafeString(SEditBox.Text);
                oelVoucher.GatePassType = Validation.GetSafeString(cbxGatePassType.Text);
                oelVoucher.ProcessType = IsOut ? 1 : 2;
                oelVoucher.GPType = GPType;
                oelVoucher.OperationType = cbxProductionType.SelectedIndex;
                oelVoucher.Description = "N/A";
                oelVoucher.CreatedDateTime = VDate.Value;
                #endregion
                ///Add Stock Detail 
                #region Stock Entries
                if (ValidateRows())
                {
                    if (GPType == 1 && IsOut && !CheckMandatoryItemQuantity() && txtArticle.Visible == true)
                    {
                        frmAuthenticate = new frmAuthentication();
                        frmAuthenticate.ShowDialog();
                        if (!Operations.IsAuthenticate)
                        {
                            MessageBox.Show("You Are Not Authenticated, Please Authenticate");
                            return;
                        }
                    }
                    for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelProductionIssuance = new VoucherDetailEL();
                        ItemsEL oelItem = new ItemsEL();
                        if (grdProducts.Rows[i].Cells["colIdDetail"].Value != null)
                        {
                            //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                            oelProductionIssuance.IdVoucherDetail = new Guid(grdProducts.Rows[i].Cells["colIdDetail"].Value.ToString());
                            oelProductionIssuance.IsNew = false;
                        }
                        else
                        {
                            oelProductionIssuance.IdVoucherDetail = Guid.NewGuid();
                            //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                            oelProductionIssuance.IsNew = true;
                        }
                        oelProductionIssuance.Seq = i + 1;
                        oelProductionIssuance.IdVoucher = oelVoucher.IdVoucher;
                        oelProductionIssuance.VoucherNo = Convert.ToInt64(VEditBox.Text);
                        oelProductionIssuance.IdItem = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdItem"].Value);
                        if(!IsOut && GPType == 1 && cbxProductionType.Text == "Stitching")
                        {
                            oelProductionIssuance.IdItem = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdArticle"].Value);
                        }
                        oelProductionIssuance.IdArticle = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdArticle"].Value);
                        oelProductionIssuance.IdBrand = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdbrand"].Value);
                        oelProductionIssuance.PackingSize = Validation.GetSafeString(grdProducts.Rows[i].Cells["colpacking"].Value);
                        oelProductionIssuance.IdSize = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colSizes"].Value);
                        oelProductionIssuance.IssuanceWidth = Validation.GetSafeString(grdProducts.Rows[i].Cells["colWidth"].Value);
                        if (GPType == 1)
                        {
                            if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Cuff Cutting")
                            {
                                oelProductionIssuance.IssuanceDept = 1;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Cuff Printing")
                            {
                                oelProductionIssuance.IssuanceDept = 2;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "OverLock")
                            {
                                oelProductionIssuance.IssuanceDept = 3;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Magzi/Tape")
                            {
                                oelProductionIssuance.IssuanceDept = 4;
                            }
                            else
                            {
                                oelProductionIssuance.IssuanceDept = -1;
                            }
                        }
                        else
                        { 
                            oelProductionIssuance.IssuanceDept = -2;
                        }
                        oelProductionIssuance.Units = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colQty"].Value);
                        oelProductionIssuance.UnitPrice = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colRate"].Value);
                        oelProductionIssuance.Amount = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);

                        if (!IsOut)
                        {
                            for (int j = 0; j < grdProducts.Rows.Count - 1; j++)
                            {
                                oelVoucher.TotalUnits += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colQty"].Value);
                                oelVoucher.TotalRate += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colRate"].Value);
                                oelVoucher.TotalAmount += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);
                            }
                        }
                        else
                        {
                            oelProductionIssuance.TotalUnits = 0;
                            oelProductionIssuance.TotalRate = 0;
                            oelProductionIssuance.TotalAmount = 0;
                        }
                        oelProductionIssuanceDetailCollection.Add(oelProductionIssuance);
                    }
                }
                #endregion
                #region Insert Values
                if (IdVoucher == Guid.Empty)
                {
                    var manager = new ProductionIssuanceHeadBLL();
                    var VManager = new VoucherBLL();
                    
                        EntityoperationInfo infoResult = manager.InsertProductionIssuance(oelVoucher, oelProductionIssuanceDetailCollection, false);
                        if (infoResult.IsSuccess)
                        {
                            if (IsOut)
                            {
                                MessageBox.Show("Inventory Issued Successfully...");
                            }
                            else
                            {
                                MessageBox.Show("Production Recieved Successfully");
                            }
                            ClearControl();
                            FillData();
                        }
                        else
                        {
                            MessageBox.Show("Problem Occured While Issuance Production Stock :");
                        }                    
                }
                else
                {
                    var manager = new ProductionIssuanceHeadBLL();
                    var VManager = new VoucherBLL();
                    var ItemManager = new ItemsBLL();
                    EntityoperationInfo infoResult = manager.UpdateProductionIssuance(oelVoucher, oelProductionIssuanceDetailCollection, false);
                    if (infoResult.IsSuccess)
                    {
                        MessageBox.Show("Inventory Issuance Updated Successfully...");
                        ClearControl();
                        FillData();
                    }
                }
                #endregion
            }
        }
        private bool CheckMandatoryItemQuantity()
        {
            var Manager = new ItemsBLL();
            bool? IsMandatoryExists=false, Status = true;
            List<ItemsEL> list = null;
            decimal MandatoryQty = 0;
            Guid IdItem = Guid.Empty;
            for (int i = 0; i < grdProducts.Rows.Count-1; i++)
            {
                list = Manager.GetItemById(Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdItem"].Value));
                if (list.Count > 0)
                { 
                    IsMandatoryExists = Validation.GetSafeBooleanNullable(list[0].IsMandatory);
                    if(IsMandatoryExists.HasValue)
                    {
                        IdItem = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdItem"].Value);
                        MandatoryQty = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colQty"].Value);
                        break;
                    }
                }
            }
            if (IsMandatoryExists.HasValue)
            {
                for (int j = 0; j < grdProducts.Rows.Count - 1; j++)
                {
                    if(IdItem != Validation.GetSafeGuid(grdProducts.Rows[j].Cells["colIdItem"].Value))
                    {
                        if (Validation.GetSafeDecimal(grdProducts.Rows[j].Cells["colQty"].Value) > MandatoryQty)
                        {
                            Status = false;
                            break;
                        }
                    }
                }
            }
            return Status.Value;
        }
        private void txtArticle_ButtonClick(object sender, EventArgs e)
        {
            frmstockAccounts = new frmStockAccounts();
            EventStockName = "";
            frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            frmstockAccounts.ShowDialog();
        }
        private void cbxProductionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GPType == 1)
            {
                ShowHideColumns();
            }
        }
        private void grdProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                //if (cbxGatePassType.Text == "Rubber Cuff" && GPType == 1)
                //{
                //    var manager = new ProductionIssuanceHeadBLL();
                //    List<VoucherDetailEL> obj = manager.GetRubberingStockById(Operations.IdCompany, Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdItem"].Value));
                //    if (obj.Count > 0)
                //    {
                //        if (Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value) > Validation.GetSafeDecimal(obj[0].ClosingUnits))
                //        {
                //            MessageBox.Show("Available Quantity For Rubber Cuff Is : " + obj[0].ClosingUnits.ToString() + " Which is Less Than Required Quantity");
                //            grdProducts.Rows[e.RowIndex].Cells["colQty"].Value = "";
                //        }
                //    }
                //}
                if (GPType == 1 && IsOut)
                {
                    var Manager = new ItemsBLL();
                    if (cbxGatePassType.Text == "Gloves Repair" && IsOut)
                    {
                        var PManager = new ProductionProcessDetailBLL();
                        List<VoucherDetailEL> list = PManager.GetGlovesRepairableClosingStock(Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdArticle"].Value));
                        if (Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value) > Validation.GetSafeDecimal(list[0].ClosingUnits))
                        {
                            MessageBox.Show("Available Quantity For Gloves Repair for Production : " + grdProducts.Rows[e.RowIndex].Cells["colArticleName"].Value.ToString() + " Is : " + list[0].ClosingUnits.ToString() + " Which is Greater Than Required Quantity");///
                            grdProducts.Rows[e.RowIndex].Cells["colQty"].Value = "";
                            //grdProducts.Rows[e.RowIndex].Cells["colRate"].Value = Manager.GetItemAverageRate(Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdItem"].Value))[0].TotalAmount;
                        }
                        else
                        {
                            grdProducts.Rows[e.RowIndex].Cells["colRate"].Value = (Manager.GetItemAverageRate(Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdArticle"].Value))[0].TotalAmount
                                                                                     * Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value)).ToString("0.00");
                        }
                    }
                    else
                    {
                       
                        List<ItemsEL> obj = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdItem"].Value));
                        if (grdProducts.Rows[e.RowIndex].Cells["colQty"].Value != null && obj.Count > 0)
                        {
                            if (Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value) > Validation.GetSafeDecimal(obj[0].Qty))
                            {
                                MessageBox.Show("Available Quantity For " + grdProducts.Rows[e.RowIndex].Cells["colItemName"].Value.ToString() + " Is : " + obj[0].Qty.ToString() + " Which is Greater Than Required Quantity");
                                grdProducts.Rows[e.RowIndex].Cells["colQty"].Value = "";
                                //grdProducts.Rows[e.RowIndex].Cells["colRate"].Value = Manager.GetItemAverageRate(Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdItem"].Value))[0].TotalAmount;
                            }
                            else
                            {
                                grdProducts.Rows[e.RowIndex].Cells["colRate"].Value = (Manager.GetItemAverageRate(Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdItem"].Value))[0].TotalAmount
                                                                                         * Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value)).ToString("0.00");
                            }
                        }
                    }
                }
            }
            if (grdProducts.Rows[e.RowIndex].Cells["colRate"].Value != null)
            {
                grdProducts.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colRate"].Value) * Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value)).ToString("0.00");
            }
        }
        private void frmStockIssuance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControl();
                FillData();
            }
        }

        private void cbxGatePassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGatePassType.Text == "Gloves Repair")
            {
                ShowHideColumns();
            }
        }
    }
}
