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
  public  class OrdersDAL
    {
        IDataReader objReader;
        OrderDetailDAL dal;
        StockDAL stockdal;
        public OrdersDAL()
             {
            dal = new OrderDetailDAL();
            stockdal = new StockDAL();
        }
        public bool InsertOrders(OrdersEL oelOrder, List<OrdersDetailEL> oelOrderDetailCollection, List<ItemsAttributesDetailsEL> oelBreakupCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                //// Insert Orders Voucher

                SqlCommand cmdOrders = new SqlCommand("[Transactions].[Proc_CreateOrders]", objConn,objTran);
                cmdOrders.CommandType = CommandType.StoredProcedure;

                cmdOrders.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelOrder.IdOrder;
                cmdOrders.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelOrder.IdCompany;
                cmdOrders.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelOrder.IdUser;
                cmdOrders.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelOrder.IdBrand;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderNo", DbType.Int64)).Value = oelOrder.OrderNo;
                cmdOrders.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = oelOrder.CustomerPo;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderType", DbType.Int32)).Value = oelOrder.OrderType;
                cmdOrders.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelOrder.AccountNo;
                cmdOrders.Parameters.Add(new SqlParameter("@Description", DbType.Int32)).Value = oelOrder.Description;
                cmdOrders.Parameters.Add(new SqlParameter("@Status", DbType.Int32)).Value = oelOrder.OrderStatus;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderDate", DbType.DateTime)).Value = oelOrder.OrderDate;
                cmdOrders.Parameters.Add(new SqlParameter("@ProductionDate", DbType.DateTime)).Value = oelOrder.ProductionDate;
                cmdOrders.Parameters.Add(new SqlParameter("@DeliveryDate", DbType.DateTime)).Value = oelOrder.DeliveryDate;

              
                cmdOrders.ExecuteNonQuery();

                //// Insert Order Details
                dal.InsertOrderDetail(oelOrderDetailCollection, objConn, objTran);

                //// Insert Order Breakup
                dal.InsertOrderBreakupDetail(oelBreakupCollection, objConn, objTran);
                objTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                throw ex;
            }
        }        
        public bool UpdateOrder(OrdersEL oelOrder, List<OrdersDetailEL> oelOrdersDetailCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdOrders = new SqlCommand("[Transactions].[Proc_UpdateOrders]", objConn);
                cmdOrders.CommandType = CommandType.StoredProcedure;
                cmdOrders.Transaction = objTran;

                cmdOrders.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelOrder.IdOrder;
                cmdOrders.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelOrder.IdCompany;
                cmdOrders.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelOrder.IdUser;
                cmdOrders.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelOrder.IdBrand;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderNo", DbType.Int64)).Value = oelOrder.OrderNo;
                cmdOrders.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = oelOrder.CustomerPo;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderType", DbType.Int32)).Value = oelOrder.OrderType;
                cmdOrders.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelOrder.AccountNo;
                cmdOrders.Parameters.Add(new SqlParameter("@Description", DbType.Int32)).Value = oelOrder.Description;
                cmdOrders.Parameters.Add(new SqlParameter("@Status", DbType.Int32)).Value = oelOrder.OrderStatus;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderDate", DbType.DateTime)).Value = oelOrder.OrderDate;
                cmdOrders.Parameters.Add(new SqlParameter("@ProductionDate", DbType.DateTime)).Value = oelOrder.ProductionDate;
                cmdOrders.Parameters.Add(new SqlParameter("@DeliveryDate", DbType.DateTime)).Value = oelOrder.DeliveryDate;
              
                cmdOrders.ExecuteNonQuery();

                //// Insert And Update Orders Detail
                dal.UpdateOrdersDetail(oelOrdersDetailCollection, objConn, objTran);

                objTran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                throw ex;
            }

        }
        public string GetMaxOrderNumber(Int32 OrderType, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetMaxOrderNoByOrderType]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@OrderType", SqlDbType.NVarChar).Value = OrderType;
                return cmdVouchers.ExecuteScalar().ToString();
            }
        }
        public List<OrdersEL> GetOpenCustomerPos(int OrderType, SqlConnection objConn)
        {
            List<OrdersEL> list = new List<OrdersEL>();
            SqlCommand cmdOrders = new SqlCommand("[Production].[Proc_GetCustomersOpenPOS]", objConn);
            cmdOrders.CommandType = CommandType.StoredProcedure;
            cmdOrders.Parameters.Add(new SqlParameter("@OrderType", DbType.Int64)).Value = OrderType;
            objReader = cmdOrders.ExecuteReader();
            if (objReader.Read())
            {
                OrdersEL oelOrder = new OrdersEL();
                oelOrder.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                oelOrder.OrderNo = Validation.GetSafeLong(objReader["OrderNo"]);
                oelOrder.PoNumber = Validation.GetSafeString(objReader["PoNumber"]);
                oelOrder.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelOrder.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);

                list.Add(oelOrder);
            }
            return list;
        }
        public bool CheckPoNumber(string PoNumber,int OrderType, SqlConnection objConn)
        {
            List<OrdersEL> list = new List<OrdersEL>();
            SqlCommand cmdOrders = new SqlCommand("[Production].[Proc_CheckPoNumber]", objConn);
            cmdOrders.CommandType = CommandType.StoredProcedure;
            cmdOrders.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = PoNumber;
            cmdOrders.Parameters.Add(new SqlParameter("@OrderType", DbType.Int64)).Value = PoNumber;
            objReader = cmdOrders.ExecuteReader();
            if (objReader.Read())
            {
                OrdersEL oelOrder = new OrdersEL();
                oelOrder.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                oelOrder.OrderNo = Validation.GetSafeLong(objReader["OrderNo"]);
                oelOrder.PoNumber = Validation.GetSafeString(objReader["PoNumber"]);

                list.Add(oelOrder);
            }
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CompleteOrder(Guid IdOrder,SqlConnection objConn)
        {
            SqlCommand cmdOrders = new SqlCommand("[Production].[Proc_CompleteOrder]", objConn);
            cmdOrders.CommandType = CommandType.StoredProcedure;
            cmdOrders.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = IdOrder;
            cmdOrders.ExecuteNonQuery();
            return true;
        }
      }
    }
