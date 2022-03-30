<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="HealthcareData.Signup" %>

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
    <div class="container" style="background-position: center center; background-image: url('Content/image1.jpg'); height: 531px; width: 90%;">

        <form class="form-signin" runat="server">
            <h2 class="form-signin-heading"><%: Page.Title %></h2>

            <div class="form-group">
                <label>Name</label>
                <asp:TextBox runat="server" ID="Name" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <table style="width: 65%;">
                    <tr>
                        <td>
                            <label>Age</label>
                            <asp:TextBox runat="server" ID="Age" TextMode="Number" min="1" max="200" class="form-control"></asp:TextBox>

                        </td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <label>Gender</label>
                            <asp:DropDownList runat="server" ID="Gender" CssClass="form-control">
                                <asp:ListItem Text="Male" Value="Male" />
                                <asp:ListItem Text="Female" Value="Female" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="form-group">
                <label>PhoneNo</label>
                <asp:TextBox runat="server" ID="PhoneNo" TextMode="Number" min="1" max="9999999999" class="form-control"></asp:TextBox>

            </div>
            <div class="form-group">
                <label>Email Address</label>
                <asp:TextBox runat="server" ID="EmailAddress" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password</label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button Text="Signup" runat="server" ID="btnSignup" OnClick="btnSignup_Click" class="btn btn-primary" />
                <asp:LinkButton Text="Login Now" runat="server" CssClass="col-md-offset-3" PostBackUrl="~/Default.aspx" />
            </div>
            <asp:Label runat="server" ID="ErorrMessage" ForeColor="Red" Font-Bold="true" Enabled="false"></asp:Label>
        </form>
    </div>
</body>
</html>
