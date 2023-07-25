<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebformTryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TryIt! Page for Alex Cayer&#39;s Services</h1>
        <p class="lead">&nbsp;</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Word Filter Service</h2>
            <p>&nbsp;</p>
            <p>
                This service takes in a string and filters out the stop words (such as &quot;a&quot;, &quot;am&quot;, &quot;that&quot;, etc) and returns the filtered string.</p>
            <p>
                URL: http://webstrar16.fulton.asu.edu/page7/Service1.svc</p>
            <p>
                Methods:</p>
            <p>
                string WordFilter(string str); Parameter: /filter/{str}</p>
            <p>
                Insert string to filter:</p>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="193px"></asp:TextBox>
            </p>
            <p>
                &nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Filter" Width="191px" />
            </p>
            <p>
                Filtered string:</p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Air Quality Service</h2>
            <p>
                This web service computes an air quality heuristic, 3 if the air is good, 2 if it is usg or unhealthy quality, or a 1 if the air quality is hazardous. Such a heuristic</p>
            <p>
                can be used as a parameter for computing other things. The heuristic is determined by getting data from the Aeris Weather company based on an input zip code.
            </p>
            <p>
                URL: <a href="http://webstrar16.fulton.asu.edu/page7/Service1.svc">http://webstrar16.fulton.asu.edu/page7/Service1.svc</a></p>
            <p>
                Methods:</p>
            <p>
                int GetAirQualityHeuristic(string str); Parameter: /zip/{str}</p>
            <p>
                Input a zip code to compute the air quality heuristic:</p>
            <p>
                <asp:TextBox ID="TextBox2" runat="server" Width="174px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Compute Heuristic" Width="177px" />
            </p>
            <p>
                Air Quality Heuristic for</p>
            <p>
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Natural Hazards Service</h2>
            <p>
                This web service gets climate data from the National Centers For Environmental Information (NCDC) for an area from the year 2021 defined by an input zipcode.
            </p>
            <p>
                URL: <a href="http://webstrar16.fulton.asu.edu/page7/Service1.svc">http://webstrar16.fulton.asu.edu/page7/Service1.svc</a></p>
            <p>
                Methods:</p>
            <p>
                string GetEMXT(string str); Parameter: /zipEMXT/{str}</p>
            <p>
                string GetEMNT(string str); Parameter: /zipEMNT/{str}</p>
            <p>
                string GetWSFG(string str); Parameter: /zipWSFG/{str}</p>
            <p>
                string GetEMXP(string str); Parameter: /zipEMXP/{str}</p>
            <p>
                string GetEMSN(string str); Parameter: /zipEMSN/{str}</p>
            <p>
                Input a zipcode to get relevent climate data:</p>
            <p>
                <asp:TextBox ID="TextBox3" runat="server" Width="175px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Get Max Temperature" Width="175px" />
            </p>
            <p>
                Extreme Max Temperature:
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Get Min Temperature" Width="177px" />
            </p>
            <p>
                Extreme Min Temperature:</p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Get Wind Gust Speed" Width="163px" />
            </p>
            <p>
                Max Wind Gust Speed:</p>
            <p>
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Get Precipitation" Width="172px" />
            </p>
            <p>
                Highest Daily Precipitation:</p>
            <p>
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Get Snowfall" Width="155px" />
            </p>
            <p>
                Highest Daily Snowfall:</p>
            <p>
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
