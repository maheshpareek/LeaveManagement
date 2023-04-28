<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Event.aspx.cs" Inherits="LMS.Event" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event</title>
    <link rel="stylesheet" type="text/css" href="~/login.css" />
</head>
<body>
<h1>Create a Event</h1>
    <form id="form1" class="form-control1" runat="server">
    <div >
        <asp:Label ID="ename" runat="server" Text="Event Name"></asp:Label>
        <asp:TextBox ID="ename1" runat="server"></asp:TextBox><br />
    </div>
    <div >
        <asp:Label ID="eceo" runat="server" Text="Event CEO"></asp:Label>
        <asp:TextBox ID="eceo1" runat="server"></asp:TextBox><br />
    </div>
    <div >
        <asp:Label ID="ecoordinator" runat="server" Text="Event Coordinator"></asp:Label>
        <asp:TextBox ID="ecoordinator1" runat="server"></asp:TextBox><br />
    </div>
    <div >   
        <asp:Label ID="eabout" runat="server" Text="About Event"></asp:Label>
        <asp:TextBox ID="eabout1" runat="server"></asp:TextBox><br />
    </div>
    <div >     
        <asp:Label ID="edate" runat="server" Text="Event Date"></asp:Label>
       <asp:Calendar ID="edate1" runat="server" Height="50px" Width="100px"></asp:Calendar><br />

    </div >
    <div >
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
    </div> 
     </form>
     
    
</body>
</html>

    
