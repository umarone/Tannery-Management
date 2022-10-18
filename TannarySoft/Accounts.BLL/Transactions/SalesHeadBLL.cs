using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;

namespace Accounts.BLL
{
    public class SalesHeadBLL
    {
        SalesHeadDAL dal;
        public SalesHeadBLL()
        {
            dal = new SalesHeadDAL();
        }
        //public bool InsertSales(VouchersEL oelVoucher, List<SaleDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelStockReceiptCollection)
        public bool InsertSales(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<VoucherDetailEL> oelSalesTransactionsCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                //return dal.InsertSales(oelVoucher, oelSaleCollection, oelTransactionsCollection, oelStockReceiptCollection, objconn);
                return dal.InsertSales(oelVoucher, oelSaleCollection, oelSalesTransactionsCollection, oelTransactionsCollection, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        //public bool UpdateSales(VouchersEL oelSaleMaster, List<SaleDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelStockReceiptCollection)
        public bool UpdateSales(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<VoucherDetailEL> oelSalesTransactionsCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                //return dal.UpdateSales(oelSaleMaster, oelSaleCollection, oelTransactionsCollection, oelStockReceiptCollection, objconn);
                return dal.UpdateSales(oelVoucher, oelSaleCollection, oelSalesTransactionsCollection, oelTransactionsCollection, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public bool UpdateSamplesHeadForSales(Guid? IdVoucher, bool IsSold)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                //return dal.UpdateSales(oelSaleMaster, oelSaleCollection, oelTransactionsCollection, oelStockReceiptCollection, objconn);
                return dal.UpdateSamplesHeadForSales(IdVoucher, IsSold, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        //public bool InsertSalesReturn(VouchersEL oelVoucher, List<SaleDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelStockRecieptCollection)
        public bool InsertSalesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                //return dal.InsertSalesReturn(oelVoucher, oelSaleCollection, oelTransactionsCollection, oelStockRecieptCollection, objconn);
                return dal.InsertSalesReturn(oelVoucher, oelSaleCollection, oelTransactionsCollection, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }    
        }
        //public bool UpdateSalesReturn(VouchersEL oelSaleMaster, List<SaleDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelStockReceiptCollection)
        public bool UpdateSalesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                //return dal.UpdateSalesReturn(oelSaleMaster, oelSaleCollection, oelTransactionsCollection, oelStockReceiptCollection, objconn);
                return dal.UpdateSalesReturn(oelVoucher, oelSaleCollection, oelTransactionsCollection, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public bool DeleteSale(Guid IdVoucher, Int64 VoucherNo, string TransactionType, Guid IdCompany)
        {        
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.DeleteSale(IdVoucher, VoucherNo, TransactionType, IdCompany, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public bool DeleteSalesReturn(Guid IdVoucher, Int64 VoucherNo, string TransactionType, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.DeleteSalesReturn(IdVoucher, VoucherNo, TransactionType, IdCompany, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public bool CheckSales(Guid IdCompany, Int64 VoucherNo)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.CheckSales(IdCompany,VoucherNo, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetSaleDays(Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetSaleDays(IdCompany, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetSaleDaysByDate(Guid IdCompany, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetSaleDaysByDate(IdCompany, StartDate, EndDate, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetSaleDaysByEmployees(Guid IdCompany, string EmpCode)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetSaleDaysByEmployees(IdCompany, EmpCode, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetSaleDaysByEmployeesByDate(Guid IdCompany, string EmpCode, DateTime StartDate, DateTime EndDate)
        {

            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetSaleDaysByEmployeesByDate(IdCompany, EmpCode, StartDate, EndDate, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetDateWiseSalesReport(Guid IdCompany, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetDateWiseSalesReport(IdCompany, StartDate, EndDate, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetDateAndEmployeeWiseSalesReport(Guid IdCompany, string EmpCode, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetDateAndEmployeeWiseSalesReport(IdCompany, EmpCode, StartDate, EndDate, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetDateWiseClaimReturnReport(Guid IdCompany, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetDateWiseClaimReturnReport(IdCompany, StartDate, EndDate, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetClaimedVouchersByAccountNo(Guid IdCompany, string AccountNo)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetClaimedVouchersByAccountNo(IdCompany, AccountNo, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetClaimedVouchersDetail(Guid IdVoucher)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetClaimedVouchersDetail(IdVoucher, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
   }
}
