<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveForm.aspx.cs" Inherits="LMS.User.LeaveForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Form</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    <h2>Leave Form </h2>
        
        <asp:Label runat="server" Text="Student Id"></asp:Label>
        <asp:TextBox ID="StudentId" runat="server"></asp:TextBox><br>
        <asp:Label runat="server" Text="Student Name"></asp:Label>
        <asp:TextBox ID="StudentName" runat="server"></asp:TextBox><br>
        <asp:Label runat="server" Text="Department"></asp:Label>
        <asp:TextBox ID="Department" runat="server"></asp:TextBox><br>
        <asp:Label runat="server" Text="Class"></asp:Label>
        <asp:TextBox ID="Class" runat="server"></asp:TextBox><br>
        <div>
                <asp:Label runat="server" Text="Leave Type"></asp:Label>
            <asp:DropDownList ID="LeaveType" runat="server">
                <asp:ListItem Text="Leave Type"></asp:ListItem>
                <asp:ListItem Text="Sick Leave"></asp:ListItem>
                <asp:ListItem Text="Vaction Leave"></asp:ListItem>
                <asp:ListItem Text="Collage Event"></asp:ListItem>
                <asp:ListItem Text="Marraige Leave"></asp:ListItem>
                <asp:ListItem Text="Sports Leave"></asp:ListItem>  
            </asp:DropDownList>
            <h3>Leave Duration</h3>
      <div>
        <asp:Label runat="server" Text="From"></asp:Label>
          <asp:TextBox ID="cal11" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" Height="20px" ImageUrl="~/User/calendar.png" OnClick="ImageButton1_Click" Width="21px" runat="server" />
            <asp:Calendar ID="Calendar1" onselectionchanged="Calendar1_SelectionChanged" Visible="false" runat="server" >
            </asp:Calendar>  
    </div>
        <div>
            <asp:Label runat="server" Text="To"></asp:Label>
            <asp:TextBox ID="cal2" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton2" Height="20px" ImageUrl="~/User/calendar.png" OnClick="ImageButton2_Click" Width="21px" runat="server" />
            <asp:Calendar ID="Calendar2" onselectionchanged="Calendar2_SelectionChanged" Visible="false" runat="server" >
            </asp:Calendar> 
        </div>
            <asp:Button runat="server" Text="Submit" OnClick="Unnamed13_Click" />
    </form>
</body>
</html>
