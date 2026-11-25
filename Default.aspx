<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Practical9.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Placement Summary</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 30px; }
        .card { display: inline-block; width: 180px; padding: 15px; margin: 8px; border: 1px solid #ccc; border-radius: 6px; text-align: center; }
        table { border-collapse: collapse; margin-top: 20px; }
        th, td { border: 1px solid #777; padding: 7px 10px; text-align: left; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <h2>Placement Management Dashboard</h2>
    <div class="card">Total Students<br /><asp:Label ID="lblTotal" runat="server" /></div>
    <div class="card">Placed Students<br /><asp:Label ID="lblPlaced" runat="server" /></div>
    <div class="card">Unplaced Students<br /><asp:Label ID="lblUnplaced" runat="server" /></div>
    <div class="card">Highest Package<br /><asp:Label ID="lblHighestPackage" runat="server" /></div>
    <div class="card">Placement Percentage<br /><asp:Label ID="lblPercentage" runat="server" /></div>

    <asp:GridView ID="gvPlacements" runat="server" AutoGenerateColumns="true"></asp:GridView>
</form>
</body>
</html>
