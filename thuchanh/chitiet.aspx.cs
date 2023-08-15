using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace thuchanh
{
    public partial class chitiet : System.Web.UI.Page
    {
        lopketnoi ketnoi = new lopketnoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string mahang = Request.QueryString["mh"] + "";
            if (mahang != "")
            {
                string sql = "select * from MATHANG where MAHANG=" + mahang;

                DataList1.DataSource = ketnoi.laydulieu(sql);
                DataList1.DataBind();
            }
            else
            {
                lbthongbao.Text = "San pham k ton tại";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tendangnhap = Session["username"] + "";
            if (tendangnhap != "")
            {
                string mahang = ((Button)sender).CommandArgument;
                Button bt_mua = (Button)sender; //lấy button1 r mới lấy được txtsoluong
                DataListItem item = (DataListItem)bt_mua.Parent;
                TextBox txtSouong = (TextBox)item.FindControl("txt_soluong");//láy được đối tuong textbox
                string soluong = txtSouong.Text;


                string sql_dulieu = "select * from DONHANG where TENDANGNHAP='" + tendangnhap + "'and MAHANG=" + mahang;
                DataTable dt = ketnoi.laydulieu(sql_dulieu);
                string sql_capnhat = "";
                if (dt.Rows.Count > 0)
                {
                    //update
                    sql_capnhat = "update DONHANG Set SOLUONG=SOLUONG+" + soluong
                        + " where TENDANGNHAP='" + tendangnhap + "'and MAHANG=" + mahang;

                }
                else
                {
                    //insert
                    sql_capnhat = "insert into DONHANG values('" + tendangnhap + "'," + mahang + "," + soluong + ")";
                }


                //string sql="insert into DONHANG values('"+tendangnhap+"',"+mahang+","+soluong+")";
                int ketqua = ketnoi.capnhat(sql_capnhat);
                if (ketqua > 0)
                {
                    lbthongbao.Text = "thanh cong";
                }
                else
                {
                    lbthongbao.Text = "k thanh cong";
                }


            }
            else
            {
                lbthongbao.Text = "ban phai dang nhap!";

            }
        }
    }
}