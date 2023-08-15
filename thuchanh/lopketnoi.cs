using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;//add
using System.Data;//ADD thêm

namespace thuchanh
{
    public class lopketnoi : System.Web.UI.Page

    {
        SqlConnection con;

        public void ketnoi()
        {
            string sqlcn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("/App_Data/BANHANG.mdf") + ";Integrated Security=True";
            con = new SqlConnection(sqlcn);
            con.Open();
        }
        public void dongketnoi()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public DataTable laydulieu(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                ketnoi();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            catch
            {
                //loi
            }
            finally
            {
                dongketnoi();
            }
            return dt;
        }

        public int capnhat(string sql)
        {
            int kq = 0;
            try
            {
                ketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                kq = cmd.ExecuteNonQuery(); //thêm + sưa + xóa đeu dùng  nàyExecuteNonQuery
            }
            catch
            {
                kq = 0;
            }
            finally
            {
                dongketnoi();
            }

            return kq;

        }
    }
}