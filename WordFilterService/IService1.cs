using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WordFilterService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //word filter service methods
        //

        [OperationContract]
        [WebGet(UriTemplate = "/filter/{str}", ResponseFormat = WebMessageFormat.Json)]
        string WordFilter(string str);

        //air quality service methods
        //

        [OperationContract]
        [WebGet(UriTemplate = "/zip/{str}", ResponseFormat = WebMessageFormat.Json)]
        int GetAirQualityHeuristic(string str);//returns a heuristic used to determine the air quality in an area from zipcode

        //natural hazards service methods
        //

        [OperationContract]
        [WebGet(UriTemplate = "/zipEMXT/{str}", ResponseFormat = WebMessageFormat.Json)]
        double GetEMXT(string str);

        [OperationContract]
        [WebGet(UriTemplate = "/zipEMNT/{str}", ResponseFormat = WebMessageFormat.Json)]
        double GetEMNT(string str);

        [OperationContract]
        [WebGet(UriTemplate = "/zipWSFG/{str}", ResponseFormat = WebMessageFormat.Json)]
        double GetWSFG(string str);

        [OperationContract]
        [WebGet(UriTemplate = "/zipEMXP/{str}", ResponseFormat = WebMessageFormat.Json)]
        double GetEMXP(string str);

        [OperationContract]
        [WebGet(UriTemplate = "/zipEMSN/{str}", ResponseFormat = WebMessageFormat.Json)]
        double GetEMSN(string str);
    }

    //for air quality service
    //
    public class RootObjectAir
    {
        public string success { get; set; }
        public string error { get; set; }
        public Response[] response { get; set; }
        public Profile profile { get; set; }
        public string[] stations { get; set; }
    }

    public class Response
    {
        public string id { get; set; }
        public Location loc { get; set; }
        public Place place { get; set; }
        public Periods[] periods { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double @long { get; set; }
    }

    public class Place
    {
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }

    public class Periods
    {
        public string dateTimeISO { get; set; }
        public string timestamp { get; set; }
        public string aqi { get; set; }
        public string category { get; set; }
        public string color { get; set; }
        public string method { get; set; }
        public string dominant { get; set; }
        public Pollutants[] pollutants { get; set; }
    }

    public class Pollutants
    {
        public string type { get; set; }
        public string name { get; set; }
        public string valuePPB { get; set; }
        public string valueUGM3 { get; set; }
        public string aqi { get; set; }
        public string category { get; set; }
        public string color { get; set; }
        public string method { get; set; }
    }

    public class Profile
    {
        public string tz { get; set; }
        public Sources[] sources { get; set; }
    }

    public class Sources
    {
        public string name { get; set; }
    }

    //for natural hazards service
    //
    public class RootObject
    {
        public Metadata meta { get; set; }
        public Results[] results { get; set; }
    }

    public class Metadata
    {
        public ResultSet rset { get; set; }
    }

    public class ResultSet
    {
        int offset { get; set; }
        int count { get; set; }
        int limit { get; set; }
    }

    public class Results
    {
        public string date { get; set; }
        public string datatype { get; set; }
        public string station { get; set; }
        public string attributes { get; set; }
        public double value { get; set; }
    }
}
