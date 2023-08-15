using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace thuchanh
{
    public partial class _default : System.Web.UI.Page
    {
        lopketnoi ketnoi = new lopketnoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return; //Bắt buộc
            string maloai = Request.QueryString["ml"] +"";
            string sql = "";
            if(maloai == "")
            {
                sql = "select * from MATHANG";
            }
            else
            {
                sql = "select * from MATHANG where MALOAI =" + maloai;
            }

            ddl_mathang.DataSource = ketnoi.laydulieu(sql);
            ddl_mathang.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string mahang = ((ImageButton)sender).CommandArgument;
            Response.Redirect("chitiet.aspx?mh=" + mahang);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string mahang = ((LinkButton)sender).CommandArgument;
            Response.Redirect("chitiet.aspx?mh=" + mahang);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string mahang = ((LinkButton)sender).CommandArgument;
            Response.Redirect("chitiet.aspx?mh=" + mahang);
        }
    }
}