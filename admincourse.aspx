<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admincourse.aspx.cs" Inherits="student_management_system.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 59px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 50%; margin:auto";>
        <tr>
            <td>
                <asp:Label CssClass="label" ID="Label1" runat="server" Text="Course Id :"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="input" ID="txtcid" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="label" ID="Label2" runat="server" Text="Course Name :"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="input" ID="txtcname" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="label" ID="Label3" runat="server" Text="Sem :"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="input" ID="txtsem" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="label" ID="Label4" runat="server" Text="Department :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="input" ID="ddcdep" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>BCA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="label" ID="Label5" runat="server" Text="Teacher Name :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="input" ID="ddteachername" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT [name], [Id] FROM [user_data] WHERE ([type] = @type)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="teacher" Name="type" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label CssClass="label" ID="Label6" runat="server" Text="Teacher Id :"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList CssClass="input" ID="ddtid" runat="server" DataSourceID="SqlDataSource1" DataTextField="Id" DataValueField="Id">
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="label" ID="Label7" runat="server" Text="Credit :"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="input" ID="txtcredit" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="lead" ID="error" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Button CssClass="inputsubmit" ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </td>
            <td>
                <asp:Label CssClass="label" ID="sm" runat="server" ForeColor="#66FF33" Height="24px"></asp:Label>
            </td>
        </tr>
    </table>
    <div>
        <asp:Button ID="btnedit" runat="server" Text="Edit" OnClick="btnedit_Click" />
        <br /><asp:ImageButton ID="btnback" runat="server" Height="23px" ImageUrl="~/image/back-button.png" OnClick="btnback_Click" Width="28px" />
    </div>
</asp:Content>
