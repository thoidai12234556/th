<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="thuchanh._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="ddl_mathang" runat="server">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "image/"+Eval("HINH") %>' OnClick="ImageButton1_Click" CommandArgument='<%# Eval("MAHANG") %>' />
            <br />
            <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("TENHANG") %>' CommandArgument='<%# Eval("MAHANG") %>' OnClick="LinkButton2_Click"></asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("MAHANG") %>' OnClick="LinkButton3_Click" >Chi tiết</asp:LinkButton>
        </ItemTemplate>

    </asp:DataList>
    
</asp:Content>
