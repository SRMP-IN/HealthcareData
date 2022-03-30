<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HealthcareData.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Content/bootstrap.js"></script>
    <script src="Content/jquery.js"></script>
</head>
<body>
  <div class="container">
        <form class="form-signin" runat="server">
            <h2 class="form-signin-heading"><%: Page.Title %></h2>
            <div class="form-group">
                <label>Email Address</label>
                <asp:TextBox runat="server" ID="EmailAddress"  class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password</label>
                <asp:TextBox runat="server" ID="Password"  TextMode="Password" class="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button Text="Login" runat="server" ID="btnLogin" OnClick="btnLogin_Click" class="btn btn-primary" />             
                <asp:LinkButton Text="Signup Now" runat="server" CssClass="col-md-offset-3"  PostBackUrl="~/Signup.aspx" />
            </div>
            <asp:Label runat="server" ID="ErorrMessage"  ForeColor="Red" Font-Bold="true" Enabled="false"></asp:Label>
        </form>
    </div>
</body>
</html>
