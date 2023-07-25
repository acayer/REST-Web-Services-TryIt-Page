<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TryItPagesWebsite.WebForm1" %>
<%@ OutputCache Duration="20" VaryByParam="*" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" GridLines="Both" Width="700">
                <asp:TableRow BackColor="#daeef3"><asp:TableCell ColumnSpan="4" Font-Bold="true" HorizontalAlign="Center">Service Directory</asp:TableCell></asp:TableRow>
                <asp:TableRow BackColor="#daeef3"><asp:TableCell ColumnSpan="4">This project is developed by: Alexandre Cayer</asp:TableCell></asp:TableRow>
                <asp:TableRow BackColor="#daeef3">
                    <asp:TableCell>Service name</asp:TableCell>
                    <asp:TableCell>TryIt link</asp:TableCell>
                    <asp:TableCell>Service description</asp:TableCell>
                    <asp:TableCell>APIs/Web Service Methods</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Natural Hazards Service</asp:TableCell>
                    <asp:TableCell><a href="http://localhost:60815/Default.aspx">Try It</a></asp:TableCell>
                    <asp:TableCell>This web service gets climate data from the National Centers For Environmental Information (NCDC) for an area from the year 2021 defined by an input zipcode. </asp:TableCell>
                    <asp:TableCell>ncdc.noaa.gov/cdo-web/api/v2 ,GetEMXT(), GetEMNT(), GetWSFG(), GetEMXP(), GetEMSN()</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Air Quality Service</asp:TableCell>
                    <asp:TableCell><a href="http://localhost:60815/Default.aspx">Try It</a></asp:TableCell>
                    <asp:TableCell>This web service computes an air quality heuristic, 3 if the air quality is good, 2 if it is usg or unhealthy quality, or a 1 if the air quality is hazardous. Such a heuristic can be used as a parameter for computing other things. The heuristic is determined by getting data from the Aeris Weather company based on an input zipcode.</asp:TableCell>
                    <asp:TableCell>api.aerisapi.com/airquality/ , int GetAirQualityHeuristic(string str)</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Word Filter Service</asp:TableCell>
                    <asp:TableCell><a href="http://localhost:60815/Default.aspx">Try It</a></asp:TableCell>
                    <asp:TableCell>This service takes in a string and filters out the stop words (such as "a", "am", "that", etc) and returns the filtered string. </asp:TableCell>
                    <asp:TableCell>WordFilter(string str)</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
