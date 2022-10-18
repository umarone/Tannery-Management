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
    public partial class frmGlovesProduction : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmstockAccounts;
        frmWorkPurchases frmworkpurchases;
        Guid IdVoucher = Guid.Empty;
        Guid IdCutting;
        Guid IdStitching;
        Guid IdPrinting;
        Guid IdOverLock;
        Guid IdMagzi;
        Guid IdInspection;
        Guid IdPacking; 
        Guid IdQuality;
        Guid IdEntity;
        string LoadType;
        string EventFiringName;
        string EmpAccountNo = "";
        string EmpAccountName = "";
        decimal postAmount;
        bool EntryAlreadyDone;
        #endregion
        #region Windows Form Events
        public frmGlovesProduction()
        {
            InitializeComponent();
        }
        private void frmGarmentProduction_Load(object sender, EventArgs e)
        {
            this.grdCutting.AutoGenerateColumns = false;
            this.grdStitching.AutoGenerateColumns = false;
            this.grdCuffPrinting.AutoGenerateColumns = false;
            this.grdCuffPrinting.AutoGenerateColumns = false;
            this.grdOverlockMaterials.AutoGenerateColumns = false;
            this.grdMagzi.AutoGenerateColumns = false;
            this.grdInspection.AutoGenerateColumns = false;
            this.grdPacking.AutoGenerateColumns = false;
            ProductionTab.SelectedIndex = 0;
            FillMaxProductionNo();
            FillCustomerPos();
        }
        private void FillMaxProductionNo()
        {
            var Manager = new ProductionProcessesHeadBLL();
            VEditBox.Text = Validation.GetSafeString(Manager.GetMaxProductionProcessCode(Operations.IdCompany,1));
        }
        #endregion
        #region Cutting Grid Events
        private void grdCutting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 12)
            {
                e.Value = "Post";
            }
        }
        private void grdCutting_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCutting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 11)
            {
                if (Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value), Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdCutting.Columns.Count; i++)
                    {
                        grdCutting.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 12)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(1))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.Description = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdCutting == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdCutting;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Cutting";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Guid.Empty; //Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdItem"].Value);
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty; //Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value);
                    oelProductionDetail.GType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdCutting.Rows[e.RowIndex].Cells["colCuttingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdCutting.Rows[e.RowIndex].Cells["colCuttingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdCutting = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) == "Employees")
                                {
                                    grdCutting.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Gloves Cutting Purchases";
                                    frmworkpurchases.ProcessName = "Gloves Cutting";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Gloves Cutting Purchases";
                        frmworkpurchases.ProcessName = "Gloves Cutting";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelTanneryProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdCutting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                //if (grdCutting.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value != null)
                //{
                //    grdCutting.Rows[e.RowIndex].Cells["colTrimmingAmount"].Value = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value) * Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colTrimmingRate"].Value);
                //}
                //else
                //{
                //    grdCutting.Rows[e.RowIndex].Cells["colTrimmingAmount"].Value = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value) * Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colTrimmingRate"].Value);
                //}
            }
        }
        private void grdCutting_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 6)
            {
                TextBox txtCuttingVendorName = e.Control as TextBox;
                if (txtCuttingVendorName != null)
                {
                    txtCuttingVendorName.KeyPress -= new KeyPressEventHandler(txtCuttingVendorName_KeyPress);
                    txtCuttingVendorName.KeyPress += new KeyPressEventHandler(txtCuttingVendorName_KeyPress);
                }
            }
        }
        void txtCuttingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Cuff Cutting";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Cutting Grid Material Events
        private void grdCuttingMaterialUsed_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuttingMaterialUsed.CurrentCellAddress.X == 3)
            {
                TextBox txtCuttingMaterialName = e.Control as TextBox;
                if (txtCuttingMaterialName != null)
                {
                    txtCuttingMaterialName.KeyPress -= new KeyPressEventHandler(txtCuttingMaterialName_KeyPress);
                    txtCuttingMaterialName.KeyPress += new KeyPressEventHandler(txtCuttingMaterialName_KeyPress);
                }
            }
        }
        void txtCuttingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuttingMaterialUsed.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Cutting Materials";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Cutting Grid Wastage
        private void grdCuttingWastage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuttingWastage.CurrentCellAddress.X == 3)
            {
                TextBox txtCuttingWastageMaterialName = e.Control as TextBox;
                if (txtCuttingWastageMaterialName != null)
                {
                    txtCuttingWastageMaterialName.KeyPress -= new KeyPressEventHandler(txtCuttingWastageMaterialName_KeyPress);
                    txtCuttingWastageMaterialName.KeyPress += new KeyPressEventHandler(txtCuttingWastageMaterialName_KeyPress);
                }
            }
        }
        void txtCuttingWastageMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuttingWastage.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Cutting Wastage";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Cuff Printing Grid Events
        private void grdCuffPrinting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {                        
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 14)
            {
                e.Value = "Posting";
            }
        }
        private void grdCuffPrinting_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCuffPrinting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
            {
                if (Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdCuffPrinting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value),
                            Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdCuffPrinting.Columns.Count; i++)
                    {
                        grdCuffPrinting.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 14)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(2))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.Description = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdPrinting == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdPrinting;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Printing";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdCuffPrinting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingVendorName"].Value);
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingIdItem"].Value);
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.GType = 0;
                    oelProductionDetail.GarmentWorkType = 0;


                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdPrinting = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountType"].Value) == "Employees")
                                {
                                    grdCuffPrinting.Rows[e.RowIndex].ReadOnly = true;
                                }
                                else if (Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Gloves Printing Purchases";
                                    frmworkpurchases.ProcessName = "Gloves Printing";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Gloves Printing Purchases";
                        frmworkpurchases.ProcessName = "Gloves Printing";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdCuffPrinting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
        }
        private void grdCuffPrinting_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void grdCuffPrinting_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuffPrinting.CurrentCellAddress.X == 7)
            {
                TextBox txtPrintingVendorName = e.Control as TextBox;
                if (txtPrintingVendorName != null)
                {
                    txtPrintingVendorName.KeyPress -= new KeyPressEventHandler(txtPrintingVendorName_KeyPress);
                    txtPrintingVendorName.KeyPress += new KeyPressEventHandler(txtPrintingVendorName_KeyPress);
                }
            }
            else if (grdCuffPrinting.CurrentCellAddress.X == 8)
            {
                TextBox txtPrintingBrand = e.Control as TextBox;
                if(txtPrintingBrand != null)
                {
                    txtPrintingBrand.KeyPress -=new KeyPressEventHandler(txtPrintingBrand_KeyPress);
                    txtPrintingBrand.KeyPress +=new KeyPressEventHandler(txtPrintingBrand_KeyPress);
                }
            }
        }
        void txtPrintingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrinting.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Printing";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void  txtPrintingBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
 	        if (grdCuffPrinting.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "PrintingBrand";
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
        #endregion
        #region Gloves Printing Grid Material Events
        private void grdCuffPrintingMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuffPrintingMaterial.CurrentCellAddress.X == 3)
            {
                TextBox txtCuffPrintingMaterialName = e.Control as TextBox;
                if (txtCuffPrintingMaterialName != null)
                {
                    txtCuffPrintingMaterialName.KeyPress -= new KeyPressEventHandler(txtCuffPrintingMaterialName_KeyPress);
                    txtCuffPrintingMaterialName.KeyPress += new KeyPressEventHandler(txtCuffPrintingMaterialName_KeyPress);
                }
            }
        }
        void txtCuffPrintingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrintingMaterial.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Printing Materials";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Gloves Printing Grid Wastage
        private void grdCuffPrintingWastage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (grdCuffPrintingWastage.CurrentCellAddress.X == 3)
            {
                TextBox txtCuffPrintingWastageMaterialName = e.Control as TextBox;
                if (txtCuffPrintingWastageMaterialName != null)
                {
                    txtCuffPrintingWastageMaterialName.KeyPress -= new KeyPressEventHandler(txtCuffPrintingWastageMaterialName_KeyPress);
                    txtCuffPrintingWastageMaterialName.KeyPress += new KeyPressEventHandler(txtCuffPrintingWastageMaterialName_KeyPress);
                }
            }
        }
        void txtCuffPrintingWastageMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrintingWastage.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Printing Wastage";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region OverLock Grid Events
        private void grdOverLock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {            
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 12)
            {
                e.Value = "Posting";
            }
        }
        private void grdOverLock_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdOverLock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 11)
            {
                if (Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdOverLock.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value),
                            Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colOverLockIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdOverLock.Columns.Count; i++)
                    {
                        grdOverLock.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 12)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(3))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.Description = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdOverLock == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdOverLock;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves OverLock";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdOverLock.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockVendorName"].Value);
                    oelProductionDetail.IdItem = Guid.Empty;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    oelProductionDetail.Description = "N/A";

                    oelProductionDetail.GType = 0;
                    oelProductionDetail.GarmentWorkType = 0;

                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdOverLock.Rows[e.RowIndex].Cells["colOverLockQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdOverLock.Rows[e.RowIndex].Cells["colOverLockDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdOverLock.Rows[e.RowIndex].Cells["colOverLockRates"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }

                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdOverLock = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountType"].Value) == "Employees")
                                {
                                    grdOverLock.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Gloves OverLock Purchases";
                                    frmworkpurchases.ProcessName = "Gloves OverLock";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Gloves OverLock Purchases";
                        frmworkpurchases.ProcessName = "Gloves OverLock";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdOverLock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdOverLock_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdOverLock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOverLock.CurrentCellAddress.X == 6)
            {
                TextBox txtOverLockVendorName = e.Control as TextBox;
                if (txtOverLockVendorName != null)
                {
                    txtOverLockVendorName.KeyPress -= new KeyPressEventHandler(txtOverLockVendorName_KeyPress);
                    txtOverLockVendorName.KeyPress += new KeyPressEventHandler(txtOverLockVendorName_KeyPress);
                }
            }
        }
        void txtOverLockVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOverLock.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves OverLock";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Over Lock Materials Events
        private void grdOverlockMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOverlockMaterials.CurrentCellAddress.X == 3)
            {
                TextBox txtOverLockMaterialName = e.Control as TextBox;
                if (txtOverLockMaterialName != null)
                {
                    txtOverLockMaterialName.KeyPress -= new KeyPressEventHandler(txtOverLockMaterialName_KeyPress);
                    txtOverLockMaterialName.KeyPress += new KeyPressEventHandler(txtOverLockMaterialName_KeyPress);
                }
            }
        }
        void txtOverLockMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOverlockMaterials.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves OverLock Materials";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Magzi/Tape Grid Events
        private void grdMagzi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {                                   
            if (e.ColumnIndex == 12)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 13)
            {
                e.Value = "Post";
            }
        }
        private void grdMagzi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdMagzi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Recored Deletion
            if (e.ColumnIndex == 12)
            {
                if (Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdMagzi.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value),
                            Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colMagziIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdMagzi.Columns.Count; i++)
                    {
                        grdMagzi.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 13)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(4))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.Description = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdMagzi == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdMagzi;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Magzi/Tape";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdMagzi.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziVendorName"].Value);
                    oelProductionDetail.IdItem = Guid.Empty;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    oelProductionDetail.Description = "N/A";

                    oelProductionDetail.GType = 0;
                    if (Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziWorkType"].Value) == "Magzi")
                    {
                        oelProductionDetail.GarmentWorkType = 1;
                    }
                    else if (Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziWorkType"].Value) == "Tape")
                    {
                        oelProductionDetail.GarmentWorkType = 2;
                    }
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdMagzi.Rows[e.RowIndex].Cells["colMagziQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdMagzi.Rows[e.RowIndex].Cells["colMagziWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdMagzi.Rows[e.RowIndex].Cells["colMagziRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdMagzi.Rows[e.RowIndex].Cells["colMagziAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdMagzi = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountType"].Value) == "Employees")
                                {
                                    grdMagzi.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Gloves Magzi/Tape Purchases";
                                    frmworkpurchases.ProcessName = "Gloves Magzi/Tape";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Gloves Magzi/Tape Purchases";
                        frmworkpurchases.ProcessName = "Gloves Magzi/Tape";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdMagzi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {           
        }
        private void grdMagzi_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdMagzi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdMagzi.CurrentCellAddress.X == 6)
            {
                TextBox txtMagziVendorName = e.Control as TextBox;
                if (txtMagziVendorName != null)
                {
                    txtMagziVendorName.KeyPress -= new KeyPressEventHandler(txtMagziVendorName_KeyPress);
                    txtMagziVendorName.KeyPress += new KeyPressEventHandler(txtMagziVendorName_KeyPress);
                }
            }
        }
        void txtMagziVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdMagzi.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Magzi";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Magzi/Tape Materials Grid Events
        private void grdMagziMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdMagziMaterial.CurrentCellAddress.X == 3)
            {
                TextBox txtMagziTapMaterialName = e.Control as TextBox;
                if (txtMagziTapMaterialName != null)
                {
                    txtMagziTapMaterialName.KeyPress -= new KeyPressEventHandler(txtMagziTapMaterialName_KeyPress);
                    txtMagziTapMaterialName.KeyPress += new KeyPressEventHandler(txtMagziTapMaterialName_KeyPress);
                }
            }
        }
        void txtMagziTapMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdMagziMaterial.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Magzi Materials";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Stitching Grid Events
        private void grdStitching_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 12)
            {
                e.Value = "Posting";
            }

        }
        private void grdStitching_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdStitching_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 11)
            {
                if (Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdStitching.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value),
                            Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdStitching.Columns.Count; i++)
                    {
                        grdStitching.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 12)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(5))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.Description = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdStitching == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdStitching;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Stitching";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdStitching.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Guid.Empty;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;

                    oelProductionDetail.GType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdStitching.Rows[e.RowIndex].Cells["colStitchingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdStitching.Rows[e.RowIndex].Cells["colStitchingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdStitching.Rows[e.RowIndex].Cells["colStitchingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colStitchingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdStitching = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountType"].Value) == "Employees")
                                {
                                    grdStitching.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Gloves Stitching Purchases";
                                    frmworkpurchases.ProcessName = "Gloves Stitching";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Gloves Stitching Purchases";
                        frmworkpurchases.ProcessName = "Gloves Stitching";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdStitching_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
            //if (grdStitching.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value != null)
            //{
            //    grdStitching.Rows[e.RowIndex].Cells["colSplittingAmount"].Value = Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) * Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colSplittingRate"].Value);
            //}
            //else
            //{
            //    grdStitching.Rows[e.RowIndex].Cells["colSplittingAmount"].Value = Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) * Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colSplittingRate"].Value);
            //}
        }
        private void grdStitching_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {            
            if (grdStitching.CurrentCellAddress.X == 6)
            {
                TextBox txtStitchingVendorName = e.Control as TextBox;
                if (txtStitchingVendorName != null)
                {
                    txtStitchingVendorName.KeyPress -= new KeyPressEventHandler(txtStitchingVendorName_KeyPress);
                    txtStitchingVendorName.KeyPress += new KeyPressEventHandler(txtStitchingVendorName_KeyPress);
                }
            }
        }
        void txtStitchingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitching.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Stitching";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Stitching Material Grid Events
        private void grdStitchingMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdStitchingMaterials.CurrentCellAddress.X == 3)
            {
                TextBox txtStitchingMaterialName = e.Control as TextBox;
                txtStitchingMaterialName.KeyPress -= new KeyPressEventHandler(txtStitchingMaterialName_KeyPress);
                txtStitchingMaterialName.KeyPress += new KeyPressEventHandler(txtStitchingMaterialName_KeyPress);
            }
        }
        void txtStitchingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitchingMaterials.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Stitching Materials";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Inspection Grid Events
        private void grdInspection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {            
            if (e.ColumnIndex == 15)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 16)
            {
                e.Value = "Posting";
            }
        }
        private void grdInspection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 15)
            {
                if (Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdInspection.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value),
                            Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdInspection.Columns.Count; i++)
                    {
                        grdInspection.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 16)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(6))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.Description = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdInspection == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdInspection;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Inspection";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdInspection.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdItem"].Value);
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;

                    oelProductionDetail.GType = 0;

                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionPassQuantity"].Value);
                    oelProductionDetail.Rejection = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionRejectedQuantity"].Value); ;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdInspection = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountType"].Value) == "Employees")
                                {
                                    grdInspection.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Gloves Inspection Purchases";
                                    frmworkpurchases.ProcessName = "Gloves Inspection";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Gloves Inspection Purchases";
                        frmworkpurchases.ProcessName = "Gloves Inspection";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdInspection_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdInspection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdInspection_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdInspection_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 7)
            {
                TextBox txtInspectionVendorName = e.Control as TextBox;
                if (txtInspectionVendorName != null)
                {
                    txtInspectionVendorName.KeyPress -= new KeyPressEventHandler(txtInspectionVendorName_KeyPress);
                    txtInspectionVendorName.KeyPress += new KeyPressEventHandler(txtInspectionVendorName_KeyPress);
                }
            }
            else if (grdInspection.CurrentCellAddress.X == 8)
            {
                TextBox txtInspectionBrandName = e.Control as TextBox;
                if(txtInspectionBrandName != null)
                {
                    txtInspectionBrandName.KeyPress -=new KeyPressEventHandler(txtInspectionBrandName_KeyPress);
                    txtInspectionBrandName.KeyPress +=new KeyPressEventHandler(txtInspectionBrandName_KeyPress);
                }
            }
        }
        void txtInspectionVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Inspection";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void  txtInspectionBrandName_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (grdInspection.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "InspectionBrand";
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
        #endregion              
        #region Packing Grid Events
        private void grdPacking_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 14)
            {
                e.Value = "Post";
            }
        }
        private void grdPacking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
            {
                if (Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdPacking.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value),
                            Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colInspectionIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdPacking.Columns.Count; i++)
                    {
                        grdPacking.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 14)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(7))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.Description = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdPacking == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdPacking;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Packing";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdPacking.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingIdItem"].Value);
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;

                    oelProductionDetail.GType = 0;
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;

                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value); ;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdPacking.Rows[e.RowIndex].Cells["colPackingWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingRates"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdPacking = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountType"].Value) == "Employees")
                                {
                                    grdPacking.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Gloves Packing Purchases";
                                    frmworkpurchases.ProcessName = "Gloves Packing";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Gloves Packing Purchases";
                        frmworkpurchases.ProcessName = "Gloves Packing";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdPacking_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdPacking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdPacking_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdPacking_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 7)
            {
                TextBox txtPackingVendorName = e.Control as TextBox;
                if (txtPackingVendorName != null)
                {
                    txtPackingVendorName.KeyPress -= new KeyPressEventHandler(txtPackingVendorName_KeyPress);
                    txtPackingVendorName.KeyPress += new KeyPressEventHandler(txtPackingVendorName_KeyPress);
                }
            }
            else if (grdPacking.CurrentCellAddress.X == 8)
            {
                TextBox txtPackingArticleName = e.Control as TextBox;
                if(txtPackingArticleName != null)
                {
                    txtPackingArticleName.KeyPress -=new KeyPressEventHandler(txtPackingArticleName_KeyPress);
                    txtPackingArticleName.KeyPress +=new KeyPressEventHandler(txtPackingArticleName_KeyPress);
                }
            }
        }
        void txtPackingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Packing";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void  txtPackingArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
 	        if (grdPacking.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "PackingBrand";
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
        #endregion 
        #region Packing Material Grid Events
        private void grdPackingMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 3)
            {
                TextBox txtPackingMaterialName = e.Control as TextBox;
                if (txtPackingMaterialName != null)
                {
                    txtPackingMaterialName.KeyPress -= new KeyPressEventHandler(txtPackingMaterialName_KeyPress);
                    txtPackingMaterialName.KeyPress += new KeyPressEventHandler(txtPackingMaterialName_KeyPress);
                }
            }
        }
        void txtPackingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Packing Materials";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region OverHeads Grid Events
        private void grdMiscCost_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "Delete";
            }
        }
        private void grdMiscCost_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdMiscCost.CurrentCellAddress.X == 3)
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
            if (grdMiscCost.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "OverHeads";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Common Events        
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (EventFiringName == "Gloves Cuff Cutting")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdCutting.CurrentRow.Cells["colCuttingAccountNo"].Value = oelAccount.AccountNo;
                    grdCutting.CurrentRow.Cells["colCuttingVendorName"].Value = oelAccount.AccountName;
                    grdCutting.CurrentRow.Cells["colCuttingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Stitching")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdStitching.CurrentRow.Cells["colStitchingAccountNo"].Value = oelAccount.AccountNo;
                    grdStitching.CurrentRow.Cells["colStitchingVendorName"].Value = oelAccount.AccountName;
                    grdStitching.CurrentRow.Cells["colStitchingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Printing")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdCuffPrinting.CurrentRow.Cells["colCuffPrintingAccountNo"].Value = oelAccount.AccountNo;
                    grdCuffPrinting.CurrentRow.Cells["colCuffPrintingVendorName"].Value = oelAccount.AccountName;
                    grdCuffPrinting.CurrentRow.Cells["colCuffPrintingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves OverLock")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdOverLock.CurrentRow.Cells["colOverLockAccountNo"].Value = oelAccount.AccountNo;
                    grdOverLock.CurrentRow.Cells["colOverLockVendorName"].Value = oelAccount.AccountName;
                    grdOverLock.CurrentRow.Cells["colOverLockAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Magzi")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdMagzi.CurrentRow.Cells["colMagziAccountNo"].Value = oelAccount.AccountNo;
                    grdMagzi.CurrentRow.Cells["colMagziVendorName"].Value = oelAccount.AccountName;
                    grdMagzi.CurrentRow.Cells["colMagziAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Inspection")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdInspection.CurrentRow.Cells["colInspectionAccountNo"].Value = oelAccount.AccountNo;
                    grdInspection.CurrentRow.Cells["colInspectionVendorName"].Value = oelAccount.AccountName;
                    grdInspection.CurrentRow.Cells["colInspectionAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Packing")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdPacking.CurrentRow.Cells["colPackingAccountNo"].Value = oelAccount.AccountNo;
                    grdPacking.CurrentRow.Cells["colPackingVendorName"].Value = oelAccount.AccountName;
                    grdPacking.CurrentRow.Cells["colPackingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "OverHeads")
            {
                grdMiscCost.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                grdMiscCost.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
            }
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            if (EventFiringName == "PrintingBrand")
            {
                grdCuffPrinting.CurrentRow.Cells["colCuffPrintingIdItem"].Value = oelItems.IdItem;
                grdCuffPrinting.CurrentRow.Cells["colCuffPrintingBrand"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "InspectionBrand")
            {
                grdInspection.CurrentRow.Cells["colInspectionIdItem"].Value = oelItems.IdItem;
                grdInspection.CurrentRow.Cells["colInspectionBrandName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "PackingBrand")
            {
                grdPacking.CurrentRow.Cells["colPackingIdItem"].Value = oelItems.IdItem;
                grdPacking.CurrentRow.Cells["colPackingArticleName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves Cutting")
            {
                grdCutting.CurrentRow.Cells["colCuttingIdItem"].Value = oelItems.IdItem;
                grdCutting.CurrentRow.Cells["colCuttingClotheName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves Cutting Materials")
            {
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialIdItem"].Value = oelItems.IdItem;
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves Cutting Wastage")
            {
                grdCuttingWastage.CurrentRow.Cells["colCuttingWastageIdItem"].Value = oelItems.IdItem;
                grdCuttingWastage.CurrentRow.Cells["colCuttingWastageName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves Printing Materials")
            {
                grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingIdItem"].Value = oelItems.IdItem;
                grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingMaterialName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves Printing Wastage")
            {
                grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingWastageIdItem"].Value = oelItems.IdItem;
                grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingWastageName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves OverLock Materials")
            {
                grdOverlockMaterials.CurrentRow.Cells["colOverLockMaterialIdItem"].Value = oelItems.IdItem;
                grdOverlockMaterials.CurrentRow.Cells["colOverLockMaterialName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves Magzi Materials")
            {
                grdMagziMaterial.CurrentRow.Cells["colMagziMaterialIdItem"].Value = oelItems.IdItem;
                grdMagziMaterial.CurrentRow.Cells["colMagziMaterialName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves Stitching Materials")
            {
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialIdItem"].Value = oelItems.IdItem;
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Gloves Packing Materials")
            {
                grdMagziMaterial.CurrentRow.Cells["colPackingMaterialIdItem"].Value = oelItems.IdItem;
                grdMagziMaterial.CurrentRow.Cells["colPackingMaterialName"].Value = oelItems.AccountName;
            }
            else
            {
                //txtQuality.Text = oelItems.AccountName;
                IdQuality = oelItems.IdItem;
            }
        }
        private void cbxCustomerPOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCustomerPOS.SelectedIndex > 0)
            {
                GetVoucherInfoByCustomerPONo(cbxCustomerPOS.Text);
                LoadType = "CustomerPo";
                ProductionTab_SelectedIndexChanged(sender, e);
                ProductionTab_SelectedIndexChanged(sender, e);   
            }
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadType = "Voucher";
                GetProductionVoucher();
                ProductionTab_SelectedIndexChanged(sender, e);
            }
        }
        private void GetProductionVoucher()
        {
            var manager = new ProductionProcessesHeadBLL();
            List<ProductionProcessesHeadEL> list = manager.GetProductionByNumberAndType(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), 1);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
            }
            else
            {
                IdVoucher = Guid.Empty;
            }
        }
        #endregion
        #region Tabs Related Events And Methods
        private void ProductionTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Manager = new ProductionProcessDetailBLL();
            var MManager = new ProductionMaterialsBLL();
            List<ProductionProcessDetailEL> list = null;
            List<ProductionProcessesEL> listProcess = null;
            string ProcessName = "";
            #region Gloves Cutting Process
            if (ProductionTab.SelectedIndex == 0)
            {
                ProcessName = "Gloves Cutting";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    //VEditBox.Text = list[0].VoucherNo.ToString();
                    if (grdCutting.Rows.Count > 0)
                    {
                        grdCutting.Rows.Clear();
                    }
                    IdCutting = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (grdCuttingMaterialUsed.Rows.Count > 0)
                    {
                        grdCuttingMaterialUsed.Rows.Clear();
                    }
                    FillMaterials(listMaterials, ProcessName);
                    List<ProductionMaterialUsedEL> listWastage = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    FillWastage(listWastage, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdCutting = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Gloves Printing Process
            else if (ProductionTab.SelectedIndex == 1)
            {
                ProcessName = "Gloves Printing";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (grdCuffPrinting.Rows.Count > 0)
                    {
                        grdCuffPrinting.Rows.Clear();
                    }
                    IdPrinting = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdCuffPrintingMaterial.Rows.Count > 0)
                        {
                            grdCuffPrintingMaterial.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                    List<ProductionMaterialUsedEL> listWastage = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (listWastage.Count > 0)
                    {
                        if (grdCuffPrintingMaterial.Rows.Count > 0)
                        {
                            grdCuffPrintingMaterial.Rows.Clear();
                            FillWastage(listWastage, ProcessName);
                        }
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdPrinting = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Overlock Process
            else if (ProductionTab.SelectedIndex == 2)
            {
                ProcessName = "Gloves OverLock";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);                    
                    if (grdOverLock.Rows.Count > 0)
                    {
                        grdOverLock.Rows.Clear();
                    }
                    IdOverLock = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdOverlockMaterials.Rows.Count > 0)
                        {
                            grdOverlockMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdOverLock = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Magzi / Tape Process
            else if (ProductionTab.SelectedIndex == 3)
            {
                ProcessName = "Gloves Magzi/Tape";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (grdMagzi.Rows.Count > 0)
                    {
                        grdMagzi.Rows.Clear();
                    }
                    IdMagzi = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdMagziMaterial.Rows.Count > 0)
                        {
                            grdMagziMaterial.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdMagzi = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Gloves Stitching Process
            else if (ProductionTab.SelectedIndex == 4)
            {
                ProcessName = "Gloves Stitching";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (grdStitching.Rows.Count > 0)
                    {
                        grdStitching.Rows.Clear();
                    }
                    IdStitching = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdStitchingMaterials.Rows.Count > 0)
                        {
                            grdStitchingMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdStitching = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Gloves Inspection Process
            else if (ProductionTab.SelectedIndex == 5)
            {
                ProcessName = "Gloves Inspection";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (grdInspection.Rows.Count > 0)
                    {
                        grdInspection.Rows.Clear();
                    }
                    IdInspection = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdInspection = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Gloves Packing Process
            else if (ProductionTab.SelectedIndex == 6)
            {
                ProcessName = "Gloves Packing";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (grdPacking.Rows.Count > 0)
                    {
                        grdPacking.Rows.Clear();
                    }
                    IdPacking = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdPackingMaterials.Rows.Count > 0)
                        {
                            grdPackingMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdPacking = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Factory OverHeads
            else if (ProductionTab.SelectedIndex == 7)
            {
                var OverHeadManager = new ProductionOverHeadsBLL();
                List<ProductionOverHeadEL> listCost = OverHeadManager.GetProductionOverHeadsByVoucher(IdVoucher, 1);
                if (listCost.Count > 0)
                {
                    FillProductionCost(listCost);
                }
            }
            #endregion
        }
        private void FillProcessDetails(List<ProductionProcessDetailEL> list, string ProcessName)
        {
            IdVoucher = list[0].IdVoucher;
            for (int i = 0; i < list.Count; i++)
            {
                #region Gloves Cutting Entries
                if (ProcessName == "Gloves Cutting")
                {
                    grdCutting.Rows.Add();
                    grdCutting.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdCutting.Rows[i].Cells[1].Value = list[i].Posted;
                    grdCutting.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdCutting.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdCutting.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdCutting.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdCutting.Rows[i].Cells[6].Value = list[i].AccountName;
                    grdCutting.Rows[i].Cells[7].Value = list[i].ItemSize;
                    grdCutting.Rows[i].Cells[8].Value = list[i].Quantity;

                    grdCutting.Rows[i].Cells[9].Value = list[i].Rate;
                    grdCutting.Rows[i].Cells[10].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdCutting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[10].ReadOnly = true;
                        grdCutting.Rows[i].Cells[11].ReadOnly = true;
                        grdCutting.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Gloves Printing Entries
                else if (ProcessName == "Gloves Printing")
                {
                    grdCuffPrinting.Rows.Add();
                    grdCuffPrinting.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdCuffPrinting.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdCuffPrinting.Rows[i].Cells[2].Value = list[i].Posted;
                    grdCuffPrinting.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdCuffPrinting.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdCuffPrinting.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdCuffPrinting.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdCuffPrinting.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdCuffPrinting.Rows[i].Cells[8].Value = list[i].ItemName;

                    grdCuffPrinting.Rows[i].Cells[9].Value = list[i].ItemSize;
                    grdCuffPrinting.Rows[i].Cells[10].Value = list[i].Quantity;



                    grdCuffPrinting.Rows[i].Cells[11].Value = list[i].Rate;
                    grdCuffPrinting.Rows[i].Cells[12].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdCuffPrinting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;

                        grdCuffPrinting.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region OverLock Entries
                else if (ProcessName == "Gloves OverLock")
                {
                    grdOverLock.Rows.Add();
                    grdOverLock.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdOverLock.Rows[i].Cells[1].Value = list[i].Posted;
                    grdOverLock.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdOverLock.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdOverLock.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdOverLock.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdOverLock.Rows[i].Cells[6].Value = list[i].AccountName;

                    grdOverLock.Rows[i].Cells[7].Value = list[i].ItemSize;
                    grdOverLock.Rows[i].Cells[8].Value = list[i].Quantity;

                    grdOverLock.Rows[i].Cells[9].Value = list[i].Rate;
                    grdOverLock.Rows[i].Cells[10].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdOverLock.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;

                        grdOverLock.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Magzi Entriese
                else if (ProcessName == "Gloves Magzi/Tape")
                {
                    grdMagzi.Rows.Add();
                    grdMagzi.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdMagzi.Rows[i].Cells[1].Value = list[i].Posted;
                    grdMagzi.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdMagzi.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdMagzi.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdMagzi.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdMagzi.Rows[i].Cells[6].Value = list[i].AccountName;
                    if (list[i].GarmentWorkType == 1)
                    {
                        grdMagzi.Rows[i].Cells[7].Value = "Magzi";
                    }
                    else if (list[i].GarmentWorkType == 2)
                    {
                        grdMagzi.Rows[i].Cells[8].Value = "Tape";
                    }
                    grdMagzi.Rows[i].Cells[8].Value = list[i].ItemSize;
                    grdMagzi.Rows[i].Cells[9].Value = list[i].Quantity;

                    grdMagzi.Rows[i].Cells[10].Value = list[i].Rate;
                    grdMagzi.Rows[i].Cells[11].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdMagzi.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;

                        grdMagzi.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Stitching Entries
                else if (ProcessName == "Gloves Stitching")
                {

                    grdStitching.Rows.Add();
                    grdStitching.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdStitching.Rows[i].Cells[1].Value = list[i].Posted;
                    grdStitching.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdStitching.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdStitching.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdStitching.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdStitching.Rows[i].Cells[6].Value = list[i].AccountName;
                    grdStitching.Rows[i].Cells[7].Value = list[i].ItemSize;

                    grdStitching.Rows[i].Cells[8].Value = list[i].Quantity;
                    grdStitching.Rows[i].Cells[9].Value = list[i].Rate;
                    grdStitching.Rows[i].Cells[10].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdStitching.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;

                        grdStitching.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Checking / Inspection Entries
                else if (ProcessName == "Gloves Inspection")
                {
                    grdInspection.Rows.Add();
                    grdInspection.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdInspection.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdInspection.Rows[i].Cells[2].Value = list[i].Posted;
                    grdInspection.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdInspection.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdInspection.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdInspection.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdInspection.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdInspection.Rows[i].Cells[8].Value = list[i].ItemName;

                    grdInspection.Rows[i].Cells[9].Value = list[i].ItemSize;
                    grdInspection.Rows[i].Cells[10].Value = list[i].Quantity;
                    grdInspection.Rows[i].Cells[11].Value = list[i].ReadyUnits;
                    grdInspection.Rows[i].Cells[12].Value = list[i].Rejection;


                    grdInspection.Rows[i].Cells[13].Value = list[i].Rate;
                    grdInspection.Rows[i].Cells[14].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdInspection.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;

                        grdInspection.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Packing Entries
                else if (ProcessName == "Gloves Packing")
                {
                    grdPacking.Rows.Add();
                    grdPacking.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdPacking.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdPacking.Rows[i].Cells[2].Value = list[i].Posted;
                    grdPacking.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdPacking.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdPacking.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdPacking.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdPacking.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdPacking.Rows[i].Cells[8].Value = list[i].ItemName;

                    grdPacking.Rows[i].Cells[9].Value = list[i].ItemSize;
                    grdPacking.Rows[i].Cells[10].Value = list[i].Quantity;
                    grdPacking.Rows[i].Cells[11].Value = list[i].Rate;
                    grdPacking.Rows[i].Cells[12].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdPacking.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;

                        grdPacking.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
            }
        }
        private void FillMaterials(List<ProductionMaterialUsedEL> list, string ProcessName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                #region Cutting Materials Entries
                if (ProcessName == "Gloves Cutting")
                {
                    grdCuttingMaterialUsed.Rows.Add();
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value = list[i].IdItem;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialName"].Value = list[i].ItemName;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUOM"].Value = list[i].PackingSize;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Gloves Cuff Printing Materials Entries
                if (ProcessName == "Gloves Cuff Printing")
                {
                    grdCuffPrinting.Rows.Add();
                    grdCuffPrinting.Rows[i].Cells["colCuffPrintingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdCuffPrinting.Rows[i].Cells["colCuffPrintingMaterialIdItem"].Value = list[i].IdItem;
                    grdCuffPrinting.Rows[i].Cells["colCuffPrintingMaterialName"].Value = list[i].ItemName;
                    grdCuffPrinting.Rows[i].Cells["colCuffPrintingMaterialUOM"].Value = list[i].PackingSize;
                    grdCuffPrinting.Rows[i].Cells["colCuffPrintingMaterialUsedQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Gloves OverLock Materials Entries
                if (ProcessName == "Gloves OverLock")
                {
                    grdOverlockMaterials.Rows.Add();
                    grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialIdItem"].Value = list[i].IdItem;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialName"].Value = list[i].ItemName;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialUOM"].Value = list[i].PackingSize;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Gloves Magzi/Tape Materials Entries
                if (ProcessName == "Gloves Magzi/Tape")
                {
                    grdMagzi.Rows.Add();
                    grdMagzi.Rows[i].Cells["colMagziIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdMagzi.Rows[i].Cells["colMagziMaterialIdItem"].Value = list[i].IdItem;
                    grdMagzi.Rows[i].Cells["colMagziMaterialName"].Value = list[i].ItemName;
                    grdMagzi.Rows[i].Cells["colMagziMaterialUOM"].Value = list[i].PackingSize;
                    grdMagzi.Rows[i].Cells["colMagziMaterialUsedQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Stitching Materials Entries
                if (ProcessName == "Gloves Stitching")
                {
                    grdStitchingMaterials.Rows.Add();
                    grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdItem"].Value = list[i].IdItem;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialName"].Value = list[i].ItemName;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialUOM"].Value = list[i].PackingSize;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Packing Materials Entries
                if (ProcessName == "Gloves Packing")
                {
                    grdPacking.Rows.Add();
                    grdPacking.Rows[i].Cells["colPackingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdPacking.Rows[i].Cells["colPackingMaterialIdItem"].Value = list[i].IdItem;
                    grdPacking.Rows[i].Cells["colPackingMaterialName"].Value = list[i].ItemName;
                    grdPacking.Rows[i].Cells["colPackingMaterialUOM"].Value = list[i].ItemName;
                    grdPacking.Rows[i].Cells["colPackingMaterialQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
            }
        }
        private void FillWastage(List<ProductionMaterialUsedEL> list, string ProcessName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                #region Gloves Cutting Wastage Entries
                if (ProcessName == "Gloves Cutting")
                {
                    grdCuttingWastage.Rows.Add();
                    grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value = list[i].IdMaterialUsed;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageIdItem"].Value = list[i].IdItem;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageName"].Value = list[i].ItemName;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageUOM"].Value = list[i].PackingSize;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Gloves Prinint Wastage Entries
                if (ProcessName == "Gloves Printing")
                {
                    grdCuffPrintingMaterial.Rows.Add();
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdWastage"].Value = list[i].IdMaterialUsed;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingWastageIdItem"].Value = list[i].IdItem;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingWastageName"].Value = list[i].ItemName;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingWastageUOM"].Value = list[i].PackingSize;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingWastageQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
            }
        }
        private void FillProductionCost(List<ProductionOverHeadEL> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                grdMiscCost.Rows.Add();
                grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value = list[0].IdProductionOverHead;
                grdMiscCost.Rows[i].Cells["colCostDate"].Value = list[0].OverHeadDate;
                grdMiscCost.Rows[i].Cells["colAccountNo"].Value = list[0].IdProductionOverHead;
                grdMiscCost.Rows[i].Cells["colAccountName"].Value = list[0].AccountName;
                grdMiscCost.Rows[i].Cells["colCostDescription"].Value = list[0].Description;
                grdMiscCost.Rows[i].Cells["colCost"].Value = list[0].OverHeadCost;
            }
        }
        #endregion
        #region Methods
        private bool ValidateRecords(int GridNumber)
        {
            bool Status = true;
            #region Misc Validations
            if (cbxCustomerPOS.Text == string.Empty)
            {
                MessageBox.Show("Please Select Customer Order Number :");
                Status = false;
            }
            else if (VEditBox.Text == string.Empty)
            {
                MessageBox.Show("Production Number Is Empty :");
                Status = false;
            }
            #endregion
            #region Cuff Cutting Grid Validation
            else if (GridNumber == 1)
            {
                for (int i = 0; i < grdCutting.Rows.Count; i++)
                {
                    if (grdCutting.Rows[i].Cells["colCuttingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdCutting.Rows[i].Cells["colCuttingAmount"].Value == null || Validation.GetSafeDecimal(grdCutting.Rows[i].Cells["colCuttingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Cuff Printing Grid Validation
            else if (GridNumber == 2)
            {
                for (int i = 0; i < grdCuffPrinting.Rows.Count; i++)
                {
                    if (grdCuffPrinting.Rows[i].Cells["colCuffPrintingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdCuffPrinting.Rows[i].Cells["colCuffPrintingAmount"].Value == null || Validation.GetSafeDecimal(grdCuffPrinting.Rows[i].Cells["colCuffPrintingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region OverLock Grid Validation
            else if (GridNumber == 3)
            {
                for (int i = 0; i < grdOverLock.Rows.Count; i++)
                {
                    if (grdOverLock.Rows[i].Cells["colOverLockVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdOverLock.Rows[i].Cells["colOverLockAmount"].Value == null || Validation.GetSafeDecimal(grdOverLock.Rows[i].Cells["colOverLockAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Magzi / Tape Grid Validation
            else if (GridNumber == 4)
            {
                for (int i = 0; i < grdMagzi.Rows.Count; i++)
                {
                    if (grdMagzi.Rows[i].Cells["colMagziVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdMagzi.Rows[i].Cells["colMagziAmount"].Value == null || Validation.GetSafeDecimal(grdMagzi.Rows[i].Cells["colMagziAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Stitching Grid Validation
            else if (GridNumber == 5)
            {
                for (int i = 0; i < grdStitching.Rows.Count; i++)
                {
                    if (grdStitching.Rows[i].Cells["colStitchingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdStitching.Rows[i].Cells["colStitchingAmount"].Value == null || Validation.GetSafeDecimal(grdStitching.Rows[i].Cells["colStitchingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Checking Grid Validation
            else if (GridNumber == 6)
            {
                for (int i = 0; i < grdInspection.Rows.Count; i++)
                {
                    if (grdInspection.Rows[i].Cells["colInspectionVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdInspection.Rows[i].Cells["colInspectionAmount"].Value == null || Validation.GetSafeDecimal(grdInspection.Rows[i].Cells["colInspectionAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Packing Grid Validation
            else if (GridNumber == 7)
            {
                for (int i = 0; i < grdPacking.Rows.Count; i++)
                {
                    if (grdPacking.Rows[i].Cells["colPackingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdPacking.Rows[i].Cells["colPackingAmount"].Value == null || Validation.GetSafeDecimal(grdPacking.Rows[i].Cells["colPackingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            return Status;
        }
        private void FillCustomerPos()
        {
            var manager = new ProductionProcessesHeadBLL();
            List<ProductionProcessesHeadEL> list = manager.GetCustomerPOSByStatusAndType(1);
            list.Insert(0, new ProductionProcessesHeadEL() { CustomerPO = "" });
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cbxCustomerPOS.Items.Add(list[i].CustomerPO ?? "");
                }
            }
        }
        private void GetVoucherInfoByCustomerPONo(string CustomerPo)
        {
            var Manager = new ProductionProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = Manager.GetVoucherInfoByCustomerPo(CustomerPo, 1);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
                VEditBox.Text = list[0].VoucherNo.ToString();
            }
            else
            {
                IdVoucher = Guid.Empty;
                ClearControls();
            }
        }
        private void ClearControls()
        {
            #region Clearing Variables
            IdVoucher = Guid.Empty;
            IdCutting = Guid.Empty;
            IdStitching = Guid.Empty;
            IdPrinting = Guid.Empty;
            IdOverLock = Guid.Empty;
            IdMagzi = Guid.Empty;
            IdInspection = Guid.Empty;
            IdPacking = Guid.Empty;
            #endregion
            #region Clearing Grids

            grdCutting.Rows.Clear();
            grdCuttingMaterialUsed.Rows.Clear();
            grdCuttingWastage.Rows.Clear();

            grdCuffPrinting.Rows.Clear();
            grdCuffPrintingMaterial.Rows.Clear();
            grdCuffPrintingWastage.Rows.Clear();

            grdOverLock.Rows.Clear();
            grdOverlockMaterials.Rows.Clear();

            grdMagzi.Rows.Clear();
            grdMagziMaterial.Rows.Clear();

            grdStitching.Rows.Clear();
            grdStitchingMaterials.Rows.Clear();


            grdInspection.Rows.Clear();

            grdPacking.Rows.Clear();
            grdPackingMaterials.Rows.Clear();

            grdMiscCost.Rows.Clear();

            #endregion
        }
        #endregion
        #region Buttons Events
        private void btnCuttingSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdCuttingMaterialUsed.Rows.Count > 0)
            {
                for (int i = 0; i < grdCuttingMaterialUsed.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value == null || Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value);
                    oelMaterialDetail.ProcessType = 1;
                    oelMaterialDetail.ProductionProcessName = "Cuff Cutting Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialDate"].Value);

                    oelCuttingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (grdCuttingWastage.Rows.Count > 0)
            {
                for (int i = 0; i < grdCuttingWastage.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelCuttingWastage = new ProductionMaterialUsedEL();
                    if (grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value == null || Validation.GetSafeGuid(grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value) == Guid.Empty)
                    {
                        oelCuttingWastage.IdVoucherDetail = Guid.NewGuid();
                        oelCuttingWastage.IsNew = true;
                        grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value = oelCuttingWastage.IdVoucherDetail;
                    }
                    else
                    {
                        oelCuttingWastage.IdVoucherDetail = Validation.GetSafeGuid(grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value);
                        oelCuttingWastage.IsNew = false;
                    }
                    oelCuttingWastage.IdVoucher = IdVoucher;
                    oelCuttingWastage.IdItem = Validation.GetSafeGuid(grdCuttingWastage.Rows[i].Cells["colCuttingWastageIdItem"].Value);
                    oelCuttingWastage.Qty = Validation.GetSafeLong(grdCuttingWastage.Rows[i].Cells["colCuttingWastageQuantity"].Value);
                    oelCuttingWastage.ProcessType = 1;
                    oelCuttingWastage.ProductionProcessName = "Cuff Cutting Wastage";
                    oelCuttingWastage.VDate = Convert.ToDateTime(grdCuttingWastage.Rows[i].Cells["colCuttingWastageDate"].Value);
                    oelCuttingWastageCollection.Add(oelCuttingWastage);
                }
            }
            if (Manager.CreateMaterialsUsed(oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {

            }
        }
        private void btnStitchingSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdStitching.Rows.Count > 0)
            {
                for (int i = 0; i < grdStitchingMaterials.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdStitching.Rows[i].Cells["colStitchingIdMaterial"].Value == null || Validation.GetSafeGuid(grdStitching.Rows[i].Cells["colStitchingIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdStitching.Rows[i].Cells["colStitchingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdStitching.Rows[i].Cells["colStitchingIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdStitching.Rows[i].Cells["colStitchingMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdStitching.Rows[i].Cells["colStitchingMaterialQuantity"].Value);
                    oelMaterialDetail.ProcessType = 1;
                    oelMaterialDetail.ProductionProcessName = "Stitching Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdStitching.Rows[i].Cells["colStitchingMaterialDate"].Value);

                    oelCuttingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (Manager.CreateMaterialsUsed(oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {

            }
        }
        private void btnCuffPrintingSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelPrintingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelPrintingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdCuffPrintingMaterial.Rows.Count > 0)
            {
                for (int i = 0; i < grdCuffPrintingMaterial.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value == null || Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialUsedQuantity"].Value);
                    oelMaterialDetail.ProcessType = 1;
                    oelMaterialDetail.ProductionProcessName = "Cuff Printing Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialDate"].Value);

                    oelPrintingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (grdCuffPrintingWastage.Rows.Count > 0)
            {
                for (int i = 0; i < grdCuttingWastage.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelPrintingWastage = new ProductionMaterialUsedEL();
                    if (grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingIdWastage"].Value == null || Validation.GetSafeGuid(grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingIdWastage"].Value) == Guid.Empty)
                    {
                        oelPrintingWastage.IdVoucherDetail = Guid.NewGuid();
                        oelPrintingWastage.IsNew = true;
                        grdCuttingWastage.Rows[i].Cells["colCuffPrintingIdWastage"].Value = oelPrintingWastage.IdVoucherDetail;
                    }
                    else
                    {
                        oelPrintingWastage.IdVoucherDetail = Validation.GetSafeGuid(grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingIdWastage"].Value);
                        oelPrintingWastage.IsNew = false;
                    }
                    oelPrintingWastage.IdVoucher = IdVoucher;
                    oelPrintingWastage.IdItem = Validation.GetSafeGuid(grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingWastageIdItem"].Value);
                    oelPrintingWastage.Qty = Validation.GetSafeLong(grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingWastageQuantity"].Value);
                    oelPrintingWastage.ProcessType = 1;
                    oelPrintingWastage.ProductionProcessName = "Cuff Printing Wastage";
                    oelPrintingWastage.VDate = Convert.ToDateTime(grdCuffPrintingWastage.Rows[i].Cells["colCuttingWastageDate"].Value);
                    oelPrintingWastageCollection.Add(oelPrintingWastage);
                }
            }
            if (Manager.CreateMaterialsUsed(oelPrintingMaterialCollection, oelPrintingWastageCollection))
            {

            }
        }
        private void btnOverLockSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelOverLockMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdOverlockMaterials.Rows.Count > 0)
            {
                for (int i = 0; i < grdOverlockMaterials.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value == null || Validation.GetSafeGuid(grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialQuantity"].Value);
                    oelMaterialDetail.ProcessType = 1;
                    oelMaterialDetail.ProductionProcessName = "OverLock Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDate"].Value);

                    oelOverLockMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (Manager.CreateMaterialsUsed(oelOverLockMaterialCollection, oelCuttingWastageCollection))
            {

            }
        }
        private void btnPackingSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdPackingMaterials.Rows.Count > 0)
            {
                for (int i = 0; i < grdPackingMaterials.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value == null || Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdPackingMaterials.Rows[i].Cells["colPackingMaterialQuantity"].Value);
                    oelMaterialDetail.ProcessType = 1;
                    oelMaterialDetail.ProductionProcessName = "Packing Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdPackingMaterials.Rows[i].Cells["colPackingMaterialDate"].Value);

                    oelCuttingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (Manager.CreateMaterialsUsed(oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {

            }
        }
        private void btnMagziSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdMagziMaterial.Rows.Count > 0)
            {
                for (int i = 0; i < grdPackingMaterials.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value == null || Validation.GetSafeGuid(grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colMagziMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdPackingMaterials.Rows[i].Cells["colMagziMaterialUsedQuantity"].Value);
                    oelMaterialDetail.ProcessType = 1;
                    oelMaterialDetail.ProductionProcessName = "Magzi Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdPackingMaterials.Rows[i].Cells["colPackingMaterialDate"].Value);

                    oelCuttingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (Manager.CreateMaterialsUsed(oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {

            }
        }
        private void btnOverHeadsSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionOverHeadsBLL();
            List<ProductionOverHeadEL> oelProductionOverHeadCollection = new List<ProductionOverHeadEL>();
            if (grdMiscCost.Rows.Count > 0)
            {
                for (int i = 0; i < grdMiscCost.Rows.Count - 1; i++)
                {
                    ProductionOverHeadEL oelProductionOverhead = new ProductionOverHeadEL();
                    if (grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value == null || Validation.GetSafeGuid(grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value) == Guid.Empty)
                    {
                        oelProductionOverhead.IdProductionOverHead = Guid.NewGuid();
                        oelProductionOverhead.IsNew = true;
                        grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value = oelProductionOverhead.IdProductionOverHead;
                    }
                    else
                    {
                        oelProductionOverhead.IdProductionOverHead = Validation.GetSafeGuid(grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value);
                        oelProductionOverhead.IsNew = false;
                    }
                    oelProductionOverhead.IdVoucher = IdVoucher;
                    oelProductionOverhead.AccountNo = Validation.GetSafeString(grdMiscCost.Rows[i].Cells["colAccountNo"].Value);
                    oelProductionOverhead.Description = Validation.GetSafeString(grdMiscCost.Rows[i].Cells["colCostDescription"].Value);
                    oelProductionOverhead.ProcessType = 1;
                    oelProductionOverhead.OverHeadCost = Validation.GetSafeDecimal(grdMiscCost.Rows[i].Cells["colCost"].Value);
                    oelProductionOverhead.OverHeadDate = Convert.ToDateTime(grdMiscCost.Rows[i].Cells["colCostDate"].Value);

                    oelProductionOverHeadCollection.Add(oelProductionOverhead);
                }
            }
            if (Manager.CreateUpdateProductionOverHeads(oelProductionOverHeadCollection))
            {

            }
        }
        #endregion       
    }
}