<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="student_management_system.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .column {
  float: left;
  width: 33.33%;
  padding: 0 10px;
}

.row {
    margin: 0;
    
}

.row:after {
  content: "";
  display: table;
  clear: both;
}

@media screen and (max-width: 600px) {
  .column {
    width: 33.33%;
    display: block;
    margin-bottom: 20px;
  }
  .row {
    
    transform:translateY(-50%);
}
.icon-resp{
    font-size:12px;
}
}


.card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  padding: 2px;
  text-align: center;
  background-color:white;
  opacity: 0.8;
  border-radius: 25px;
  color:#BD0006;
  
}
    </style>
    <script src="js/background.cycle.js"></script>
	<script type="text/javascript">
            $(document).ready(function() {
                $("body").backgroundCycle({
                    imageUrls: [
                        'image/img1.JPG',
                        'image/img2.JPG',
                        'image/img3.JPG'
                    ],
                    fadeSpeed: 2000,
                    duration: 3000,
                    backgroundSize: SCALING_MODE_COVER
                });
            });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="text-align:center;display: table; margin:inherit;">
        <div style=" display: table-cell;padding-right:10px" >
    <asp:ImageButton ID="Btncourse" runat="server" OnClick="Btncourse_Click1" Visible="False" Height="87px" ImageUrl="~/image/online-course.png" Width="94px" AlternateText="Course" />
           <br /> <asp:Label ID="Label1" runat="server" Text="Course" Visible="False"></asp:Label>
            </div>
        <div style=" display: table-cell ;padding-right:10px">
    <asp:ImageButton ID="Btnuser" runat="server" Height="82px" ImageUrl="~/image/add-user.png" OnClick="Btnuser_Click1" Width="94px" Visible="False" AlternateText="User" />
       <br /> <asp:Label ID="Label2" runat="server" Text="User" Visible="False"></asp:Label>
        </div>
        <div style=" display: table-cell;padding-right:10px">
    <asp:ImageButton ID="Btnattandance" runat="server" ImageUrl="~/image/student-attendance-icon.jpg" OnClick="Btnattandance_Click" Width="94px" Visible="False" AlternateText="Attandance" />
   <br /> <asp:Label ID="Label3" runat="server" Text="Attandance" Visible="False"></asp:Label>
        </div>
        <div style=" display: table-cell;padding-right:10px">
    <asp:ImageButton ID="Btnresult" runat="server" ImageUrl="~/image/diploma.png" OnClick="Btnresult_Click" Width="94px" Visible="False" AlternateText="Result" />
   <br /> <asp:Label ID="Label4" runat="server" Text="Result" Visible="False"></asp:Label>
    </div>
    
        </div>
    <div class="row">
  <div class="column">
    <div class="card">
        
      <h3 class="icon-resp">Total Number of Faculty
          </h3>
      <h1 class='icon-resp' >
          <asp:Label ID="countt" runat="server" Text=""></asp:Label></h1>
    </div>
      </div>
        <div class="column">
    <div class="card">
       
      <h3 class="icon-resp">Total Number of Student</h3>
    <h1 class='icon-resp' >
          <asp:Label ID="counts" runat="server" Text=""></asp:Label></h1>
    </div>
    </div>
        <div class="column">
    <div class="card">
        
      <h3 class="icon-resp">Total Number of Courses</h3>
     <h1 class='icon-resp' >
          <asp:Label ID="countc" runat="server" Text=""></asp:Label></h1>
    </div>
  </div>
        </div>
    

</asp:Content>
