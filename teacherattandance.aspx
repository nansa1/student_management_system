﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="teacherattandance.aspx.cs" Inherits="student_management_system.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="width:100%;">
        
        <tr>
            <td >
                <asp:Label CssClass="label" ID="Label2" runat="server" Text="Sem "></asp:Label>
            </td>
            <td >
                <asp:DropDownList CssClass="input" ID="DropDownList1" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
  
      

            <td >
                <asp:Label CssClass="label" ID="Label3" runat="server" Text="Department "></asp:Label>
            </td>
            <td >
                <asp:DropDownList CssClass="input" ID="ddtdep" runat="server" >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>BCA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>

            </td>
            
            </tr>
        <tr>

        
            <td >
                <asp:Label CssClass="label" ID="Label4" runat="server" Text="Course Id "></asp:Label>
            </td>
            <td >
                <asp:DropDownList CssClass="input" ID="ddcid" runat="server" DataSourceID="SqlDataSource1" DataTextField="Cid" DataValueField="Cid">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT [Cid], [Course name] AS Course_name FROM [course] WHERE ([teacherid] = @teacherid)">
                    <SelectParameters>
                        <asp:SessionParameter Name="teacherid" SessionField="userid" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td >
                <asp:Label CssClass="label" ID="Label6" runat="server" Text="Course Name "></asp:Label>
            </td>
            <td >
                <asp:DropDownList CssClass="input" ID="ddcname" runat="server" DataSourceID="SqlDataSource1" DataTextField="Course_name" DataValueField="Course_name">
                </asp:DropDownList>
            </td>
            
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/search.PNG" Height="51px" Width="55px" OnClick="ImageButton1_Click"  />
            </td>

        </tr>
        
    </table>
         <div>

             <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                 ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" 
                 OnRowCancelingEdit="GridView1_RowCancelingEdit"
                 OnRowUpdating="GridView1_RowUpdating" Width="100%" AllowPaging="True"
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
                    <asp:TemplateField HeaderText="Student Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("name") %>' runat="server" />
                        </ItemTemplate>
                        
                        
                   </asp:TemplateField>
                     <asp:TemplateField HeaderText="Student Id">
                        <ItemTemplate>
                            <asp:Label ID="id" Text='<%# Eval("id") %>' runat="server" />
                        </ItemTemplate>
                        
                   </asp:TemplateField>
                  <asp:TemplateField HeaderText="Attandance">
                        <ItemTemplate>
                            
                        </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtAttandance"  runat="server" />
                        </EditItemTemplate>
                        
                   </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/image/addnew.png" runat="server"  CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>

                        </ItemTemplate>
                          <EditItemTemplate>
                              <asp:ImageButton ImageUrl="~/image/addnew.png" runat="server"  CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                              <asp:ImageButton ImageUrl="~/image/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                          </EditItemTemplate>
                                     
                    </asp:TemplateField>
               </Columns>
             </asp:GridView>
             <asp:Button ID="btnedit" runat="server" Text="Edit" OnClick="btnedit_Click" />

             <br />

        <asp:ImageButton ID="btnback" runat="server" Height="23px" ImageUrl="~/image/back-button.png" OnClick="btnback_Click" Width="28px" />



             <br />
              
             <asp:Label CssClass="label" ID="lblSuccessMessage" runat="server" ForeColor="#33CC33"></asp:Label>
             <asp:Label CssClass="label" ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>

         </div>


</asp:Content>
