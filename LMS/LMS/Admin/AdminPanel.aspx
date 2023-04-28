<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="LMS.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Admin Panel</title>
    <style>
       /* Body */
body {
  font-family: Arial, Helvetica, sans-serif;
  background-color: rgba(0, 128, 0, 0.3) ;
  margin: 0;
}

/* Header */
h1 {
  color: #333;
  text-align: center;
  margin-top: 50px;
}

/* Menu */
.menu {
color: #222;
padding: 10px;
text-align: center; /* add this rule */
}

.menu h2 {
margin: 0;
padding: 0;
display: inline-block; /* add this rule */
}

#Menu1 {
margin-top: 5px;
display: inline-block; /* add this rule */
}

#Menu1 li {
display: inline-block;
margin-right: 10px;
margin-left: 10px; /* add this rule */
}

#Menu1 ul {
  list-style: none;
  margin: 0;
  padding: 0;
}



#Menu1 li a {
  color: #222;
  text-decoration: none;
  padding: 10px;
  transition: background-color 0.3s;
}

#Menu1 li a:hover {
  background-color: #555;
  color: #fff;
}

/* Main Boxes */
.row {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 50px;
}

.col-md-4 {
  margin: 0 10px;
}

.main-box {
  text-align: center;
  padding: 20px;
  background-color: #fff;
  border-radius: 5px;
  box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.3);
  transition: box-shadow 0.3s;
}

.main-box:hover {
  box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.6);
}

.mb-red {
  background-color: #ff6b6b;
  color: #fff;
}

.mb-dull {
  background-color: #a4b0be;
  color: #fff;
}

.mb-pink {
  background-color: #ff9ff3;
  color: #fff;
}

/* Icons */
.fa {
  margin-bottom: 10px;
}

.fa-5x {
  font-size: 5em;
}

    </style>

</head>
<body>
    <h1>Welcome to Leave Management System</h1>
    <form id="form1" runat="server">
    <div class="menu">
    <h2>
        <asp:Menu ID="Menu1"  runat="server" StaticSubMenuIndent="16px">
            <Items>
                <asp:MenuItem Text="Student List" Value="student_list" NavigateUrl="~/Admin/StudentList.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Application List" Value="application_list" NavigateUrl="~/Admin/ApplicationList.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Report" Value="report" NavigateUrl="~/Admin/Report.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
        </h2>
    </div>
        <div class="row">
                    <div class="col-md-4">
                        <div class="main-box mb-red">
                            <a href="#">
                                <i class="fa fa-user fa-5x""></i>
                                <h2>
								<asp:Label ID="pending" runat="server" Text="Pending Application"></asp:Label>
								</h2>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="main-box mb-dull">
                            <a href="#">
							 <i class="fa fa-dollar fa-5x"></i>
                                <h2>
                                 <asp:Label ID="approved" runat="server" Text="Approved Leave"></asp:Label>   
								</h2>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="main-box mb-pink">
                            <a href="#">
                               <i class="fa fa-user-md fa-5x"></i>
                                <h2>
                                    <asp:Label ID="rejected" runat="server" Text="Rejected Leave "></asp:Label>
								</h2>
                            </a>
                        </div>
                    </div>
            </div>
        
    </form>
</body>
</html>
