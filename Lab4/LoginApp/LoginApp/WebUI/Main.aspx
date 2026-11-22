<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WEB.Main" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Main</title>
</head>
<body>
    <form id="form1" runat="server">

        <h1>Welcome</h1>

        <asp:Button ID="btnCustomer" runat="server"
            Text="Customer"
            OnClick="btnCustomer_Click" />

        <asp:Button ID="btnProduct" runat="server"
            Text="Product"
            OnClick="btnProduct_Click" />

        <asp:Button ID="btnSupplier" runat="server"
            Text="Supplier"
            OnClick="btnSupplier_Click" />
    </form>
</body>
</html>
