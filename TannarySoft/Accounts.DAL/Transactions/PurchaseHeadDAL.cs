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
   public class PurchaseHeadDAL
    {
       TransactionsDAL Tdal;
       PurchaseDetailDAL Pdal;
       IDataReader objReader;
       public PurchaseHeadDAL()
       {
           Tdal = new TransactionsDAL();
           Pdal = new PurchaseDetailDAL();
       }
       public EntityoperationInfo InsertPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, List<VoucherDetailEL> oelPurchaseTransactionsCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreatePurchaseHead]", objConn);

               try
               {
                   objTran = objConn.BeginTransaction();
                   cmdPurchaseHead.Transaction = objTran;
                   cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillNo", DbType.String)).Value = oelVoucher.BillNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VehicalNo", DbType.String)).Value = oelVoucher.VehicalNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VehicalType", DbType.Int32)).Value = oelVoucher.VehicalType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Weight", DbType.Decimal)).Value = oelVoucher.Weight;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@PurchaseType", DbType.Int32)).Value = oelVoucher.PurchaseType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IsImport", DbType.Boolean)).Value = oelVoucher.IsImport;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Purchaser", DbType.Int32)).Value = oelVoucher.Purchaser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();

                   // Insert Purchase Collection...
                   Pdal.InsertPurchaseDetail(oelPurchaseCollection, objConn, objTran);

                   // Insert PurchaseTransactionsDetails
                   Pdal.InsertPurchaseTransactionsDetail(oelPurchaseTransactionsCollection, objConn, objTran);
                   
                   // Insert Purchase Transactions...
                   Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                   objTran.Commit();
                   infoResult.IsSuccess = true;
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }



               return infoResult;   
           }          
       }
       public EntityoperationInfo UpdatePurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, List<VoucherDetailEL> oelPurchaseTransactionsCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdatePurchaseHead]", objConn);
               try
               {
                   objTran = objConn.BeginTransaction();

                   cmdPurchaseHead.Transaction = objTran;
                   cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillNo", DbType.String)).Value = oelVoucher.BillNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VehicalNo", DbType.String)).Value = oelVoucher.VehicalNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VehicalType", DbType.Int32)).Value = oelVoucher.VehicalType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Weight", DbType.Decimal)).Value = oelVoucher.Weight;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@PurchaseType", DbType.Decimal)).Value = oelVoucher.PurchaseType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Purchaser", DbType.Int32)).Value = oelVoucher.Purchaser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();



                   //var dal = new StockDAL();
                   // dal.UpdateStock(oelStockReceiptCollection, oTran, objConn);

                   //SqlCommand cmdStockReceiptDetail = new SqlCommand();
                   //cmdStockReceiptDetail.CommandType = CommandType.StoredProcedure;
                   //cmdStockReceiptDetail.Transaction = oTran;
                   //cmdStockReceiptDetail.Connection = objConn;
                   //for (int i = 0; i < oelStockReceiptCollection.Count; i++)
                   //{
                   //    if (oelStockReceiptCollection[i].IsNew)
                   //    {
                   //        cmdStockReceiptDetail.CommandText = "sp_InsertStockReceipt";
                   //    }
                   //    else
                   //    {
                   //        cmdStockReceiptDetail.CommandText = "sp_updateStockReceipt";
                   //    }
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@IdStockReceipt", DbType.Guid)).Value = oelStockReceiptCollection[i].IdStockReceipt;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelStockReceiptCollection[i].IdUser;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelStockReceiptCollection[i].VoucherNo;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelStockReceiptCollection[i].ItemNo;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@units", DbType.Int64)).Value = oelStockReceiptCollection[i].Units;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int64)).Value = oelStockReceiptCollection[i].RemainingUnits;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelStockReceiptCollection[i].Amount;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@stockdate", DbType.DateTime)).Value = oelStockReceiptCollection[i].StockDate;
                   //    cmdStockReceiptDetail.ExecuteNonQuery();
                   //    cmdStockReceiptDetail.Parameters.Clear();

                   //}

                   // Insert Purchase Collection...
                   Pdal.UpdatePurchaseDetail(oelPurchaseCollection, objConn, objTran);

                   //Update Purchases Details Collection 
                   Pdal.UpdatePurchaseTransactionsDetail(oelPurchaseTransactionsCollection, objConn, objTran);

                   // Insert Purchase Transactions...
                   Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);
                   objTran.Commit();
                   infoResult.IsSuccess = true;
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }

               return infoResult;
           }
       }
       public EntityoperationInfo InsertWorkPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreatePurchaseWorkHead]", objConn);

               try
               {
                   objTran = objConn.BeginTransaction();
                   cmdPurchaseHead.Transaction = objTran;
                   cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;                  
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();

                   // Insert Purchase Collection...
                   Pdal.InsertWorkPurchaseDetail(oelPurchaseCollection, objConn, objTran);

                   // Insert Purchase Transactions...
                   Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                   objTran.Commit();
                   infoResult.IsSuccess = true;
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }



               return infoResult;
           }
       }
       public EntityoperationInfo UpdateWorkPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdatePurchaseWorkHead]", objConn);

               try
               {
                   objTran = objConn.BeginTransaction();
                   cmdPurchaseHead.Transaction = objTran;
                   cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();

                   // Update Purchase Collection...
                   Pdal.InsertWorkPurchaseDetail(oelPurchaseCollection, objConn, objTran);

                   // Insert Purchase Transactions...
                   Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);

                   objTran.Commit();
                   infoResult.IsSuccess = true;
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }



               return infoResult;
           }
       }
       public EntityoperationInfo InsertPurchasesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreatePurchaseReturnHead]", objConn);

               try
               {
                   objTran = objConn.BeginTransaction();
                   cmdPurchaseHead.Transaction = objTran;
                   cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillNo", DbType.String)).Value = oelVoucher.BillNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();

                   // Insert Purchase Collection...
                   Pdal.InsertPurchaseReturnDetail(oelPurchaseCollection, objConn, objTran);

                   // Insert Purchase Transactions...
                   Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                   objTran.Commit();
                   infoResult.IsSuccess = true;
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }

               return infoResult;
           }
        
       }       
       public EntityoperationInfo UpdatePurchasesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdatePurchaseReturnHead]", objConn);
               try
               {
                   objTran = objConn.BeginTransaction();

                   cmdPurchaseHead.Transaction = objTran;
                   cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillNo", DbType.String)).Value = oelVoucher.BillNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();



                   //var dal = new StockDAL();
                   // dal.UpdateStock(oelStockReceiptCollection, oTran, objConn);

                   //SqlCommand cmdStockReceiptDetail = new SqlCommand();
                   //cmdStockReceiptDetail.CommandType = CommandType.StoredProcedure;
                   //cmdStockReceiptDetail.Transaction = oTran;
                   //cmdStockReceiptDetail.Connection = objConn;
                   //for (int i = 0; i < oelStockReceiptCollection.Count; i++)
                   //{
                   //    if (oelStockReceiptCollection[i].IsNew)
                   //    {
                   //        cmdStockReceiptDetail.CommandText = "sp_InsertStockReceipt";
                   //    }
                   //    else
                   //    {
                   //        cmdStockReceiptDetail.CommandText = "sp_updateStockReceipt";
                   //    }
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@IdStockReceipt", DbType.Guid)).Value = oelStockReceiptCollection[i].IdStockReceipt;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelStockReceiptCollection[i].IdUser;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelStockReceiptCollection[i].VoucherNo;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelStockReceiptCollection[i].ItemNo;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@units", DbType.Int64)).Value = oelStockReceiptCollection[i].Units;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int64)).Value = oelStockReceiptCollection[i].RemainingUnits;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelStockReceiptCollection[i].Amount;
                   //    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@stockdate", DbType.DateTime)).Value = oelStockReceiptCollection[i].StockDate;
                   //    cmdStockReceiptDetail.ExecuteNonQuery();
                   //    cmdStockReceiptDetail.Parameters.Clear();

                   //}

                   // Insert Purchase Collection...
                   Pdal.UpdatePurchaseReturnDetail(oelPurchaseCollection, objConn, objTran);

                   // Insert Purchase Transactions...
                   Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);
                   objTran.Commit();
                   infoResult.IsSuccess = true;
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }
               return infoResult;   
           }         
       }
       public EntityoperationInfo InsertPurchaseOrder(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseOrderDetailCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreatePurchaseOrderHead]", objConn);

               try
               {
                   objTran = objConn.BeginTransaction();
                   cmdPurchaseHead.Transaction = objTran;
                   cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelVoucher.IdOrder;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelVoucher.IdRequisition;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@PaymentTerms", DbType.String)).Value = oelVoucher.PaymentTerms;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@DeliveryTerms", DbType.String)).Value = oelVoucher.DeliveryTerms;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@PurchaseType", DbType.Int32)).Value = oelVoucher.PurchaseType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();

                   // Insert Purchase Order Detail Collection...
                   Pdal.InsertPurchaseOrderDetail(oelPurchaseOrderDetailCollection, objConn, objTran);

                   objTran.Commit();
                   infoResult.IsSuccess = true;
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }



               return infoResult;
           }
       }
       public EntityoperationInfo UpdatePurchaseOrder(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseOrderDetailCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdatePurchaseOrderHead]", objConn);
               try
               {
                   objTran = objConn.BeginTransaction();

                   cmdPurchaseHead.Transaction = objTran;
                   cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelVoucher.IdOrder;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelVoucher.IdRequisition;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@PaymentTerms", DbType.String)).Value = oelVoucher.PaymentTerms;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@DeliveryTerms", DbType.String)).Value = oelVoucher.DeliveryTerms;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@PurchaseType", DbType.Int32)).Value = oelVoucher.PurchaseType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();



                  
                   // Insert Purchase Order Detail Collection...
                   Pdal.UpdatePurchaseOrderDetail(oelPurchaseOrderDetailCollection, objConn, objTran);

                   objTran.Commit();
                   infoResult.IsSuccess = true;
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }

               return infoResult;
           }
       }
       public bool DeleteStock(Guid IdVoucher,Int64 VoucherNo, string TransactionType, Guid IdCompany ,SqlConnection objConn)
       {
           using (SqlTransaction objTran = objConn.BeginTransaction())
           {
               try
               {
                   SqlCommand cmdDeleteStockReceipt = new SqlCommand("[Transactions].[Proc_DeleteVoucherWithtransaction]", objConn);
                   cmdDeleteStockReceipt.CommandType = CommandType.StoredProcedure;
                   cmdDeleteStockReceipt.Transaction = objTran;
                   cmdDeleteStockReceipt.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                   cmdDeleteStockReceipt.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                   cmdDeleteStockReceipt.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = TransactionType;
                   cmdDeleteStockReceipt.ExecuteNonQuery();

                   cmdDeleteStockReceipt.CommandText = "[Transactions].[Proc_DeleteTransaction]";
                   //cmdDeleteStockReceipt.ExecuteNonQuery();

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
       public bool UpdateStockItems(List<TransactionsEL> oelItemQuatityCollection,string ActionType, SqlConnection objConn)
       {
           using (SqlTransaction objTran = objConn.BeginTransaction())
           {
               try
               {
                   SqlCommand cmdUpdateQuatity = new SqlCommand("sp_updateItemsQty", objConn);
                   cmdUpdateQuatity.CommandType = CommandType.StoredProcedure;
                   cmdUpdateQuatity.CommandTimeout = 0;
                   cmdUpdateQuatity.Transaction = objTran;

                   for (int i = 0; i < oelItemQuatityCollection.Count; i++)
                   {
                       cmdUpdateQuatity.Parameters.Add("@ItemNo", SqlDbType.NVarChar).Value = oelItemQuatityCollection[i].AccountNo;
                       cmdUpdateQuatity.Parameters.Add("@Quantity", SqlDbType.Int).Value = oelItemQuatityCollection[i].Qty;
                       cmdUpdateQuatity.Parameters.Add("@ActionType", SqlDbType.NVarChar).Value = ActionType;
                       cmdUpdateQuatity.ExecuteNonQuery();
                       cmdUpdateQuatity.Parameters.Clear();
                   }
               }
               catch (Exception ex)
               {
                   objTran.Rollback();
                   throw ex;
               }
               objTran.Commit();
           }
           return true;
       }
       //public static bool UpdatePurchaseMaster(PurchaseMasterEL oelPurchaseMaster, SqlConnection oConn)
       //{
       //    using (SqlCommand cmdPurchaseMaster = new SqlCommand("sp_updatePurchaseMaster", oConn))
       //    {
       //        cmdPurchaseMaster.CommandType = CommandType.StoredProcedure;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int32)).Value = oelPurchaseMaster.VoucherNo;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@Date", DbType.DateTime)).Value = oelPurchaseMaster.Date;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@SupplierNo", DbType.String)).Value = oelPurchaseMaster.SupplierNo;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelPurchaseMaster.Description;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelPurchaseMaster.TotalAmount;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@CashPaid", DbType.Decimal)).Value = oelPurchaseMaster.CashPaid;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@PaidAccountNo", DbType.String)).Value = oelPurchaseMaster.PaidAccountNo;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@PaidAccountDescription", DbType.String)).Value = oelPurchaseMaster.PaidAccountDescription;
       //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@Balance", DbType.Decimal)).Value = oelPurchaseMaster.Balance;
       //        cmdPurchaseMaster.ExecuteNonQuery();
       //        return true;

       //    }
       //}
       public List<VoucherDetailEL> GetVehicalDetail(string VehicalNo, Guid IdCompany, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdPurchase = new SqlCommand("[Transactions].[Proc_GetVehicalDetail]", objConn))
           {
               cmdPurchase.CommandType = CommandType.StoredProcedure;
               cmdPurchase.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
               cmdPurchase.Parameters.Add("@VehicalNo", SqlDbType.VarChar).Value = VehicalNo;
               objReader = cmdPurchase.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL oelVehical = new VoucherDetailEL();
                   oelVehical.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                   oelVehical.Weight = Validation.GetSafeDecimal(objReader["Weight"]);
                   oelVehical.CreatedDateTime = Validation.GetSafeDateTime(objReader["VDate"]);
                   oelVehical.VoucherType =  Validation.GetSafeString(objReader["VehicalType"]);
                   list.Add(oelVehical);
               }
           }
           return list;
       }
       
    }
}
