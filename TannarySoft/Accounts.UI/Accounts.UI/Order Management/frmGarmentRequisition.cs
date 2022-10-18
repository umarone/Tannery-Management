﻿using System;
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
    public partial class frmGarmentRequisition : MetroForm
    {
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        public Int64 VoucherNo { get; set; }
        public Int64 GarmentOrderNo { get; set; }
        public string VoucherType { get; set; }
        Guid IdOrder;
        Guid IdRequisition;
        Guid IdArticle;
        string EventCommandName;
        int EventTime = 0;
        string StockCommand = "";
        string LinkAccountNo = "";
        public frmGarmentRequisition()
        {
            InitializeComponent();
        }

        private void frmGarmentRequisition_Load(object sender, EventArgs e)
        {
            this.grdOrderdArticles.AutoGenerateColumns = false;
            FillMaxRequisitionNumber();
            FillGarmentOrder();
        }
        private void FillMaxRequisitionNumber()
        {
            var manager = new GarmentsRequisitionBLL();
            VEditBox.Text = manager.GetMaxRequisitionNumber(2, Operations.IdCompany).ToString();
        }
        private void FillGarmentOrder()
        {
            var Manager = new OrderDetailBLL();
            VoucherType = "SalesOrder";
            if (VEditBox.Text != string.Empty)
            {
                List<ItemsAttributesDetailsEL> list = Manager.GetGarmentBreakupByOrderNo(GarmentOrderNo, Operations.IdCompany);
                if (list.Count > 0)
                {
                    txtCustomerPo.Text = list[0].CustomerPo;
                    if (list[0].Posted)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                    }

                    FillGarmentOrderDetail(list);

                }
                else
                {
                    MessageBox.Show("Order Number Not Found ...");
                    //ClearControl();
                }
            }
        }
        private void FillGarmentOrderDetail(List<ItemsAttributesDetailsEL> List)
        {
            if (grdOrderdArticles.Rows.Count > 0)
            {
                grdOrderdArticles.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {
                for (int i = 0; i < List.Count; i++)
                {
                    grdOrderdArticles.Rows.Add();
                    grdOrderdArticles.Rows[i].Cells[0].Value = List[i].IdOrderDetail;
                    grdOrderdArticles.Rows[i].Cells[1].Value = List[i].IdItem;
                    grdOrderdArticles.Rows[i].Cells[2].Value = List[i].ItemName;
                }
            }
        }

        private void grdOrderdArticles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var manager = new OrderDetailBLL();
            var RManager = new GarmentsRequisitionDetailBLL();
            List<RequisitionDetailEL> listPreparedRequisition = RManager.GetGarmentsRequisitionDetailsArticles(Validation.GetSafeGuid(grdOrderdArticles.Rows[e.RowIndex].Cells["colOrderdArticleIdItem"].Value), IdRequisition);
            if (listPreparedRequisition.Count == 0)
            {
                List<ItemsAttributesDetailsEL> list = manager.GetGarmentBreakupDetailById(Validation.GetSafeGuid(grdOrderdArticles.Rows[e.RowIndex].Cells["colOrderedIdDetail"].Value));
                IdArticle = Validation.GetSafeGuid(grdOrderdArticles.Rows[e.RowIndex].Cells["colOrderdArticleIdItem"].Value);
                if (list.Count > 0)
                {
                    FillGarmentBreakupDetail(list);
                    LoadGarmentMaterials(list);
                }
            }
            else
            {
                List<RequisitionDetailEL> listClothe = listPreparedRequisition.FindAll(x => x.ReqDetailType == 1);
                List<RequisitionDetailEL> listMaterials = listPreparedRequisition.FindAll(x => x.ReqDetailType == 2);
                if (listClothe.Count > 0)
                {
                    for (int i = 0; i < listClothe.Count; i++)
                    {
                        grdOrderdClothe.Rows.Add();

                        grdOrderdClothe.Rows[i].Cells["colClotheIdDetail"].Value = listClothe[i].IdRequisitionDetail;
                        grdOrderdClothe.Rows[i].Cells["colClotheIdItem"].Value = listClothe[i].IdItem;
                        grdOrderdClothe.Rows[i].Cells["colClotheItemName"].Value = listClothe[i].ItemName;

                        grdOrderdClothe.Rows[i].Cells["colClotheSmall"].Value = listClothe[i].Small;
                        grdOrderdClothe.Rows[i].Cells["colClotheMedium"].Value = listClothe[i].Medium;
                        grdOrderdClothe.Rows[i].Cells["colClotheLarge"].Value = listClothe[i].Large;
                        grdOrderdClothe.Rows[i].Cells["colClotheXL"].Value = listClothe[i].XLarge;
                        grdOrderdClothe.Rows[i].Cells["colClothe2XL"].Value = listClothe[i].DoubleXLarge;
                        grdOrderdClothe.Rows[i].Cells["colClothe3XL"].Value = listClothe[i].TripleXLarge;
                        grdOrderdClothe.Rows[i].Cells["colClothe4XL"].Value = listClothe[i].FourthXLarge;
                        grdOrderdClothe.Rows[i].Cells["colClothe5XL"].Value = listClothe[i].FifthXLarge;
                        grdOrderdClothe.Rows[i].Cells["colClotheDying"].Value = listClothe[i].Dying;
                        grdOrderdClothe.Rows[i].Cells["colClotheTotal"].Value = listClothe[i].TotalBreakup;
                    }
                }
                else
                {
                    grdOrderdClothe.Rows.Clear();
                }
                if (listMaterials.Count > 0)
                {
                    for (int i = 0; i < listMaterials.Count; i++)
                    {
                        grdOrderBreakup.Rows.Add();

                        grdOrderBreakup.Rows[i].Cells["colBreakupIdDetail"].Value = listMaterials[i].IdRequisitionDetail;
                        grdOrderBreakup.Rows[i].Cells["colBreakupIdItem"].Value = listMaterials[i].IdItem;
                        grdOrderBreakup.Rows[i].Cells["colBreakupItemName"].Value = listMaterials[i].ItemName;

                        grdOrderBreakup.Rows[i].Cells["colBreakupSmall"].Value = listMaterials[i].Small;
                        grdOrderBreakup.Rows[i].Cells["colBreakupMedium"].Value = listMaterials[i].Medium;
                        grdOrderBreakup.Rows[i].Cells["colBreakupLarge"].Value = listMaterials[i].Large;
                        grdOrderBreakup.Rows[i].Cells["colBreakupXL"].Value = listMaterials[i].XLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakup2XLarge"].Value = listMaterials[i].DoubleXLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakup3XL"].Value = listMaterials[i].TripleXLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakup4XL"].Value = listMaterials[i].FourthXLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakup5XL"].Value = listMaterials[i].FifthXLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakupTotal"].Value = listMaterials[i].TotalBreakup;
                    }
                }
            }
        }
        private void FillGarmentBreakupDetail(List<ItemsAttributesDetailsEL> list)
        {
            if (list.Count > 0)
            { 
                // First Rename Breakup Columns
                grdOrderBreakup.Columns[4].HeaderText = grdOrderBreakup.Columns[4].HeaderText + "("+list[0].Small+")";
                grdOrderBreakup.Columns[5].HeaderText = grdOrderBreakup.Columns[5].HeaderText + "(" + list[0].Large + ")";
                grdOrderBreakup.Columns[6].HeaderText = grdOrderBreakup.Columns[6].HeaderText + "(" + list[0].XLarge + ")";
                grdOrderBreakup.Columns[7].HeaderText = grdOrderBreakup.Columns[7].HeaderText + "(" + list[0].DoubleXLarge + ")";
                grdOrderBreakup.Columns[8].HeaderText = grdOrderBreakup.Columns[8].HeaderText + "(" + list[0].TripleXLarge + ")"; 
                grdOrderBreakup.Columns[9].HeaderText = grdOrderBreakup.Columns[9].HeaderText + "(" + list[0].FourthXLarge + ")"; 
                grdOrderBreakup.Columns[10].HeaderText = grdOrderBreakup.Columns[10].HeaderText + "(" + list[0].FifthXLarge + ")";
                grdOrderBreakup.Columns[11].HeaderText = grdOrderBreakup.Columns[11].HeaderText + "(" + list[0].TotalBreakup + ")"; 

            }
        }
        private void LoadGarmentMaterials(List<ItemsAttributesDetailsEL> list)
        { 
            var manager = new ItemsBLL();
            var CManager = new GarmentsCalculationBLL();
            List<ItemsEL> listItemsCollection = manager.GetItemsByCategoryType("Garments Materials");
            List<ItemFormulaEL> listItemsFormula = null;
            if (listItemsCollection.Count > 0)
            {
                for (int i = 0; i < listItemsCollection.Count; i++)
                {
                    grdOrderBreakup.Rows.Add();
                    grdOrderBreakup.Rows[i].Cells["colBreakupIdItem"].Value = listItemsCollection[i].IdItem;
                    grdOrderBreakup.Rows[i].Cells["colBreakupItemName"].Value = listItemsCollection[i].ItemName;
                    listItemsFormula =  CManager.GetFormulaByItem(listItemsCollection[i].IdItem);
                    if (listItemsFormula.Count > 0)
                    {                        
                        grdOrderBreakup.Rows[i].Cells["colBreakupSmall"].Value = listItemsFormula[0].TotalExactQty * list[0].Small;
                        grdOrderBreakup.Rows[i].Cells["colBreakupMedium"].Value = listItemsFormula[0].TotalExactQty * list[0].Medium;
                        grdOrderBreakup.Rows[i].Cells["colBreakupLarge"].Value = listItemsFormula[0].TotalExactQty * list[0].Large;
                        grdOrderBreakup.Rows[i].Cells["colBreakupXL"].Value = listItemsFormula[0].TotalExactQty * list[0].XLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakup2XLarge"].Value = listItemsFormula[0].TotalExactQty * list[0].DoubleXLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakup3XL"].Value = listItemsFormula[0].TotalExactQty * list[0].TripleXLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakup4XL"].Value = listItemsFormula[0].TotalExactQty * list[0].FourthXLarge;
                        grdOrderBreakup.Rows[i].Cells["colBreakup5XL"].Value = listItemsFormula[0].TotalExactQty * list[0].FifthXLarge;
                    }
                    if (listItemsFormula[0].MaterialType == "ELASTIC")
                    {
                        grdOrderBreakup.Rows[i].Cells["colBreakupTotal"].Value = ((((list[0].Small + list[0].Medium + list[0].Large + list[0].XLarge + list[0].DoubleXLarge +
                                                       list[0].TripleXLarge + list[0].FourthXLarge + list[0].FifthXLarge) * listItemsFormula[0].TotalQty) / 39) / 30);
                    }
                    else
                    {
                        grdOrderBreakup.Rows[i].Cells["colBreakupTotal"].Value = list[0].Small + list[0].Medium + list[0].Large + list[0].XLarge + list[0].DoubleXLarge +
                                                                               list[0].TripleXLarge + list[0].FourthXLarge + list[0].FifthXLarge;
                    }
                }
            }
        }
        private bool ValidateRows()
        {

            //for (int i = 0; i < grdOrders.Rows.Count - 1; i++)
            //{
            //    if (grdOrders.Rows[i].Cells["colItemNo"].Value == null)
            //    {
            //        return false;
            //    }
            //    else if (grdOrders.Rows[i].Cells["colQty"].Value == null)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }
        private bool ValidateControls()
        {
            //if (SEditBox.Text == string.Empty)
            //{
            //    lblStatuMessage.Text = "Customer Missing...";
            //    return false;
            //}
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<RequisitionDetailEL> oelRequisitionCollection = new List<RequisitionDetailEL>();
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    /// Add Voucher...
                    #region Voucher Head Entries
                    RequisitionEL oelRequisition = new RequisitionEL();
                    if (IdRequisition == Guid.Empty)
                    {
                        oelRequisition.IdRequisition = Guid.NewGuid();
                    }
                    else
                    {
                        oelRequisition.IdRequisition = IdRequisition;
                    }
                    oelRequisition.IdUser = Operations.UserID;
                    oelRequisition.IdCompany = Operations.IdCompany;
                    oelRequisition.ReqNo = Convert.ToInt64(VEditBox.Text);
                    oelRequisition.CustomerPo = Validation.GetSafeString(txtCustomerPo.Text);
                    //oelRequisition.Description = Validation.GetSafeString(txtDescription.Text);
                    oelRequisition.ReqType = 2;
                    oelRequisition.ReqDate = reqDate.Value;
                    #endregion
                    ///Add Stock Detail 
                    #region Stock Entries
                    for (int i = 0; i < grdOrderdClothe.Rows.Count - 1; i++)
                    {
                        RequisitionDetailEL oelReqDetail = new RequisitionDetailEL();
                        ItemsEL oelItem = new ItemsEL();
                        oelReqDetail.IdRequisition = oelRequisition.IdRequisition;
                        oelReqDetail.VoucherNo = Convert.ToInt64(VEditBox.Text);

                        if (grdOrderdClothe.Rows[i].Cells["colClotheIdDetail"].Value != null)
                        {
                            oelReqDetail.IdRequisitionDetail = new Guid(grdOrderdClothe.Rows[i].Cells["colClotheIdDetail"].Value.ToString());
                            oelReqDetail.IsNew = false;
                        }
                        else
                        {
                            oelReqDetail.IdRequisitionDetail = Guid.NewGuid();
                            oelReqDetail.IsNew = true;
                        }
                        oelReqDetail.Seq = i + 1;
                        oelReqDetail.IdItem = Validation.GetSafeGuid(grdOrderdClothe.Rows[i].Cells["colClotheIdItem"].Value);
                        oelReqDetail.IdArticle = IdArticle;
                        oelReqDetail.Small =  Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClotheSmall"].Value);
                        oelReqDetail.Medium = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClotheMedium"].Value);
                        oelReqDetail.Large = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClotheLarge"].Value);
                        oelReqDetail.XLarge = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClotheXL"].Value);
                        oelReqDetail.DoubleXLarge = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClothe2XL"].Value);
                        oelReqDetail.TripleXLarge = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClothe3XL"].Value);
                        oelReqDetail.FourthXLarge = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClothe4XL"].Value);
                        oelReqDetail.FifthXLarge = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClothe5XL"].Value);
                        oelReqDetail.TotalBreakup = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClotheTotal"].Value);
                        oelReqDetail.Dying = Validation.GetSafeLong(grdOrderdClothe.Rows[i].Cells["colClotheDying"].Value);
                        oelReqDetail.ReqDetailType = 1;
                        oelRequisitionCollection.Add(oelReqDetail);
                    }
                    #endregion
                    // Now Add Order Breakup Detail
                    #region Stock Entries
                    for (int i = 0; i < grdOrderBreakup.Rows.Count; i++)
                    {
                        RequisitionDetailEL oelMaterialDetail = new RequisitionDetailEL();
                        ItemsEL oelItem = new ItemsEL();
                        oelMaterialDetail.IdRequisition = oelRequisition.IdRequisition;
                        oelMaterialDetail.VoucherNo = Convert.ToInt64(VEditBox.Text);

                        if (grdOrderBreakup.Rows[i].Cells["colBreakupIdDetail"].Value != null)
                        {
                            oelMaterialDetail.IdRequisitionDetail = new Guid(grdOrderBreakup.Rows[i].Cells["colBreakupIdDetail"].Value.ToString());
                            oelMaterialDetail.IsNew = false;
                        }
                        else
                        {
                            oelMaterialDetail.IdRequisitionDetail = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                        }
                        oelMaterialDetail.Seq = i + 1;
                        oelMaterialDetail.IdArticle = IdArticle;
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdOrderBreakup.Rows[i].Cells["colBreakupIdItem"].Value);

                        oelMaterialDetail.Small = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupSmall"].Value);
                        oelMaterialDetail.Medium = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupMedium"].Value);
                        oelMaterialDetail.Large = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupLarge"].Value);
                        oelMaterialDetail.XLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupXL"].Value);
                        oelMaterialDetail.DoubleXLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakup2XLarge"].Value);
                        oelMaterialDetail.TripleXLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakup3XL"].Value);
                        oelMaterialDetail.FourthXLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakup4XL"].Value);
                        oelMaterialDetail.FifthXLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakup5XL"].Value);
                        oelMaterialDetail.TotalBreakup = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupTotal"].Value);
                        oelMaterialDetail.Dying = 0;
                        oelMaterialDetail.ReqDetailType = 2;

                        oelRequisitionCollection.Add(oelMaterialDetail);
                    }
                    #endregion
                    if (IdRequisition == Guid.Empty)
                    {
                        var manager = new GarmentsRequisitionBLL();
                        if (manager.CreateGarmentsRequisiton(oelRequisition, oelRequisitionCollection))
                        {
                            lblStatuMessage.Text = "Garments Sales Order Inserted Successfully...";
                            ClearControl();
                            FillMaxRequisitionNumber();
                        }
                        else
                        {
                            MessageBox.Show("Some Problem Occured while Saving Order :");
                        }
                    }
                    else
                    {
                        var manager = new GarmentsRequisitionBLL();
                        if (manager.UpdateGarmentsRequisiton(oelRequisition, oelRequisitionCollection))
                        {
                            lblStatuMessage.Text = "Garments Sales Order Updated Successfully...";
                            ClearControl();
                            FillMaxRequisitionNumber();
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
        private void ClearControl()
        {
            grdOrderdClothe.Rows.Clear();
            grdOrderBreakup.Rows.Clear();            
            VoucherNo = 0;
            IdOrder = Guid.Empty;
            VEditBox.Enabled = true;
            //txtDescription.Text = string.Empty;

            SEditBox.Text = string.Empty;
            lblStatuMessage.Text = string.Empty;

            txtCustomerPo.Text = "";

        }

        private void grdOrderdClothe_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOrderdClothe.CurrentCellAddress.X == 3)
            {
                TextBox txtClotheItemName = e.Control as TextBox;
                if (txtClotheItemName != null)
                {
                    txtClotheItemName.KeyPress -= new KeyPressEventHandler(txtClotheItemName_KeyPress);
                    txtClotheItemName.KeyPress += new KeyPressEventHandler(txtClotheItemName_KeyPress);
                }
            }
        }

        void txtClotheItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOrderdClothe.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockCommand = "OrderClothe";
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
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            var manager = new ItemsBLL();
            if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {
                lblStatuMessage.Text = "";
                if (StockCommand == "OrderClothe")
                {
                    grdOrderdClothe.CurrentRow.Cells["colClotheIdItem"].Value = oelItems.IdItem;
                    //grdOrderdClothe.CurrentRow.Cells["colItemNo"].Value = oelItems.AccountNo;
                    grdOrderdClothe.CurrentRow.Cells["colClotheItemName"].Value = oelItems.AccountName;
                    //grdOrderdClothe.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                }
                else
                {
                    grdOrderBreakup.CurrentRow.Cells["colBreakupIdItem"].Value = oelItems.IdItem;
                    grdOrderBreakup.CurrentRow.Cells["colBreakupItemName"].Value = oelItems.AccountName;
         
                }

         
            }
            else
            {
                lblStatuMessage.Text = "Wrong Account...";
            }
        }

        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillRequistionArticles();
            }
        }

        private void FillRequistionArticles()
        {
            var manager = new GarmentsRequisitionDetailBLL();
            List<RequisitionDetailEL> list = manager.GetGarmentsRequisitionArticles(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
            if (list.Count > 0)
            {
                IdRequisition = list[0].IdRequisition;
                grdOrderdArticles.DataSource = list;
            }
        }
    }
}
