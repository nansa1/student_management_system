<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminuseredit.aspx.cs" Inherits="student_management_system.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 163px;
        }
        
        .auto-style3 {
            width: 586px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
    <table style="width:50%;margin:auto">
        <tr>
            <td >
                <asp:Label CssClass="label" ID="Label1" runat="server" Text="User Id :"></asp:Label>
            </td>
            <td >
                <asp:DropDownList CssClass="input" ID="txtid" runat="server" DataSourceID="SqlDataSource1" DataTextField="Id" DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT [Id] FROM [user_data]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" ImageUrl="~/image/search.PNG" Width="45px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        
    </table>
</div>
    <div>

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
            ShowHeaderWhenEmpty="true"  AutoGenerateColumns="false" DataKeyNames="Id"
            OnRowEditing="GridView1_RowEditing" 
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowDeleting="GridView1_RowDeleting"
            >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

            <Columns>
                <asp:TemplateField HeaderText="User Id">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Id") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="txtuid" Text='<%# Eval("Id") %>' runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("name") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtname" Text='<%# Eval("name") %>' runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("password") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtpassword" Text='<%# Eval("password") %>' runat="server" />
                    </EditItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Semister">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("sem") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtsem" Text='<%# Eval("sem") %>' runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/image/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                        <asp:ImageButton ImageUrl="~/image/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/image/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                        <asp:ImageButton ImageUrl="~/image/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </div>
    <asp:Label CssClass="label" ID="lblSuccessMessage" runat="server" ForeColor="#66FF33"></asp:Label>

    <asp:Label CssClass="label" ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>

    <br />
    <asp:ImageButton ID="btnback" runat="server" Height="23px" ImageUrl="~/image/back-button.png" OnClick="btnback_Click" Width="28px" />

</asp:Content>
