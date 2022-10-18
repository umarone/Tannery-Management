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
using System.Collections;

namespace Accounts.UI
{
    public partial class frmMain : Form
    {

        UserModulesBLL manager = new UserModulesBLL();

        frmLogin frmlogin = null;
        //frmChartOfAccounts frmAccounts = null;
        frmAccounts frmAccounts = null;
        frmCashReceiptVoucher frmcashReceipt = null;
        frmVouchers frmvouchers = null;
        frmSalesManLedger frmsaleManLedger = null;
        frmSales frmsales = null;
        frmUsers frmusers = null;
        frmOpeningBalance frmopeningbalance = null;
        frmOpeningBalancesByType frmOpeningType = null;
        frmPriceList frmpricelist = new frmPriceList();
        frmStockReceipt frmstockreceipt = null;
        frmStockReturn frmstockReturn = null;
        frmgeneralLedger frmledger = null;
        frmExpenses frmExpense = null;
        frmSalesReturn frmSaleReturn = null;
        frmAccountBalance frmAccountbalanceReport = null;
        frmBackup frmbackup = null;
        frmUnpostedVouchers frmunpostedVouchers = null;
        frmIncomeStatement frmincomestatement = null;
        //frmPrescriberSample frmprescriberSample = null;
        frmSaleReports frmSaleReport = null;
        frmBankVocher frmbankVoucher = null;
        frmBankReceiptVoucher frmbankReceiptVoucher = null;
        frmJournalVoucher frmjournalvoucher = null;
        frmTrialBalance frmtrialbalance = null;
        frmMiniTrialBalance frmminitrialbalance = null;
        frmDetailedJournalLedger frmDetailLedger;
        frmTotalStock frmtotalStock;
        frmPersons frmPerson;
        frmStockItems frmstockitems;
        frmCompany frmCompanies;
        frmModulesRights frmModuleRights;
        frmModulesPermissions frmModulesPermission;
        frmChangePassword frmchangePassword;
        frmUsersRoles frmuserRoles;
        frmProducts frmProduct = null;
        frmHeadsSetup frmheadsSetup = null;
        frmSamples frmSample = null;
        frmSamplesReturn frmSampleReturn = null;
        frmCategories frmcategories = null;
        frmSampleReports frmsampleReports = null;
        frmRecoveryReport frmrecoveryReport = null;
        frmSampleSaleDays frmsamplesaledays = null;
        frmMonthlySalesReport frmmonthlySaleReport = null;
        frmMonthlyClaimReport frmmonthlyClaimReturn = null;
        frmClotheProcess frmclotheprocess;
        frmPartyRubberingStock frmpartyrubberingstock;
        frmCurrentStock frmcurrentStock = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            rbnMain.ThemeColor = RibbonTheme.Normal;
            rbnMain.Refresh();
            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = Color.LightSteelBlue;
                    break;
                }
            }
            frmlogin = new frmLogin();
            frmlogin.ShowDialog(this);
            if (Operations.UserName != null)
            {
                UserNameStatus.Text = Operations.UserName.ToUpper();
            }
            if (Operations.CompanyName != string.Empty)
            {
                toolStripCompanyName.Text = Operations.CompanyName;
            }
        }

        private void rbnBtnUsers_Click(object sender, EventArgs e)
        {
            frmusers = new frmUsers();
            frmusers.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmusers.Show();
            }
            else if (CheckModuleRights(frmusers.Name) != Guid.Empty)
            {
                frmusers.Show();
            }
            else
            {
                frmusers.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnAccount_Click(object sender, EventArgs e)
        {
            frmAccounts = new frmAccounts();
            frmAccounts.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmAccounts.Show();
            }
            else if (CheckModuleRights(frmAccounts.Name) != Guid.Empty)
            {
                frmAccounts.Show();
            }
            else
            {
                frmAccounts.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void rbnBtnPriceList_Click(object sender, EventArgs e)
        {
            frmpricelist = new frmPriceList();
            frmpricelist.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmpricelist.Show();
            }
            else if (CheckModuleRights(frmpricelist.Name) != Guid.Empty)
            {
                frmpricelist.Show();
            }
            else
            {
                frmpricelist.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnStock_Click(object sender, EventArgs e)
        {

        }

        private void rbnBtnCashPayment_Click(object sender, EventArgs e)
        {
            frmvouchers = new frmVouchers();
            frmvouchers.MdiParent = this;
            frmvouchers.VoucherType = VoucherTypes.PaymentVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {

                frmvouchers.Show();
            }
            else if (CheckModuleRights(frmvouchers.Name + "/Cash Payments") != Guid.Empty)
            {
                frmvouchers.MdiParent = this;
                frmvouchers.Show();
            }
            else
            {

            }
        }

        private void rbnBtnCashReciept_Click(object sender, EventArgs e)
        {
            frmvouchers = new frmVouchers();
            frmvouchers.MdiParent = this;
            frmvouchers.VoucherType = VoucherTypes.CashReceiptVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmvouchers.Show();
            }
            else if (CheckModuleRights(frmvouchers.Name + "/Cash Receipts") != Guid.Empty)
            {
                frmvouchers.Show();
            }
            else
            {

            }
        }
        private void rbnBtnDailyExpenseReport_Click(object sender, EventArgs e)
        {
            frmExpense = new frmExpenses();
            frmExpense.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmExpense.Show();
            }
            else if (CheckModuleRights(frmExpense.Name) != Guid.Empty)
            {
                frmExpense.Show();
            }
            else
            {
                frmExpense.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnBalances_Click(object sender, EventArgs e)
        {
            frmAccountbalanceReport = new frmAccountBalance();
            frmAccountbalanceReport.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmAccountbalanceReport.Show();
            }
            else if (CheckModuleRights(frmAccountbalanceReport.Name) != Guid.Empty)
            {
                frmAccountbalanceReport.Show();
            }
            else
            {
                frmAccountbalanceReport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnSignOut_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
                if (!frmlogin.IsDisposed)
                {
                    frmlogin.ShowDialog(this);
                }
                else
                {
                    frmlogin = new frmLogin();
                    frmlogin.ShowDialog(this);
                }
                if (Operations.UserName != null)
                {
                    UserNameStatus.Text = Operations.UserName.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Umar");
            }
        }

        private void rbnBtnBackUp_Click(object sender, EventArgs e)
        {
            frmbackup = new frmBackup();
            frmbackup.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmbackup.Show();
            }
            else if (CheckModuleRights(frmbackup.Name) != Guid.Empty)
            {
                frmbackup.Show();
            }
            else
            {
                frmbackup.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void rbnBtnPosting_Click(object sender, EventArgs e)
        {
            frmunpostedVouchers = new frmUnpostedVouchers();
            frmunpostedVouchers.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmunpostedVouchers.Show();
            }
            else if (CheckModuleRights(frmunpostedVouchers.Name) != Guid.Empty)
            {
                frmunpostedVouchers.Show();
            }
            else
            {
                frmunpostedVouchers.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnIncome_Click(object sender, EventArgs e)
        {
            frmincomestatement = new frmIncomeStatement();
            frmincomestatement.MdiParent = this;
            frmincomestatement.Show();
        }

        //private void rbnBtnPrescriberSample_Click(object sender, EventArgs e)
        //{
        //    frmprescriberSample = new frmPrescriberSample();
        //    frmprescriberSample.MdiParent = this;
        //    frmprescriberSample.Show();
        //}

        private void rbnBtnBankPayment_Click(object sender, EventArgs e)
        {
            frmvouchers = new frmVouchers();
            frmvouchers.MdiParent = this;
            frmvouchers.VoucherType = VoucherTypes.BankPaymentVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {

                frmvouchers.Show();
            }
            else if (CheckModuleRights(frmvouchers.Name + "/Bank Payment") != Guid.Empty)
            {
                frmvouchers.Show();
            }
            else
            {

            }
        }

        private void rbnBtnBankReceipt_Click(object sender, EventArgs e)
        {
            frmvouchers = new frmVouchers();
            frmvouchers.MdiParent = this;
            frmvouchers.VoucherType = VoucherTypes.BankReceiptVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmvouchers.Show();
            }
            else if (CheckModuleRights(frmvouchers.Name + "/Bank Receipt") != Guid.Empty)
            {
                frmvouchers.Show();
            }
            else
            {

            }
        }

        private void rbtnBtnJournalVoucher_Click(object sender, EventArgs e)
        {
            frmjournalvoucher = new frmJournalVoucher();
            frmjournalvoucher.MdiParent = this;
            frmjournalvoucher.VoucherType = VoucherTypes.JournalVoucher.ToString();
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmjournalvoucher.Show();
            }
            else if (CheckModuleRights(frmjournalvoucher.Name) != Guid.Empty)
            {
                frmjournalvoucher.Show();
            }
            else
            {
                frmjournalvoucher.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void rbnBtnLedgerReport_Click(object sender, EventArgs e)
        {
            frmledger = new frmgeneralLedger();
            frmledger.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmledger.Show();
            }
            else if (CheckModuleRights(frmledger.Name) != Guid.Empty)
            {
                frmledger.Show();
            }
            else
            {
                frmledger.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void rbnBtnDetailedLedgerReport_Click(object sender, EventArgs e)
        {
            frmDetailLedger = new frmDetailedJournalLedger();
            frmDetailLedger.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmDetailLedger.Show();
            }
            else if (CheckModuleRights(frmDetailLedger.Name) != Guid.Empty)
            {
                frmDetailLedger.Show();
            }
            else
            {
                frmDetailLedger.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnSaleReport_Click(object sender, EventArgs e)
        {
            frmSaleReport = new frmSaleReports();
            frmSaleReport.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmSaleReport.ReportType = "Sale";
                frmSaleReport.Show();
            }
            else if (CheckModuleRights(frmSaleReport.Name) != Guid.Empty)
            {
                frmSaleReport.ReportType = "Sale";
                frmSaleReport.Show();
            }
            else
            {
                frmSaleReport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnPurchaseReport_Click(object sender, EventArgs e)
        {
            frmSaleReport = new frmSaleReports();
            frmSaleReport.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmSaleReport.ReportType = "Purchase";
                frmSaleReport.Show();
            }
            else if (CheckModuleRights(frmSaleReport.Name) != Guid.Empty)
            {
                frmSaleReport.ReportType = "Purchase";
                frmSaleReport.Show();
            }
            else
            {
                frmSaleReport.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void rbnBtnPersons_Click(object sender, EventArgs e)
        {
            frmPerson = new frmPersons();
            frmPerson.PersonsType = "Employees";
            frmPerson.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmPerson.Show();
            }
            else if (CheckModuleRights(frmPerson.Name) != Guid.Empty)
            {
                frmPerson.Show();
            }
            else
            {
                frmPerson.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnItems_Click(object sender, EventArgs e)
        {
            //frmstockitems = new frmStockItems();
            //frmstockitems.MdiParent = this;
            //if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            //{
            //    frmstockitems.Show();
            //}
            //else if (CheckModuleRights(frmstockitems.Name) != Guid.Empty)
            //{
            //    frmstockitems.Show();
            //}
            //else
            //{
            //    frmstockitems.Dispose();
            //    MessageBox.Show("Access Is Denied");
            //}

            frmProduct = new frmProducts();
            frmProduct.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmProduct.Show();
            }
            else if (CheckModuleRights(frmProduct.Name) != Guid.Empty)
            {
                frmProduct.Show();
            }
            else
            {
                frmProduct.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnCompanies_Click(object sender, EventArgs e)
        {
            frmCompanies = new frmCompany();
            frmCompanies.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmCompanies.Show();
            }
            else if (CheckModuleRights(frmCompanies.Name) != Guid.Empty)
            {
                frmCompanies.Show();
            }
            else
            {
                frmCompanies.Dispose();
                MessageBox.Show("Access Is Denied");
            }
            //MessageBox.Show("Access Is Denied");
        }

        private void rbnBtnModules_Click(object sender, EventArgs e)
        {
            frmModuleRights = new frmModulesRights();
            frmModuleRights.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmModuleRights.Show();
            }
            else if (CheckModuleRights(frmModuleRights.Name) != Guid.Empty)
            {
                frmModuleRights.Show();
            }
            else
            {
                frmModuleRights.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnPermissions_Click(object sender, EventArgs e)
        {
            frmModulesPermission = new frmModulesPermissions();
            frmModulesPermission.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmModulesPermission.Show();
            }
            else if (CheckModuleRights(frmModulesPermission.Name) != Guid.Empty)
            {
                frmModulesPermission.Show();
            }
            else
            {
                frmModulesPermission.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnPassword_Click(object sender, EventArgs e)
        {
            frmchangePassword = new frmChangePassword();
            frmchangePassword.MdiParent = this;
            frmchangePassword.Show();
        }
        private Guid CheckModuleRights(string FormName)
        {
            var Manager = new UserModulesBLL();
            List<UserModulesEL> list = manager.GetUserModuleRightsByIdAndForm(Operations.UserID, FormName);
            if (list.Count > 0)
            {
                UserPermissions.IdModule = list[0].IdModule;
                return list[0].IdModule;
            }
            else
            {
                UserPermissions.IdModule = Guid.Empty;
                return Guid.Empty;
            }
        }

        private void rbnBtnUserRoles_Click(object sender, EventArgs e)
        {
            frmuserRoles = new frmUsersRoles();
            frmuserRoles.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmuserRoles.Show();
            }
            else if (CheckModuleRights(frmuserRoles.Name) != Guid.Empty)
            {
                frmuserRoles.Show();
            }
            else
            {
                frmuserRoles.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnSalesManHistory_Click(object sender, EventArgs e)
        {
            frmsaleManLedger = new frmSalesManLedger();
            frmsaleManLedger.MdiParent = this;
            frmsaleManLedger.Show();
        }

        private void rbnBtnOpeningBalances_Click(object sender, EventArgs e)
        {
            frmopeningbalance = new frmOpeningBalance();
            frmopeningbalance.MdiParent = this;
            frmopeningbalance.Show();

        }

        private void rbnBtnViewOpening_Click(object sender, EventArgs e)
        {
            frmOpeningType = new frmOpeningBalancesByType();
            frmOpeningType.MdiParent = this;
            frmOpeningType.Show();
        }

        private void rbnBtnHeads_Click(object sender, EventArgs e)
        {
            frmheadsSetup = new frmHeadsSetup();
            frmheadsSetup.MdiParent = this;
            frmheadsSetup.Show();
        }
        private void rbnBtnSample_Click(object sender, EventArgs e)
        {
            frmSample = new frmSamples();
            frmSample.MdiParent = this;
            frmSample.Show();
        }

        private void rbnBtnSamplesReturn_Click(object sender, EventArgs e)
        {
            frmSampleReturn = new frmSamplesReturn();
            frmSampleReturn.MdiParent = this;
            frmSampleReturn.Show();
        }

        private void rbnBtnCategory_Click(object sender, EventArgs e)
        {
            frmcategories = new frmCategories();
            frmcategories.MdiParent = this;
            frmcategories.Show();
        }

        private void rbnBtnSampleReport_Click(object sender, EventArgs e)
        {
            frmsampleReports = new frmSampleReports();
            frmsampleReports.MdiParent = this;
            frmsampleReports.Show();
        }

        private void rbnBtnRecover_Click(object sender, EventArgs e)
        {
            frmrecoveryReport = new frmRecoveryReport();
            frmrecoveryReport.MdiParent = this;
            frmrecoveryReport.Show();
        }

        private void rbnBtnMiniTrial_Click(object sender, EventArgs e)
        {
            frmminitrialbalance = new frmMiniTrialBalance();
            frmminitrialbalance.MdiParent = this;
            frmminitrialbalance.Show();
        }
        private void rbnBtnDetailTrial_Click(object sender, EventArgs e)
        {
            frmtrialbalance = new frmTrialBalance();
            frmtrialbalance.MdiParent = this;
            frmtrialbalance.Show();
        }

        private void rbnBtnAlerts_Click(object sender, EventArgs e)
        {
            frmsamplesaledays = new frmSampleSaleDays();
            frmsamplesaledays.MdiParent = this;
            frmsamplesaledays.Show();
        }
        private void rbnBtnSaleReturn_Click(object sender, EventArgs e)
        {

        }
        private void rbnBtnClaimReturn_Click(object sender, EventArgs e)
        {
            frmmonthlyClaimReturn = new frmMonthlyClaimReport();
            frmmonthlyClaimReturn.MdiParent = this;
            frmmonthlyClaimReturn.Show();
        }

        private void rbnBtnMonthlySalesReport_Click(object sender, EventArgs e)
        {
            frmmonthlySaleReport = new frmMonthlySalesReport();
            frmmonthlySaleReport.MdiParent = this;
            frmmonthlySaleReport.Show();
        }

        private void rbnBtnSale_Click(object sender, EventArgs e)
        {

        }
        frmTradingCo frmtradingCo = null;
        private void rbnBtnTradingCo_Click(object sender, EventArgs e)
        {
            frmtradingCo = new frmTradingCo();
            frmtradingCo.MdiParent = this;
            frmtradingCo.Show();
        }
        frmMonthlySalesReport frmmonthlySalesReport = null;
        private void rbnBtnMonthlySale_Click(object sender, EventArgs e)
        {
            frmmonthlySalesReport = new frmMonthlySalesReport();
            frmmonthlySalesReport.MdiParent = this;
            frmmonthlySalesReport.Show();
        }

        private void rbnBtnCustomers_Click(object sender, EventArgs e)
        {
            frmPerson = new frmPersons();
            frmPerson.PersonsType = "Persons";
            frmPerson.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmPerson.Show();
            }
            else if (CheckModuleRights(frmPerson.Name) != Guid.Empty)
            {
                frmPerson.Show();
            }
            else
            {
                frmPerson.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        private void rbnBtnOpeningStock_Click(object sender, EventArgs e)
        {
            frmcurrentStock = new frmCurrentStock();
            frmcurrentStock.MdiParent = this;
            frmcurrentStock.Show();
        }

        private void rbnBtnCompany_Click(object sender, EventArgs e)
        {
            frmCompanies = new frmCompany();
            frmCompanies.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmCompanies.Show();
            }
            else if (CheckModuleRights(frmCompanies.Name) != Guid.Empty)
            {
                frmCompanies.Show();
            }
            else
            {
                frmCompanies.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }       
        frmGarmentOrders frmgarmentorders;
        private void rbnBtnGarmentOrders_Click(object sender, EventArgs e)
        {
            frmgarmentorders = new frmGarmentOrders();
            frmgarmentorders.MdiParent = this;
            frmgarmentorders.Show();
        }
        //frmGarmentProduction frmgarmentProduction;
        private void rbnBtnGarmentProduction_Click(object sender, EventArgs e)
        {
            //frmgarmentProduction = new frmGarmentProduction();
            //frmgarmentProduction.MdiParent = this;
            //frmgarmentProduction.Show();
        }
        //frmGlovesProduction frmglovesProduction;
        private void rbnBtnGlovesProduction_Click(object sender, EventArgs e)
        {
            //frmglovesProduction = new frmGlovesProduction();
           //frmglovesProduction.MdiParent = this;
            //frmglovesProduction.Show();
        }

        private void rbnBtnOrders_Click(object sender, EventArgs e)
        {
            frmOrder frmorder = new frmOrder();
            frmorder.MdiParent = this;
            frmorder.Show();
        }        
        frmMainTannery frmmaintannery;
        private void rbnBtnTanneryProduction_Click(object sender, EventArgs e)
        {
            frmmaintannery = new frmMainTannery();
            frmmaintannery.MdiParent = this;
            frmmaintannery.Show();
        }
        frmVehicleLots frmvehicleLots;
        private void rbnBtnTanneryVehicleLotsReports_Click(object sender, EventArgs e)
        {
            frmvehicleLots = new frmVehicleLots();
            frmvehicleLots.MdiParent = this;
            frmvehicleLots.Show();
        }
        frmTanneryWorkerReport frmtanneryworkerReport;
        private void rbnBtnTanneryWorkerReport_Click(object sender, EventArgs e)
        {
            frmtanneryworkerReport = new frmTanneryWorkerReport();
            frmtanneryworkerReport.MdiParent = this;
            frmtanneryworkerReport.Show();
        }
        frmProductionWages frmproductionwages;
        private void rbnBtnProductionWages_Click(object sender, EventArgs e)
        {
            frmproductionwages = new frmProductionWages();
            frmproductionwages.MdiParent = this;
            frmproductionwages.Show();
        }
        frmPrintLots frmprintlots = null;
        private void rbnBtnTanneryLotsByStatus_Click(object sender, EventArgs e)
        {
            frmprintlots = new frmPrintLots();
            frmprintlots.MdiParent = this;
            frmprintlots.Show();
        }

        private void rbnBtnPurchases_Click(object sender, EventArgs e)
        {
            frmstockreceipt = new frmStockReceipt();
            frmstockreceipt.MdiParent = this;
            frmstockreceipt.IsImport = false;
            frmstockreceipt.PurchaseType = "Vehical";
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmstockreceipt.Show();
            }
            else if (CheckModuleRights(frmstockreceipt.Name) != Guid.Empty)
            {
                frmstockreceipt.Show();
            }
            else
            {
                frmstockreceipt.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }

        private void rbnBtnPurchases_Click_1(object sender, EventArgs e)
        {

        }
        frmVehicleStockComparison frmstockcomparison = null;
        private void rbnBtnTanneryVehicleWiseStock_Click(object sender, EventArgs e)
        {
            frmstockcomparison = new frmVehicleStockComparison();
            frmstockcomparison.MdiParent = this;
            frmstockcomparison.Show();
        }
        frmBrandSetup frmbrandsetup;
        private void rbnBtnBrandSetup_Click(object sender, EventArgs e)
        {
            frmbrandsetup = new frmBrandSetup();
            frmbrandsetup.MdiParent = this;
            frmbrandsetup.Show();
        }
        frmTanneryQualityStock frmtanneryqualitystock = null;
        private void rbnBtnTanneryCuttingStockReport_Click(object sender, EventArgs e)
        {
            frmtanneryqualitystock = new frmTanneryQualityStock();
            frmtanneryqualitystock.MdiParent = this;
            frmtanneryqualitystock.Show();
        }
        frmPurchaseOrder frmpurchaseorder = null;
        private void rbnBtnPurchasesOrder_Click(object sender, EventArgs e)
        {
            frmpurchaseorder = new frmPurchaseOrder();
            frmpurchaseorder.MdiParent = this;
            frmpurchaseorder.Show();
        }

        private void rbnBtnRubberizing_Click(object sender, EventArgs e)
        {
            frmclotheprocess = new frmClotheProcess();
            frmclotheprocess.MdiParent = this;
            frmclotheprocess.IssuanceType = 1;
            frmclotheprocess.Show();
        }
        private void rbnBtnRubberizingIn_Click(object sender, EventArgs e)
        {
            frmclotheprocess = new frmClotheProcess();
            frmclotheprocess.MdiParent = this;
            frmclotheprocess.IssuanceType = 2;
            frmclotheprocess.Show();
        }
        private void rbnBtnPartyWiseRubberizing_Click(object sender, EventArgs e)
        {
            frmpartyrubberingstock = new frmPartyRubberingStock();
            frmpartyrubberingstock.MdiParent = this;
            frmpartyrubberingstock.Show();
        }
        frmProductRubberingStock frmproductrubberingstock;
        private void rbnBtnItemWiseRubberizingReport_Click(object sender, EventArgs e)
        {
            frmproductrubberingstock = new frmProductRubberingStock();
            frmproductrubberingstock.MdiParent = this;
            frmproductrubberingstock.Show();
        }

        private void rbnBtnOutGatePass_Click(object sender, EventArgs e)
        {
            frmStockIssuance issuance = new frmStockIssuance();
            issuance.IsOut = true;
            issuance.GPType = 1;
            issuance.MdiParent = this;
            issuance.Show();
        }

        private void rbnBtnInGatePass_Click(object sender, EventArgs e)
        {
            frmStockIssuance issuance = new frmStockIssuance();
            issuance.IsOut = false;
            issuance.GPType = 1;
            issuance.MdiParent = this;
            issuance.Show();
        }
        frmPackingInspection frmpackingInspection;
        private void rbnBtnInspectionDropDown_Click(object sender, EventArgs e)
        {
            frmpackingInspection = new frmPackingInspection();
            frmpackingInspection.ProductionType = 1;
            frmpackingInspection.WorkType = 1;
            frmpackingInspection.MdiParent = this;
            frmpackingInspection.Show();
        }
        private void rbnBtnGarmentInspection_Click(object sender, EventArgs e)
        {
            frmpackingInspection = new frmPackingInspection();
            frmpackingInspection.ProductionType = 2;
            frmpackingInspection.WorkType = 1;
            frmpackingInspection.MdiParent = this;
            frmpackingInspection.Show();
        }
        private void rbnBtnPackingDropDown_Click(object sender, EventArgs e)
        {
            frmpackingInspection = new frmPackingInspection();
            frmpackingInspection.ProductionType = 1;
            frmpackingInspection.WorkType = 2;
            frmpackingInspection.MdiParent = this;
            frmpackingInspection.Show();
        }
        private void rbnBtnGarmentPacking_Click(object sender, EventArgs e)
        {
            frmpackingInspection = new frmPackingInspection();
            frmpackingInspection.ProductionType = 2;
            frmpackingInspection.WorkType = 2;
            frmpackingInspection.MdiParent = this;
            frmpackingInspection.Show();
        }
        frmPackingInspectionReport frmpackingInspectionReport;

        private void rbnBtnGlovesStockInspectionReports_Click(object sender, EventArgs e)
        {
            frmpackingInspectionReport = new frmPackingInspectionReport();
            frmpackingInspectionReport.ProductionType = 1;
            frmpackingInspectionReport.WorkType = 1;
            frmpackingInspectionReport.SummaryType = "";
            frmpackingInspectionReport.MdiParent = this;
            frmpackingInspectionReport.Show();
        }
        frmPackingInspectionWorkerFinancialReport frminspectionpackingfinancialReport;
        private void rbnBtnGlovesWorkerInspectionFinancialReport_Click(object sender, EventArgs e)
        {
            frminspectionpackingfinancialReport = new frmPackingInspectionWorkerFinancialReport();
            frminspectionpackingfinancialReport.ProductionType = 1;
            frminspectionpackingfinancialReport.WorkType = 1;
            frminspectionpackingfinancialReport.SummaryType = "";
            frminspectionpackingfinancialReport.MdiParent = this;
            frminspectionpackingfinancialReport.Show();
        }

        private void rbnBtnPackingManFinancialReport_Click(object sender, EventArgs e)
        {
            frminspectionpackingfinancialReport = new frmPackingInspectionWorkerFinancialReport();
            frminspectionpackingfinancialReport.ProductionType = 1;
            frminspectionpackingfinancialReport.WorkType = 2;
            frminspectionpackingfinancialReport.SummaryType = "";
            frminspectionpackingfinancialReport.MdiParent = this;
            frminspectionpackingfinancialReport.Show();
        }
        private void rbnBtnStitcherStockPerformanceReport_Click(object sender, EventArgs e)
        {
            frmpackingInspectionReport = new frmPackingInspectionReport();
            frmpackingInspectionReport.ProductionType = 1;
            frmpackingInspectionReport.WorkType = 1;
            frmpackingInspectionReport.SummaryType = "Stitcher";
            frmpackingInspectionReport.MdiParent = this;
            frmpackingInspectionReport.Show();
        }

        private void rbnBtnStitcherFinancialReport_Click(object sender, EventArgs e)
        {
            frminspectionpackingfinancialReport = new frmPackingInspectionWorkerFinancialReport();
            frminspectionpackingfinancialReport.ProductionType = 1;
            frminspectionpackingfinancialReport.WorkType = 1;
            frminspectionpackingfinancialReport.SummaryType = "Stitcher";
            frminspectionpackingfinancialReport.MdiParent = this;
            frminspectionpackingfinancialReport.Show();
        } 

        private void rbnBtnGlovesPackingWorkerReport_Click(object sender, EventArgs e)
        {
            
        }
        frmGlovesProcessWiseReport frmglovesprocesswisereport;
        private void rbnBtnGlovesProcessesReports_Click(object sender, EventArgs e)
        {
            frmglovesprocesswisereport = new frmGlovesProcessWiseReport();
            frmglovesprocesswisereport.ProductionType = 1;
            frmglovesprocesswisereport.MdiParent = this;
            frmglovesprocesswisereport.Show();
        }
        frmTanneryGenerateLotNo frmtannerycustomlot;
        private void rbnBtnCreateSelfLot_Click(object sender, EventArgs e)
        {
            frmtannerycustomlot = new frmTanneryGenerateLotNo();
            frmtannerycustomlot.MdiParent = this;
            frmtannerycustomlot.Show();
        }
        private void rbnBtnTanneryStock_Click(object sender, EventArgs e)
        {
            frmtotalStock = new frmTotalStock();
            frmtotalStock.StockType = "Tannery";
            frmtotalStock.BossCategory = 1;
            frmtotalStock.MdiParent = this;
            frmtotalStock.Show();
        }
        private void rbnBtnGlovesStock_Click(object sender, EventArgs e)
        {
            frmtotalStock = new frmTotalStock();
            frmtotalStock.StockType = "Gloves";
            frmtotalStock.BossCategory = 2;
            frmtotalStock.Show();
        }
        private void rbnBtnGarmentStock_Click(object sender, EventArgs e)
        {
            frmtotalStock = new frmTotalStock();
            frmtotalStock.StockType = "Garments";
            frmtotalStock.BossCategory = 3;
            frmtotalStock.Show();
        }
        frmStitcherCrossTabInfo frmstitchercrosstabinfo;
        private void rbnBtnStitcherCrossTabInfo_Click(object sender, EventArgs e)
        {
            frmstitchercrosstabinfo = new frmStitcherCrossTabInfo();
            frmstitchercrosstabinfo.MdiParent = this;
            frmstitchercrosstabinfo.Show();
        }
        frmWorkInProcessReport frmworkinprocess;
        private void rbnBtnGlovesWorkInProcess_Click(object sender, EventArgs e)
        {
            frmworkinprocess = new frmWorkInProcessReport();
            frmworkinprocess.ProductionType = 1;
            frmworkinprocess.MdiParent = this;
            frmworkinprocess.Show();
        }
        frmArticleStock frmarticlestock;
        private void rbnBtnGlovesArticleStock_Click(object sender, EventArgs e)
        {
            frmarticlestock = new frmArticleStock();
            frmarticlestock.ProductionType = 1;
            frmarticlestock.MdiParent = this;
            frmarticlestock.Show();
        }
        private void rbnBtnPakcingManPerformanceReport_Click(object sender, EventArgs e)
        {
            frmpackingInspectionReport = new frmPackingInspectionReport();
            frmpackingInspectionReport.ProductionType = 1;
            frmpackingInspectionReport.WorkType = 2;
            frmpackingInspectionReport.SummaryType = "";
            frmpackingInspectionReport.MdiParent = this;
            frmpackingInspectionReport.Show();
        }

        private void rbnBtnGarmentsInspectionWorkerReport_Click(object sender, EventArgs e)
        {
            frmpackingInspectionReport = new frmPackingInspectionReport();
            frmpackingInspectionReport.ProductionType = 2;
            frmpackingInspectionReport.WorkType = 1;
            frmpackingInspectionReport.SummaryType = "";
            frmpackingInspectionReport.MdiParent = this;
            frmpackingInspectionReport.Show();
        }

        private void rbnBtnGarmentsInspectionWorkerFinancialReport_Click(object sender, EventArgs e)
        {
            frminspectionpackingfinancialReport = new frmPackingInspectionWorkerFinancialReport();
            frminspectionpackingfinancialReport.ProductionType = 2;
            frminspectionpackingfinancialReport.WorkType = 1;
            frminspectionpackingfinancialReport.SummaryType = "";
            frminspectionpackingfinancialReport.MdiParent = this;
            frminspectionpackingfinancialReport.Show();
        }

        private void rbnBtnGarmentsPackingManPerformanceReport_Click(object sender, EventArgs e)
        {
            frmpackingInspectionReport = new frmPackingInspectionReport();
            frmpackingInspectionReport.ProductionType = 2;
            frmpackingInspectionReport.WorkType = 2;
            frmpackingInspectionReport.SummaryType = "";
            frmpackingInspectionReport.MdiParent = this;
            frmpackingInspectionReport.Show();
        }

        private void rbnBtnGarmentsPackingManFinancialReport_Click(object sender, EventArgs e)
        {
            frminspectionpackingfinancialReport = new frmPackingInspectionWorkerFinancialReport();
            frminspectionpackingfinancialReport.ProductionType = 2;
            frminspectionpackingfinancialReport.WorkType = 2;
            frminspectionpackingfinancialReport.SummaryType = "";
            frminspectionpackingfinancialReport.MdiParent = this;
            frminspectionpackingfinancialReport.Show();
        }

        private void rbnBtnGarmentStitchingManPerformanceReport_Click(object sender, EventArgs e)
        {
            frmpackingInspectionReport = new frmPackingInspectionReport();
            frmpackingInspectionReport.ProductionType = 2;
            frmpackingInspectionReport.WorkType = 1;
            frmpackingInspectionReport.SummaryType = "Stitcher";
            frmpackingInspectionReport.MdiParent = this;
            frmpackingInspectionReport.Show();
        }

        private void rbnBtnGarmentStitchingManFinancialReport_Click(object sender, EventArgs e)
        {
            frminspectionpackingfinancialReport = new frmPackingInspectionWorkerFinancialReport();
            frminspectionpackingfinancialReport.ProductionType = 2;
            frminspectionpackingfinancialReport.WorkType = 1;
            frminspectionpackingfinancialReport.SummaryType = "Stitcher";
            frminspectionpackingfinancialReport.MdiParent = this;
            frminspectionpackingfinancialReport.Show();
        }

        private void rbnBtnGarmentsOutGatePass_Click(object sender, EventArgs e)
        {
            frmStockIssuance issuance = new frmStockIssuance();
            issuance.IsOut = true;
            issuance.GPType = 2;
            issuance.MdiParent = this;
            issuance.Show();
        }

        private void rbnBtnGarmentsInGatePass_Click(object sender, EventArgs e)
        {
            frmStockIssuance issuance = new frmStockIssuance();
            issuance.IsOut = false;
            issuance.GPType = 2;
            issuance.MdiParent = this;
            issuance.Show();
        }

        private void rbnBtnGarmentsSticherWorkInProcess_Click(object sender, EventArgs e)
        {
            frmworkinprocess = new frmWorkInProcessReport();
            frmworkinprocess.ProductionType = 2;
            frmworkinprocess.MdiParent = this;
            frmworkinprocess.Show();
        }

        private void rbnBtnGarmentsArticleStock_Click(object sender, EventArgs e)
        {
            frmarticlestock = new frmArticleStock();
            frmarticlestock.ProductionType = 2;
            frmarticlestock.MdiParent = this;
            frmarticlestock.Show();
        }
        frmBasicGlovesGarmentsWorkerFinancialReport frmbasicglovesgarmentsworkerfinancialreport;
        private void rbnBtnGlovesWorkerFinancialReport_Click(object sender, EventArgs e)
        {
            frmbasicglovesgarmentsworkerfinancialreport = new frmBasicGlovesGarmentsWorkerFinancialReport();
            frmbasicglovesgarmentsworkerfinancialreport.MdiParent = this;
            frmbasicglovesgarmentsworkerfinancialreport.GPType = 1;
            frmbasicglovesgarmentsworkerfinancialreport.Show();
        }
        frmReadyToInspectionStock frmreadystock;
        private void rbnBtnGlovesReadyToInpsectionStock_Click(object sender, EventArgs e)
        {
            frmreadystock = new frmReadyToInspectionStock();
            frmreadystock.MdiParent = this;
            frmreadystock.ProductionType = 1;
            frmreadystock.TabType = 1;
            frmreadystock.Show();
        }

        private void rbnBtnGlovesReadyToPackStock_Click(object sender, EventArgs e)
        {
            frmreadystock = new frmReadyToInspectionStock();
            frmreadystock.MdiParent = this;
            frmreadystock.ProductionType = 1;
            frmreadystock.TabType = 2;
            frmreadystock.Show();
        }

        private void rbnBtnGarmentsReadyForInspectionReport_Click(object sender, EventArgs e)
        {
            frmreadystock = new frmReadyToInspectionStock();
            frmreadystock.MdiParent = this;
            frmreadystock.ProductionType = 2;
            frmreadystock.TabType = 1;
            frmreadystock.Show();
        }

        private void rbnBtnGarmentsReadyForPackingReport_Click(object sender, EventArgs e)
        {
            frmreadystock = new frmReadyToInspectionStock();
            frmreadystock.MdiParent = this;
            frmreadystock.ProductionType = 2;
            frmreadystock.TabType = 2;
            frmreadystock.Show();
        }
        frmRepairStockReport frmRepairStock;
        private void rbnBtnGlovesRepairStock_Click(object sender, EventArgs e)
        {
            frmRepairStock = new frmRepairStockReport();
            frmRepairStock.MdiParent = this;
            frmRepairStock.ProductionType = 1;
            frmRepairStock.TabType = 1;
            frmRepairStock.Show();
        }
        frmRejectionStockReport frmrejectionstockreport;
        private void rbnBtnGlovesRejectionStockReport_Click(object sender, EventArgs e)
        {
            frmrejectionstockreport = new frmRejectionStockReport();
            frmrejectionstockreport.MdiParent = this;
            frmrejectionstockreport.ProductionType = 1;
            frmrejectionstockreport.Show();
        }

        private void rbnBtnGarmentsRejectionStockReport_Click(object sender, EventArgs e)
        {
            frmrejectionstockreport = new frmRejectionStockReport();
            frmrejectionstockreport.MdiParent = this;
            frmrejectionstockreport.ProductionType = 2;
            frmrejectionstockreport.Show();
        }
        frmTotalCartonsStockReport frmtotalcartons;
        private void rbnBtnGlovesTotalCartonsStock_Click(object sender, EventArgs e)
        {
            frmtotalcartons = new frmTotalCartonsStockReport();
            frmtotalcartons.MdiParent = this;
            frmtotalcartons.ProductionType = 1;
            frmtotalcartons.Show();
        }

        private void rbnBtnGarmentsTotalCartonStockReport_Click(object sender, EventArgs e)
        {
            frmtotalcartons = new frmTotalCartonsStockReport();
            frmtotalcartons.MdiParent = this;
            frmtotalcartons.ProductionType = 2;
            frmtotalcartons.Show();
        }
        frmStitcherWiseRepairReport frmstitcherwiserepair;
        private void rbnBtnStitcherWiseRepairStockReport_Click(object sender, EventArgs e)
        {
            frmstitcherwiserepair = new frmStitcherWiseRepairReport();
            frmstitcherwiserepair.MdiParent = this;
            frmstitcherwiserepair.ProductionType = 1;
            frmstitcherwiserepair.Show();
        }
        frmProcessWiseStock frmprocessstock;
        private void rbnBtnGlovesProcessWiseStock_Click(object sender, EventArgs e)
        {
            frmprocessstock = new frmProcessWiseStock();
            frmprocessstock.MdiParent = this;
            frmprocessstock.ProductionType = 1;
            frmprocessstock.Show();
        }

        private void rbnBtnPurchasesReturn_Click(object sender, EventArgs e)
        {
            frmstockReturn = new frmStockReturn();
            frmstockReturn.MdiParent = this;
            frmstockReturn.IsImport = false;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmstockReturn.Show();
            }
            else if (CheckModuleRights(frmstockReturn.Name) != Guid.Empty)
            {
                frmstockReturn.Show();
            }
            else
            {
                frmstockReturn.Dispose();
                MessageBox.Show("Access Is Denied");
            }

        }
        frmDayBook frmdaybook;
        private void rbnBtnDayBook_Click(object sender, EventArgs e)
        {
            frmdaybook = new frmDayBook();
            frmdaybook.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive))
            {
                frmdaybook.Show();
            }
            //else if (CheckModuleRights(frmdaybook.Name) != Guid.Empty)
            //{
            //    frmstockReturn.Show();
            //}
            else
            {
                frmdaybook.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        frmVehicleProfitLoss frmvehicleprofitloss;
        private void rbnBtnSingleVehicleProfitAndLoss_Click(object sender, EventArgs e)
        {
            frmvehicleprofitloss = new frmVehicleProfitLoss();
            frmvehicleprofitloss.MdiParent = this;
            frmvehicleprofitloss.Show();
        }
        frmAllVehiclesProfitLoss frmallvehicleprofitloss;
        private void rbnBtnAllVehiclesProfitAndLoss_Click(object sender, EventArgs e)
        {
            frmallvehicleprofitloss = new frmAllVehiclesProfitLoss();
            frmallvehicleprofitloss.MdiParent = this;
            ///if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive))
            {
                frmallvehicleprofitloss.Show();
            }
            //else
            {
                //frmallvehicleprofitloss.Dispose();
               // MessageBox.Show("Access Is Denied");
            }
        }

        frmTannaryProcesses frmtannaryprocess = null;
        private void rbnBtnDepartments_Click(object sender, EventArgs e)
        {
            frmtannaryprocess = new frmTannaryProcesses();
            frmtannaryprocess.MdiParent = this;
            frmtannaryprocess.Show();
        }

        private void rbnBtnSales_Click(object sender, EventArgs e)
        {
            frmsales = new frmSales();
            frmsales.MdiParent = this;
            frmsales.IsImport = false;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmsales.Show();
            }
            else if (CheckModuleRights(frmsales.Name) != Guid.Empty)
            {
                frmsales.Show();
            }
            else
            {
                frmsales.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        frmWorkerFinancialAndWorkComparisonReport frmworkerfinancialcomparisonreport;
        private void rbnBtnWorkerFinancialComparisonReport_Click(object sender, EventArgs e)
        {
            frmworkerfinancialcomparisonreport = new frmWorkerFinancialAndWorkComparisonReport();
            frmworkerfinancialcomparisonreport.MdiParent = this;
            frmworkerfinancialcomparisonreport.Show();
        }
        frmDepartmentFinancialAndWorkComparisonReport frmdepartmentfinancereport;
        private void rbnBtnDepartmentFinancialComparisonReport_Click(object sender, EventArgs e)
        {
            frmdepartmentfinancereport = new frmDepartmentFinancialAndWorkComparisonReport();
            frmdepartmentfinancereport.MdiParent = this;
            frmdepartmentfinancereport.Show();
        }
        frmTanneryBusinessFinanceAnalysis frmtannerybusinessfinanceanalysis;
        private void rbnBtnTanneryBusinessFinanceAnalysisReport_Click(object sender, EventArgs e)
        {
            frmtannerybusinessfinanceanalysis = new frmTanneryBusinessFinanceAnalysis();
            frmtannerybusinessfinanceanalysis.MdiParent = this;
            frmtannerybusinessfinanceanalysis.Show();
        }
        frmTanneryBusinessWorkFinanceAnalysis frmtannerybusinessworkfinanceanalysis;
        private void rbnBtnTanneryBusinessWorkFinanceReport_Click(object sender, EventArgs e)
        {
            frmtannerybusinessworkfinanceanalysis = new frmTanneryBusinessWorkFinanceAnalysis();
            frmtannerybusinessworkfinanceanalysis.MdiParent = this;
            frmtannerybusinessworkfinanceanalysis.Show();
        }

        private void rbnBtnSalesReturn_Click(object sender, EventArgs e)
        {
            frmSaleReturn = new frmSalesReturn();
            frmSaleReturn.MdiParent = this;
            frmSaleReturn.IsImport = false;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmSaleReturn.Show();
            }
            else if (CheckModuleRights(frmSaleReturn.Name) != Guid.Empty)
            {
                frmSaleReturn.Show();
            }
            else
            {
                frmSaleReturn.Dispose();
                MessageBox.Show("Access Is Denied");
            }
        }
        frmBalanceSheet frmbalanacesheet;
        private void rbnBtnBalanceSheet_Click(object sender, EventArgs e)
        {
            frmbalanacesheet = new frmBalanceSheet();
            frmbalanacesheet.MdiParent = this;
            frmbalanacesheet.Show();
        }
        frmArticleSaleReports frmarticlereports;
        private void rbnBtnArticlesSaleReport_Click(object sender, EventArgs e)
        {
            frmarticlereports = new frmArticleSaleReports();
            frmarticlereports.MdiParent = this;
            frmarticlereports.Show();
        }
        frmWorkergeneralLedger frmworkerledger = null;
        private void rbnBtnTanneryWorkerLedger_Click(object sender, EventArgs e)
        {
            frmworkerledger = new frmWorkergeneralLedger();
            frmworkerledger.MdiParent = this;
            frmworkerledger.Show();
        }
        frmLotsFilters frmlotfilters;
        private void rbnBtnTanneryLotsFilter_Click(object sender, EventArgs e)
        {
            frmlotfilters = new frmLotsFilters();
            frmlotfilters.MdiParent = this;
            frmlotfilters.Show();
        }
        frmTanneryLotsByChemical frmtannerylotsbychecmical;
        private void rbnBtnTanneryLotsByChemical_Click(object sender, EventArgs e)
        {
            frmtannerylotsbychecmical = new frmTanneryLotsByChemical();
            frmtannerylotsbychecmical.MdiParent = this;
            frmtannerylotsbychecmical.Show();
        }
        
        frmInventoryIssuance frminventoryissuance;
        private void rbnBtnGeneralGatePass_Click(object sender, EventArgs e)
        {
            frminventoryissuance = new frmInventoryIssuance();
            frminventoryissuance.MdiParent = this;
            frminventoryissuance.Show();
        }
        frmGatePassReports frmgatepassreports;
        private void rbnBtnGeneralGatePasReport_Click(object sender, EventArgs e)
        {
            frmgatepassreports = new frmGatePassReports();
            frmgatepassreports.MdiParent = this;
            frmgatepassreports.Show();
        }
        frmUserActivityReport frmuseractivitylogger;
        private void rbnBtnActivityLogger_Click(object sender, EventArgs e)
        {
            frmuseractivitylogger = new frmUserActivityReport();
            frmuseractivitylogger.MdiParent = this;
            if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
            {
                frmuseractivitylogger.Show();
            }
            else if (CheckModuleRights(frmusers.Name) != Guid.Empty)
            {
                frmuseractivitylogger.Show();
            }
            else
            {
                frmuseractivitylogger.Dispose();
                MessageBox.Show("Access Is Denied");
            }           
            
        }      
        //private string GetNonNullableUserRoleNames()
        //{
        //    string RoleName = "";
        //    var manager = new UserRolesBLL();
        //    List<UserRolesEL> list = manager.GetUserRolesById(Operations.UserID);
        //    if (list.Count > 0)
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            if (list[i].IdUserRole != Guid.Empty)
        //            {
        //                RoleName = list[i].RoleName;
        //            }
        //        }
        //    }
        //    return RoleName;
        //}
    }
}
