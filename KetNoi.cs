using System;
using System.Data;
using System.Data.SqlClient;

namespace Quan_li_nhan_su
{
    internal static class KetNoi
    {
        private const string ConnStr = "Server=localhost\\SQLEXPRESS,1433;Database=test2;UID=sa;PWD=12345";

        public static DataTable GetData(string select)
        {
            try
            {
                using (var sda = new SqlDataAdapter(select, ConnStr))
                {
                    using (var ds = new DataSet())
                    {
                        sda.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public static bool Execute(string exec)
        {
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(exec, conn))
                    {
                        var kq = cmd.ExecuteNonQuery();
                        conn.Close();
                        return kq == 1;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}