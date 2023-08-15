using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace thuchanh
{
    public partial class giohang : System.Web.UI.Page
    {
        lopketnoi ketnoi = new lopketnoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return; // bắt buộc thêm

            string tendangnhap = Session["username"] + "";
            if (tendangnhap != "")
            {
                string sql = "select MATHANG.MAHANG, TENHANG, MOTA, DONGIA, SOLUONG, DONGIA*SOLUONG AS ThanhTien " +
                    "from MATHANG, DONHANG" +
                    "where TENDANGNHAP='" + tendangnhap + "' And MATHANG.MAHANG = DONHANG.MAHANG";
                GridView1.DataSource = ketnoi.laydulieu(sql);
                GridView1.DataBind();

            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //nút xóa
            string tendangnhap = Session["username"] + "";
            if (tendangnhap != "")
            {
                string mahang = ((LinkButton)sender).CommandArgument;
                string sql = "delete DONHANG where MAHANG=" + mahang + "and TENDANGNHAP='" + tendangnhap + "'";
                int ketqua = ketnoi.capnhat(sql);
                if (ketqua > 0) lbthongbao.Text = "thanh cong";
                else lbthongbao.Text = "k thanh cong";
            }
        }


    }
}