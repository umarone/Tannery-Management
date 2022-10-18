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
    public partial class frmGarmentProduction : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmstockAccounts;
        frmWorkPurchases frmworkpurchases;
        Guid IdVoucher = Guid.Empty;
        Guid IdCutting;
        Guid IdStitching;
        Guid IdFeedo;
        Guid IdBartake;
        Guid IdThreading;
        Guid IdInspection;
        Guid IdPress;
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
        #region Windows Form Events And Methods
        public frmGarmentProduction()
        {
            InitializeComponent();
        }
        private void frmGarmentProduction_Load(object sender, EventArgs e)
        {
            this.grdCutting.AutoGenerateColumns = false;
            this.grdStitching.AutoGenerateColumns = false;
            this.grdFeedoSaftey.AutoGenerateColumns = false;
            this.grdFeedoSaftey.AutoGenerateColumns = false;
            this.grdBartakeMaterials.AutoGenerateColumns = false;
            this.grdThreading.AutoGenerateColumns = false;
            this.grdInspection.AutoGenerateColumns = false;
            this.grdPress.AutoGenerateColumns = false;
            this.grdPacking.AutoGenerateColumns = false;
            ProductionTab.SelectedIndex = 0;
            FillMaxProductionNo();
            FillCustomerPos();
        }
        private void FillMaxProductionNo()
        {
            var Manager = new ProductionProcessesHeadBLL();
            VEditBox.Text = Validation.GetSafeString(Manager.GetMaxProductionProcessCode(Operations.IdCompany, 2));
        }
        #endregion
        #region Cutting Grid Events
        private void grdCutting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 17)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 18)
            {
                e.Value = "Post";
            }
        }
        private void grdCutting_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCutting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Recored Deletion
            if (e.ColumnIndex == 17)
            {
                var Manager = new ProductionProcessDetailBLL();
                if (Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value) != Guid.Empty)
                {
                    if (grdCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    { 
                        if(Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value),Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender,e);
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
            else if (e.ColumnIndex == 18)
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
                    oelProductionHead.ProductionType = 2;

                    if (IdCutting == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdCutting;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Cutting";
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
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdItem"].Value);
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingSizes"].Value);
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value);
                    if (Validation.GetSafeInteger(grdCutting.Rows[e.RowIndex].Cells["colCuttingType"].Value) == 1)
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else
                    {
                        oelProductionDetail.GType = 2;
                    }
                    if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingClotheQuality"].Value) == "Fresh")
                    {
                        oelProductionDetail.Quality = 1;
                    }
                    else if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingClotheQuality"].Value) == "Cut Pieces")
                    {
                        oelProductionDetail.Quality = 2;
                    }
                    else if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingClotheQuality"].Value) == "B Grade")
                    {
                        oelProductionDetail.Quality = 3;
                    }
                    oelProductionDetail.Meters = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingMeters"].Value);
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
                                }
                                if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Cutting Purchases";
                                    frmworkpurchases.ProcessName = "Garments Cutting";
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
                        frmworkpurchases.PurchasesType = "Garments Cutting Purchases";
                        frmworkpurchases.ProcessName = "Garments Cutting";
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
            if (grdCutting.CurrentCellAddress.X == 7)
            {
                TextBox txtVendorName = e.Control as TextBox;
                if (txtVendorName != null)
                {
                    txtVendorName.KeyPress -= new KeyPressEventHandler(txtVendorName_KeyPress);
                    txtVendorName.KeyPress += new KeyPressEventHandler(txtVendorName_KeyPress);
                }
            }
            else if (grdCutting.CurrentCellAddress.X == 8)
            {
                TextBox txtCuttingClotheType = e.Control as TextBox;
                if (txtCuttingClotheType != null)
                {
                    txtCuttingClotheType.KeyPress -= new KeyPressEventHandler(txtCuttingClotheType_KeyPress);
                    txtCuttingClotheType.KeyPress += new KeyPressEventHandler(txtCuttingClotheType_KeyPress);
                }
            }
        }
        void txtVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Cutting";
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
        void txtCuttingClotheType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Cutting";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
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
                    EventFiringName = "Garment Cutting Materials";
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
                    EventFiringName = "Garment Cutting Wastage";
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
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 14)
            {
                e.Value = "Posting";
            }

        }
        private void grdStitching_CellEnter(object sender, DataGridViewCellEventArgs e)
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
        private void grdStitching_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
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
                        if(Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value),Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender,e);
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
                    oelProductionHead.ProductionType = 2;

                    if (IdStitching == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdStitching;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Stitching";
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
                    if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdStitching.Rows[e.RowIndex].Cells["colStitchingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
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
                                    frmworkpurchases.PurchasesType = "Garments Stitching Purchases";
                                    frmworkpurchases.ProcessName = "Garments Stitching";
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
                        frmworkpurchases.PurchasesType = "Garments Stitching Purchases";
                        frmworkpurchases.ProcessName = "Garments Stitching";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
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
                    EventFiringName = "Garments Stitching";
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
                    EventFiringName = "Garment Stitching Material";
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
        #region Feedo/Saftey Grid Events
        private void grdFeedoSaftey_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        private void grdFeedoSaftey_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdFeedoSaftey_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
            {
                if (Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                     var Manager = new ProductionProcessDetailBLL();
                    if (grdFeedoSaftey.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    { 
                        if(Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value),Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender,e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdFeedoSaftey.Columns.Count; i++)
                    {
                        grdFeedoSaftey.Rows[e.RowIndex].Cells[i].Value = "";
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
                    oelProductionHead.ProductionType = 2;

                    if (IdFeedo == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdFeedo;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Feedo/Saftey";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdFeedoSaftey.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Guid.Empty;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoBrandType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoBrandType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoWorkType"].Value) == "Feedo")
                    {
                        oelProductionDetail.GarmentWorkType = 1;
                    }
                    else if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoWorkType"].Value) == "Saftey")
                    {
                        oelProductionDetail.GarmentWorkType = 2;
                    }
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAccountType"].Value) == "Employees")
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
                            IdFeedo = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAccountType"].Value) == "Employees")
                                {
                                    grdFeedoSaftey.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Feedo/Saftey Purchases";
                                    frmworkpurchases.ProcessName = "Garments Feedo/Saftey";
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
                        frmworkpurchases.PurchasesType = "Garments Feedo/Saftey Purchases";
                        frmworkpurchases.ProcessName = "Garments Feedo/Saftey";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}

                }
            }
            #endregion
        }        
        private void grdFeedoSaftey_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdFeedoSaftey_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdFeedoSaftey_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdFeedoSaftey.CurrentCellAddress.X == 6)
            {
                TextBox txtFeedoSafteyVendorName = e.Control as TextBox;
                if (txtFeedoSafteyVendorName != null)
                {
                    txtFeedoSafteyVendorName.KeyPress -= new KeyPressEventHandler(txtFeedoSafteyVendorName_KeyPress);
                    txtFeedoSafteyVendorName.KeyPress += new KeyPressEventHandler(txtFeedoSafteyVendorName_KeyPress);
                }
            }
        }
        void txtFeedoSafteyVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdFeedoSaftey.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Feedo";
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
        #region Feedo / Saftey Material Grid Events
        private void grdFeedoMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdFeedoMaterials.CurrentCellAddress.X == 3)
            {
                TextBox txtFeedoSafteyMaterialName = e.Control as TextBox;
                txtFeedoSafteyMaterialName.KeyPress -= new KeyPressEventHandler(txtFeedoSafteyMaterialName_KeyPress);
                txtFeedoSafteyMaterialName.KeyPress += new KeyPressEventHandler(txtFeedoSafteyMaterialName_KeyPress);
            }
        }
        void txtFeedoSafteyMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdFeedoMaterials.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Feedo/Saftey Material";
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
        #region Bartake/Kage/Buttons Grid Events
        private void grdBartake_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        private void grdBartake_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdBartake_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 15)
            {
                if (Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdBartake.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    { 
                        if(Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value),Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colBartakeIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender,e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdBartake.Columns.Count; i++)
                    {
                        grdBartakeMaterials.Rows[e.RowIndex].Cells[i].Value = "";
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
                    oelProductionHead.ProductionType = 2;

                    if (IdBartake == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdBartake;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Bartake/Buttons/Kaaj";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdBartake.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colBartakeIdItem"].Value);
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeWorkType"].Value) == "Bartake")
                    {
                        oelProductionDetail.GarmentWorkType = 1;
                    }
                    else if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeWorkType"].Value) == "Kaaj")
                    {
                        oelProductionDetail.GarmentWorkType = 2;
                    }
                    else if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeWorkType"].Value) == "Buttons")
                    {
                        oelProductionDetail.GarmentWorkType = 3;
                    }
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdBartake.Rows[e.RowIndex].Cells["colBartakeQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdBartake.Rows[e.RowIndex].Cells["colBartakeDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdBartake.Rows[e.RowIndex].Cells["colBartakeRates"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdBartake.Rows[e.RowIndex].Cells["colBartakeAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountType"].Value) == "Employees")
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
                            IdBartake = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountType"].Value) == "Employees")
                                {
                                    grdBartake.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Bartake / Button / Kaaj Purchases";
                                    frmworkpurchases.ProcessName = "Garments Bartake/Buttons/Kaaj";
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
                        frmworkpurchases.PurchasesType = "Garment Bartake / Button / Kaaj Purchases";
                        frmworkpurchases.ProcessName = "Garment Feedo/Button/Kaaj";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdBartake_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdBartake_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdBartake_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdBartake.CurrentCellAddress.X == 7)
            {
                TextBox txtBartakeVendorName = e.Control as TextBox;
                if (txtBartakeVendorName != null)
                {
                    txtBartakeVendorName.KeyPress -= new KeyPressEventHandler(txtBartakeVendorName_KeyPress);
                    txtBartakeVendorName.KeyPress += new KeyPressEventHandler(txtBartakeVendorName_KeyPress);
                }
            }
            else if (grdBartake.CurrentCellAddress.X == 8)
            {
                TextBox txtFinishedProduct = e.Control as TextBox;
                if (txtFinishedProduct != null)
                {
                    txtFinishedProduct.KeyPress -= new KeyPressEventHandler(txtFinishedProduct_KeyPress);
                    txtFinishedProduct.KeyPress += new KeyPressEventHandler(txtFinishedProduct_KeyPress);
                }
            }
        }
        void txtBartakeVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdBartake.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Bartake";
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
        void txtFinishedProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdBartake.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "FinishedProduct";
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
        #region Bartake/kaaj/Button Material Grid Events
        private void grdBartakeMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdBartakeMaterials.CurrentCellAddress.X == 3)
            {
                TextBox txtBartakeMaterialName = e.Control as TextBox;
                txtBartakeMaterialName.KeyPress -= new KeyPressEventHandler(txtBartakeMaterialName_KeyPress);
                txtBartakeMaterialName.KeyPress += new KeyPressEventHandler(txtBartakeMaterialName_KeyPress);
            }
        }
        void txtBartakeMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdBartakeMaterials.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Bartake Material";
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
        #region Threading Grid Events
        private void grdThreading_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 13)
            {
                e.Value = "Save";
            }
        }
        private void grdThreading_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 12)
            {
                if (Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdThreading.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    { 
                        if(Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value),Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colThreadingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender,e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdThreading.Columns.Count; i++)
                    {
                        grdThreading.Rows[e.RowIndex].Cells[i].Value = "";
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
                    oelProductionHead.ProductionType = 2;

                    if (IdThreading == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdThreading;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Threading";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdThreading.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Guid.Empty;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdThreading.Rows[e.RowIndex].Cells["colThreadingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdThreading.Rows[e.RowIndex].Cells["colThreadingWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdThreading.Rows[e.RowIndex].Cells["colThreadingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdThreading.Rows[e.RowIndex].Cells["colThreadingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountType"].Value) == "Employees")
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
                            IdThreading = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountType"].Value) == "Employees")
                                {
                                    grdThreading.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Threading Purchases";
                                    frmworkpurchases.ProcessName = "Garments Threading";
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
                        frmworkpurchases.PurchasesType = "Garments Threading Purchases";
                        frmworkpurchases.ProcessName = "Garments Threading";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdThreading_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void grdThreading_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdThreading_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdThreading_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdThreading.CurrentCellAddress.X == 6)
            {
                TextBox txtThreadingVendorName = e.Control as TextBox;
                if (txtThreadingVendorName != null)
                {
                    txtThreadingVendorName.KeyPress -= new KeyPressEventHandler(txtThreadingVendorName_KeyPress);
                    txtThreadingVendorName.KeyPress += new KeyPressEventHandler(txtThreadingVendorName_KeyPress);
                }
            }
        }
        void txtThreadingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdThreading.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Threading";
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
        #region Inspection Grid Events
        private void grdInspection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 15)
            {
                e.Value = "Posting";
            }
        }
        private void grdInspection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 14)
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
                        if(Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value),Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender,e);
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
            else if (e.ColumnIndex == 15)
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
                    oelProductionHead.ProductionType = 2;

                    if (IdInspection == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdInspection;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Inspection";
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
                    oelProductionDetail.IdItem = Guid.Empty;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Meters = 0;
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
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Inspection Purchases";
                                    frmworkpurchases.ProcessName = "Garments Inspection";
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
                        frmworkpurchases.PurchasesType = "Garments Inspection Purchases";
                        frmworkpurchases.ProcessName = "Inspection";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdInspection_CellEnter(object sender, DataGridViewCellEventArgs e)
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
        private void grdInspection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdInspection_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdInspection_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 6)
            {
                TextBox txtInspectionVendorName = e.Control as TextBox;
                if (txtInspectionVendorName != null)
                {
                    txtInspectionVendorName.KeyPress -= new KeyPressEventHandler(txtInspectionVendorName_KeyPress);
                    txtInspectionVendorName.KeyPress += new KeyPressEventHandler(txtInspectionVendorName_KeyPress);
                }
            }
        }
        void txtInspectionVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Inspection";
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
        #region Press Grid Events
        private void grdPress_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 15)
            {
                e.Value = "Post";
            }
        }
        private void grdPress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
            {
                if (Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdPress.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    { 
                        if(Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value),Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colPressIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender,e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdPress.Columns.Count; i++)
                    {
                        grdPress.Rows[e.RowIndex].Cells[i].Value = "";
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
                    oelProductionHead.ProductionType = 2;

                    if (IdPress == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdPress;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Press";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    if (grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdPress.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Guid.Empty;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressReadyUnits"].Value);
                    oelProductionDetail.Rejection = Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressRejection"].Value);
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdPress.Rows[e.RowIndex].Cells["colPressWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressRates"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdPress.Rows[e.RowIndex].Cells["colPressAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountType"].Value) == "Employees")
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
                            IdPress = oelProductionProcess.IdProductionProcess;
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountType"].Value) == "Employees")
                                {
                                    grdPress.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Press Purchases";
                                    frmworkpurchases.ProcessName = "Garments Press";
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
                        frmworkpurchases.PurchasesType = "Garments Press Purchases";
                        frmworkpurchases.ProcessName = "Garment Press";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdPress_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdPress_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdPress_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdPress_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdPress.CurrentCellAddress.X == 6)
            {
                TextBox txtPressVendorName = e.Control as TextBox;
                if (txtPressVendorName != null)
                {
                    txtPressVendorName.KeyPress -= new KeyPressEventHandler(txtPressVendorName_KeyPress);
                    txtPressVendorName.KeyPress += new KeyPressEventHandler(txtPressVendorName_KeyPress);
                }
            }
        }
        void txtPressVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPress.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Pressing";
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
        #region Packing Grid Events
        private void grdPacking_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 15)
            {
                e.Value = "Post";
            }
        }
        private void grdPacking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 14)
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
                        if(Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value),Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender,e);
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
            #region Record Insetion / Updation
            else if (e.ColumnIndex == 15)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(8))
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
                    oelProductionHead.ProductionType = 2;

                    if (IdPacking == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdPacking;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Packing";
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
                    if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;

                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value); ;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
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
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Packing Purchases";
                                    frmworkpurchases.ProcessName = "Garments Packing";
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
                        frmworkpurchases.PurchasesType = "Garments Packing Purchases";
                        frmworkpurchases.ProcessName = "Garments Packing";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdPacking_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 9)
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
            if (grdPacking.CurrentCellAddress.X == 8)
            {
                TextBox txtPackingArticleName = e.Control as TextBox;
                if (txtPackingArticleName != null)
                {
                    txtPackingArticleName.KeyPress -= new KeyPressEventHandler(txtPackingArticleName_KeyPress);
                    txtPackingArticleName.KeyPress += new KeyPressEventHandler(txtPackingArticleName_KeyPress);
                }
            }
        }
        void txtPackingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Packing";
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
        void txtPackingArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Packing";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Feedo / Saftey Material Grid Events
        private void grdPackingMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 3)
            {
                TextBox txtPackingMaterialName = e.Control as TextBox;
                txtPackingMaterialName.KeyPress -= new KeyPressEventHandler(txtPackingMaterialName_KeyPress);
                txtPackingMaterialName.KeyPress += new KeyPressEventHandler(txtPackingMaterialName_KeyPress);
            }
        }
        void txtPackingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Packing Material";
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
            if (EventFiringName == "Garments Cutting")
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
            else if (EventFiringName == "Garments Stitching")
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
            else if (EventFiringName == "Garments Feedo")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdFeedoSaftey.CurrentRow.Cells["colFeedoAccountNo"].Value = oelAccount.AccountNo;
                    grdFeedoSaftey.CurrentRow.Cells["colFeedoVendorName"].Value = oelAccount.AccountName;
                    grdFeedoSaftey.CurrentRow.Cells["colFeedoAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Bartake")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdBartake.CurrentRow.Cells["colBartakeAccountNo"].Value = oelAccount.AccountNo;
                    grdBartake.CurrentRow.Cells["colBartakeVendorName"].Value = oelAccount.AccountName;
                    grdBartake.CurrentRow.Cells["colBartakeAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Threading")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdThreading.CurrentRow.Cells["colThreadingAccountNo"].Value = oelAccount.AccountNo;
                    grdThreading.CurrentRow.Cells["colThreadingVendorName"].Value = oelAccount.AccountName;
                    grdThreading.CurrentRow.Cells["colThreadingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Inspection")
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
            else if (EventFiringName == "Garments Pressing")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdPress.CurrentRow.Cells["colPressAccountNo"].Value = oelAccount.AccountNo;
                    grdPress.CurrentRow.Cells["colPressVendorName"].Value = oelAccount.AccountName;
                    grdPress.CurrentRow.Cells["colPressAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Packing")
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
            if (EventFiringName == "FinishedProduct")
            {
                grdBartake.CurrentRow.Cells["colBartakeIdItem"].Value = oelItems.IdItem;
                grdBartake.CurrentRow.Cells["colBartakeFinishedGoods"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Garments Cutting")
            {
                grdCutting.CurrentRow.Cells["colCuttingIdItem"].Value = oelItems.IdItem;
                grdCutting.CurrentRow.Cells["colCuttingClotheName"].Value = oelItems.AccountName;

                GetItemsColorAttributes(oelItems.IdItem, "Garments Cutting");
            }
            else if (EventFiringName == "Garment Cutting Materials")
            {
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialIdItem"].Value = oelItems.IdItem;
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Garment Cutting Wastage")
            {
                grdCuttingWastage.CurrentRow.Cells["colCuttingWastageIdItem"].Value = oelItems.IdItem;
                grdCuttingWastage.CurrentRow.Cells["colCuttingWastageName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Garment Stitching Material")
            {
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialIdItem"].Value = oelItems.IdItem;
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Garment Feedo/Saftey Material")
            {
                grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialIdItem"].Value = oelItems.IdItem;
                grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Garments Packing")
            {
                grdPacking.CurrentRow.Cells["colPackingIdItem"].Value = oelItems.IdItem;
                grdPacking.CurrentRow.Cells["colPackingArticleName"].Value = oelItems.AccountName;
            }
            else if (EventFiringName == "Garment Packing Material")
            {
                grdPackingMaterials.CurrentRow.Cells["colPackingMaterialIdItem"].Value = oelItems.IdItem;
                grdPackingMaterials.CurrentRow.Cells["colPackingMaterialName"].Value = oelItems.AccountName;
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
                ProductionTab.SelectedIndex = 0;
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
        #endregion
        #region Methods
        private void GetProductionVoucher()
        {
            var manager = new ProductionProcessesHeadBLL();
            List<ProductionProcessesHeadEL> list = manager.GetProductionByNumberAndType(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), 2);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
            }
            else
            {
                ClearControls();
            }
        }
        private void GetItemsColorAttributes(Guid Id, string ProcessName)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> oelItemsColorAttributes = manager.GetItemsColorAttributes(Id);
            if (oelItemsColorAttributes.Count > 0)
            {
                if (ProcessName == "Garments Cutting")
                {
                    oelItemsColorAttributes.Insert(0, new ItemsEL() { IdColor = Guid.Empty, ItemColor = "" });

                    colCuttingColors.DataSource = oelItemsColorAttributes;
                    colCuttingColors.DisplayMember = "ItemColor";
                    colCuttingColors.ValueMember = "IdColor";
                }
            }
            else
            {
                colCuttingColors.DataSource = null;
            }
        }
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
            #region Garments Cutting Grid Validation
            else if (GridNumber == 1)
            {
                for (int i = 0; i < grdCutting.Rows.Count; i++)
                {
                    if (grdCutting.Rows[i].Cells["colCuttingAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdCutting.Rows[i].Cells["colCuttingVendorName"].Value == null)
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
            #region Garments Stitching Grid Validation
            else if (GridNumber == 5)
            {
                for (int i = 0; i < grdStitching.Rows.Count; i++)
                {
                    if (grdStitching.Rows[i].Cells["colStitchingAccountNo"].Value == null)
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
            #region Garments Feed/Saftey Grid Validation
            else if (GridNumber == 2)
            {
                for (int i = 0; i < grdFeedoSaftey.Rows.Count; i++)
                {
                    if (grdFeedoSaftey.Rows[i].Cells["colFeedoAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdFeedoSaftey.Rows[i].Cells["colFeedoAmount"].Value == null || Validation.GetSafeDecimal(grdFeedoSaftey.Rows[i].Cells["colFeedoAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Bartake / Kaaj / Buttons Grid Validation
            else if (GridNumber == 3)
            {
                for (int i = 0; i < grdBartake.Rows.Count; i++)
                {
                    if (grdBartake.Rows[i].Cells["colBartakeAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdBartake.Rows[i].Cells["colBartakeAccountNo"].Value == null || Validation.GetSafeDecimal(grdBartake.Rows[i].Cells["colBartakeAccountNo"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Threading Grid Validation
            else if (GridNumber == 4)
            {
                for (int i = 0; i < grdThreading.Rows.Count; i++)
                {
                    if (grdThreading.Rows[i].Cells["colThreadingAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdThreading.Rows[i].Cells["colThreadingAmount"].Value == null || Validation.GetSafeDecimal(grdThreading.Rows[i].Cells["colThreadingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Checking / Inspection Grid Validation
            else if (GridNumber == 6)
            {
                for (int i = 0; i < grdInspection.Rows.Count; i++)
                {
                    if (grdInspection.Rows[i].Cells["colInspectionAccountNo"].Value == null)
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
            #region Garments Press Grid Validation
            else if (GridNumber == 7)
            {
                for (int i = 0; i < grdPress.Rows.Count; i++)
                {
                    if (grdPress.Rows[i].Cells["colPressAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdPress.Rows[i].Cells["colPressAmount"].Value == null || Validation.GetSafeDecimal(grdPress.Rows[i].Cells["colPressAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Packing Grid Validation
            else if (GridNumber == 8)
            {
                for (int i = 0; i < grdPacking.Rows.Count; i++)
                {
                    if (grdPacking.Rows[i].Cells["colPackingAccountNo"].Value == null)
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
            List<ProductionProcessesHeadEL> list = manager.GetCustomerPOSByStatusAndType(2);
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
                ClearControls();
            }
        }
        private void ClearControls()
        {
            #region Clearing Variables
            IdVoucher = Guid.Empty;
             IdCutting = Guid.Empty; 
             IdStitching = Guid.Empty;
             IdFeedo = Guid.Empty;
             IdBartake = Guid.Empty;
             IdThreading = Guid.Empty;
             IdInspection = Guid.Empty;
             IdPress = Guid.Empty;
             IdPacking = Guid.Empty;
            #endregion
            #region Clearing Grids
             grdCutting.Rows.Clear();
             grdCuttingMaterialUsed.Rows.Clear();
             grdCuttingWastage.Rows.Clear();

             grdStitching.Rows.Clear();
             grdStitchingMaterials.Rows.Clear();

             grdFeedoSaftey.Rows.Clear();
             grdFeedoMaterials.Rows.Clear();

             grdBartake.Rows.Clear();
             grdBartakeMaterials.Rows.Clear();

             grdThreading.Rows.Clear();

             grdInspection.Rows.Clear();

             grdPress.Rows.Clear();

             grdPacking.Rows.Clear();
             grdPackingMaterials.Rows.Clear();

             grdMiscCost.Rows.Clear();
            #endregion
        }
        #endregion
        #region Tab Related Events and Methods
        private void ProductionTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Manager = new ProductionProcessDetailBLL();
            var MManager = new ProductionMaterialsBLL();
            List<ProductionProcessDetailEL> list = null;
            List<ProductionProcessesEL> listProcess = null;
            string ProcessName = "";
            #region Garments Cutting
            if (ProductionTab.SelectedIndex == 0)
            {
                ProcessName = "Garments Cutting";
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
                    if (grdCutting.Rows.Count > 0)
                    {
                        grdCutting.Rows.Clear();
                    }
                    IdCutting = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, ProcessName);
                    if (grdCuttingMaterialUsed.Rows.Count > 0)
                    {
                        grdCuttingMaterialUsed.Rows.Clear();
                    }
                    FillMaterials(listMaterials, "ProcessName");
                    List<ProductionMaterialUsedEL> listWastage = MManager.GetProductionWastageByVoucher(IdVoucher, 2, ProcessName);
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
            #region Garments Stitching
            else if (ProductionTab.SelectedIndex == 1)
            {
                ProcessName = "Garments Stitching";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, ProcessName);
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
            #region Garments Feedo/Saftey
            else if (ProductionTab.SelectedIndex == 2)
            {
                ProcessName = "Garments Feedo/Saftey";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, ProcessName);
                    if (grdFeedoSaftey.Rows.Count > 0)
                    {
                        grdFeedoSaftey.Rows.Clear();
                    }
                    IdFeedo = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdFeedoMaterials.Rows.Count > 0)
                        {
                            grdFeedoMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdFeedo = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Garments Bartake/Buttons/Kaaj
            else if (ProductionTab.SelectedIndex == 3)
            {
                ProcessName = "Garments Bartake/Buttons/Kaaj";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, ProcessName);
                    if (grdBartake.Rows.Count > 0)
                    {
                        grdBartake.Rows.Clear();
                    }
                    IdBartake = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdBartakeMaterials.Rows.Count > 0)
                        {
                            grdBartakeMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdBartake = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Garments Threading
            else if (ProductionTab.SelectedIndex == 4)
            {
                ProcessName = "Garments Threading";
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
                    if (grdThreading.Rows.Count > 0)
                    {
                        grdThreading.Rows.Clear();
                    }
                    IdThreading = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdThreading = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Garments Inspection
            else if (ProductionTab.SelectedIndex == 5)
            {
                ProcessName = "Garments Inspection";
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
            #region Garments Press
            else if (ProductionTab.SelectedIndex == 6)
            {
                ProcessName = "Garments Press";
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
                    if (grdPress.Rows.Count > 0)
                    {
                        grdPress.Rows.Clear();
                    }
                    IdPress = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdPress = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Garments Packing
            else if (ProductionTab.SelectedIndex == 7)
            {
                ProcessName = "Garments Packing";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, ProcessName);
                    if (grdPacking.Rows.Count > 0)
                    {
                        grdPacking.Rows.Clear();
                    }
                    IdPacking = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (grdPackingMaterials.Rows.Count > 0)
                    {
                        grdPackingMaterials.Rows.Clear();
                    }
                    FillMaterials(listMaterials, ProcessName);
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
            #region Garments OverHeads
            else if (ProductionTab.SelectedIndex == 8)
            {
                var OverHeadManager = new ProductionOverHeadsBLL();
                List<ProductionOverHeadEL> listCost = OverHeadManager.GetProductionOverHeadsByVoucher(IdVoucher, 2);
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
                #region Garment Cutting Entries
                if (ProcessName == "Garments Cutting")
                {
                    grdCutting.Rows.Add();
                    grdCutting.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdCutting.Rows[i].Cells[1].Value = list[i].Posted;
                    grdCutting.Rows[i].Cells[2].Value = list[i].IdItem;
                    grdCutting.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdCutting.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdCutting.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdCutting.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdCutting.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdCutting.Rows[i].Cells[8].Value = list[i].ItemName;
                    GetItemsColorAttributes(list[i].IdItem,"Garments Cutting");
                    grdCutting.Rows[i].Cells[9].Value = list[i].IdColor;
                    grdCutting.Rows[i].Cells[10].Value = list[i].ItemSize;
                    if (list[i].GType == 1)
                    {
                        grdCutting.Rows[i].Cells[11].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdCutting.Rows[i].Cells[11].Value = "Pant & Shirt";
                    }
                    if (list[i].Quality == 1)
                    {
                        grdCutting.Rows[i].Cells[12].Value = "Fresh";
                    }
                    else if (list[i].Quality == 2)
                    {
                        grdCutting.Rows[i].Cells[12].Value = "Cut Pieces";
                    }
                    else if (list[i].Quality == 3)
                    {
                        grdCutting.Rows[i].Cells[12].Value = "B Grade";
                    }
                    grdCutting.Rows[i].Cells[13].Value = list[i].Quantity;
                    grdCutting.Rows[i].Cells[14].Value = list[i].Meters;


                    grdCutting.Rows[i].Cells[14].Value = list[i].Rate;
                    grdCutting.Rows[i].Cells[15].Value = list[i].Amount.ToString("0.00");

                    if (list[i].Posted)
                    {
                        grdCutting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;

                        grdCutting.Rows[i].Cells[14].ReadOnly = true;
                        grdCutting.Rows[i].Cells[15].ReadOnly = true;
                        grdCutting.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Stitching Entries
                else if (ProcessName == "Garments Stitching")
                {

                    grdStitching.Rows.Add();
                    grdStitching.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdStitching.Rows[i].Cells[1].Value = list[i].Posted;
                    grdStitching.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdStitching.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdStitching.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdStitching.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdStitching.Rows[i].Cells[6].Value = list[i].AccountName;
                    grdStitching.Rows[i].Cells[7].Value = list[i].Description;
                    grdStitching.Rows[i].Cells[8].Value = list[i].ItemSize;
                    if (list[i].GType == 1)
                    {
                        grdStitching.Rows[i].Cells[9].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdStitching.Rows[i].Cells[9].Value = "Pant & Shirt";
                    }
                    grdStitching.Rows[i].Cells[10].Value = list[i].Quantity;



                    grdStitching.Rows[i].Cells[11].Value = list[i].Rate;
                    grdStitching.Rows[i].Cells[12].Value = list[i].Amount;

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
                        grdStitching.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Feedo / Saftey Entries
                else if (ProcessName == "Garments Feedo/Saftey")
                {
                    grdFeedoSaftey.Rows.Add();
                    grdFeedoSaftey.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdFeedoSaftey.Rows[i].Cells[1].Value = list[i].Posted;
                    grdFeedoSaftey.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdFeedoSaftey.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdFeedoSaftey.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdFeedoSaftey.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdFeedoSaftey.Rows[i].Cells[6].Value = list[i].AccountName;
                    grdFeedoSaftey.Rows[i].Cells[7].Value = list[i].Description;
                    if (list[i].GarmentWorkType == 1)
                    {
                        grdFeedoSaftey.Rows[i].Cells[8].Value = "Feedo";
                    }
                    else if (list[i].GarmentWorkType == 2)
                    {
                        grdFeedoSaftey.Rows[i].Cells[8].Value = "Saftey";
                    }
                    if (list[i].GType == 1)
                    {
                        grdFeedoSaftey.Rows[i].Cells[9].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdFeedoSaftey.Rows[i].Cells[9].Value = "Pant & Shirt";
                    }
                    grdFeedoSaftey.Rows[i].Cells[10].Value = list[i].ItemSize;
                    grdFeedoSaftey.Rows[i].Cells[11].Value = list[i].Quantity;



                    grdFeedoSaftey.Rows[i].Cells[12].Value = list[i].Rate;
                    grdFeedoSaftey.Rows[i].Cells[13].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdFeedoSaftey.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Bartake / Kaaj / Buttons Entries
                else if (ProcessName == "Garments Bartake/Buttons/Kaaj")
                {
                    grdBartake.Rows.Add();
                    grdBartake.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdBartake.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdBartake.Rows[i].Cells[2].Value = list[i].Posted;
                    grdBartake.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdBartake.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdBartake.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdBartake.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdBartake.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdBartake.Rows[i].Cells[8].Value = list[i].ItemName;
                    if (list[i].GarmentWorkType == 1)
                    {
                        grdBartake.Rows[i].Cells[9].Value = "Bartake";
                    }
                    else if (list[i].GarmentWorkType == 2)
                    {
                        grdBartake.Rows[i].Cells[9].Value = "Kaaj";
                    }
                    else if (list[i].GarmentWorkType == 2)
                    {
                        grdBartake.Rows[i].Cells[9].Value = "Buttons";
                    }
                    if (list[i].GType == 1)
                    {
                        grdFeedoSaftey.Rows[i].Cells[10].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdBartake.Rows[i].Cells[10].Value = "Pant & Shirt";
                    }
                    grdBartake.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdBartake.Rows[i].Cells[12].Value = list[i].Quantity;



                    grdBartake.Rows[i].Cells[13].Value = list[i].Rate;
                    grdBartake.Rows[i].Cells[14].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdBartake.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Threading Entries
                else if (ProcessName == "Garments Threading")
                {
                    grdThreading.Rows.Add();
                    grdThreading.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdThreading.Rows[i].Cells[1].Value = list[i].Posted;
                    grdThreading.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdThreading.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdThreading.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdThreading.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdThreading.Rows[i].Cells[6].Value = list[i].AccountName;
                    if (list[i].GType == 1)
                    {
                        grdThreading.Rows[i].Cells[7].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdThreading.Rows[i].Cells[7].Value = "Pant & Shirt";
                    }
                    grdThreading.Rows[i].Cells[8].Value = list[i].ItemSize;
                    grdThreading.Rows[i].Cells[9].Value = list[i].Quantity;

                    grdThreading.Rows[i].Cells[10].Value = list[i].Rate;
                    grdThreading.Rows[i].Cells[11].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdThreading.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;

                        grdThreading.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Checking / Inspection Entries
                else if (ProcessName == "Garments Inspection")
                {
                    grdInspection.Rows.Add();
                    grdInspection.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdInspection.Rows[i].Cells[1].Value = list[i].Posted;
                    grdInspection.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdInspection.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdInspection.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdInspection.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdInspection.Rows[i].Cells[6].Value = list[i].AccountName;
                    if (list[i].GType == 1)
                    {
                        grdInspection.Rows[i].Cells[7].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdInspection.Rows[i].Cells[7].Value = "Pant & Shirt";
                    }
                    grdInspection.Rows[i].Cells[8].Value = list[i].ItemSize;
                    grdInspection.Rows[i].Cells[9].Value = list[i].Quantity;
                    grdInspection.Rows[i].Cells[10].Value = list[i].ReadyUnits;
                    grdInspection.Rows[i].Cells[11].Value = list[i].Rejection;


                    grdInspection.Rows[i].Cells[12].Value = list[i].Rate;
                    grdInspection.Rows[i].Cells[13].Value = list[i].Amount;

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

                        grdInspection.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Press Entries
                else if (ProcessName == "Garments Press")
                {
                    grdPress.Rows.Add();
                    grdPress.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdPress.Rows[i].Cells[1].Value = list[i].Posted;
                    grdPress.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdPress.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdPress.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdPress.Rows[i].Cells[5].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdPress.Rows[i].Cells[6].Value = list[i].AccountName;
                    if (list[i].GType == 1)
                    {
                        grdPress.Rows[i].Cells[7].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdPress.Rows[i].Cells[7].Value = "Pant & Shirt";
                    }
                    grdPress.Rows[i].Cells[8].Value = list[i].ItemSize;
                    grdPress.Rows[i].Cells[9].Value = list[i].Quantity;
                    grdPress.Rows[i].Cells[10].Value = list[i].ReadyUnits;
                    grdPress.Rows[i].Cells[11].Value = list[i].Rejection;


                    grdPress.Rows[i].Cells[12].Value = list[i].Rate;
                    grdPress.Rows[i].Cells[13].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdPress.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;

                        grdPress.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Packing Entries
                else if (ProcessName == "Garments Packing")
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
                    if (list[i].GType == 1)
                    {
                        grdPacking.Rows[i].Cells[9].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdPacking.Rows[i].Cells[9].Value = "Pant & Shirt";
                    }
                    grdPacking.Rows[i].Cells[10].Value = list[i].ItemSize;
                    grdPacking.Rows[i].Cells[11].Value = list[i].Quantity;

                    grdPacking.Rows[i].Cells[12].Value = list[i].Rate;
                    grdPacking.Rows[i].Cells[13].Value = list[i].Amount;

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
                        grdPacking.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;

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
                if (ProcessName == "Garments Cutting")
                {
                    grdCuttingMaterialUsed.Rows.Add();
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value = list[i].IdItem;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialName"].Value = list[i].ItemName;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUOM"].Value = list[i].PackingSize;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Stitching Materials Entries
                if (ProcessName == "Garments Stitching")
                {
                    grdStitchingMaterials.Rows.Add();
                    grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdItem"].Value = list[i].IdItem;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialName"].Value = list[i].ItemName;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialUOM"].Value = list[i].PackingSize;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Cutting Materials Entries
                if (ProcessName == "Garments Feedo/Saftey")
                {
                    grdFeedoMaterials.Rows.Add();
                    grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialIdItem"].Value = list[i].IdItem;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialName"].Value = list[i].ItemName;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialUOM"].Value = list[i].ItemName;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialUsedQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Bartake / Kaaj / Buttons Materials Entries
                if (ProcessName == "Garments Bartake / Kaaj / Buttons")
                {
                    grdBartakeMaterials.Rows.Add();
                    grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialIdItem"].Value = list[i].IdItem;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialName"].Value = list[i].ItemName;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialUOM"].Value = list[i].PackingSize;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Packing Materials Entries
                if (ProcessName == "Garments Packing")
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
                #region Cutting Wastage Entries
                if (ProcessName == "Garments Cutting")
                {
                    grdCuttingWastage.Rows.Add();
                    grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value = list[i].IdMaterialUsed;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageIdItem"].Value = list[i].IdItem;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageName"].Value = list[i].ItemName;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageUOM"].Value = list[i].PackingSize;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageQuantity"].Value = list[i].UsedQuantity;
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
        #region Buttons Related Events and Methods
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
                    oelMaterialDetail.ProcessType = 2;
                    oelMaterialDetail.ProductionProcessName = "Cutting Material Usage";
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
                    oelCuttingWastage.ProcessType = 2;
                    oelCuttingWastage.ProductionProcessName = "Cutting Wastage";
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
                    if (grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value == null || Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialQuantity"].Value);
                    oelMaterialDetail.ProcessType = 2;
                    oelMaterialDetail.ProductionProcessName = "Stitching Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDate"].Value);

                    oelCuttingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (Manager.CreateMaterialsUsed(oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {

            }
        }
        private void btnFeedoSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdFeedoMaterials.Rows.Count > 0)
            {
                for (int i = 0; i < grdFeedoMaterials.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value == null || Validation.GetSafeGuid(grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialUsedQuantity"].Value);
                    oelMaterialDetail.ProcessType = 2;
                    oelMaterialDetail.ProductionProcessName = "Feedo Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialDate"].Value);

                    oelCuttingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (Manager.CreateMaterialsUsed(oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {

            }
        }
        private void btnBartakeSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdBartakeMaterials.Rows.Count > 0)
            {
                for (int i = 0; i < grdBartakeMaterials.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value == null || Validation.GetSafeGuid(grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialQuantity"].Value);
                    oelMaterialDetail.ProcessType = 2;
                    oelMaterialDetail.ProductionProcessName = "Bartake/Kaaj/Buttons Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialDate"].Value);

                    oelCuttingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (Manager.CreateMaterialsUsed(oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {

            }
        }
        private void btnPackingSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelPackingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelPackingWastageCollection = new List<ProductionMaterialUsedEL>();
            if (grdPackingMaterials.Rows.Count > 0)
            {
                for (int i = 0; i < grdPackingMaterials.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                    if (grdPackingMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value == null || Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value) == Guid.Empty)
                    {
                        oelMaterialDetail.IdVoucherDetail = Guid.NewGuid();
                        oelMaterialDetail.IsNew = true;
                        grdPackingMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                    }
                    else
                    {
                        oelMaterialDetail.IdVoucherDetail = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value);
                        oelMaterialDetail.IsNew = false;
                    }
                    oelMaterialDetail.IdVoucher = IdVoucher;
                    oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingMaterialIdItem"].Value);
                    oelMaterialDetail.Qty = Validation.GetSafeLong(grdPackingMaterials.Rows[i].Cells["colPackingMaterialQuantity"].Value);
                    oelMaterialDetail.ProcessType = 2;
                    oelMaterialDetail.ProductionProcessName = "Packing Material Usage";
                    oelMaterialDetail.VDate = Convert.ToDateTime(grdPackingMaterials.Rows[i].Cells["colPackingMaterialDate"].Value);

                    oelPackingMaterialCollection.Add(oelMaterialDetail);
                }
            }
            if (Manager.CreateMaterialsUsed(oelPackingMaterialCollection, oelPackingWastageCollection))
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
                    oelProductionOverhead.ProcessType = 2;
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