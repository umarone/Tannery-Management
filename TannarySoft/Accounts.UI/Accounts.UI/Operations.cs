using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Accounts.UI
{
    public class Operations
    {        
            static Guid UserId;
            static string username;
            static Guid IDCompany;
            static string _CompanyName;
            static Guid IDRole;
            static bool _IsAuthenticate;
            public static Guid IdCompany
            {
                get { return IDCompany; }
                set { IDCompany = value; }
            }
            public static string CompanyName
            {
                get { return _CompanyName; }
                set { _CompanyName = value; }
            }
            public static Guid UserID
            {
                get { return UserId; }
                set { UserId = value; }
            }
            public static Guid IdRole
            {
                get { return IDRole; }
                set { IDRole = value; }
            }
            public static string UserName
            {
                get { return username; }
                set { username = value; }
            }
            public static bool IsAuthenticate
            {
                get { return _IsAuthenticate; }
                set { _IsAuthenticate = value; }
            }             
    }
    public static class DataOperations
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if(prop.PropertyType != null)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
                prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        } 
    }
}
