using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.DAL
{
    public class SalesHeadDAL
    {
        IDataReader objReader;
        SaleDetailDAL dal;
        TransactionsDAL Tdal;
        StockDAL stockdal;
        public SalesHeadDAL()
        {
            dal = new SaleDetailDAL();
            Tdal = new TransactionsDAL();
            stockdal = new StockDAL();
        }
        //public bool InsertSales(VouchersEL oelVoucher, List<SaleDetailEL> oelSaleCollection ,List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelStockReceiptCollection, SqlConnection objConn)
        public bool InsertSales(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<VoucherDetailEL> oelSalesTransactionsCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    //// Insert Sale Voucher
                    SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_CreateSalesHead]", objConn);

                    cmdSales.CommandType = CommandType.StoredProcedure;
                    cmdSales.Transaction = objTran;
                    cmdSales.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSales.Parameters.Add(new SqlParameter("@SampleNo", DbType.Int64)).Value = oelVoucher.SampleNo;
                    cmdSales.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSales.Parameters.Add(new SqlParameter("@Date", DbType.DateTime)).Value = oelVoucher.Date;
                    cmdSales.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdSales.Parameters.Add(new SqlParameter("@MemoSaleNo", DbType.Int64)).Value = oelVoucher.MemoSaleNo;
                    cmdSales.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSales.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelVoucher.VehicalNo;
                    cmdSales.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.Amount;
                    cmdSales.Parameters.Add(new SqlParameter("@VAT", DbType.Decimal)).Value = oelVoucher.VAT;
                    cmdSales.Parameters.Add(new SqlParameter("@VATAmount", DbType.Decimal)).Value = oelVoucher.VATAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@CreditDays", DbType.Int32)).Value = oelVoucher.Transactiondays;
                    cmdSales.Parameters.Add(new SqlParameter("@IsImport", DbType.Boolean)).Value = oelVoucher.IsImport;
                    cmdSales.Parameters.Add(new SqlParameter("@IsRecieved", DbType.Boolean)).Value = oelVoucher.IsRecieved;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@Discount", DbType.Decimal)).Value = oelVoucher.Discount;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@TotalDiscount", DbType.Decimal)).Value = oelVoucher.TotalDiscount;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@NetSale", DbType.Decimal)).Value = oelVoucher.NetSaleAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@Seller", DbType.Int32)).Value = oelVoucher.Seller;
                    cmdSales.Parameters.Add(new SqlParameter("@SaleType", DbType.Int32)).Value = oelVoucher.SaleType;
                    cmdSales.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSales.ExecuteNonQuery();

                    //// Insert Detail Sales In Sale Record
                    dal.InsertSaleDetail(oelSaleCollection, objConn, objTran);

                    //// Insert Sales Transactions
                    dal.InsertSalesTransactionsDetail(oelSalesTransactionsCollection, objConn, objTran);

                    /// Insert Transactions
                    Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);


                    objTran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }   
            }          
        }
        //public bool UpdateSales(VouchersEL oelSaleMaster,List<SaleDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelStockReceiptCollection, SqlConnection objConn)
        public bool UpdateSales(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<VoucherDetailEL> oelSalesTransactionsCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_UpdateSalesHead]", objConn);
                    cmdSales.CommandType = CommandType.StoredProcedure;
                    cmdSales.Transaction = objTran;

                    cmdSales.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSales.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSales.Parameters.Add(new SqlParameter("@Date", DbType.DateTime)).Value = oelVoucher.Date;
                    cmdSales.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdSales.Parameters.Add(new SqlParameter("@MemoSaleNo", DbType.Int64)).Value = oelVoucher.MemoSaleNo;
                    cmdSales.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSales.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelVoucher.VehicalNo;
                    cmdSales.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.Amount;
                    cmdSales.Parameters.Add(new SqlParameter("@VAT", DbType.Decimal)).Value = oelVoucher.VAT;
                    cmdSales.Parameters.Add(new SqlParameter("@VATAmount", DbType.Decimal)).Value = oelVoucher.VATAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@CreditDays", DbType.Int32)).Value = oelVoucher.Transactiondays;
                    cmdSales.Parameters.Add(new SqlParameter("@IsRecieved", DbType.Boolean)).Value = oelVoucher.IsRecieved;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@Discount", DbType.Decimal)).Value = oelSaleMaster.Discount;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@TotalDiscount", DbType.Decimal)).Value = oelSaleMaster.TotalDiscount;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@NetSale", DbType.Decimal)).Value = oelSaleMaster.NetSaleAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@Seller", DbType.Int32)).Value = oelVoucher.Seller;
                    cmdSales.Parameters.Add(new SqlParameter("@SaleType", DbType.Int32)).Value = oelVoucher.SaleType;
                    cmdSales.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSales.ExecuteNonQuery();

                    //// Insert And Update Sales In Sale Record
                    dal.UpdateSaleDetail(oelSaleCollection, objConn, objTran);

                    //// Insert And Update Sales Transactions
                    dal.UpdateSalesTransactionsDetail(oelSalesTransactionsCollection, objConn, objTran);
                    ///
                    Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);


                    objTran.Commit();
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
                finally
                {

                }
                return true;   
            }          
        }
        public bool UpdateSamplesHeadForSales(Guid? IdVoucher, bool IsSold, SqlConnection objConn)
        {
            try
            {
                SqlCommand cmdSample = new SqlCommand("[Transactions].[Proc_UpdateSampleHeadForSale]", objConn);
                cmdSample.CommandType = CommandType.StoredProcedure;
               
                cmdSample.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
                cmdSample.Parameters.Add(new SqlParameter("@IsSold", DbType.Boolean)).Value = IsSold;
                cmdSample.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {

            }
            return true;


        }
        //public bool InsertSalesReturn(VouchersEL oelVoucher, List<SaleDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelStockRecieptCollection, SqlConnection objConn)
        public bool InsertSalesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();

                try
                {
                    //// Insert SalesReturn Voucher
                    SqlCommand cmdSalesReturn = new SqlCommand("[Transactions].[Proc_CreateSalesReturnHead]", objConn);

                    cmdSalesReturn.CommandType = CommandType.StoredProcedure;
                    cmdSalesReturn.Transaction = objTran;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = oelVoucher.AccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@MemoSaleNo", DbType.Int64)).Value = oelVoucher.MemoSaleNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@InWardGatePassNo", DbType.String)).Value = oelVoucher.InWardGatePassNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.Amount;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VAT", DbType.Decimal)).Value = oelVoucher.VAT;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VATAmount", DbType.Decimal)).Value = oelVoucher.VATAmount;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IsImport", DbType.Boolean)).Value = oelVoucher.IsImport;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@ReturnType", DbType.Decimal)).Value = oelVoucher.ReturnType;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSalesReturn.ExecuteNonQuery();

                    //// Insert SalesReturn In SaleReturn Record
                    dal.InsertSalesReturnDetail(oelSaleCollection, objConn, objTran);

                    /// Insert Stock Transactions
                    Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                    objTran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }   
            }         
        }
        //public bool UpdateSalesReturn(VouchersEL oelSaleMaster, List<SaleDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelStockReceiptCollection, SqlConnection objConn)
        public bool UpdateSalesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    SqlCommand cmdSalesReturn = new SqlCommand("[Transactions].[Proc_UpdateSalesReturnHead]", objConn);
                    cmdSalesReturn.CommandType = CommandType.StoredProcedure;
                    cmdSalesReturn.Transaction = objTran;

                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@MemoSaleNo", DbType.Int64)).Value = oelVoucher.MemoSaleNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@InWardGatePassNo", DbType.String)).Value = oelVoucher.InWardGatePassNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.Amount;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VAT", DbType.Decimal)).Value = oelVoucher.VAT;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VATAmount", DbType.Decimal)).Value = oelVoucher.VATAmount;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@ReturnType", DbType.Decimal)).Value = oelVoucher.ReturnType;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSalesReturn.ExecuteNonQuery();

                    //// Insert And Update Sales In Sale Record
                    dal.UpdateSalesReturnDetail(oelSaleCollection, objConn, objTran);

                    /// Insert and Update Sales Return Transactions
                    Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);

                    objTran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }   
            }              
        }
        public bool DeleteSale(Guid IdVoucher, Int64 VoucherNo, string TransactionType, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlTransaction objTran = objConn.BeginTransaction())
            {
                try
                {
                    SqlCommand cmdDeleteVouchers = new SqlCommand("[Transactions].[Proc_DeleteVoucherWithtransaction]", objConn);
                    cmdDeleteVouchers.CommandType = CommandType.StoredProcedure;
                    cmdDeleteVouchers.Transaction = objTran;
                    cmdDeleteVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                    cmdDeleteVouchers.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                    cmdDeleteVouchers.Parameters.Add("@TransactionType", SqlDbType.NVarChar).Value = TransactionType;
                    cmdDeleteVouchers.ExecuteNonQuery();
                    cmdDeleteVouchers.Parameters.Clear();

                    Tdal.DeleteTransactions(IdVoucher, TransactionType, IdCompany, objConn, objTran);

                    objTran.Commit();
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
            }
            return true;           
        }
        public bool DeleteSalesReturn(Guid IdVoucher, Int64 VoucherNo, string TransactionType, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlTransaction objTran = objConn.BeginTransaction())
            {
                try
                {
                    SqlCommand cmdDeleteVouchers = new SqlCommand("[Transactions].[Proc_DeleteVoucherWithtransaction]", objConn);
                    cmdDeleteVouchers.CommandType = CommandType.StoredProcedure;
                    cmdDeleteVouchers.Transaction = objTran;
                    cmdDeleteVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                    cmdDeleteVouchers.Parameters.Add("@IdVoucher", SqlDbType.BigInt).Value = IdVoucher;
                    cmdDeleteVouchers.Parameters.Add("@TransactionType", SqlDbType.NVarChar).Value = TransactionType;
                    cmdDeleteVouchers.ExecuteNonQuery();
                    cmdDeleteVouchers.Parameters.Clear();

                    Tdal.DeleteTransactions(IdVoucher, TransactionType, IdCompany, objConn, objTran);

                    objTran.Commit();
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
            }
            return true; 
        }
        public bool CheckSales(Guid IdCompnay,Int64 VoucherNo, SqlConnection objConn)
        {
            List<VouchersEL> oelSaleCollection = new List<VouchersEL>();
            bool IsExists = false;
            using (SqlCommand cmdCheckSales = new SqlCommand("[Transactions].[Proc_CheckSale]", objConn))
            {
                cmdCheckSales.CommandType = CommandType.StoredProcedure;

                cmdCheckSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompnay;
                cmdCheckSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = VoucherNo;
                
                IDataReader objReader = cmdCheckSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelSaleMaster = new VouchersEL();
                    oelSaleMaster.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelSaleCollection.Add(oelSaleMaster);
                }
            }
            if (oelSaleCollection.Count > 0)
            {
                IsExists = true;
            }
            return IsExists;
        }
        public List<VouchersEL> GetSaleDays(Guid IdCompany, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleDays]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelVoucher.Transactiondays = Validation.GetSafeInteger(objReader["CreditDays"]);
                    oelVoucher.RemainingDays = Validation.GetSafeInteger(objReader["RemainingDays"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetSaleDaysByDate(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleDaysByDate]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelVoucher.Transactiondays = Validation.GetSafeInteger(objReader["CreditDays"]);
                    oelVoucher.RemainingDays = Validation.GetSafeInteger(objReader["RemainingDays"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetSaleDaysByEmployees(Guid IdCompany, string EmpCode, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleDaysByEmployee]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = EmpCode;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelVoucher.Transactiondays = Validation.GetSafeInteger(objReader["CreditDays"]);
                    oelVoucher.RemainingDays = Validation.GetSafeInteger(objReader["RemainingDays"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetSaleDaysByEmployeesByDate(Guid IdCompany, string EmpCode,DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleDaysByEmployeeByDate]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = EmpCode;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelVoucher.Transactiondays = Validation.GetSafeInteger(objReader["CreditDays"]);
                    oelVoucher.RemainingDays = Validation.GetSafeInteger(objReader["RemainingDays"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetDateWiseSalesReport(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Reports].[Proc_GetDateWiseSales]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();                   
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.TotalSales = Validation.GetSafeLong(objReader["TotalSales"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;            
        }
        public List<VouchersEL> GetDateAndEmployeeWiseSalesReport(Guid IdCompany, string EmpCode, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Reports].[Proc_GetDateAndEmployeeWiseSales]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@EmpCode", SqlDbType.UniqueIdentifier).Value = EmpCode;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.TotalSales = Validation.GetSafeLong(objReader["TotalSales"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetDateWiseClaimReturnReport(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Reports].[Proc_GetDateWiseClaimReturns]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.TotalSalesReturn = Validation.GetSafeLong(objReader["TotalClaims"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetClaimedVouchersByAccountNo(Guid IdCompany, string AccountNo, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Reports].[Proc_GetClaimedVouchersByAccountNo]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetClaimedVouchersDetail(Guid IdVoucher, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetClaimedVoucherDetail]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelVoucherDetail = new VoucherDetailEL();
                    oelVoucherDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelVoucherDetail.Units = Validation.GetSafeInteger(objReader["Units"]);
                    oelVoucherDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    //oelVoucherDetail.Discount = Validation.GetSafeDecimal(objReader["DisCount"]);
                    oelVoucherDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucherDetail);
                }
            }
            return list;
        }
    }
}
