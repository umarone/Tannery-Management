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
   public class ProcessHeadDAL
    {
       TransactionsDAL Tdal;
       ProcessDetailDAL Pdal;
       IDataReader objReader;
       public ProcessHeadDAL()
       {
           Tdal = new TransactionsDAL();
           Pdal = new ProcessDetailDAL();
       }
       public EntityoperationInfo InsertWorkProcess(VouchersEL oelVoucher, List<VoucherDetailEL> oelProcessCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreateProcessHead]", objConn);

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
                   //cmdPurchaseHead.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@WorkType", DbType.Boolean)).Value = oelVoucher.WorkType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@ProcessType", DbType.Int32)).Value = oelVoucher.ProcessType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Claimed", DbType.Boolean)).Value = oelVoucher.IsClaimed;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IsPlain", DbType.Boolean)).Value = oelVoucher.IsPlain;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();

                   // Insert Purchase Collection...
                   Pdal.InsertProcessDetail(oelProcessCollection, objConn, objTran);
                  
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
       public EntityoperationInfo UpdateWorkProcess(VouchersEL oelVoucher, List<VoucherDetailEL> oelProcessCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
       {
           lock (this)
           {
               EntityoperationInfo infoResult = new EntityoperationInfo();
               SqlTransaction objTran = null;
               SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdateProcessHead]", objConn);
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
                   //cmdPurchaseHead.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@WorkType", DbType.Boolean)).Value = oelVoucher.WorkType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@ProcessType", DbType.Int32)).Value = oelVoucher.ProcessType;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Claimed", DbType.Boolean)).Value = oelVoucher.IsClaimed;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@IsPlain", DbType.Boolean)).Value = oelVoucher.IsPlain;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                   cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                   cmdPurchaseHead.ExecuteNonQuery();
                   
                   // Insert Process Collection...
                   Pdal.UpdateProcessDetail(oelProcessCollection, objConn, objTran);
                                     
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
       public Int64 GetMaxRubberizingVoucherNumber(Guid IdCompany, int IssuanceType, SqlConnection objConn)
       {
           using (SqlCommand cmdGatePass = new SqlCommand("[Production].[Proc_GetMaxRubberizingGatePassNumberByType]", objConn))
           {
               cmdGatePass.CommandType = CommandType.StoredProcedure;
               cmdGatePass.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
               cmdGatePass.Parameters.Add("@WorkType", SqlDbType.Int).Value = IssuanceType;
               return Validation.GetSafeLong(cmdGatePass.ExecuteScalar());
           }
       }
       public List<ItemsEL> GetRubberingClosingStockToParty(Guid IdItem, string AccountNo, SqlConnection objConn)
       {
           List<ItemsEL> list = new List<ItemsEL>();
           SqlCommand cmdStock = new SqlCommand("[Transactions].[Proc_GetRubberingClosingStockToParty]", objConn);
           cmdStock.CommandType = CommandType.StoredProcedure;
           cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
           cmdStock.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
           objReader = cmdStock.ExecuteReader();
           while (objReader.Read())
           {
               ItemsEL oelItem = new ItemsEL();
               oelItem.Qty = Validation.GetSafeLong(objReader["Closing"]);
               list.Add(oelItem);
           }

           return list;
       }
       public bool DeleteProcessHead(Guid IdVoucher, SqlConnection objConn)
       {
           using (SqlCommand cmdGatePass = new SqlCommand("[Transactions].[Proc_DeleteWorkProcessByVoucher]", objConn))
           {
               cmdGatePass.CommandType = CommandType.StoredProcedure;
               cmdGatePass.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
               cmdGatePass.ExecuteNonQuery();
               return true;
           }
       }
       
    }
}
