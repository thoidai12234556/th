<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="chitiet.aspx.cs" Inherits="thuchanh.chitiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <table style="width:100%;">
                <tr>
                    <td rowspan="4">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "image/"+Eval("HINH") %>' />
                    </td>
                    <td>Tên hàng:<asp:Label ID="Label1" runat="server" Text='<%# Eval("TENHANG") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>mô tả:<asp:Label ID="Label2" runat="server" Text='<%# Eval("MOTA") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Đơn giá:<asp:Label ID="Label3" runat="server" Text='<%# Eval("DONGIA") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Sô lượng:
                        <asp:TextBox ID="txt_soluong" runat="server" Text=""></asp:TextBox>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Mua" CommandArgument='<%# Eval("MAHANG") %>' OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>

    </asp:DataList>
    <asp:Label ID="lbthongbao" runat="server" Text="Label"></asp:Label>
</asp:Content>
