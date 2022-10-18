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
    public class ProductionProcessesDetailsDAL
    {
        public ProductionProcessesDetailsDAL()
        {

        }
        IDataReader objReader;
        public bool CreateProductionProcessesDetails(List<ProductionProcessDetailEL> oelProductionProcessDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProcessDetails = new SqlCommand("[Production].[Proc_CreateProductionProcessesDetails]", objConn, objTran);

            cmdProcessDetails.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelProductionProcessDetailCollection.Count; i++)
            {
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdProductionProcessDetails", DbType.Guid)).Value = oelProductionProcessDetailCollection[i].IdProductionProcessDetail;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProductionProcessDetailCollection[i].IdVoucher;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelProductionProcessDetailCollection[i].AccountNo;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProductionProcessDetailCollection[i].IdItem;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelProductionProcessDetailCollection[i].IdBrand;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@ItemSize", DbType.String)).Value = oelProductionProcessDetailCollection[i].ItemSize;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@UOM", DbType.String)).Value = oelProductionProcessDetailCollection[i].PackingSize;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@PackingStyle", DbType.String)).Value = oelProductionProcessDetailCollection[i].PStyle;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Quality", DbType.Int32)).Value = oelProductionProcessDetailCollection[i].Quality;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Quantity", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].Quantity;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@ReadyUnits", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].ReadyUnits;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Rejection", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].Rejection;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@BQuantity", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].BQuantity;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@RepairQuantity", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].RepairQuantity;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@PackingCartons", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].PackingCartons;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Rate", DbType.Decimal)).Value = oelProductionProcessDetailCollection[i].Rate;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProductionProcessDetailCollection[i].Amount;

                cmdProcessDetails.Parameters.Add(new SqlParameter("@InspectorRate", DbType.Decimal)).Value = oelProductionProcessDetailCollection[i].InspectorRate;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@InspectorAmount", DbType.Decimal)).Value = oelProductionProcessDetailCollection[i].InspectorAmount;

                cmdProcessDetails.ExecuteNonQuery();
                cmdProcessDetails.Parameters.Clear();
            }

            return true;
        }
        public bool UpdateProductionProcessesDetails(List<ProductionProcessDetailEL> oelProductionProcessDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProcessDetails = new SqlCommand("[Production].[Proc_UpdateProductionProcessesDetails]", objConn, objTran);
            cmdProcessDetails.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelProductionProcessDetailCollection.Count; i++)
            {
                if (oelProductionProcessDetailCollection[i].IsNew)
                {
                    cmdProcessDetails.CommandText = "[Production].[Proc_CreateProductionProcessesDetails]";
                }
                else
                {
                    cmdProcessDetails.CommandText = "[Production].[Proc_UpdateProductionProcessesDetails]";
                }
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdProductionProcessDetails", DbType.Guid)).Value = oelProductionProcessDetailCollection[i].IdProductionProcessDetail;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProductionProcessDetailCollection[i].IdVoucher;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelProductionProcessDetailCollection[i].AccountNo;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProductionProcessDetailCollection[i].IdItem;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelProductionProcessDetailCollection[i].IdBrand;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@ItemSize", DbType.String)).Value = oelProductionProcessDetailCollection[i].ItemSize;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@UOM", DbType.String)).Value = oelProductionProcessDetailCollection[i].PackingSize;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@PackingStyle", DbType.String)).Value = oelProductionProcessDetailCollection[i].PStyle;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Quality", DbType.Int32)).Value = oelProductionProcessDetailCollection[i].Quality;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Quantity", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].Quantity;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@ReadyUnits", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].ReadyUnits;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Rejection", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].Rejection;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@BQuantity", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].BQuantity;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@RepairQuantity", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].RepairQuantity;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@PackingCartons", DbType.Int64)).Value = oelProductionProcessDetailCollection[i].PackingCartons;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Rate", DbType.Decimal)).Value = oelProductionProcessDetailCollection[i].Rate;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProductionProcessDetailCollection[i].Amount;

                cmdProcessDetails.Parameters.Add(new SqlParameter("@InspectorRate", DbType.Decimal)).Value = oelProductionProcessDetailCollection[i].InspectorRate;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@InspectorAmount", DbType.Decimal)).Value = oelProductionProcessDetailCollection[i].InspectorAmount;

                cmdProcessDetails.ExecuteNonQuery();
                cmdProcessDetails.Parameters.Clear();

            }

            return true;
        }
        public bool DeleteProductionProcessesDetails(Guid Id, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProductionProcessDetails = new SqlCommand("[Production].[Proc_DeleteProductionProcessesDetails]", objConn);
            cmdProductionProcessDetails.CommandType = CommandType.StoredProcedure;
            cmdProductionProcessDetails.Parameters.Add(new SqlParameter("@IdProductionProcessDetails", DbType.Guid)).Value = Id;

            cmdProductionProcessDetails.ExecuteNonQuery();
            cmdProductionProcessDetails.Parameters.Clear();

            return true;
        }
        public List<ProductionProcessesEL> GetProcessDetailByName(string ProcessName, SqlConnection objConn)
        {
            List<ProductionProcessesEL> list = new List<ProductionProcessesEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetProcessDetailByProcessName]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessesEL oelProces = new ProductionProcessesEL();

                oelProces.IdProductionProcess = Validation.GetSafeGuid(objReader["Process_Id"]);

                list.Add(oelProces);
            }
            return list;
        }
        public List<TanneryProcessDetailsEL> GetProcessesDetailByVehicleAndProcess(Guid IdCompany, string ProcessName, string VehicleNo, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Tannery].[Proc_GetProcessesDetailByVehicleAndProcess]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = VehicleNo;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessDetailsEL oelProcessDetail = new TanneryProcessDetailsEL();
                oelProcessDetail.IdProcessDetail = Validation.GetSafeGuid(objReader["ProcessDetails_Id"]);
                oelProcessDetail.IdProcess = Validation.GetSafeGuid(objReader["Process_Id"]);
                oelProcessDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProcessDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                oelProcessDetail.PostingNo = Validation.GetSafeLong(objReader["PostingNo"]);
                if (DBNull.Value != objReader["Posted"])
                {
                    oelProcessDetail.Posted = Convert.ToBoolean(objReader["Posted"]);
                }
                else
                {
                    oelProcessDetail.Posted = false;
                }
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelProcessDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelProcessDetail.Galma = Validation.GetSafeInteger(objReader["Galma"]);
                oelProcessDetail.GalmaPieces = Validation.GetSafeInteger(objReader["GalmaPieces"]);
                oelProcessDetail.Puttha = Validation.GetSafeInteger(objReader["Puttha"]);
                oelProcessDetail.PutthaPieces = Validation.GetSafeInteger(objReader["PutthaPieces"]);
                oelProcessDetail.DGalma = Validation.GetSafeInteger(objReader["DGalma"]);
                oelProcessDetail.DPuttha = Validation.GetSafeInteger(objReader["DPuttha"]);
                oelProcessDetail.Pieces = Validation.GetSafeInteger(objReader["Pieces"]);
                oelProcessDetail.WorkDate = Convert.ToDateTime(objReader["WorkDate"]);
                oelProcessDetail.SSet = Validation.GetSafeInteger(objReader["Sset"]);
                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<ProductionProcessDetailEL> GetGarmentProcessesDetailByVoucherNoAndProcess(Guid IdCompany, string ProcessName, Int64 VoucherNo, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetGarmentsProcessesDetailByVoucherAndProcess]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = VoucherNo;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelProcessDetail = new ProductionProcessDetailEL();
                oelProcessDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProcessDetail.CustomerPO = Validation.GetSafeString(objReader["CustomerPoNo"]);

                oelProcessDetail.IdProductionProcess = Validation.GetSafeGuid(objReader["Process_Id"]);
                oelProcessDetail.IdProductionProcessDetail = Validation.GetSafeGuid(objReader["ProductionProcessDetails_Id"]);
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.IdPosting = Validation.GetSafeGuid(objReader["Posting_Id"]);
                oelProcessDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.ItemSize = Validation.GetSafeString(objReader["ItemSize"]);
                oelProcessDetail.IdColor = Validation.GetSafeGuid(objReader["Color_Id"]);
                oelProcessDetail.ItemColor = Validation.GetSafeString(objReader["Color"]);
                oelProcessDetail.GType = Validation.GetSafeInteger(objReader["Gtype"]);
                oelProcessDetail.GarmentWorkType = Validation.GetSafeInteger(objReader["WorkType"]);
                oelProcessDetail.Quality = Validation.GetSafeInteger(objReader["Quality"]);
                oelProcessDetail.Quantity = Validation.GetSafeInteger(objReader["Quantity"]);
                oelProcessDetail.ReadyUnits = Validation.GetSafeInteger(objReader["ReadyUnits"]);
                oelProcessDetail.Rejection = Validation.GetSafeInteger(objReader["Rejection"]);

                oelProcessDetail.Meters = Validation.GetSafeDecimal(objReader["Meters"]);
                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                oelProcessDetail.WorkDate = Validation.GetSafeDateTime(objReader["WorkDate"]);
                oelProcessDetail.Posted = Convert.ToBoolean(objReader["Posted"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<ProductionProcessDetailEL> GetProductionProcessDetailByVoucherNoAndProductionType(Guid IdCompany, Int64 VoucherNo, int WorkType, int ProductionType, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetProductionProcessDetailByVoucherNoAndProductionType]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = VoucherNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Int64)).Value = WorkType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int64)).Value = ProductionType;

            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelProcessDetail = new ProductionProcessDetailEL();
                oelProcessDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProcessDetail.VDate = Convert.ToDateTime(objReader["VDate"]);
                oelProcessDetail.CustomerPO = Validation.GetSafeString(objReader["CustomerPoNo"]);
                oelProcessDetail.WorkType = Validation.GetSafeInteger(objReader["WorkType"]);
                oelProcessDetail.ProductionType = Validation.GetSafeInteger(objReader["ProductionType"]);
                oelProcessDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                oelProcessDetail.Posted = Convert.ToBoolean(objReader["Posted"]);

                oelProcessDetail.IdProductionProcessDetail = Validation.GetSafeGuid(objReader["ProductionProcessDetails_Id"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.LinkAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                oelProcessDetail.LinkAccountName = Validation.GetSafeString(objReader["EmpName"]);
                oelProcessDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.ItemSize = Validation.GetSafeString(objReader["ItemSize"]);
                oelProcessDetail.PackingSize = Validation.GetSafeString(objReader["UOM"]);
                oelProcessDetail.PStyle = Validation.GetSafeString(objReader["PackingStyle"]);
                oelProcessDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                oelProcessDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                oelProcessDetail.Quality = Validation.GetSafeInteger(objReader["Quality"]);
                oelProcessDetail.Quantity = Validation.GetSafeInteger(objReader["Quantity"]);
                oelProcessDetail.ReadyUnits = Validation.GetSafeInteger(objReader["ReadyUnits"]);
                oelProcessDetail.Rejection = Validation.GetSafeInteger(objReader["Rejection"]);
                oelProcessDetail.BQuantity = Validation.GetSafeInteger(objReader["BQuantity"]);
                oelProcessDetail.RepairQuantity = Validation.GetSafeLong(objReader["RepairQuantity"]);
                oelProcessDetail.PackingCartons = Validation.GetSafeLong(objReader["PackingCartons"]);

                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                oelProcessDetail.InspectorRate = Validation.GetSafeDecimal(objReader["InspectorRate"]);
                oelProcessDetail.InspectorAmount = Validation.GetSafeDecimal(objReader["InspectorAmount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<ProductionProcessDetailEL> GetGarmentProcessesDetailByCustomerPoNoAndProcess(Guid IdCompany, string ProcessName, string CustomerPo, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetGarmentsProcessesDetailByCustomerPoAndProcess]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@CustomerPo", DbType.String)).Value = CustomerPo;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelProcessDetail = new ProductionProcessDetailEL();
                oelProcessDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProcessDetail.CustomerPO = Validation.GetSafeString(objReader["CustomerPoNo"]);

                oelProcessDetail.IdProductionProcess = Validation.GetSafeGuid(objReader["Process_Id"]);
                oelProcessDetail.IdProductionProcessDetail = Validation.GetSafeGuid(objReader["ProductionProcessDetails_Id"]);
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.AccountType = Validation.GetSafeString(objReader["AccountType"]);
                oelProcessDetail.IdPosting = Validation.GetSafeGuid(objReader["Posting_Id"]);
                oelProcessDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.ItemSize = Validation.GetSafeString(objReader["ItemSize"]);
                oelProcessDetail.IdColor = Validation.GetSafeGuid(objReader["Color_Id"]);
                oelProcessDetail.ItemColor = Validation.GetSafeString(objReader["Color"]);
                oelProcessDetail.GType = Validation.GetSafeInteger(objReader["Gtype"]);
                oelProcessDetail.GarmentWorkType = Validation.GetSafeInteger(objReader["WorkType"]);
                oelProcessDetail.Quality = Validation.GetSafeInteger(objReader["Quality"]);
                oelProcessDetail.Quantity = Validation.GetSafeInteger(objReader["Quantity"]);
                oelProcessDetail.ReadyUnits = Validation.GetSafeInteger(objReader["ReadyUnits"]);
                oelProcessDetail.Rejection = Validation.GetSafeInteger(objReader["Rejection"]);

                oelProcessDetail.Meters = Validation.GetSafeDecimal(objReader["Meters"]);
                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                oelProcessDetail.WorkDate = Validation.GetSafeDateTime(objReader["WorkDate"]);
                oelProcessDetail.Posted = Convert.ToBoolean(objReader["Posted"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<ProductionProcessDetailEL> GetVendorDateWiseWorkReport(string AccountNo, int ProductionType, DateTime startDate, DateTime endDate, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetVendorDateWiseWorkReport]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProductionType", DbType.Boolean)).Value = ProductionType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = startDate;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = endDate;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelDetail = new ProductionProcessDetailEL();
                oelDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelDetail.ProductionProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelDetail.WorkDate = Convert.ToDateTime(objReader["WorkDate"]);
                oelDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelDetail);
            }
            return list;
        }
        public List<ProductionProcessDetailEL> GetOrderCosting(string CustomerPoNo, int ProductionType, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetOrderCosting]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@CustomerPoNo", DbType.String)).Value = CustomerPoNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProductionType", DbType.Boolean)).Value = ProductionType;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelDetail = new ProductionProcessDetailEL();
                oelDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelDetail.Amount = Validation.GetSafeDecimal(objReader["OrderCosting"]);

                list.Add(oelDetail);
            }
            return list;
        }
        public bool DeleteGarmentsProcessEntry(Guid IdEntry, Guid IdVoucher, SqlConnection objConn)
        {
            using (SqlTransaction oTran = objConn.BeginTransaction())
            {
                try
                {
                    SqlCommand cmdDelete = new SqlCommand("[Production].[Proc_DeleteGarmentProcessesDetailById]", objConn);
                    cmdDelete.Transaction = oTran;
                    cmdDelete.CommandType = CommandType.StoredProcedure;
                    cmdDelete.Parameters.Add("@IdEntry", SqlDbType.UniqueIdentifier).Value = IdEntry;
                    cmdDelete.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                    cmdDelete.ExecuteNonQuery();

                    oTran.Commit();
                }
                catch (Exception ex)
                {
                    oTran.Rollback();
                    throw ex;
                }
            }
            return true;
        }

        public List<ProductionProcessDetailEL> GetWorkerInspectionPackingReport(Guid IdCompany, string AccountNo, int WorkType, int ProductionType, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetWorkerInspectionAndPackingReport]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.String)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = AccountNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Int64)).Value = WorkType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int64)).Value = ProductionType;

            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelProcessDetail = new ProductionProcessDetailEL();
                oelProcessDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);

                oelProcessDetail.VDate = Convert.ToDateTime(objReader["VDate"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.ItemSize = Validation.GetSafeString(objReader["ItemSize"]);
                oelProcessDetail.PackingSize = Validation.GetSafeString(objReader["UOM"]);
                oelProcessDetail.PStyle = Validation.GetSafeString(objReader["PackingStyle"]);
                oelProcessDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                oelProcessDetail.Quality = Validation.GetSafeInteger(objReader["Quality"]);
                oelProcessDetail.Quantity = Validation.GetSafeInteger(objReader["Quantity"]);
                oelProcessDetail.ReadyUnits = Validation.GetSafeInteger(objReader["ReadyUnits"]);
                oelProcessDetail.Rejection = Validation.GetSafeInteger(objReader["Rejection"]);
                oelProcessDetail.BQuantity = Validation.GetSafeInteger(objReader["BQuantity"]);
                oelProcessDetail.RepairQuantity = Validation.GetSafeInteger(objReader["RepairQuantity"]);

                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                oelProcessDetail.InspectorRate = Validation.GetSafeDecimal(objReader["InspectorRate"]);
                oelProcessDetail.InspectorAmount = Validation.GetSafeDecimal(objReader["InspectorAmount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<ProductionProcessDetailEL> GetWorkerInspectionPackingReportByDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, int WorkType, int ProductionType, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetWorkerInspectionAndPackingReportByDate]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.String)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = AccountNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Int64)).Value = WorkType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int64)).Value = ProductionType;

            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelProcessDetail = new ProductionProcessDetailEL();
                oelProcessDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);

                oelProcessDetail.VDate = Convert.ToDateTime(objReader["VDate"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.ItemSize = Validation.GetSafeString(objReader["ItemSize"]);
                oelProcessDetail.PackingSize = Validation.GetSafeString(objReader["UOM"]);
                oelProcessDetail.PStyle = Validation.GetSafeString(objReader["PackingStyle"]);
                oelProcessDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                oelProcessDetail.Quality = Validation.GetSafeInteger(objReader["Quality"]);
                oelProcessDetail.Quantity = Validation.GetSafeInteger(objReader["Quantity"]);
                oelProcessDetail.ReadyUnits = Validation.GetSafeInteger(objReader["ReadyUnits"]);
                oelProcessDetail.Rejection = Validation.GetSafeInteger(objReader["Rejection"]);
                oelProcessDetail.BQuantity = Validation.GetSafeInteger(objReader["BQuantity"]);
                oelProcessDetail.RepairQuantity = Validation.GetSafeInteger(objReader["RepairQuantity"]);
                oelProcessDetail.PackingCartons = Validation.GetSafeLong(objReader["PackingCartons"]);

                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                oelProcessDetail.InspectorRate = Validation.GetSafeDecimal(objReader["InspectorRate"]);
                oelProcessDetail.InspectorAmount = Validation.GetSafeDecimal(objReader["InspectorAmount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<ProductionProcessDetailEL> GetStitcherWorkerInspectionReport(Guid IdCompany, string AccountNo, int WorkType, int ProductionType, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetStitcherWorkerInspectionReport]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.String)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = AccountNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Int64)).Value = WorkType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int64)).Value = ProductionType;

            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelProcessDetail = new ProductionProcessDetailEL();
                oelProcessDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);

                oelProcessDetail.VDate = Convert.ToDateTime(objReader["VDate"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.ItemSize = Validation.GetSafeString(objReader["ItemSize"]);
                oelProcessDetail.PackingSize = Validation.GetSafeString(objReader["UOM"]);
                oelProcessDetail.PStyle = Validation.GetSafeString(objReader["PackingStyle"]);
                oelProcessDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                oelProcessDetail.Quality = Validation.GetSafeInteger(objReader["Quality"]);
                oelProcessDetail.Quantity = Validation.GetSafeInteger(objReader["Quantity"]);
                oelProcessDetail.ReadyUnits = Validation.GetSafeInteger(objReader["ReadyUnits"]);
                oelProcessDetail.Rejection = Validation.GetSafeInteger(objReader["Rejection"]);
                oelProcessDetail.BQuantity = Validation.GetSafeInteger(objReader["BQuantity"]);
                oelProcessDetail.RepairQuantity = Validation.GetSafeInteger(objReader["RepairQuantity"]);

                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                oelProcessDetail.InspectorRate = Validation.GetSafeDecimal(objReader["InspectorRate"]);
                oelProcessDetail.InspectorAmount = Validation.GetSafeDecimal(objReader["InspectorAmount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<ProductionProcessDetailEL> GetStitcherWorkerInspectionReportByDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, int WorkType, int ProductionType, SqlConnection objConn)
        {
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Production].[Proc_GetStitcherWorkerInspectionReportByDate]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.String)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = AccountNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Int64)).Value = WorkType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int64)).Value = ProductionType;

            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessDetailEL oelProcessDetail = new ProductionProcessDetailEL();
                oelProcessDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);

                oelProcessDetail.VDate = Convert.ToDateTime(objReader["VDate"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.ItemSize = Validation.GetSafeString(objReader["ItemSize"]);
                oelProcessDetail.PackingSize = Validation.GetSafeString(objReader["UOM"]);
                oelProcessDetail.PStyle = Validation.GetSafeString(objReader["PackingStyle"]);
                oelProcessDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                oelProcessDetail.Quality = Validation.GetSafeInteger(objReader["Quality"]);
                oelProcessDetail.Quantity = Validation.GetSafeInteger(objReader["Quantity"]);
                oelProcessDetail.ReadyUnits = Validation.GetSafeInteger(objReader["ReadyUnits"]);
                oelProcessDetail.Rejection = Validation.GetSafeInteger(objReader["Rejection"]);
                oelProcessDetail.BQuantity = Validation.GetSafeInteger(objReader["BQuantity"]);
                oelProcessDetail.RepairQuantity = Validation.GetSafeInteger(objReader["RepairQuantity"]);

                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public DataTable GetStitcherArticleWiseCrossTabInfo(string AccountNo, SqlConnection objConn)
        {
            SqlCommand cmdStitcherInfo = new SqlCommand("[Production].[Proc_GetStitcherArticleWiseInfo]", objConn);
            cmdStitcherInfo.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
            cmdStitcherInfo.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter DAStitcher = new SqlDataAdapter(cmdStitcherInfo);            
            DataTable dt = new DataTable();
            DAStitcher.Fill(dt);
            return dt;
        }

        public List<VoucherDetailEL> GetReadyToInspectionStockByArticle(Guid IdArticle, int ProductionType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetReadyToInspectionStockByArticle]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = IdArticle;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();
                   
                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    obj.Units = Validation.GetSafeLong(objReader["ReadyForInspection"]);
                    obj.Qty = Validation.GetSafeLong(objReader["PassQty"]);
                    obj.GatePassType = Validation.GetSafeString(objReader["GatePass"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetReadyToInspectionStockForAllArticles(int ProductionType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetReadyToInspectionStockForAllArticles]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    obj.Units = Validation.GetSafeLong(objReader["ReadyForInspection"]);
                    obj.Qty = Validation.GetSafeLong(objReader["PassQty"]);
                    obj.RemainingUnits = Validation.GetSafeLong(objReader["Remaining"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetReadyToPackingStockByArticle(Guid IdArticle, int ProductionType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetReadyToPackingStockByArticle]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = IdArticle;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    obj.Units = Validation.GetSafeLong(objReader["ReadyForPacking"]);
                    obj.Qty = Validation.GetSafeLong(objReader["Packed"]);
                    obj.GatePassType = Validation.GetSafeString(objReader["GatePass"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetReadyToPackingStockForAllArticles(int ProductionType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetReadyToPackingStockForAllArticles]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    obj.Units = Validation.GetSafeLong(objReader["ReadyForPacking"]);
                    obj.Qty = Validation.GetSafeLong(objReader["Packed"]);
                    obj.RemainingUnits = Validation.GetSafeLong(objReader["Remaining"]);
                    list.Add(obj);
                }
            }
            return list;
        }

       
        public List<VoucherDetailEL> GetGlovesRepairableClosingStock(Guid IdItem, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            SqlCommand cmdStock = new SqlCommand("[Production].[Proc_GetGlovesRepairableClosingStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                VoucherDetailEL oelItem = new VoucherDetailEL();
                oelItem.ClosingUnits = Validation.GetSafeLong(objReader["Closing"]);


                list.Add(oelItem);
            }

            return list;
        }
        public List<VoucherDetailEL> GetGlovesGarmentsRejectionClosingStock(Guid IdItem, int ProductionType, int SaleType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            SqlCommand cmdStock = new SqlCommand("[Production].[Proc_GetGlovesGarmentsRejectionClosingStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            cmdStock.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
            cmdStock.Parameters.Add("@SaleType", SqlDbType.Int).Value = SaleType;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                VoucherDetailEL oelItem = new VoucherDetailEL();
                oelItem.ClosingUnits = Validation.GetSafeLong(objReader["Closing"]);


                list.Add(oelItem);
            }

            return list;
        }
        public List<VoucherDetailEL> GetRepairStockByArticle(Guid IdArticle, int ProductionType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRepairStockByArticle]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = IdArticle;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    obj.Units = Validation.GetSafeLong(objReader["RepairStock"]);
                    obj.Qty = Validation.GetSafeLong(objReader["RepairQuantity"]);
                    obj.GatePassType = Validation.GetSafeString(objReader["GatePass"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetRepairStockForAllArticles(int ProductionType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRepairStockForAllArticles]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    obj.Units = Validation.GetSafeLong(objReader["RepairQuantity"]);
                    obj.Qty = Validation.GetSafeLong(objReader["RepairIssuance"]);
                    obj.RemainingUnits = Validation.GetSafeLong(objReader["Remaining"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetRepairStockByArticleAndWorker(Guid IdArticle, int ProductionType, string AccountNo, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRepairStockByArticleAndWorker]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = IdArticle;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    obj.Units = Validation.GetSafeLong(objReader["RepairStock"]);
                    obj.Qty = Validation.GetSafeLong(objReader["RepairQuantity"]);
                    obj.GatePassType = Validation.GetSafeString(objReader["GatePass"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetGlovesGarmentsRejectionStockByArticle(Guid IdArticle, int ProductionType, int SaleType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetGlovesGarmentsRejectionStockByArticle]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = IdArticle;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                cmdRequisition.Parameters.Add(new SqlParameter("@SaleType", DbType.Int32)).Value = SaleType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    obj.Units = Validation.GetSafeLong(objReader["Rejection"]);
                    obj.Qty = Validation.GetSafeLong(objReader["RejectionSold"]);
                    obj.GatePassType = Validation.GetSafeString(objReader["GatePass"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetGlovesGarmentsTotalCartonsStockByArticle(Guid IdArticle, int ProductionType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetGlovesGarmentsTotalCartonsStockByArticle]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = IdArticle;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    obj.Units = Validation.GetSafeLong(objReader["PackingCartons"]);
                    obj.Qty = Validation.GetSafeLong(objReader["SoldOut"]);
                    obj.GatePassType = Validation.GetSafeString(objReader["GatePass"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetGlovesGarmentsTotalCartonsClosingStock(Guid IdItem, int ProductionType, int SaleType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            SqlCommand cmdStock = new SqlCommand("[Production].[Proc_GetGlovesGarmentsTotalCartonsClosingStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            cmdStock.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
            cmdStock.Parameters.Add("@SaleType", SqlDbType.Int).Value = SaleType;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                VoucherDetailEL oelItem = new VoucherDetailEL();
                oelItem.ClosingUnits = Validation.GetSafeLong(objReader["Closing"]);


                list.Add(oelItem);
            }

            return list;
        }

        public List<VoucherDetailEL> GetRepairStockByStitcher(string AccountNo, int ProductionType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRepairStockByMaker]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.String)).Value = ProductionType;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    obj.Units = Validation.GetSafeLong(objReader["RepairStock"]);
                    obj.Qty = Validation.GetSafeLong(objReader["RepairQuantity"]);
                    obj.GatePassType = Validation.GetSafeString(objReader["GatePass"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetRepairStockForAllArticlesByStitcher(int ProductionType, string AccountNo, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRepairStockForAllArticlesByMaker]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int16)).Value = ProductionType;
                cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL obj = new VoucherDetailEL();

                    obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    obj.Units = Validation.GetSafeLong(objReader["RepairQuantity"]);
                    obj.Qty = Validation.GetSafeLong(objReader["RepairIssuance"]);
                    obj.RemainingUnits = Validation.GetSafeLong(objReader["Remaining"]);
                    list.Add(obj);
                }
            }
            return list;
        }
    }
}
