<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="LMS.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel</title>
    <link rel="stylesheet" type="text/css" href="~/login.css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>Admin Panel</h1>
    <div class="menu">
    <h2>
        <asp:Menu ID="Menu1"  runat="server" StaticSubMenuIndent="16px">
            <Items>
                <asp:MenuItem Text="Create an Event" Value="event" navigateurl="Event.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Approve Leave" Value="app_leave"></asp:MenuItem>
                <asp:MenuItem Text="Generate Report" Value="gen_report"></asp:MenuItem>
            </Items>
        
        </asp:Menu>
        </h2>
    </div>
    </form>
</body>
</html>
