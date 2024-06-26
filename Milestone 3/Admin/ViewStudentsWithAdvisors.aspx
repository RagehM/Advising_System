﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStudentsWithAdvisors.aspx.cs" Inherits="Milestone_3.Admin.ViewStudentsWithAdvisors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    table{
        text-align: center;
    }
    th, td {
        border: 1px solid black;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            List of Students with their Assigned Advisors
        </h2>
        <hr />
        <table runat="server" id="table1">
            <tr>
                <th>
                    Student ID
                </th>
                <th>
                    Student First Name
                </th>
                <th>
                    Student Last Name
                </th>
                <th>
                    Advisor ID
                </th>
                <th>
                    Advisor Name
                </th>
            </tr>
        </table>
        
    <asp:Button Text="Back to Home" OnClick="Back" runat="server" />
    </form>
</body>
</html>
