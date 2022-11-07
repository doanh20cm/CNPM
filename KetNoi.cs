using System.Data;
using System.Data.SqlClient;

namespace Quan_li_nhan_su
{
	internal static class KetNoi
	{
		public static DataTable GetData(string select)
		{
			using (var sda = new SqlDataAdapter(select, GiaoDienChinh.ConnStr))
			{
				using (var ds = new DataSet())
				{
					sda.Fill(ds);
					return ds.Tables[0];
				}
			}
		}

		//public static bool Execute(string exec)
		//{
		//    try
		//    {
		//        using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
		//        {
		//            conn.Open();
		//            using (var cmd = new SqlCommand(exec, conn))
		//            {
		//                var kq = cmd.ExecuteNonQuery();
		//                conn.Close();
		//                return kq == 1;
		//            }
		//        }
		//    }
		//    catch (Exception)
		//    {
		//        return false;
		//    }
		//}
	}
}