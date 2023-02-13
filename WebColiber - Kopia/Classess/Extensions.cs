using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebColiber
{
    public static class Extensions
    {
        public static object GetValue(this SqlDataReader reader, string columnName)
        {
            try
            {
                return reader.GetValue(reader.GetOrdinal(columnName));
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
    }
}