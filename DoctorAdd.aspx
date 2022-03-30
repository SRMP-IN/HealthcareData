<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorAdd.aspx.cs" Inherits="HealthcareData.DoctorAdd" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Admin</title>
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Content/bootstrap.js"></script>
    <script src="Content/jquery.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                            <span class="sr-only">Project name</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">Project name</a>
                    </div>
                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li  >
                                <a href="Admin.aspx">Home</a>
                            </li>
                            <li>
                                <a href="DoctorList.aspx">Doctor List</a></li>
                            <li>
                                <a href="UserList.aspx">User List</a></li>

                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li  >
                                <a>
                                    <asp:Label ID="LoginName" runat="server" />
                                    <span class="sr-only">(current)</span></a></li>
                            <li><a href="Logout.aspx">Log Out</a></li>
                        </ul>
                    </div>
                </div>
            </nav>


            <div class=" ">
                <h2>Doctor Edit </h2>
                <br />


                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="form-group">

                                <label>Doctor Name</label>
                                <asp:TextBox runat="server" ID="Name" class="form-control"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <label>PhoneNo</label>
                                <asp:TextBox runat="server" ID="PhoneNo" TextMode="Number" min="1" max="9999999999" class="form-control"></asp:TextBox>
                            </div>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <div class="form-group">
                                <label>Email Address</label>
                                <asp:TextBox runat="server" ID="EmailAddress" class="form-control"></asp:TextBox>
                            </div>

                        </td>
                        <td>
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox runat="server" ID="Password" class="form-control"></asp:TextBox>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <div class="form-group">
                                <label>Age</label>
                                <asp:TextBox runat="server" ID="Age" TextMode="Number" min="1" max="200" class="form-control"></asp:TextBox>
                            </div>
                        </td>

                        <td>
                            <div class="form-group">
                                <label>Gender</label>
                                <asp:DropDownList runat="server" ID="Gender" CssClass="form-control">
                                    <asp:ListItem Text="Male" Value="Male" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <div class="form-group">
                                <label>DoctorDegree</label>
                                <asp:TextBox runat="server" ID="DoctorDegree" class="form-control"></asp:TextBox>
                            </div>

                        </td>
                        <td>
                            <div class="form-group">
                                <label>Specialization</label>
                                <asp:TextBox runat="server" ID="Specialization" class="form-control"></asp:TextBox>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <div class="form-group">
                                <label>CloseTime</label>
                                <asp:TextBox runat="server" ID="CloseTime" class="form-control"></asp:TextBox>
                            </div>

                        </td>
                        <td>
                            <div class="form-group">
                                <label>OpenTime</label>
                                <asp:TextBox runat="server" ID="OpenTime" class="form-control"></asp:TextBox>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox runat="server" ID="Address" class="form-control"></asp:TextBox>
                            </div>

                        </td>
                        <td>
                            <div class="form-group">
                                <label>City</label>
                                <asp:TextBox runat="server" ID="City" class="form-control"></asp:TextBox>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <div class="form-group">
                                <label>State</label>
                                <asp:TextBox runat="server" ID="State" class="form-control"></asp:TextBox>
                            </div>

                        </td>

                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:Button Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click" class="btn btn-primary" />

                        </td>
                        <td>
                            <br />
                            <asp:LinkButton Text="Back" runat="server" CssClass="col-md-offset-3" PostBackUrl="~/DoctorList.aspx" />

                        </td>

                    </tr>
                </table>

                <asp:Label runat="server" ID="ErorrMessage" ForeColor="Red" Font-Bold="true" Enabled="false"></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
