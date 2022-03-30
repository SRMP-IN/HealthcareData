<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doctor.aspx.cs" Inherits="HealthcareData.Doctor" %>


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
                                <a href="Doctor.aspx">Home</a>
                            </li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li>
                                <a> <b>Welcome ! <asp:Label ID="LoginName" runat="server" /></b> <span class="sr-only">(current)</span></a></li>
                            <li><a href="Logout.aspx">Log Out</a></li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div class=" ">
                <h3>Appointment List </h3>
                <br />
                <asp:GridView ID="Grid" class="table table-bordered" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
                        <asp:BoundField DataField="PatientAge" HeaderText="Patient Age" /> 
                        <asp:BoundField DataField="PatientGender" HeaderText="Patient Gender" />  
                        <asp:BoundField DataField="BookDate" HeaderText="Book Date" DataFormatString="{0:dd/MM/yyyy HH:mm:tt}" />
                        <asp:BoundField DataField="BookingSlot" HeaderText="Booking Slot"  DataFormatString="{0:dd/MM/yyyy HH:mm:tt}" />                        
                        <asp:BoundField DataField="Checked" HeaderText="Attended" NullDisplayText="No" />
                        <asp:BoundField DataField="Symptoms" HeaderText="Symptoms" />
                        <asp:HyperLinkField DataNavigateUrlFields="Id" HeaderText="Detail" Text="Detail" DataNavigateUrlFormatString="~/PrescriptionSave.aspx?Id={0}" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
