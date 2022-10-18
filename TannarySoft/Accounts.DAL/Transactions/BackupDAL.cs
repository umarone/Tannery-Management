using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Accounts.EL;

namespace Accounts.DAL
{
    public class BackupDAL
    {
        public bool DbBackUp(SqlConnection objConn,string Path)
        { 
            EntityoperationInfo backupInfo = new EntityoperationInfo();
            bool Status = false;
            int rowsEffected = -1;

            //string Query = @"backup database " + "CombineAssociates" + " to disk ='" + "c:\\Backup\\CombineBackup" + ".bak' with init,stats=10;";
            string Query = @"backup database " + "FSTLive" + " to disk ='" + Path + ".bak' with init,stats=10;";
            using (SqlCommand cmdBackup = new SqlCommand(Query, objConn))
            {
                try
                {
                    cmdBackup.CommandType = CommandType.Text;
                    cmdBackup.ExecuteNonQuery();
                    Status = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Status;
        }
    }
}
