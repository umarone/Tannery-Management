﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.EL;
using System.Data.SqlClient;
using System.Data;
using Accounts.Common;

namespace Accounts.DAL
{
    public class CompanyDAL
    {
        IDataReader objReader;
        public CompanyDAL()
        { 
        
        }
        public EntityoperationInfo InsertCompany(CompanyEL oelCompany, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            using (SqlCommand cmdCompany = new SqlCommand("[Setup].[Proc_CreateCompany]", objConn))
            {
                cmdCompany.CommandType = CommandType.StoredProcedure;

                cmdCompany.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelCompany.IdCompany;
                cmdCompany.Parameters.Add(new SqlParameter("@CompanyName", DbType.String)).Value = oelCompany.CompanyName;
                cmdCompany.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelCompany.Discription;
                cmdCompany.Parameters.Add(new SqlParameter("@IsActive", DbType.String)).Value = oelCompany.IsActive;    
                cmdCompany.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelCompany.CreatedDateTime;

                if (cmdCompany.ExecuteNonQuery() > -1)
                {
                    InfoResult.IsSuccess = true;
                }
                else
                {
                    InfoResult.IsSuccess = false;
                }

            }
            return InfoResult;
        }
        public EntityoperationInfo UpdateCompany(CompanyEL oelCompany, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            using (SqlCommand cmdCompany = new SqlCommand("[Setup].[Proc_UpdateCompany]", objConn))
            {
                cmdCompany.CommandType = CommandType.StoredProcedure;

                cmdCompany.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelCompany.IdCompany;
                cmdCompany.Parameters.Add(new SqlParameter("@CompanyName", DbType.String)).Value = oelCompany.CompanyName;
                cmdCompany.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelCompany.Discription;
                cmdCompany.Parameters.Add(new SqlParameter("@IsActive", DbType.String)).Value = oelCompany.IsActive;    
                cmdCompany.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelCompany.CreatedDateTime;

                if (cmdCompany.ExecuteNonQuery() > -1)
                {
                    InfoResult.IsSuccess = true;
                }
                else
                {
                    InfoResult.IsSuccess = false;
                }

            }
            return InfoResult;
        }
        public EntityoperationInfo DeleteCompany(Guid IdCompany, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            using (SqlCommand cmdCompany = new SqlCommand("[Setup].[Proc_DeleteCompany]", objConn))
            {
                cmdCompany.CommandType = CommandType.StoredProcedure;
                cmdCompany.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;                
                
                if (cmdCompany.ExecuteNonQuery() > -1)
                {
                    InfoResult.IsSuccess = true;
                }
                else
                {
                    InfoResult.IsSuccess = false;
                }

            }
            return InfoResult;
        }
        public List<CompanyEL> GetAllCompanies(SqlConnection objConn)
        {
            List<CompanyEL> list = new List<CompanyEL>();
            SqlCommand cmdParents = new SqlCommand("[Setup].[Proc_getAllCompanies]", objConn);
            cmdParents.CommandType = CommandType.StoredProcedure;
            objReader = cmdParents.ExecuteReader();
            while (objReader.Read())
            {
                CompanyEL oelCompany = new CompanyEL();

                oelCompany.IdCompany = Validation.GetSafeGuid(objReader["Company_Id"]);
                oelCompany.CompanyName = Validation.GetSafeString(objReader["Company_Name"]);
                oelCompany.Discription = Validation.GetSafeString(objReader["Discription"]);
                oelCompany.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);

                list.Add(oelCompany);
            }
            return list;
        }
        public List<CompanyEL> GetCompanyById(Guid? Id, SqlConnection objConn)
        {
            List<CompanyEL> list = new List<CompanyEL>();
            SqlCommand cmdCompany = new SqlCommand("[Setup].[Proc_GetCompanyById]", objConn);
            cmdCompany.CommandType = CommandType.StoredProcedure;
            
            cmdCompany.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = Id.Value;

            objReader = cmdCompany.ExecuteReader();
            while (objReader.Read())
            {
                CompanyEL oelCompany = new CompanyEL();

                oelCompany.IdCompany = Validation.GetSafeGuid(objReader["Company_Id"]);
                oelCompany.CompanyName = Validation.GetSafeString(objReader["Company_Name"]);
                oelCompany.Discription = Validation.GetSafeString(objReader["Discription"]);
                oelCompany.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);

                list.Add(oelCompany);
            }
            return list;
        }
    }
}
