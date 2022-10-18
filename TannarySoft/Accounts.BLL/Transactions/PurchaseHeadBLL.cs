using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;
namespace Accounts.BLL
{
    public class PurchaseHeadBLL
    {
        PurchaseHeadDAL dal;
        public PurchaseHeadBLL()
        {
            dal = new PurchaseHeadDAL();
        }
        public EntityoperationInfo InsertPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseDetailCollection, List<TransactionsEL> oelTransactionsCollection, List<VoucherDetailEL> oelPurchaseTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                objConn.Open();
                infoResult = dal.InsertPurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionsCollection, oelPurchaseTransactionsCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();                                
                throw ex;
                
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();                    
                }
            }
            return infoResult;
        }
        public EntityoperationInfo InsertWorkPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                objConn.Open();
                infoResult = dal.InsertWorkPurchases(oelVoucher, oelPurchaseCollection, oelTransactionsCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;

            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo UpdateWorkPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                objConn.Open();
                infoResult = dal.UpdateWorkPurchases(oelVoucher, oelPurchaseCollection, oelTransactionsCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;

            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo InsertPurchasesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseDetailCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                objConn.Open();
                infoResult = dal.InsertPurchasesReturn(oelVoucher, oelPurchaseDetailCollection, oelTransactionsCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;

            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo UpdatePurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseDetailCollection,List<TransactionsEL> oelTransactionsCollection, List<VoucherDetailEL> oelPurchaseTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                objConn.Open();
                infoResult = dal.UpdatePurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionsCollection, oelPurchaseTransactionsCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;

            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo UpdatePurchasesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseDetailCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                objConn.Open();
                infoResult = dal.UpdatePurchasesReturn(oelVoucher, oelPurchaseDetailCollection, oelTransactionsCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;

            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo InsertPurchaseOrder(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseOrderDetailCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                objConn.Open();
                infoResult = dal.InsertPurchaseOrder(oelVoucher, oelPurchaseOrderDetailCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;

            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo UpdatePurchaseOrder(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseOrderDetailCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                objConn.Open();
                infoResult = dal.UpdatePurchaseOrder(oelVoucher, oelPurchaseOrderDetailCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;

            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public bool DeleteStock(Guid IdVoucher,Int64 VoucherNo,string TransactionType, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteStock(IdVoucher, VoucherNo, TransactionType, IdCompany, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public bool UpdateStockitems(List<TransactionsEL> oelItemQuatityCollection,string ActionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.UpdateStockItems(oelItemQuatityCollection, ActionType , objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetVehicalDetail(string VehicalNo, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetVehicalDetail(VehicalNo, IdCompany, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
    }
}
