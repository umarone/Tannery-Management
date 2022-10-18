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
    public class ProductionMaterialsDAL
    {
        IDataReader objReader;
        public bool CreateMaterialsUsed(List<ProductionMaterialUsedEL> oelMaterialsCollection, List<ProductionMaterialUsedEL> oelMaterialsWastageCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            SqlCommand cmdMaterials = new SqlCommand("[Production].[Proc_CreateMaterialUsed]", objConn, objTran);
            for (int i = 0; i < oelMaterialsCollection.Count; i++)
            {
                if (oelMaterialsCollection[i].IsNew)
                {
                    cmdMaterials.CommandText = "[Production].[Proc_CreateMaterialUsed]";
                }
                else
                {
                    cmdMaterials.CommandText = "[Production].[Proc_UpdateMaterialUsed]";
                }
                cmdMaterials.CommandType = CommandType.StoredProcedure;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdMaterial", DbType.Guid)).Value = oelMaterialsCollection[i].IdMaterialUsed;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelMaterialsCollection[i].IdVoucher;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelMaterialsCollection[i].IdItem;
                cmdMaterials.Parameters.Add(new SqlParameter("@UsedQuantity", DbType.Int64)).Value = oelMaterialsCollection[i].UsedQuantity;
                cmdMaterials.Parameters.Add(new SqlParameter("@CurrentQuantity", DbType.Int64)).Value = oelMaterialsCollection[i].CurrentStock;
                cmdMaterials.Parameters.Add(new SqlParameter("@ProcessHead", DbType.Int64)).Value = oelMaterialsCollection[i].ProcessType;
                cmdMaterials.Parameters.Add(new SqlParameter("@SubProcessHead", DbType.Int64)).Value = oelMaterialsCollection[i].ProductionProcessName;
                cmdMaterials.Parameters.Add(new SqlParameter("@VDate", DbType.Int64)).Value = oelMaterialsCollection[i].VDate;
                cmdMaterials.ExecuteNonQuery();
                cmdMaterials.Parameters.Clear();
            }
            CreateMaterialWastage(oelMaterialsWastageCollection, objConn, objTran);
            return true;
        }
        public bool CreateMaterialsUsed(List<ProductionMaterialUsedEL> oelMaterialsCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdMaterials = new SqlCommand("[Production].[Proc_CreateMaterialUsed]", objConn, objTran);
                for (int i = 0; i < oelMaterialsCollection.Count; i++)
                {
                    cmdMaterials.CommandType = CommandType.StoredProcedure;
                    cmdMaterials.Parameters.Add(new SqlParameter("@IdMaterial", DbType.Guid)).Value = oelMaterialsCollection[i].IdMaterialUsed;
                    cmdMaterials.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelMaterialsCollection[i].IdVoucher;
                    cmdMaterials.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelMaterialsCollection[i].IdItem;
                    cmdMaterials.Parameters.Add(new SqlParameter("@UsedQuantity", DbType.Int64)).Value = oelMaterialsCollection[i].UsedQuantity;
                    cmdMaterials.Parameters.Add(new SqlParameter("@CurrentQuantity", DbType.Int64)).Value = oelMaterialsCollection[i].CurrentStock;
                    cmdMaterials.ExecuteNonQuery();
                    cmdMaterials.Parameters.Clear();
                }

                objTran.Commit();
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                objTran.Dispose();
            }
            finally
            {
                objTran.Dispose();
            }
            return true;
        }
        public bool UpdateMaterialsUsed(List<ProductionMaterialUsedEL> oelMaterialsCollection, List<ProductionMaterialUsedEL> oelMaterialsWastageCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            SqlCommand cmdMaterials = new SqlCommand("[Production].[Proc_UpdateMaterialUsed]", objConn, objTran);
            cmdMaterials.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelMaterialsCollection.Count; i++)
            {
                if (oelMaterialsCollection[i].IsNew)
                {
                    cmdMaterials.CommandText = "[Production].[Proc_CreateMaterialUsed]";
                }
                else
                {
                    cmdMaterials.CommandText = "[Production].[Proc_UpdateMaterialUsed]";
                }
                cmdMaterials.Parameters.Add(new SqlParameter("@IdMaterial", DbType.Guid)).Value = oelMaterialsCollection[i].IdMaterialUsed;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelMaterialsCollection[i].IdVoucher;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelMaterialsCollection[i].IdItem;
                cmdMaterials.Parameters.Add(new SqlParameter("@UsedQuantity", DbType.Int64)).Value = oelMaterialsCollection[i].UsedQuantity;
                cmdMaterials.Parameters.Add(new SqlParameter("@CurrentQuantity", DbType.Int64)).Value = oelMaterialsCollection[i].CurrentStock;
                cmdMaterials.ExecuteNonQuery();
                cmdMaterials.Parameters.Clear();
            }
            if (oelMaterialsWastageCollection.Count > 0)
            {
                UpdateMaterialsWastage(oelMaterialsWastageCollection, objConn, objTran);
            }
            return true;
        }
        public bool UpdateMaterialsUsed(List<ProductionMaterialUsedEL> oelMaterialsCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdMaterials = new SqlCommand("[Production].[Proc_UpdateMaterialUsed]", objConn, objTran);
                cmdMaterials.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < oelMaterialsCollection.Count; i++)
                {
                    if (oelMaterialsCollection[i].IsNew)
                    {
                        cmdMaterials.CommandText = "[Production].[Proc_CreateMaterialUsed]";
                    }
                    else
                    {
                        cmdMaterials.CommandText = "[Production].[Proc_UpdateMaterialUsed]";
                    }
                    cmdMaterials.Parameters.Add(new SqlParameter("@IdMaterial", DbType.Guid)).Value = oelMaterialsCollection[i].IdMaterialUsed;
                    cmdMaterials.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelMaterialsCollection[i].IdVoucher;
                    cmdMaterials.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelMaterialsCollection[i].IdItem;
                    cmdMaterials.Parameters.Add(new SqlParameter("@UsedQuantity", DbType.Int64)).Value = oelMaterialsCollection[i].UsedQuantity;
                    cmdMaterials.Parameters.Add(new SqlParameter("@CurrentQuantity", DbType.Int64)).Value = oelMaterialsCollection[i].CurrentStock;
                    cmdMaterials.ExecuteNonQuery();
                    cmdMaterials.Parameters.Clear();
                }
                objTran.Commit();
            }
            catch (Exception)
            {
                objTran.Rollback();
                objTran.Dispose();
            }
            finally
            {
                objTran.Dispose();
            }
            return true;
        }
        public bool CreateMaterialWastage(List<ProductionMaterialUsedEL> oelMaterialsWastageCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdMaterials = new SqlCommand("[Production].[Proc_CreateMaterialWastage]", objConn, objTran);
            for (int i = 0; i < oelMaterialsWastageCollection.Count; i++)
            {
                if (oelMaterialsWastageCollection[i].IsNew)
                {
                    cmdMaterials.CommandText = "[Production].[Proc_CreateMaterialWastage]";
                }
                else
                {
                    cmdMaterials.CommandText = "[Production].[Proc_UpdateMaterialWastage]";
                }
                cmdMaterials.CommandType = CommandType.StoredProcedure;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdMaterial", DbType.Guid)).Value = oelMaterialsWastageCollection[i].IdMaterialUsed;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelMaterialsWastageCollection[i].IdVoucher;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelMaterialsWastageCollection[i].IdItem;
                cmdMaterials.Parameters.Add(new SqlParameter("@UsedQuantity", DbType.Int64)).Value = oelMaterialsWastageCollection[i].UsedQuantity;
                cmdMaterials.Parameters.Add(new SqlParameter("@CurrentQuantity", DbType.Int64)).Value = oelMaterialsWastageCollection[i].CurrentStock;
                cmdMaterials.Parameters.Add(new SqlParameter("@ProcessHead", DbType.Int64)).Value = oelMaterialsWastageCollection[i].ProcessType;
                cmdMaterials.Parameters.Add(new SqlParameter("@SubProcessHead", DbType.Int64)).Value = oelMaterialsWastageCollection[i].ProductionProcessName;
                cmdMaterials.Parameters.Add(new SqlParameter("@VDate", DbType.Int64)).Value = oelMaterialsWastageCollection[i].VDate;
                cmdMaterials.ExecuteNonQuery();
                cmdMaterials.Parameters.Clear();
            }
            if (oelMaterialsWastageCollection.Count > 0)
            {
                CreateMaterialWastage(oelMaterialsWastageCollection, objConn, objTran);
            }
            return true;
        }
        public bool UpdateMaterialsWastage(List<ProductionMaterialUsedEL> oelMaterialsWastageCollection, SqlConnection objConn, SqlTransaction objTran)
        {

            SqlCommand cmdMaterials = new SqlCommand("[Production].[Proc_UpdateMaterialWastage]", objConn, objTran);
            cmdMaterials.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelMaterialsWastageCollection.Count; i++)
            {
                if (oelMaterialsWastageCollection[i].IsNew)
                {
                    cmdMaterials.CommandText = "[Production].[Proc_CreateMaterialUsed]";
                }
                else
                {
                    cmdMaterials.CommandText = "[Production].[Proc_UpdateMaterialUsed]";
                }
                cmdMaterials.Parameters.Add(new SqlParameter("@IdMaterial", DbType.Guid)).Value = oelMaterialsWastageCollection[i].IdMaterialUsed;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelMaterialsWastageCollection[i].IdVoucher;
                cmdMaterials.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelMaterialsWastageCollection[i].IdItem;
                cmdMaterials.Parameters.Add(new SqlParameter("@UsedQuantity", DbType.Int64)).Value = oelMaterialsWastageCollection[i].UsedQuantity;
                cmdMaterials.Parameters.Add(new SqlParameter("@CurrentQuantity", DbType.Int64)).Value = oelMaterialsWastageCollection[i].CurrentStock;
                cmdMaterials.ExecuteNonQuery();
                cmdMaterials.Parameters.Clear();
            }
            return true;
        }
        public List<ProductionMaterialUsedEL> GetProductionMaterialByVoucher(Guid IdVoucher, int ProcessHead, string SubProcessHead, SqlConnection objConn)
        {
            List<ProductionMaterialUsedEL> list = new List<ProductionMaterialUsedEL>();
            SqlCommand cmdMaterialDetail = new SqlCommand("[Production].[Proc_GetProductionMaterialByVoucher]", objConn);
            cmdMaterialDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdMaterialDetail.Parameters.Add(new SqlParameter("@ProcessHead", DbType.Guid)).Value = ProcessHead;
            cmdMaterialDetail.Parameters.Add(new SqlParameter("@SubProcessHead", DbType.Guid)).Value = SubProcessHead;
            cmdMaterialDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdMaterialDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionMaterialUsedEL oelProductionMaterial = new ProductionMaterialUsedEL();
                oelProductionMaterial.IdMaterialUsed = Validation.GetSafeGuid(objReader["Material_Id"]);
                oelProductionMaterial.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProductionMaterial.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelProductionMaterial.ItemName = Validation.GetSafeString(objReader["ItemName"]);

                oelProductionMaterial.UsedQuantity = Validation.GetSafeLong(objReader["UsedQuantity"]);
                oelProductionMaterial.CurrentStock = Validation.GetSafeLong(objReader["CurrentQuantity"]);
                oelProductionMaterial.VDate = Convert.ToDateTime(objReader["VDate"]);


                list.Add(oelProductionMaterial);
            }
            return list;
        }
        public List<ProductionMaterialUsedEL> GetProductionWastageByVoucher(Guid IdVoucher, int ProcessHead, string SubProcessHead, SqlConnection objConn)
        {
            List<ProductionMaterialUsedEL> list = new List<ProductionMaterialUsedEL>();
            SqlCommand cmdMaterialDetail = new SqlCommand("[Production].[Proc_GetProductionMaterialWastageByVoucher]", objConn);
            cmdMaterialDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdMaterialDetail.Parameters.Add(new SqlParameter("@ProcessHead", DbType.Guid)).Value = ProcessHead;
            cmdMaterialDetail.Parameters.Add(new SqlParameter("@SubProcessHead", DbType.Guid)).Value = SubProcessHead;
            cmdMaterialDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdMaterialDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionMaterialUsedEL oelProductionWastage = new ProductionMaterialUsedEL();
                oelProductionWastage.IdMaterialUsed = Validation.GetSafeGuid(objReader["Material_Id"]);
                oelProductionWastage.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProductionWastage.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelProductionWastage.ItemName = Validation.GetSafeString(objReader["ItemName"]);

                oelProductionWastage.UsedQuantity = Validation.GetSafeLong(objReader["UsedQuantity"]);
                oelProductionWastage.CurrentStock = Validation.GetSafeLong(objReader["CurrentQuantity"]);
                oelProductionWastage.VDate = Convert.ToDateTime(objReader["VDate"]);


                list.Add(oelProductionWastage);
            }
            return list;
        }
        public EntityoperationInfo DeleteMaterialEntry(Guid Id, SqlConnection objConn)
        {
            EntityoperationInfo deleteInfo = new EntityoperationInfo();
            int rowsEffected = -1;
            using (SqlCommand cmdDeleteMaterial = new SqlCommand("[Production].[Proc_DeleteMaterialUsed]", objConn))
            {
                cmdDeleteMaterial.CommandType = CommandType.StoredProcedure;
                cmdDeleteMaterial.Parameters.Add("@IdMaterial", SqlDbType.BigInt).Value = Id;
                rowsEffected = Convert.ToInt32(cmdDeleteMaterial.ExecuteNonQuery());
                if (rowsEffected > -1)
                {
                    deleteInfo.IsSuccess = true;
                }
                else
                {
                    deleteInfo.IsSuccess = false;
                }
            }
            return deleteInfo;
        }        
        public EntityoperationInfo DeleteWastageEntry(Guid Id, SqlConnection objConn)
        {
            EntityoperationInfo deleteInfo = new EntityoperationInfo();
            int rowsEffected = -1;
            using (SqlCommand cmdDeleteWastage = new SqlCommand("[Production].[Proc_DeleteMaterialWastage]", objConn))
            {
                cmdDeleteWastage.CommandType = CommandType.StoredProcedure;
                cmdDeleteWastage.Parameters.Add("@IdMaterial", SqlDbType.BigInt).Value = Id;
                rowsEffected = Convert.ToInt32(cmdDeleteWastage.ExecuteNonQuery());
                if (rowsEffected > -1)
                {
                    deleteInfo.IsSuccess = true;
                }
                else
                {
                    deleteInfo.IsSuccess = false;
                }
            }
            return deleteInfo;
        }
    }
}
