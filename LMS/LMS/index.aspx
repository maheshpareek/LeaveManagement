<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LMS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Log In</title>
<link rel="stylesheet" type="text/css" href="~/login.css" />

</head>
<body>
    <h1 class="heading" > Welcome to Leave Management System</h1>
    <form id="form1" method="post" runat="server" class="form-control">
    <div class="login-container">
    <h1>Login</h1>
    <div class="form-group">
        <asp:Label class="form-label" ID="Label1" runat="server" Text="UserId"></asp:Label>
        <asp:TextBox ID="uid" runat="server"></asp:TextBox><br />
    </div>
    <div class="form-group">
        <asp:Label class="form-label" ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="pass1" TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:Label class="form-label" ID="Label3" runat="server" Text=""></asp:Label>
    </div>
    <div>
        
        <asp:Button ID="Button1" runat="server" Text="LogIn" OnClick="Button1_Click" /><br />
    </div>
 </div>
    </form>
</body>
</html>
