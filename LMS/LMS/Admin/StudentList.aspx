<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="LMS.Admin.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student List</title>
    <style>
                body {
            font-family:Arial, sans-serif;
            background-color:rgba(0, 128, 0, 0.4) ;
            margin:0;
        }
        .table {
    width: 100%;
    border-collapse: collapse;
}

.table th,
.table td {
    padding: 8px;
    text-align: left;
    border-bottom: 1px solid #ddd;
}

.table th {
    background-color: #333;
    color: white;
}
h1 {
  color: #333;
  text-align: center;
  margin-top: 50px;
}

    </style>
</head>
<body>
        <h1 class="heading" > Welcome to Leave Management System</h1>

    <form id="form1" runat="server">
    <div>
     <div id="dataContainer" runat="server"></div>
    </div>
    </form>
</body>
</html>
