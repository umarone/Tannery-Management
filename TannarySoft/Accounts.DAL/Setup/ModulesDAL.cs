﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;
using System.Data;

namespace Accounts.DAL
{
    public class ModulesDAL
    {
        IDataReader objReader;
        public List<ModulesEL> GetAllModules(SqlConnection oConn)
        {
            List<ModulesEL> oelModulesCollection = new List<ModulesEL>();
            using (SqlCommand cmdUsers = new SqlCommand("[Setup].[Proc_GetAllModules]", oConn))
            {
                cmdUsers.CommandType = CommandType.StoredProcedure;
                objReader = cmdUsers.ExecuteReader();
                while (objReader.Read())
                {
                    ModulesEL oelModule = new ModulesEL();
                    oelModule.IdModule = Validation.GetSafeGuid(objReader["Module_Id"]);
                    oelModule.ModuleName = Validation.GetSafeString(objReader["Module_Name"]);

                    oelModule.CreatedDateTime = Convert.ToDateTime(objReader["Created_DateTime"]);
                    oelModulesCollection.Add(oelModule);
                }
            }
            return oelModulesCollection;
        }
    }
}
