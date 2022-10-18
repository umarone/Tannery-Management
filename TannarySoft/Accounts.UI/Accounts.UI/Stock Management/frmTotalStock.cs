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
using SpreadsheetLight;
using System.Diagnostics;

using MetroFramework.Forms;
namespace Accounts.UI
{
    public partial class frmTotalStock : MetroForm
    {
        DataTable dt;
        public string StockType { get; set; }
        public int BossCategory { get; set; }
        public frmTotalStock()
        {
            InitializeComponent();
        }
        private void frmTotalStock_Load(object sender, EventArgs e)
        {
            grdTotalStock.AutoGenerateColumns = false;
            FillCategories();
            FillTradingCo();
            if (StockType == "Gloves")
            {
                this.Text = "Feroz Sons Gloves Stock Analysis";
                this.grdTotalStock.Columns[3].Visible = false;
            }
            else if (StockType == "Garments")
            {
                this.Text = "Feroz Sons Garments Stock Analysis";
                this.grdTotalStock.Columns[3].Visible = false;
            }
            else
            {
                 this.Text = "Feroz Sons Tannery Stock Analysis";
                //this.grdTotalStock.Columns[0].Width = 250;
                //this.grdTotalStock.Columns[1].Width = 100;
                //this.grdTotalStock.Columns[2].Width = 100;
                //this.grdTotalStock.Columns[3].Width = 100;
                //this.grdTotalStock.Columns[4].Width = 100;
                //this.grdTotalStock.Columns[5].Width = 100;
                //this.grdTotalStock.Columns[6].Width = 100;
                //this.grdTotalStock.Columns[11].Width = 100;
                //this.grdTotalStock.Columns[12].Width = 110;
                //this.grdTotalStock.Columns[8].Visible = false;
                //this.grdTotalStock.Columns[9].Visible = false;
                //this.grdTotalStock.Columns[10].Visible = false;
                //this.grdTotalStock.Columns[11].Visible = false;
            }
        }
        private void FillCategories()
        {
            var manager = new CategoryBLL();
            List<CategoryEL> listCategories = manager.GetAllCategoriesByBoss(Operations.IdCompany,BossCategory);

            //if (StockType == "Gloves")
            //{
            //    listCategories.RemoveAll(x => x.CategoryName == "CHEMICAL" || x.CategoryName == "CUTTING LEATHER" || x.CategoryName == "SHAVER TAANBA" || x.CategoryName == "SHAVER SET"
            //                            || x.CategoryName == "TANNERY POLYBAG" || x.CategoryName == "CUTTING DYE FST" || x.CategoryName == "TANNERY SOOTER");

            //}
            //else
            //{
            //     listCategories.RemoveAll(x => x.CategoryName != "CHEMICAL" && x.CategoryName != "CUTTING LEATHER" && x.CategoryName != "SHAVER TAANBA" && x.CategoryName != "SHAVER SET"
            //                            && x.CategoryName != "TANNERY POLYBAG" && x.CategoryName != "CUTTING DYE FST" && x.CategoryName != "TANNERY SOOTER");
            //    //for (int i = 0; i < listCategories.Count; i++)
            //    //{
            //    //    if (listCategories[i].CategoryName != "CHEMICAL" && listCategories[i].CategoryName != "CUTTING LEATHER" && listCategories[i].CategoryName != "SHAVER TAANBA"
            //    //                        && listCategories[i].CategoryName != "SHAVER SET" && listCategories[i].CategoryName != "TANNERY POLYBAG" && listCategories[i].CategoryName != "CUTTING DYE FST"
            //    //                        && listCategories[i].CategoryName != "TANNERY SOOTER")
            //    //    {
            //    //        listCategories.Remove(listCategories[i]);
            //    //    }
            //    //}

            //}
            CbxCategories.DataSource = listCategories;
            CbxCategories.DisplayMember = "CategoryName";
            CbxCategories.ValueMember = "IdCategory";
        }
        private void FillTradingCo()
        {
            var manager = new TradingBLL();
            List<TradingEL> listTradingCo = manager.GetAllTradingCo(Operations.IdCompany);

            CbxTrading.DataSource = listTradingCo;
            CbxTrading.DisplayMember = "TradingName";
            CbxTrading.ValueMember = "IdTrading";
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new StockRecieptBLL();
            List<StockReceiptEL> lstStock = new List<StockReceiptEL>();
            //if (chkDate.Checked)
            //{
            //    if (chkByCategory.Checked)
            //    {
            //        lstStock = manager.GetTotalStockReport(Validation.GetSafeGuid(CbxCategories.SelectedValue), Operations.IdCompany);
            //    }
            //    else
            //    {
            //        lstStock = manager.GetTradingWiseTotalStock(Validation.GetSafeGuid(CbxTrading.SelectedValue), Operations.IdCompany);
            //    }
            //    PopulateStock(lstStock);
            //}
            //else
            //{
            //    if (chkByCategory.Checked)
            //    {
            //        lstStock = manager.GetDateWiseTotalStockReport(Validation.GetSafeGuid(CbxCategories.SelectedValue), Operations.IdCompany, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            //    }
            //    else
            //    {
            //        lstStock = manager.GetDateAndTradingWiseTotalStockReport(Validation.GetSafeGuid(CbxTrading.SelectedValue), Operations.IdCompany, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            //    }
            //    PopulateStock(lstStock);
            //}
            if (StockType == "Gloves" || StockType == "Garments")
            {
                lstStock = manager.GetTotalStockReport(Validation.GetSafeGuid(CbxCategories.SelectedValue), Operations.IdCompany);
            }
            else
            {
                lstStock = manager.GetTanneryTotalStockReport(Validation.GetSafeGuid(CbxCategories.SelectedValue), Operations.IdCompany);
            }
            if (lstStock.Count > 0)
            {
                PopulateStock(lstStock);
            }
            else
            {
                MessageBox.Show("No Record Found For this Category, Please Select Another");
                grdTotalStock.DataSource = null;
            }
        }
        private void PopulateStock(List<StockReceiptEL> lstStock)
        {
            dt = new DataTable();
            ////if (lstStock.Count > 0)
            ////{
            ////    grdTotalStock.DataSource = lstStock;                
            ////}
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Clear();
            dt.Columns.Add("ItemNo");
            dt.Columns.Add("AccountName");
            dt.Columns.Add("PackingSize");
            dt.Columns.Add("Opening");
            dt.Columns.Add("CuttingQuantity");
            dt.Columns.Add("Purchases");
            dt.Columns.Add("PurchasesReturn");
            dt.Columns.Add("Sales");
            dt.Columns.Add("SoldIn");
            dt.Columns.Add("RubberingOut");
            dt.Columns.Add("RubberingIn");
            dt.Columns.Add("ProductionOut");
            dt.Columns.Add("ProductionIn");
            dt.Columns.Add("TanneryUsed");
            dt.Columns.Add("Closing");
            dt.Columns.Add("Amount");
           
            for (int i = 0; i < lstStock.Count; i++)
            {
                // Add rows.
                DataRow dr = dt.NewRow();
                dr[0] = lstStock[i].ItemNo;
                dr[1] = lstStock[i].AccountName;
                dr[2] = lstStock[i].PackingSize;
                dr[3] = lstStock[i].Opening;
                dr[4] = lstStock[i].CuttingQuantity;
                dr[5] = lstStock[i].Purchases;
                dr[6] = lstStock[i].PurchasesReturn;
                dr[7] = lstStock[i].Sales;
                dr[8] = lstStock[i].SoldIn;
                dr[9] = lstStock[i].RubberingOut;
                dr[10] = lstStock[i].RubberingIn;
                dr[11] = lstStock[i].ProductionOut;
                dr[12] = lstStock[i].ProductionIn;
                dr[13] = lstStock[i].TanneryUsed;
                dr[14] = lstStock[i].Closing;
                dr[15] = (lstStock[i].Closing * lstStock[i].Amount).ToString("0.00");
                dt.Rows.Add(dr);
            }
            if (dt.Rows.Count > 0)
            {
                grdTotalStock.DataSource = dt;
            }
            else
            {
                grdTotalStock.DataSource = null;
            }
        }
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (grdTotalStock.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdTotalStock.Columns)
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
                for (int i = 0; i < grdTotalStock.Columns.Count; i++)
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

                foreach (DataGridViewRow row in grdTotalStock.Rows)
                {
                    dt.Rows.Add();
                    int colindex = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //if (cell.Value != null)
                        //{
                            if (cell.Visible)
                            {
                                //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                                dt.Rows[dt.Rows.Count - 1][colindex] = cell.Value ?? 0.ToString();
                                colindex++;
                            }
                        //}
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
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("AccountName LIKE '%{0}%'", txtsearch.Text);
            grdTotalStock.DataSource = DV;
            //(grdTotalStock.DataSource as DataTable).DefaultView.RowFilter = string.Format("colAccountName='{0}'", txtsearch.Text);
        }
        private void chkByCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkByCategory.Checked)
            {
                chkByTrading.Checked = false;
                CbxTrading.Enabled = false;
            }
            else
            {
                //chkByTrading.Enabled = true;
                CbxTrading.Enabled = true;
            }
        }
        private void chkByTrading_CheckedChanged(object sender, EventArgs e)
        {
            if (chkByTrading.Checked)
            {
                chkByCategory.Checked = false;
                CbxCategories.Enabled = false;
            }
            else
            {
                //chkByCategory.Enabled = true;
                CbxCategories.Enabled = true;
            }
        }

        private void btnLoadOther_Click(object sender, EventArgs e)
        {
            var manager = new StockRecieptBLL();
            List<StockReceiptEL> lstStock = new List<StockReceiptEL>();
            //if (chkDate.Checked)
            //{
            //    if (chkByCategory.Checked)
            //    {
            //        lstStock = manager.GetTotalStockReport(Validation.GetSafeGuid(CbxCategories.SelectedValue), Operations.IdCompany);
            //    }
            //    else
            //    {
            //        lstStock = manager.GetTradingWiseTotalStock(Validation.GetSafeGuid(CbxTrading.SelectedValue), Operations.IdCompany);
            //    }
            //    PopulateStock(lstStock);
            //}
            //else
            //{
            //    if (chkByCategory.Checked)
            //    {
            //        lstStock = manager.GetDateWiseTotalStockReport(Validation.GetSafeGuid(CbxCategories.SelectedValue), Operations.IdCompany, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            //    }
            //    else
            //    {
            //        lstStock = manager.GetDateAndTradingWiseTotalStockReport(Validation.GetSafeGuid(CbxTrading.SelectedValue), Operations.IdCompany, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            //    }
            //    PopulateStock(lstStock);
            //}
                 
            if (lstStock.Count > 0)
            {
                PopulateStock(lstStock);
            }
            else
            {
                MessageBox.Show("No Record Found For this Category, Please Select Another");
                grdTotalStock.DataSource = null;
            }
        }      
    }
}
