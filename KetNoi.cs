using System;
using System.Data;
using System.Data.SqlClient;

namespace Quan_li_nhan_su
{

    internal class KetNoi
    {
        private string conn_str = "Server=localhost\\SQLEXPRESS,1433;Database=QLNS;UID=sa;PWD=12345";

        public DataTable GetData(string select)
        {
            try
            {
                var sda = new SqlDataAdapter(select, conn_str);
                var ds = new DataSet();
                sda.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public bool Execute(string exec)
        {
            try
            {
                var conn = new SqlConnection(conn_str);
                conn.Open();
                var cmd = new SqlCommand(exec, conn);
                var kq = cmd.ExecuteNonQuery();
                conn.Close();
                return kq == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
