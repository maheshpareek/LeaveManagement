<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPanel.aspx.cs" Inherits="LMS.User.UserPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Panel</title>
    <style>
        
        /* Body */
        
        body {
            font-family:Arial, sans-serif;
            background-color:rgba(0, 128, 0, 0.4) ;
            margin:0;
        }

        /* Header */
        
        h1 {
        color:#333;
        text-align:center;
        margin-top:50px;
        }

        /* Menu */
        .menu {
        color: #222;
        
        text-align: center;
        }

        .menu h2 {
        margin: 0;
        padding: 0;
        display: inline-block; 
        }
        #Menu1 {
        margin-top: 15px;
        
        }
        #Menu1 li {
        display: inline-block;
        margin-right: 10px;
        margin-left: 10px;
        }
        .menu a {
          display: block;
          padding: 10px;
          color: #222;
          text-decoration: none;
        }
        
        .menu a:hover {
          background-color: #555;
          color:#fff;
        }
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
          padding: 10px;
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
        a {
        text-decoration: none;
        }

    </style>
    </head>
<body >
    <h1>Welcome to Leave Management System</h1>
    <form id="form1" runat="server">
        <asp:Label ID="lbl" runat="server" Visible="false" Text="Label"></asp:Label>
    <div class="menu">
    <h2>
<asp:Menu ID="Menu1" SkipLinkText="" OnMenuItemClick="Menu1_MenuItemClick" runat="server" StaticSubMenuIndent="16px">
            <Items>
                <asp:MenuItem Text="Leave Form" Value="leave_form" ></asp:MenuItem>
                <asp:MenuItem Text="Application Status" Value="application_status" NavigateUrl="~/User/ApplicationStatus.aspx"></asp:MenuItem>
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
