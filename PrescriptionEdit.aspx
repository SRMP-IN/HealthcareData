<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrescriptionEdit.aspx.cs" Inherits="HealthcareData.PrescriptionEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Book a Doctor's Appointment</title>
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
                            <span class="sr-only">Telemedicine & Healthcare</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">Telemedicine & Healthcare</a>
                    </div>
                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li>
                                <a href="User.aspx">Home</a>
                            </li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li>
                                <a><b>Welcome !
                                    <asp:Label ID="LoginName" runat="server" /></b> <span class="sr-only">(current)</span></a></li>
                            <li><a href="Logout.aspx">Log Out</a></li>
                        </ul>
                    </div>
                </div>
            </nav>



            <div class=" ">
                <h4>Doctor's  Appointment Detail </h4>
                <br />

                <table style="width: 100%;">
                    <tr>
                        <td colspan="3">
                            <div class="form-group">
                                <label>Doctor Name</label>
                                <asp:DropDownList runat="server" ID="DoctorList" CssClass="form-control" Style="max-width: 93% !important;">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <div class="form-group">
                                <label>Patient Name</label>
                                <asp:TextBox runat="server" ID="PatientName" class="form-control"></asp:TextBox>
                            </div>

                        </td>
                        <td>
                            <div class="form-group">
                                <label>Patient Gender</label>
                                <asp:DropDownList runat="server" ID="PatientGender" CssClass="form-control">
                                    <asp:ListItem Text="Male" Value="Male" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <label>Patient Age</label>
                                <asp:TextBox runat="server" ID="PatientAge" TextMode="Number" min="1" max="200" class="form-control"></asp:TextBox>
                            </div>
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <div class="form-group">
                                <label>Patient Detail</label>
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="PatientDetail" class="form-control"></asp:TextBox>
                            </div>

                        </td>
                        <td>
                            <div class="form-group">
                                <label>Booking Slot</label>
                                <asp:TextBox runat="server" ID="BookingSlot" ReadOnly class="form-control"></asp:TextBox>
                            </div>
                        </td>

                        <td>
                            <div class="form-group">
                                <label>Attended</label>
                                <asp:TextBox ReadOnly runat="server" ID="Checked" class="form-control"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div class="form-group">
                                <label>Symptoms</label>
                                <asp:TextBox Style="max-width: 93% !important;" TextMode="MultiLine" Rows="3" runat="server" ID="Symptoms" class="form-control"></asp:TextBox>
                            </div>

                        </td>
                    </tr>

                    <tr>
                        <td colspan="3">
                            <div class="form-group">
                                <label>Prescription</label>
                                <asp:TextBox Style="max-width: 93% !important;" TextMode="MultiLine" Rows="10" runat="server" ID="Prescription" class="form-control"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div class="form-group">
                                <label>Reports</label>
                                <asp:TextBox Style="max-width: 93% !important;" TextMode="MultiLine" Rows="10" runat="server" ID="Reports" type="datetime-local" class="form-control"></asp:TextBox>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3">
                            <asp:Button Text="Delete" runat="server" ID="btnSave" OnClick="btnSave_Click" class="btn btn-primary" />

                            <asp:LinkButton Text="Back" runat="server" CssClass="col-md-offset-1" PostBackUrl="~/User.aspx" />

                        </td>
                        <asp:Label runat="server" ID="ErorrMessage" ForeColor="Red" Font-Bold="true" Enabled="false"></asp:Label>
                    </tr>
                </table>

            </div>
        </div>
    </form>
</body>
</html>
