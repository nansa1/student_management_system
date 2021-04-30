<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminuser.aspx.cs" Inherits="student_management_system.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 171px;
        }
        .auto-style2 {
            width: 171px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 50%; margin:auto">
        <tr>
            <td class="auto-style1">
                <asp:Label CssClass="label" ID="Label1" runat="server" Text="ID :"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="input" ID="txtid" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label CssClass="label" ID="Label2" runat="server">Name :</asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="input" ID="txtname" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label CssClass="label" ID="Label3" runat="server" Text="Type of user :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="input" ID="ddtype" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>student</asp:ListItem>
                    <asp:ListItem>teacher</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label CssClass="label" ID="Label4" runat="server" Text="Password :"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="input" ID="txtpassword" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label CssClass="label" ID="Label5" runat="server" Text="Department :"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:DropDownList CssClass="input" ID="dddep" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>BCA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label CssClass="label" ID="Label6" runat="server" Text="Sem :"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:DropDownList CssClass="input" ID="DropDownList" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>admin</asp:ListItem>
                    <asp:ListItem>teacher</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label CssClass="label" ID="error" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Button CssClass="inputsubmit" ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </td>
            <td>
                <asp:Label CssClass="label" ID="sm" runat="server" ForeColor="#66FF66"></asp:Label>
            </td>
        </tr>
    </table>

    <div ><asp:Button runat="server" Text="Edit" ID="btnedit" OnClick="btnedit_Click" Width="40px"></asp:Button>

        <br /><asp:ImageButton ID="btnback" runat="server" Height="23px" ImageUrl="~/image/back-button.png" OnClick="btnback_Click" Width="28px" />
    </div>

</asp:Content>
