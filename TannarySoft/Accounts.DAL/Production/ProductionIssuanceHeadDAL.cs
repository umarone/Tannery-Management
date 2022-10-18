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
    public class ProductionIssuanceHeadDAL
    {
        ProductionIssuanceDetailDAL dal;
        IDataReader objReader;       
        public ProductionIssuanceHeadDAL()
        {
            dal = new ProductionIssuanceDetailDAL();
        }
        public EntityoperationInfo InsertProductionIssuance(VouchersEL oelVoucher, List<VoucherDetailEL> oelProductionIssuanceCollection, bool WorkType, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdProductionIssuance = new SqlCommand("[Production].[Proc_CreateInventoryIssuanceHead]", objConn);

                try
                {
                    objTran = objConn.BeginTransaction();
                    cmdProductionIssuance.Transaction = objTran;
                    cmdProductionIssuance.CommandType = CommandType.StoredProcedure;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdInventoryIssuance", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IssuanceNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelVoucher.IdArticle;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    //cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = oelVoucher.IdDepartment;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@GatePassType", DbType.String)).Value = oelVoucher.GatePassType;
                    //cmdProductionIssuance.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = oelVoucher.PoNumber;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IssuanceType", DbType.Int64)).Value = oelVoucher.ProcessType;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@OperationType", DbType.Int64)).Value = oelVoucher.OperationType;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int64)).Value = oelVoucher.GPType;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@TotalUnits", DbType.Int64)).Value = oelVoucher.TotalUnits;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@TotalRate", DbType.Int64)).Value = oelVoucher.TotalRate;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Int64)).Value = oelVoucher.TotalAmount;                    
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IssuanceDate", DbType.Boolean)).Value = oelVoucher.CreatedDateTime;
                    cmdProductionIssuance.ExecuteNonQuery();

                    //// Insert Purchase Collection...
                    //if (!WorkType)
                    //{
                    //    dal.InsertProductionCuffTalliCuttingIssuanceDetail(oelProductionIssuanceCollection, objConn, objTran); 
                    //}
                    //else
                    {
                        dal.InsertProductionIssuanceDetail(oelProductionIssuanceCollection, objConn, objTran);
                    }
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
        public EntityoperationInfo UpdateProductionIssuance(VouchersEL oelVoucher, List<VoucherDetailEL> oelProductionCollection, bool WorkType, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdProductionIssuance = new SqlCommand("[Production].[Proc_UpdateInventoryIssuance]", objConn);
                try
                {
                    objTran = objConn.BeginTransaction();

                    cmdProductionIssuance.Transaction = objTran;
                    cmdProductionIssuance.CommandType = CommandType.StoredProcedure;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdInventoryIssuance", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IssuanceNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelVoucher.IdArticle;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    //cmdProductionIssuance.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = oelVoucher.IdDepartment;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@GatePassType", DbType.String)).Value = oelVoucher.GatePassType;
                    //cmdProductionIssuance.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = oelVoucher.PoNumber;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IssuanceType", DbType.String)).Value = oelVoucher.ProcessType;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@OperationType", DbType.Int64)).Value = oelVoucher.OperationType;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int64)).Value = oelVoucher.GPType;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@TotalUnits", DbType.Int64)).Value = oelVoucher.TotalUnits;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@TotalRate", DbType.Int64)).Value = oelVoucher.TotalRate;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Int64)).Value = oelVoucher.TotalAmount;
                    cmdProductionIssuance.Parameters.Add(new SqlParameter("@IssuanceDate", DbType.Boolean)).Value = oelVoucher.CreatedDateTime;
                    cmdProductionIssuance.ExecuteNonQuery();

                    //if (!WorkType)
                    //{
                       // dal.UpdateProductionCuffTalliCuttingIssanceDetail(oelProductionCollection, objConn, objTran);
                    //}
                    //else
                    {
                        // Insert Process Collection...
                        dal.UpdateProductionIssanceDetail(oelProductionCollection, objConn, objTran);
                    }
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
        public Int64 GetMaxVoucherNumber(Guid IdCompany, int IssuanceType, int ProductionType, SqlConnection objConn)
        {
            using (SqlCommand cmdGatePass = new SqlCommand("[Production].[Proc_GetMaxGatePassNumberByType]", objConn))
            {
                cmdGatePass.CommandType = CommandType.StoredProcedure;
                cmdGatePass.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdGatePass.Parameters.Add("@IssuanceType", SqlDbType.Int).Value = IssuanceType;
                cmdGatePass.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                return Validation.GetSafeLong(cmdGatePass.ExecuteScalar());
            }
        }
        public List<VouchersEL> GetProductionIssuanceVoucherByNo(Int64 IssuanceNo, Guid IdCompany, int IssuanceType, int ProductionType, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetProductionIssuanceVoucherByNo]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdProduction.Parameters.Add(new SqlParameter("@IssuanceNo", DbType.Int64)).Value = IssuanceNo;
                cmdProduction.Parameters.Add("@IssuanceType", SqlDbType.Int).Value = IssuanceType;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelIssuanceDetail = new VouchersEL();
                    oelIssuanceDetail.IdVoucher = Validation.GetSafeGuid(objReader["ProductionIssuance_Id"]);
                    oelIssuanceDetail.IdArticle = Validation.GetSafeGuid(objReader["Article_Id"]);
                    oelIssuanceDetail.ArticleName = Validation.GetSafeString(objReader["ArticleName"]);
                    //oelIssuanceDetail.WorkType = Validation.GetSafeBooleanNullable(objReader["WorkType"]);
                    //oelIssuanceDetail.IdDepartment = Validation.GetSafeGuid(objReader["Department_Id"]);
                    oelIssuanceDetail.GatePassType = Validation.GetSafeString(objReader["GatePassType"]);
                    oelIssuanceDetail.ProcessType = Validation.GetSafeInteger(objReader["IssuanceType"]);
                    oelIssuanceDetail.OperationType = Validation.GetSafeInteger(objReader["OperationType"]);
                    oelIssuanceDetail.TotalUnits = Validation.GetSafeDecimal(objReader["TotalUnits"]);
                    oelIssuanceDetail.TotalRate = Validation.GetSafeDecimal(objReader["TotalRate"]);
                    oelIssuanceDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    oelIssuanceDetail.GPType = Validation.GetSafeInteger(objReader["ProductionType"]);
                    oelIssuanceDetail.Date = Convert.ToDateTime(objReader["IssuanceDate"]);
                    //oelIssuanceDetail.PoNumber = Validation.GetSafeString(objReader["PoNumber"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public bool DeleteGatePass(Guid IdVoucher, SqlConnection objConn)
        {
            using (SqlCommand cmdGatePass = new SqlCommand("[Transactions].[Proc_DeleteGatePass]", objConn))
            {
                cmdGatePass.CommandType = CommandType.StoredProcedure;
                cmdGatePass.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                cmdGatePass.ExecuteNonQuery();
                return true;
            }
        }
    }
}
