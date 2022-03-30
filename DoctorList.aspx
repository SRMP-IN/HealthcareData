﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorList.aspx.cs" Inherits="HealthcareData.DoctorList" %>



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
                            <span class="sr-only">Telemedicine & Healthcare</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">Telemedicine & Healthcare</a>
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
                <h2>Doctor List </h2>
                 <br />
                 <h4> <asp:LinkButton Text="Add New Doctor" runat="server"   PostBackUrl="~/DoctorAdd.aspx" /></h4>
                <br />
                <asp:GridView ID="Grid" class="table table-bordered" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Doctor Name" />
                        <asp:BoundField DataField="EmailID" HeaderText="EmailID" />
                        <asp:BoundField DataField="Password" HeaderText="Password" />
                        <asp:BoundField DataField="Age" HeaderText="Age" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" /> 
                        <asp:BoundField DataField="DoctorDegree" HeaderText="DoctorDegree" />
                        <asp:BoundField DataField="OpenTime" HeaderText="OpenTime" />
                        <asp:BoundField DataField="CloseTime" HeaderText="CloseTime" />
                        <asp:BoundField DataField="Specialization" HeaderText="Specialization" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="State" HeaderText="State" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:HyperLinkField DataNavigateUrlFields="Id" HeaderText="Edit" Text="Edit" DataNavigateUrlFormatString="~/DoctorEdit.aspx?Id={0}" />
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
