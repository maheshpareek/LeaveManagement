<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="LMS.Admin.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
</head>
<body>
    <h1>Welcome to Leave Management System</h1>
    <form id="form1" runat="server">
        <div>
            <h2>
                <asp:Menu ID="Menu1"  runat="server" StaticSubMenuIndent="16px">
                    <Items>
                        <asp:MenuItem Text="Dashboard" NavigateUrl="~/Admin/dashboard.aspx" Value="dashboard"></asp:MenuItem>
                        <asp:MenuItem Text="Student List" Value="student_list"></asp:MenuItem>
                        <asp:MenuItem Text="Application List" Value="application_list"></asp:MenuItem>
                        <asp:MenuItem Text="Designation" Value="designation"></asp:MenuItem>
                        <asp:MenuItem Text="Report" Value="report"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </h2> 
       </div>

    <div>
        <h2>
            <asp:Button runat="server" Text="Pending Application" />   
            <asp:Button runat="server" Text="Total Department" />
            <asp:Button runat="server" Text="Total Designations" />     
            <asp:Button runat="server" Text="Total Type of Leave" />    
        </h2>
    </div>
    </form>
</body>
</html>
