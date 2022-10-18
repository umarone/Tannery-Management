﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounts.BLL;
using Accounts.Common;
using Accounts.UI.UserControls;
using Accounts.EL;

using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmFindAccounts : MetroForm
    {
        //ChartsOfAccountsBLL objChartOfAccount = new ChartsOfAccountsBLL();
        AccountsBLL objAccounts = new AccountsBLL();
        AccountsEL oelAccount = null;
        public string SearchText { get; set; }
        public delegate void FindAccountDelegate(Object Sender,AccountsEL oelAccount);
        public event FindAccountDelegate ExecuteFindAccountEvent;
        public frmFindAccounts()
        {
            InitializeComponent();
        }
        private void PopulateAccountsHeader()
        {
            //List<AccountsEL> list = objChartOfAccount.GetAllSubCategory();
            //list.Insert(0,new AccountsEL { Catagory = 0, SubCategoryName = "" });
           
            //cbxSubCategories.DataSource = list;
            //cbxSubCategories.DisplayMember = "SubCategoryName";
            //cbxSubCategories.ValueMember = "SubCategory";

        }
        private void frmAccounts_Load(object sender, EventArgs e)
        {
            grdFindAccounts.AutoGenerateColumns = false;            
            //PopulateAccountsHeader();
            txtSearchAccounts.Text = SearchText;
            txtSearchAccounts.SelectionStart = 1;
        }
        private void txtSearchAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grdFindAccounts.Focus();
                e.KeyChar = (char)Keys.Tab;
            }
        }

        private void txtSearchAccounts_TextChanged(object sender, EventArgs e)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = new List<AccountsEL>();
            string searchString = "";
            if (txtSearchAccounts.Text != string.Empty)
            {
                char[] chars = txtSearchAccounts.Text.ToArray();
                if (chars.Length > 0 && char.IsNumber(chars[0]))
                {
                    list = manager.SearchAccountByAccountNo(Validation.GetSafeLong(txtSearchAccounts.Text),Operations.IdCompany);
                    PopulateAccountsBySearch(list);
                }
                else
                {
                    searchString = txtSearchAccounts.Text;
                    if (txtSearchAccounts.Text.Contains("\t"))
                        searchString = txtSearchAccounts.Text.Remove(txtSearchAccounts.Text.Count() - 1);
                    list = manager.SearchAccountByAccountName(searchString,Operations.IdCompany);
                    PopulateAccountsBySearch(list);
                }
            }
            else if (grdFindAccounts.Rows.Count > 0)
            {
                grdFindAccounts.DataSource = null;
            }
        }
        private void PopulateAccountsBySearch(List<AccountsEL> list)
        {
            if (grdFindAccounts.Rows.Count > 1)
            {
                grdFindAccounts.DataSource = null;
            }
            grdFindAccounts.DataSource = list;
        }
        private void PopulateAccountsByCategory(int Id)
        {
            //List<AccountsEL> list = objChartOfAccount.GetAccountsByCategory(Id);            
            //grdFindAccount.DataSource = list;
        }
        private void PopulateAccountsByAccountNo(List<AccountsEL> list)
        {
            if (grdFindAccounts.Rows.Count > 1)
            {
                grdFindAccounts.DataSource = null;
            }
            grdFindAccounts.DataSource = list;
        }
        private void grdFindAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdFindAccounts.CurrentRow != null)
                {
                    int RowIndex = grdFindAccounts.CurrentRow.Index;
                    oelAccount = new AccountsEL();
                    oelAccount.IdAccount = Validation.GetSafeGuid(grdFindAccounts.Rows[RowIndex].Cells[0].Value);
                    oelAccount.IdParent = Validation.GetSafeGuid(grdFindAccounts.Rows[RowIndex].Cells[1].Value);
                    oelAccount.IdHead = Validation.GetSafeInteger(grdFindAccounts.Rows[RowIndex].Cells[2].Value);

                    oelAccount.LinkAccountNo = Validation.GetSafeString(grdFindAccounts.Rows[RowIndex].Cells[3].Value);
                    oelAccount.AccountNo = Validation.GetSafeString(grdFindAccounts.Rows[RowIndex].Cells[4].Value);
                    oelAccount.AccountName = Validation.GetSafeString(grdFindAccounts.Rows[RowIndex].Cells[5].Value);
                    oelAccount.AccountType = Validation.GetSafeString(grdFindAccounts.Rows[RowIndex].Cells[7].Value);
                    this.Close();
                }
            }
            else
            {
                //txtID.Focus();
            }
        }
        private void grdFindAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            oelAccount = new AccountsEL();

            oelAccount.IdAccount = Validation.GetSafeGuid(grdFindAccounts.Rows[RowIndex].Cells[0].Value);
            oelAccount.IdParent = Validation.GetSafeGuid(grdFindAccounts.Rows[RowIndex].Cells[1].Value);
            oelAccount.IdHead = Validation.GetSafeInteger(grdFindAccounts.Rows[RowIndex].Cells[2].Value);

            oelAccount.LinkAccountNo = Validation.GetSafeString(grdFindAccounts.Rows[RowIndex].Cells[3].Value);
            oelAccount.AccountNo = Validation.GetSafeString(grdFindAccounts.Rows[RowIndex].Cells[4].Value);
            oelAccount.AccountName = Validation.GetSafeString(grdFindAccounts.Rows[RowIndex].Cells[5].Value);
            oelAccount.AccountType = Validation.GetSafeString(grdFindAccounts.Rows[RowIndex].Cells[7].Value);
            this.Close();            
        }

        private void frmAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelAccount != null)
            {
                ExecuteFindAccountEvent(sender,oelAccount);
            }
        }

        private void frmFindAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    
       
    }
}
