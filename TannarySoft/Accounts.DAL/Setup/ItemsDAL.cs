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
    public class ItemsDAL
    {
        IDataReader objReader;
        public EntityoperationInfo InsertStockWithAccount(AccountsEL oelChartOfAccount, ItemsEL oelItems, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlTransaction oTran = objConn.BeginTransaction())
            {
                SqlCommand cmdAccounts = new SqlCommand("[Setup].[Proc_CreateAccounts]");
                cmdAccounts.Connection = objConn;
                cmdAccounts.Transaction = oTran;
                cmdAccounts.CommandType = CommandType.StoredProcedure;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdAccount", DbType.Guid)).Value = oelChartOfAccount.IdAccount;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelChartOfAccount.IdCompany;
                cmdAccounts.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelChartOfAccount.AccountNo;
                cmdAccounts.Parameters.Add(new SqlParameter("@AccountName", DbType.String)).Value = oelChartOfAccount.AccountName;
                cmdAccounts.Parameters.Add(new SqlParameter("@TradingCode", DbType.String)).Value = oelChartOfAccount.TradingCode;
                cmdAccounts.Parameters.Add(new SqlParameter("@AccountType", DbType.String)).Value = oelChartOfAccount.AccountType;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdParent1", DbType.Int32)).Value = oelChartOfAccount.IdParent1;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdParent2", DbType.Int32)).Value = oelChartOfAccount.IdParent2;
                cmdAccounts.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelChartOfAccount.Discription;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelChartOfAccount.UserId;
                cmdAccounts.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelChartOfAccount.IsActive;
                cmdAccounts.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelChartOfAccount.CreatedDateTime;


                SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_InsertItems]", objConn);
                cmdItems.Connection = objConn;
                cmdItems.Transaction = oTran;
                cmdItems.CommandType = CommandType.StoredProcedure;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItems.IdAccount;
                cmdItems.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelItems.IdCompany;
                cmdItems.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelItems.ItemNo;
                cmdItems.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelItems.ItemName;
                cmdItems.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelItems.PackingSize;
                cmdItems.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelItems.Description;
                cmdItems.Parameters.Add(new SqlParameter("@Qty", DbType.Decimal)).Value = oelItems.Qty;
                cmdItems.Parameters.Add(new SqlParameter("@Balance", DbType.Decimal)).Value = oelItems.Balance;
                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdItems.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                    oTran.Commit();
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
            }
            return infoResult;
        }
        public bool InsertItems(ItemsEL oelItems, List<ItemsEL> oelItemsAttributes, List<ItemsEL> oelItemsColorAttributes, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_CreateItems]", objConn, objTran);

                    cmdItems.CommandType = CommandType.StoredProcedure;
                    cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItems.IdItem;
                    cmdItems.Parameters.Add(new SqlParameter("@IdCategory", DbType.Guid)).Value = oelItems.IdCategory;
                    cmdItems.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelItems.IdCompany;
                    cmdItems.Parameters.Add(new SqlParameter("@IdTradingCo", DbType.Guid)).Value = oelItems.IdTradingCo;
                    cmdItems.Parameters.Add(new SqlParameter("@ItemNo", DbType.Int64)).Value = oelItems.ItemNo;
                    cmdItems.Parameters.Add(new SqlParameter("@ItemCode", DbType.String)).Value = oelItems.ProductCode;
                    cmdItems.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelItems.ItemName;
                    cmdItems.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelItems.PackingSize;
                    //cmdItems.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelItems.BatchNo;
                    cmdItems.Parameters.Add(new SqlParameter("@BarCode", DbType.String)).Value = oelItems.BarCode;
                    cmdItems.Parameters.Add(new SqlParameter("@MRP", DbType.Decimal)).Value = oelItems.MRP;
                    cmdItems.Parameters.Add(new SqlParameter("@ReorderLevel", DbType.Int32)).Value = oelItems.ReorderLevel;
                    cmdItems.Parameters.Add(new SqlParameter("@IsRazing", DbType.Boolean)).Value = oelItems.IsRazing;
                    cmdItems.Parameters.Add(new SqlParameter("@IsMandatory", DbType.Boolean)).Value = oelItems.IsMandatory;
                    cmdItems.Parameters.Add(new SqlParameter("@CuttingRate", DbType.Decimal)).Value = oelItems.CuttingRates;
                    cmdItems.Parameters.Add(new SqlParameter("@CuttingWages", DbType.Decimal)).Value = oelItems.CuttingWages;
                    cmdItems.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelItems.IsActive.Value;
                    cmdItems.ExecuteNonQuery();

                    InsertItemsAttributes(oelItemsAttributes, objConn, objTran);

                    InsertItemsColorAttributes(oelItemsColorAttributes, objConn, objTran);

                    objTran.Commit();

                }
                catch (Exception ex)
                {
                    objConn.Dispose();
                    objTran.Dispose();
                    return false;
                }
                finally
                {
                    objConn.Dispose();
                    objTran.Dispose();
                }
                return true;
            }

        }
        public bool InsertItemsAttributes(List<ItemsEL> oelItemsAttributes, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_InsertAttributes]", objConn, objTran);
            cmdItems.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelItemsAttributes.Count; i++)
            {
                cmdItems.Parameters.Add(new SqlParameter("@IdSize", DbType.Guid)).Value = oelItemsAttributes[i].IdSize;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItemsAttributes[i].IdItem;
                cmdItems.Parameters.Add(new SqlParameter("@Size", DbType.Guid)).Value = oelItemsAttributes[i].ItemSize;
                cmdItems.Parameters.Add(new SqlParameter("@Description", DbType.Int64)).Value = oelItemsAttributes[i].Description;

                cmdItems.ExecuteNonQuery();
                cmdItems.Parameters.Clear();
            }
            return true;
        }
        public bool InsertItemsColorAttributes(List<ItemsEL> oelItemsAttributes, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_InsertItemColorAttributes]", objConn, objTran);
            cmdItems.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelItemsAttributes.Count; i++)
            {
                cmdItems.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelItemsAttributes[i].IdColor;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItemsAttributes[i].IdItem;
                cmdItems.Parameters.Add(new SqlParameter("@Color", DbType.Guid)).Value = oelItemsAttributes[i].ItemColor;
                cmdItems.Parameters.Add(new SqlParameter("@Description", DbType.Int64)).Value = oelItemsAttributes[i].Description;

                cmdItems.ExecuteNonQuery();
                cmdItems.Parameters.Clear();
            }
            return true;
        }
        public bool UpdateItemsColorAttributes(List<ItemsEL> oelItemsAttributes, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_UpdatItemColorAttributes]", objConn, objTran);
            cmdItems.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelItemsAttributes.Count; i++)
            {
                if (oelItemsAttributes[i].IsNew)
                {
                    cmdItems.CommandText = "[Setup].[Proc_InsertItemColorAttributes]";
                }
                else
                {
                    cmdItems.CommandText = "[Setup].[Proc_UpdatItemColorAttributes]";
                }
                cmdItems.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelItemsAttributes[i].IdColor;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItemsAttributes[i].IdItem;
                cmdItems.Parameters.Add(new SqlParameter("@Color", DbType.Guid)).Value = oelItemsAttributes[i].ItemColor;
                cmdItems.Parameters.Add(new SqlParameter("@Description", DbType.Int64)).Value = oelItemsAttributes[i].Description;

                cmdItems.ExecuteNonQuery();
                cmdItems.Parameters.Clear();
            }
            return true;
        }
        public bool InsertCurrentStock(List<ItemsEL> list, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_CreateCurrentStock]", objConn);
            for (int i = 0; i < list.Count; i++)
            {
                cmdItems.CommandType = CommandType.StoredProcedure;
                cmdItems.Parameters.Add(new SqlParameter("@IdCurrentStock", DbType.Guid)).Value = list[i].IdCurrentStock;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = list[i].IdItem;
                cmdItems.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = list[i].Seq;
                cmdItems.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = list[i].PackingSize;
                //cmdItems.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = list[i].BatchNo;
                cmdItems.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = list[i].Qty;
                cmdItems.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = list[i].UnitPrice;
                cmdItems.Parameters.Add(new SqlParameter("@CurrentUnitPrice", DbType.Decimal)).Value = list[i].CurrentUnitPrice;
                cmdItems.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = list[i].TotalAmount;
                cmdItems.ExecuteNonQuery();
                cmdItems.Parameters.Clear();
            }
            return true;
        }
        public EntityoperationInfo UpdateItemsWithAccount(AccountsEL oelChartOfAccount, ItemsEL oelItems, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlTransaction oTran = objConn.BeginTransaction())
            {
                SqlCommand cmdAccounts = new SqlCommand("[Setup].[Proc_UpdateAccounts]");
                cmdAccounts.Connection = objConn;
                cmdAccounts.Transaction = oTran;
                cmdAccounts.CommandType = CommandType.StoredProcedure;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdAccount", DbType.Guid)).Value = oelChartOfAccount.IdAccount;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelChartOfAccount.IdCompany;
                cmdAccounts.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelChartOfAccount.AccountNo;
                cmdAccounts.Parameters.Add(new SqlParameter("@AccountName", DbType.String)).Value = oelChartOfAccount.AccountName;
                cmdAccounts.Parameters.Add(new SqlParameter("@TradingCode", DbType.String)).Value = oelChartOfAccount.TradingCode;
                cmdAccounts.Parameters.Add(new SqlParameter("@AccountType", DbType.String)).Value = oelChartOfAccount.AccountType;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdParent1", DbType.Int32)).Value = oelChartOfAccount.IdParent1;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdParent2", DbType.Int32)).Value = oelChartOfAccount.IdParent2;
                cmdAccounts.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelChartOfAccount.Discription;
                cmdAccounts.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelChartOfAccount.UserId;
                cmdAccounts.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelChartOfAccount.IsActive;
                cmdAccounts.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelChartOfAccount.CreatedDateTime;


                SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_UpdateItems]", objConn);
                cmdItems.Connection = objConn;
                cmdItems.Transaction = oTran;
                cmdItems.CommandType = CommandType.StoredProcedure;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItems.IdAccount;
                cmdItems.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelItems.IdCompany;
                cmdItems.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelItems.ItemNo;
                cmdItems.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelItems.ItemName;
                cmdItems.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelItems.PackingSize;
                cmdItems.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelItems.Description;
                cmdItems.Parameters.Add(new SqlParameter("@Qty", DbType.Decimal)).Value = oelItems.Qty;
                cmdItems.Parameters.Add(new SqlParameter("@Balance", DbType.Decimal)).Value = oelItems.Balance;
                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdItems.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                    oTran.Commit();
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
            }
            return infoResult;
        }
        public bool UpdateItems(ItemsEL oelItems, List<ItemsEL> oelItemsAttribute, List<ItemsEL> oelItemsColorAttributes, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();            
            try
            {
                SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_UpdateItems]", objConn,objTran);

                cmdItems.CommandType = CommandType.StoredProcedure;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItems.IdItem;
                cmdItems.Parameters.Add(new SqlParameter("@IdCategory", DbType.Guid)).Value = oelItems.IdCategory;
                cmdItems.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelItems.IdCompany;
                cmdItems.Parameters.Add(new SqlParameter("@IdTradingCo", DbType.Guid)).Value = oelItems.IdTradingCo;
                cmdItems.Parameters.Add(new SqlParameter("@ItemNo", DbType.Int64)).Value = oelItems.ItemNo;
                cmdItems.Parameters.Add(new SqlParameter("@ItemCode", DbType.String)).Value = oelItems.ProductCode;
                cmdItems.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelItems.ItemName;
                cmdItems.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelItems.PackingSize;
                //cmdItems.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelItems.BatchNo;
                cmdItems.Parameters.Add(new SqlParameter("@BarCode", DbType.String)).Value = oelItems.BarCode;
                cmdItems.Parameters.Add(new SqlParameter("@MRP", DbType.Decimal)).Value = oelItems.MRP;
                //cmdItems.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelItems.UnitPrice;
                //cmdItems.Parameters.Add(new SqlParameter("@StockOnHand", DbType.Int32)).Value = oelItems.StockOnHand;
                cmdItems.Parameters.Add(new SqlParameter("@ReorderLevel", DbType.Int32)).Value = oelItems.ReorderLevel;
                cmdItems.Parameters.Add(new SqlParameter("@IsRazing", DbType.Boolean)).Value = oelItems.IsRazing;
                cmdItems.Parameters.Add(new SqlParameter("@IsMandatory", DbType.Boolean)).Value = oelItems.IsMandatory;
                cmdItems.Parameters.Add(new SqlParameter("@CuttingRate", DbType.Decimal)).Value = oelItems.CuttingRates;
                cmdItems.Parameters.Add(new SqlParameter("@CuttingWages", DbType.Decimal)).Value = oelItems.CuttingWages;
                cmdItems.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelItems.IsActive.Value;
                //cmdItems.Parameters.Add(new SqlParameter("@StockDate", DbType.DateTime)).Value = oelItems.StockOnHandDate;

                cmdItems.ExecuteNonQuery();

                UpdateItemsAttributes(oelItemsAttribute, objConn, objTran);

                UpdateItemsColorAttributes(oelItemsColorAttributes, objConn, objTran);
                objTran.Commit();
                //UpdateCurrentStock(list, objConn, objTran);               
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                objTran.Dispose();
                objConn.Dispose();
            }
            return true;
        }
        public bool DeleteItems(Guid IdItem, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_deleteItems]", objConn);

                cmdItems.CommandType = CommandType.StoredProcedure;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
                
                cmdItems.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                objConn.Dispose();
            }
            return true;
        }
        public bool UpdateItemsAttributes(List<ItemsEL> oelItemsAttributes, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_UpdateAttributes]", objConn, objTran);
            cmdItems.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelItemsAttributes.Count; i++)
            {
                if (oelItemsAttributes[i].IsNew)
                {
                    cmdItems.CommandText = "[Setup].[Proc_InsertAttributes]";
                }
                else
                {
                    cmdItems.CommandText = "[Setup].[Proc_UpdateAttributes]";  
                }
                cmdItems.Parameters.Add(new SqlParameter("@IdSize", DbType.Guid)).Value = oelItemsAttributes[i].IdSize;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItemsAttributes[i].IdItem;
                cmdItems.Parameters.Add(new SqlParameter("@Size", DbType.Guid)).Value = oelItemsAttributes[i].ItemSize;
                cmdItems.Parameters.Add(new SqlParameter("@Description", DbType.Int64)).Value = oelItemsAttributes[i].Description;

                cmdItems.ExecuteNonQuery();
                cmdItems.Parameters.Clear();
            }
            return true;
        }
        public bool UpdateCurrentStock(List<ItemsEL> list, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdItems = new SqlCommand();
            cmdItems.Connection = objConn;
            //cmdItems.Transaction = objTran;
            cmdItems.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsNew == false)
                {
                    cmdItems.CommandText = "[Setup].[Proc_UpdateCurrentStock]";
                }
                else
                {
                    cmdItems.CommandText = "[Setup].[Proc_CreateCurrentStock]";
                }
                cmdItems.Parameters.Add(new SqlParameter("@IdCurrentStock", DbType.Guid)).Value = list[i].IdCurrentStock;
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = list[i].IdItem;
                cmdItems.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = list[i].Seq;
                cmdItems.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = list[i].PackingSize;
                cmdItems.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = list[i].Qty;
                cmdItems.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = list[i].UnitPrice;
                cmdItems.Parameters.Add(new SqlParameter("@CurrentUnitPrice", DbType.Decimal)).Value = list[i].CurrentUnitPrice;
                cmdItems.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = list[i].TotalAmount;
                cmdItems.ExecuteNonQuery();
                cmdItems.Parameters.Clear();
            }
            return true;
        }
        public void UpdateCurrentUnitPrice(List<ItemsEL> list, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdItems = new SqlCommand();
            cmdItems.Connection = objConn;
            cmdItems.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < list.Count; i++)
            {

                cmdItems.CommandText = "[Setup].[Proc_UpdateCurrentUnitPrice]";
                cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = list[i].IdItem;
                cmdItems.Parameters.Add(new SqlParameter("@CurrentUnitPrice", DbType.Decimal)).Value = list[i].CurrentUnitPrice;
                cmdItems.ExecuteNonQuery();
                cmdItems.Parameters.Clear();
            }
        }
        public Int64 GetMaxProductNo(Guid IdCompany, SqlConnection objConn)
        {
            SqlCommand cmdAccount = new SqlCommand("[Setup].[Proc_GetMaxProductNo]", objConn);
            cmdAccount.CommandType = CommandType.StoredProcedure;
            cmdAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            return Validation.GetSafeLong(cmdAccount.ExecuteScalar());

        }
        public List<ItemsEL> GetPriceWiseItems(Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            using (SqlCommand cmdPriceList = new SqlCommand("[Setup].[Proc_GetPriceWiseItems]", objConn))
            {
                cmdPriceList.CommandType = CommandType.StoredProcedure;
                cmdPriceList.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                objReader = cmdPriceList.ExecuteReader();
                while (objReader.Read())
                {
                    ItemsEL oelItems = new ItemsEL();
                    oelItems.ItemNo = objReader["ItemNo"].ToString();
                    oelItems.ItemName = objReader["ItemName"].ToString();
                    if (objReader["packingsize"] != DBNull.Value)
                    {
                        oelItems.PackingSize = objReader["packingsize"].ToString();
                    }
                    else
                    {
                        oelItems.PackingSize = "";
                    }
                    //if (objReader["ProductRegNo"] != DBNull.Value)
                    //{
                    //    oelItems.ProductRegNo = objReader["ProductRegNo"].ToString();
                    //}
                    oelItems.Description = objReader["Description"].ToString();
                    if (objReader["UnitPrice"] != DBNull.Value)
                    {
                        oelItems.UnitPrice = Convert.ToDecimal(objReader["UnitPrice"]);
                    }
                    list.Add(oelItems);
                }
            }
            return list;
        }
        public bool CreateUpdatePriceList(List<ItemsEL> oelItemsCollection, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlTransaction objTran = objConn.BeginTransaction())
            {
                try
                {
                    SqlCommand cmdPriceList = new SqlCommand("[Setup].[Proc_CreateUpdatePriceList]", objConn);
                    cmdPriceList.Transaction = objTran;
                    cmdPriceList.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < oelItemsCollection.Count; i++)
                    {
                        cmdPriceList.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                        cmdPriceList.Parameters.Add("@ItemNo", SqlDbType.NVarChar).Value = oelItemsCollection[i].ItemNo;
                        cmdPriceList.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = oelItemsCollection[i].ItemName;
                        cmdPriceList.Parameters.Add("@Description", SqlDbType.NVarChar).Value = oelItemsCollection[i].Description;
                        cmdPriceList.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = oelItemsCollection[i].UnitPrice;
                        //cmdPriceList.Parameters.Add("@ProductRegNo", SqlDbType.VarChar).Value = oelItemsCollection[i].ProductRegNo;
                        cmdPriceList.ExecuteNonQuery();
                        cmdPriceList.Parameters.Clear();
                    }
                    objTran.Commit();
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    objTran.Dispose();
                    throw ex;
                }
                finally
                {
                    objTran.Dispose();
                }
            }
            return true;
        }
        public List<ItemsEL> VerifyAccount(Guid IdCompany, string Type, string AccountNo, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            using (SqlCommand cmdVerifyAccount = new SqlCommand("[Setup].[Proc_VerifyAccount]", objConn))
            {
                cmdVerifyAccount.CommandType = CommandType.StoredProcedure;
                cmdVerifyAccount.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVerifyAccount.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
                cmdVerifyAccount.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdVerifyAccount.ExecuteReader();
                while (objReader.Read())
                {
                    ItemsEL oelItem = new ItemsEL();
                    oelItem.ItemNo = objReader["ItemNo"].ToString();
                    list.Add(oelItem);
                }
            }
            return list;
        }
        public decimal GetItemPriceByCode(Int64 ItemNo, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdItemPrice = new SqlCommand("[Setup].[Proc_GetItemPriceByCode]", objConn))
            {
                cmdItemPrice.CommandType = CommandType.StoredProcedure;
                cmdItemPrice.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdItemPrice.Parameters.Add("@ItemNo", SqlDbType.BigInt).Value = ItemNo;
                return Convert.ToDecimal(cmdItemPrice.ExecuteScalar());
            }
        }
        public List<ItemsEL> GetItemPriceAndSizeByCode(Int64 ItemNo, Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdSearchAccount = new SqlCommand("[Setup].[Proc_GetItemPriceAndSizeByCode]", objConn);

            cmdSearchAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdSearchAccount.Parameters.Add("@ItemNo", SqlDbType.BigInt).Value = ItemNo;

            cmdSearchAccount.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdSearchAccount.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.MRP = Validation.GetSafeDecimal(oReader["MRP"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        //public List<StockReceiptEL> GetStockByItemNo(string ItemNo,SqlConnection objConn)
        //{
        //    List<StockReceiptEL> list = new List<StockReceiptEL>();
        //    using (SqlCommand cmdStockReceipt = new SqlCommand("sp_GetStockByItemNo", objConn))
        //    {
        //        cmdStockReceipt.CommandType = CommandType.StoredProcedure;
        //        cmdStockReceipt.CommandTimeout = 0;
        //        cmdStockReceipt.Parameters.Add("@ItemNo", SqlDbType.NVarChar).Value = ItemNo;
        //        objReader = cmdStockReceipt.ExecuteReader();
        //        while (objReader.Read())
        //        {
        //            StockReceiptEL oelStockReceipt = new StockReceiptEL();
        //            oelStockReceipt.IdStockReceipt = new Guid(objReader["stockreceipt_id"].ToString());
        //            oelStockReceipt.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
        //            oelStockReceipt.ItemNo = objReader["ItemNo"].ToString();
        //            oelStockReceipt.Units = Convert.ToInt64(objReader["Units"]);
        //            oelStockReceipt.RemainingUnits = Convert.ToInt64(objReader["RemainingUnits"]);
        //            oelStockReceipt.Amount = Convert.ToDecimal(objReader["Amount"]);
        //            list.Add(oelStockReceipt);
        //        }
        //    }
        //    return list;
        //}
        public List<PurchaseDetailEL> GetStockByItemNo(string ItemNo, SqlConnection objConn)
        {
            List<PurchaseDetailEL> list = new List<PurchaseDetailEL>();
            using (SqlCommand cmdPurchaseDetail = new SqlCommand("sp_GetStockByItemNo", objConn))
            {
                cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
                cmdPurchaseDetail.CommandTimeout = 0;
                cmdPurchaseDetail.Parameters.Add("@ItemNo", SqlDbType.NVarChar).Value = ItemNo;
                objReader = cmdPurchaseDetail.ExecuteReader();
                while (objReader.Read())
                {
                    PurchaseDetailEL obj = new PurchaseDetailEL();
                    obj.IdPurchaseDetail = new Guid(objReader["PurchaseDetail_Id"].ToString());
                    obj.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    obj.ItemNo = objReader["ItemNo"].ToString();
                    obj.Units = Convert.ToInt64(objReader["Units"]);
                    obj.UnitPrice = Convert.ToDecimal(objReader["UnitPrice"]);
                    obj.RemainingUnits = Convert.ToInt64(objReader["RemainingUnits"]);
                    obj.Amount = Convert.ToDecimal(objReader["Amount"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public Int64 GetItemTotalQuantity(Guid IdItem, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdItemQuantity = new SqlCommand("[Transactions].[Proc_GetItemTotalQuantity]", objConn))
            {
                cmdItemQuantity.CommandType = CommandType.StoredProcedure;
                cmdItemQuantity.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdItemQuantity.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                return Validation.GetSafeLong(cmdItemQuantity.ExecuteScalar());
            }
        }
        public Int64 GetDateWiseItemTotalQuantity(Guid IdItem, string PackingSize, string BatchNo, DateTime StockDate, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdItemQuantity = new SqlCommand("[Transactions].[Proc_GetDateWiseItemTotalQuantity]", objConn))
            {
                cmdItemQuantity.CommandType = CommandType.StoredProcedure;
                cmdItemQuantity.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdItemQuantity.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                cmdItemQuantity.Parameters.Add("@PackingSize", SqlDbType.VarChar).Value = PackingSize;
                cmdItemQuantity.Parameters.Add("@BatchNo", SqlDbType.VarChar).Value = BatchNo;
                cmdItemQuantity.Parameters.Add("@StockDate", SqlDbType.DateTime).Value = StockDate;
                return Validation.GetSafeLong(cmdItemQuantity.ExecuteScalar());
            }
        }
        public Int64 GetItemCurrentTotalQuantity(Guid IdItem, string PackingSize, string BatchNo, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdItemQuantity = new SqlCommand("[Transactions].[Proc_GetItemCurrentTotalQuantity]", objConn))
            {
                cmdItemQuantity.CommandType = CommandType.StoredProcedure;
                cmdItemQuantity.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdItemQuantity.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                cmdItemQuantity.Parameters.Add("@PackingSize", SqlDbType.VarChar).Value = PackingSize;
                cmdItemQuantity.Parameters.Add("@BatchNo", SqlDbType.VarChar).Value = BatchNo;
                return Validation.GetSafeLong(cmdItemQuantity.ExecuteScalar());
            }
        }
        public ItemsEL GetItemByAccount(Int64 ItemNo, Guid IdCompany, SqlConnection objConn)
        {
            ItemsEL oelItem = new ItemsEL();
            using (SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemByAccount]", objConn))
            {
                cmdItem.CommandType = CommandType.StoredProcedure;
                cmdItem.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdItem.Parameters.Add("@ItemNo", SqlDbType.BigInt).Value = ItemNo;
                objReader = cmdItem.ExecuteReader();
                while (objReader.Read())
                {
                    oelItem.ItemName = objReader["ItemName"].ToString();
                    if (objReader["PackingSize"] != DBNull.Value)
                    {
                        oelItem.PackingSize = objReader["PackingSize"].ToString();
                    }
                    else
                    {
                        oelItem.Description = "";
                    }

                    if (objReader["Description"] != DBNull.Value)
                    {
                        oelItem.Description = objReader["Description"].ToString();
                    }
                    else
                    {
                        oelItem.Description = "";
                    }
                }
                return oelItem;
            }
        }
        public List<ItemsEL> SearchStockItemsByItemNo(Int64 ItemNo, Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdSearchAccount = new SqlCommand("[Setup].[Proc_SearchStockItemsByItemNo]", objConn);

            cmdSearchAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdSearchAccount.Parameters.Add("@ItemNo", SqlDbType.BigInt).Value = ItemNo;

            cmdSearchAccount.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdSearchAccount.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.AccountNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.Discription = Validation.GetSafeString(oReader["Description"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> SearchStockItemsByItemName(string ItemName, Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdSearchAccount = new SqlCommand("[Setup].[Proc_SearchStockItemsByItemName]", objConn);

            cmdSearchAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdSearchAccount.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = ItemName;

            cmdSearchAccount.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdSearchAccount.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.AccountNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.Discription = Validation.GetSafeString(oReader["Description"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemById(Guid IdItem, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemById]", objConn);

            cmdItem.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.IdCategory = Validation.GetSafeGuid(oReader["Category_Id"]);
                oelItems.IdTradingCo = Validation.GetSafeGuid(oReader["Trading_Id"]);
                oelItems.TradingCode = Validation.GetSafeString(oReader["Trading_Name"]);
                oelItems.AccountNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ProductCode = Validation.GetSafeString(oReader["ItemCode"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.CategoryName = Validation.GetSafeString(oReader["Category_Name"]);
                //oelItems.BatchNo = Validation.GetSafeString(oReader["BatchNo"]);
                oelItems.MRP = Validation.GetSafeDecimal(oReader["MRP"]);
                //oelItems.UnitPrice = Validation.GetSafeDecimal(oReader["UnitPrice"]);
                oelItems.BarCode = Validation.GetSafeString(oReader["BarCode"]);
                //oelItems.StockOnHand = Validation.GetSafeInteger(oReader["StockOnHand"]);
                oelItems.ReorderLevel = Validation.GetSafeInteger(oReader["ReorderLevel"]);
                oelItems.IsRazing = Validation.GetSafeBooleanNullable(oReader["IsRazing"]);
                oelItems.IsMandatory = Validation.GetSafeBooleanNullable(oReader["IsMandatory"]);
                oelItems.CuttingRates = Validation.GetSafeDecimal(oReader["CuttingRate"]);
                oelItems.CuttingWages = Validation.GetSafeDecimal(oReader["CuttingWages"]);
                //oelItems.StockOnHandDate = Convert.ToDateTime(oReader["OnHandDate"]);
                //oelItems.CreatedDateTime = Convert.ToDateTime(oReader["StockInHandDate"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemByName(string ItemName, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemByName]", objConn);

            cmdItem.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = ItemName;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.IdCategory = Validation.GetSafeGuid(oReader["Category_Id"]);
                oelItems.IdTradingCo = Validation.GetSafeGuid(oReader["Trading_Id"]);
                oelItems.TradingCode = Validation.GetSafeString(oReader["Trading_Name"]);
                oelItems.AccountNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ProductCode = Validation.GetSafeString(oReader["ItemCode"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.CategoryName = Validation.GetSafeString(oReader["Category_Name"]);
                //oelItems.BatchNo = Validation.GetSafeString(oReader["BatchNo"]);
                oelItems.MRP = Validation.GetSafeDecimal(oReader["MRP"]);
                //oelItems.UnitPrice = Validation.GetSafeDecimal(oReader["UnitPrice"]);
                oelItems.BarCode = Validation.GetSafeString(oReader["BarCode"]);
                //oelItems.StockOnHand = Validation.GetSafeInteger(oReader["StockOnHand"]);
                oelItems.ReorderLevel = Validation.GetSafeInteger(oReader["ReorderLevel"]);
                oelItems.IsRazing = Validation.GetSafeBooleanNullable(oReader["IsRazing"]);
                oelItems.IsMandatory = Validation.GetSafeBooleanNullable(oReader["IsMandatory"]);
                oelItems.CuttingRates = Validation.GetSafeDecimal(oReader["CuttingRate"]);
                oelItems.CuttingWages = Validation.GetSafeDecimal(oReader["CuttingWages"]);
                //oelItems.StockOnHandDate = Convert.ToDateTime(oReader["OnHandDate"]);
                //oelItems.CreatedDateTime = Convert.ToDateTime(oReader["StockInHandDate"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemsByCategory(Guid IdCategory, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemsByCategory]", objConn);

            cmdItem.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.IdCategory = Validation.GetSafeGuid(oReader["Category_Id"]);
                oelItems.AccountNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ProductCode = Validation.GetSafeString(oReader["ItemCode"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.CategoryName = Validation.GetSafeString(oReader["Category_Name"]);
                //oelItems.PackingSize = Validation.GetSafeString(oReader["PackingSize"]);
                //oelItems.BatchNo = Validation.GetSafeString(oReader["BatchNo"]);
                oelItems.MRP = Validation.GetSafeDecimal(oReader["MRP"]);
                //oelItems.UnitPrice = Validation.GetSafeDecimal(oReader["UnitPrice"]);
                oelItems.BarCode = Validation.GetSafeString(oReader["BarCode"]);
                //oelItems.StockOnHand = Validation.GetSafeInteger(oReader["StockOnHand"]);
                //oelItems.ReorderLevel = Validation.GetSafeInteger(oReader["ReorderLevel"]);
                //oelItems.StockOnHandDate = Convert.ToDateTime(oReader["OnHandDate"]);
                //oelItems.CreatedDateTime = Convert.ToDateTime(oReader["StockInHandDate"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemsByCategoryType(string CategoryType, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemsByCategoryType]", objConn);

            cmdItem.Parameters.Add("@CategoryType", SqlDbType.VarChar).Value = CategoryType;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.IdCategory = Validation.GetSafeGuid(oReader["Category_Id"]);
                oelItems.AccountNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ProductCode = Validation.GetSafeString(oReader["ItemCode"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.CategoryName = Validation.GetSafeString(oReader["Category_Name"]);
                //oelItems.PackingSize = Validation.GetSafeString(oReader["PackingSize"]);
                //oelItems.BatchNo = Validation.GetSafeString(oReader["BatchNo"]);
                oelItems.MRP = Validation.GetSafeDecimal(oReader["MRP"]);
                //oelItems.UnitPrice = Validation.GetSafeDecimal(oReader["UnitPrice"]);
                oelItems.BarCode = Validation.GetSafeString(oReader["BarCode"]);
                //oelItems.StockOnHand = Validation.GetSafeInteger(oReader["StockOnHand"]);
                //oelItems.ReorderLevel = Validation.GetSafeInteger(oReader["ReorderLevel"]);
                //oelItems.StockOnHandDate = Convert.ToDateTime(oReader["OnHandDate"]);
                //oelItems.CreatedDateTime = Convert.ToDateTime(oReader["StockInHandDate"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemsCurrentStockByCategory(Guid IdCategory, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemsCurrentStockByCategory]", objConn);

            cmdItem.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.IdCurrentStock = Validation.GetSafeGuid(oReader["CurrentStock_Id"]);
                oelItems.IdCategory = Validation.GetSafeGuid(oReader["Category_Id"]);
                oelItems.AccountNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ProductCode = Validation.GetSafeString(oReader["ItemCode"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.CategoryName = Validation.GetSafeString(oReader["Category_Name"]);
                //oelItems.PackingSize = Validation.GetSafeString(oReader["PackingSize"]);
                //oelItems.BatchNo = Validation.GetSafeString(oReader["BatchNo"]);
                oelItems.MRP = Validation.GetSafeDecimal(oReader["MRP"]);
                oelItems.Qty = Validation.GetSafeDecimal(oReader["Units"]);
                oelItems.UnitPrice = Validation.GetSafeDecimal(oReader["UnitPrice"]);
                oelItems.CurrentUnitPrice = Validation.GetSafeDecimal(oReader["CurrentUnitPrice"]);
                oelItems.TotalAmount = Validation.GetSafeDecimal(oReader["TotalAmount"]);
                //oelItems.UnitPrice = Validation.GetSafeDecimal(oReader["UnitPrice"]);
                oelItems.BarCode = Validation.GetSafeString(oReader["BarCode"]);
                //oelItems.StockOnHand = Validation.GetSafeInteger(oReader["StockOnHand"]);
                //oelItems.ReorderLevel = Validation.GetSafeInteger(oReader["ReorderLevel"]);
                //oelItems.StockOnHandDate = Convert.ToDateTime(oReader["OnHandDate"]);
                //oelItems.CreatedDateTime = Convert.ToDateTime(oReader["StockInHandDate"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        //public EntityoperationInfo UpdateItem(ItemsEL oelItems, SqlConnection objConn)
        //{
        //    EntityoperationInfo infoResult = new EntityoperationInfo();

        //    SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_UpdateItems]", objConn);
        //    cmdItems.Connection = objConn;
        //    cmdItems.CommandType = CommandType.StoredProcedure;

        //    cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItems.IdItem;
        //    cmdItems.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelItems.IdCompany;
        //    cmdItems.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelItems.ItemNo;
        //    cmdItems.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelItems.ItemName;
        //    cmdItems.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelItems.PackingSize;
        //    cmdItems.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelItems.Discription;
        //    cmdItems.Parameters.Add(new SqlParameter("@Qty", DbType.Decimal)).Value = oelItems.Qty;
        //    cmdItems.Parameters.Add(new SqlParameter("@Balance", DbType.Decimal)).Value = oelItems.Balance;
        //    if (cmdItems.ExecuteNonQuery() > -1)
        //    {
        //        infoResult.IsSuccess = true;
        //    }
        //    else
        //    {
        //        infoResult.IsSuccess = false;
        //    }
        //    return infoResult;
        //}
        public List<ItemsEL> SearchStockByProductNo(Int64 ProductNo, Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdSearchStock = new SqlCommand("[Setup].[Proc_SearchStockByProductNo]", objConn);

            cmdSearchStock.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdSearchStock.Parameters.Add("@ProductNo", SqlDbType.BigInt).Value = ProductNo;

            cmdSearchStock.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdSearchStock.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.ItemNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ProductCode = Validation.GetSafeString(oReader["ItemCode"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.PackingSize = Validation.GetSafeString(oReader["PackingSize"]);
                oelItems.BatchNo = Validation.GetSafeString(oReader["BatchNo"]);
                oelItems.UnitPrice = Validation.GetSafeDecimal(oReader["UnitPrice"]);
                oelItems.BarCode = Validation.GetSafeString(oReader["BarCode"]);
                oelItems.StockOnHand = Validation.GetSafeInteger(oReader["StockOnHand"]);
                oelItems.ReorderLevel = Validation.GetSafeInteger(oReader["ReorderLevel"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> SearchStockByProductName(string ProductName, Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdSearchStock = new SqlCommand("[Setup].[Proc_SearchStockByProductName]", objConn);

            cmdSearchStock.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdSearchStock.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = ProductName;

            cmdSearchStock.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdSearchStock.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.ItemNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ProductCode = Validation.GetSafeString(oReader["ItemCode"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.PackingSize = Validation.GetSafeString(oReader["PackingSize"]);
                //oelItems.BatchNo = Validation.GetSafeString(oReader["BatchNo"]);
                //oelItems.UnitPrice = Validation.GetSafeDecimal(oReader["UnitPrice"]);
                oelItems.BarCode = Validation.GetSafeString(oReader["BarCode"]);
                //oelItems.StockOnHand = Validation.GetSafeInteger(oReader["StockOnHand"]);
                oelItems.ReorderLevel = Validation.GetSafeInteger(oReader["ReorderLevel"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetCurrentOpeningStockByItem(Guid IdItem, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetCurrentStockByItem]", objConn);

            cmdItem.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader objReader = cmdItem.ExecuteReader();
            while (objReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);

                oelItems.IdCurrentStock = Validation.GetSafeGuid(objReader["CurrentStock_Id"]);
                oelItems.Seq = Validation.GetSafeInteger(objReader["Seq"]);
                oelItems.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelItems.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                oelItems.Mfg = Validation.GetSafeString(objReader["Mfg"]);
                oelItems.Expiry = Validation.GetSafeString(objReader["Expiry"]);
                oelItems.Qty = Validation.GetSafeInteger(objReader["Units"]);
                oelItems.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                oelItems.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemByBatchAndExpiry(Guid IdItem, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemByBatchAndExpiry]", objConn);

            cmdItem.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader objReader = cmdItem.ExecuteReader();
            while (objReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelItems.Qty = Validation.GetSafeLong(objReader["Units"]);
                if (objReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemsAttributes(Guid IdItem, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemSizes]", objConn);

            cmdItem.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdSize = Validation.GetSafeGuid(oReader["Size_Id"]);
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.ItemSize = Validation.GetSafeString(oReader["Size"]);
                oelItems.Description = Validation.GetSafeString(oReader["Description"]);
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemsColorAttributes(Guid IdItem, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemColors]", objConn);

            cmdItem.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdColor = Validation.GetSafeGuid(oReader["Color_Id"]);
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.ItemColor = Validation.GetSafeString(oReader["Color"]);
                oelItems.Description = Validation.GetSafeString(oReader["Description"]);
                list.Add(oelItems);
            }
            return list;
        }
        public List<ItemsEL> GetItemAverageRate(Guid IdItem, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdChemicals = new SqlCommand("[Setup].[Proc_GetItemAverageRate]", objConn);
            cmdChemicals.CommandType = CommandType.StoredProcedure;
            cmdChemicals.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
            cmdChemicals.CommandType = CommandType.StoredProcedure;
            objReader = cmdChemicals.ExecuteReader();
            while (objReader.Read())
            {
                ItemsEL oelItem = new ItemsEL();
                oelItem.TotalAmount = Validation.GetSafeDecimal(objReader["AverageAmount"]);

                list.Add(oelItem);
            }

            return list;
        }
        public List<ItemsEL> GetItemStockWithBalance(Guid IdItem, Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Reports].[Proc_GetItemWiseStockAndBalance]", objConn);
            cmdItem.CommandType = CommandType.StoredProcedure;
            cmdItem.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdItem.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
            cmdItem.CommandType = CommandType.StoredProcedure;
            objReader = cmdItem.ExecuteReader();
            while (objReader.Read())
            {
                ItemsEL oelItem = new ItemsEL();
                oelItem.TotalAmount = Validation.GetSafeDecimal(objReader["AverageAmount"]);
                oelItem.Qty = Validation.GetSafeDecimal(objReader["Closing"]);
                list.Add(oelItem);
            }

            return list;
        }
        public List<ItemsEL> GetItemClosingStock(Guid IdCompany, Guid IdItem, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetItemClosingStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                ItemsEL oelItem = new ItemsEL();
                oelItem.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelItem.AccountName = Validation.GetSafeString(objReader["ItemName"]);                
                oelItem.Qty = Validation.GetSafeLong(objReader["Closing"]);
               

                list.Add(oelItem);
            }

            return list;
        }
        public List<ItemsEL> GetTanneryItemClosingStock(Guid IdCompany, Guid IdItem, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetTannertItemClosingStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                ItemsEL oelItem = new ItemsEL();
                oelItem.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelItem.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelItem.AccountName = Validation.GetSafeString(objReader["ItemName"]);
                oelItem.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelItem.Qty = Validation.GetSafeLong(objReader["closing"]);


                list.Add(oelItem);
            }

            return list;
        }
        public List<ItemsEL> GetRawLeatherItemClosingStock(Guid IdCompany, Guid IdItem, string VehicleNo, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetRawLeatherItemClosingStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            cmdStock.Parameters.Add("@VehicleNo", SqlDbType.VarChar).Value = VehicleNo;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                ItemsEL oelItem = new ItemsEL();
                oelItem.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelItem.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelItem.AccountName = Validation.GetSafeString(objReader["ItemName"]);
                oelItem.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelItem.Qty = Validation.GetSafeLong(objReader["closing"]);


                list.Add(oelItem);
            }

            return list;
        }
    }
}
