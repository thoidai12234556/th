using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;//
using System.Data;//
//7.QLBanHang.docx

namespace thuchanh
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        lopketnoi ketnoi = new lopketnoi();

        protected void Page_Load(object sender, EventArgs e) //Đây là sự kiện xảy ra khi trang MasterPage được tải.
        {
            if (IsPostBack) return; //Check có phải là một postback (nhấn nút gửi dữ liệu lên server) hay không=> để tránh việc ghi đè lên dữ liệu đã được hiển thị
            string sql = "select * from LOAIHANG"; //Tạo một chuỗi truy vấn SQL để lấy tất cả dữ liệu từ bảng "LOAIHANG".

            DataList1.DataSource = ketnoi.laydulieu(sql); //gắn nguồn dữ liệu cho DataList1 (một điều khiển hiển thị dữ liệu) để hiển thị danh sách loại hàng.
            DataList1.DataBind(); //gắn dữ liệu từ nguồn dữ liệu vào DataList1 để hiển thị danh sách loại hàng lên trang.
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            String maloai = ((LinkButton)sender).CommandArgument;//* Dòng này lấy giá trị của thuộc tính CommandArgument của LinkButton được nhấn.
                                                                 //* sender là đối tượng gửi sự kiện (LinkButton).
                                                                 //* ((LinkButton)sender).CommandArgument truy cập thuộc tính CommandArgument của đối
                                                                 //tượng LinkButton để lấy giá trị mã loại hàng.
            Response.Redirect("default.aspx?ml=" + maloai);  //* Dòng này chuyển hướng người dùng đến trang "default.aspx" với tham số "ml" (mã loại hàng) được truyền qua URL.
                                                             //* Khi người dùng nhấn vào một LinkButton, phương thức này sẽ chạy và xác định mã loại hàng, sau đó chuyển hướng
                                                             //người dùng đến trang "default.aspx" để hiển thị danh sách hàng của loại hàng tương ứng.
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string user = Login1.UserName;
            string pass = Login1.Password;

            string sql = "select * from KHACHHANG where TENDANGNHAP='" + user + " ' " +
                "           and MATKHAU='" + pass + "' ";
            DataTable dt = ketnoi.laydulieu(sql);

            if (dt.Rows.Count > 0)
            {
                Session["username"] = user;
                Response.Redirect("default.aspx");
            }
            else
            {
                Login1.FailureText = "tên và mật khẩu không đúng";
            }
        }
    }
}