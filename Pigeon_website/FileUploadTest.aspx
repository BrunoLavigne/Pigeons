﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploadTest.aspx.cs" Inherits="FileUploadTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" /></br>
        <asp:Button ID="Button1" runat="server" Text="UploadTest" OnClick="Button1_Click" />
        </br>
        Get files:</br>
        <asp:Button ID="ButtonGetFile1" runat="server" Text="Get File ID 1" OnClick="ButtonGetFile1_Click" />
        <asp:Button ID="ButtonGetFile2" runat="server" Text="Get File ID 2" OnClick="ButtonGetFile2_Click" />
    </div>
    </form>
</body>
</html>