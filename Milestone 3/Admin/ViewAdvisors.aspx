﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAdvisors.aspx.cs" Inherits="Milestone_3.Admin.ViewAdvisors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button runat="server" onclick="Back" Text="Back To Home"/>
        <table id="table1" runat="server">
            <tr>
                <th>
                    Advisor ID
                </th>
                <th>
                    Advisor Name
                </th>
                <th>
                    Email
                </th>
                <th>
                    Office Location
                </th>
                <th>
                    Password
                </th>
            </tr>
        </table>
    </form>
</body>
</html>