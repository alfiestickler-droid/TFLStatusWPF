using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TFLStatusWPF.Models
{

    public class JourneyResponse
    {
        public string type { get; set; }
        public Journey[] journeys { get; set; }
        public Line[] lines { get; set; }
        public object[] stopMessages { get; set; }
        public int recommendedMaxAgeMinutes { get; set; }
        public Searchcriteria searchCriteria { get; set; }
        public Journeyvector journeyVector { get; set; }
    }

    public class Searchcriteria
    {
        public string type { get; set; }
        public DateTime dateTime { get; set; }
        public string dateTimeType { get; set; }
        public Timeadjustments timeAdjustments { get; set; }
    }

    public class Timeadjustments
    {
        public string type { get; set; }
        public Earliest earliest { get; set; }
        public Earlier earlier { get; set; }
        public Later later { get; set; }
        public Latest latest { get; set; }
    }

    public class Earliest
    {
        public string type { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string timeIs { get; set; }
        public string uri { get; set; }
    }

    public class Earlier
    {
        public string type { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string timeIs { get; set; }
        public string uri { get; set; }
    }

    public class Later
    {
        public string type { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string timeIs { get; set; }
        public string uri { get; set; }
    }

    public class Latest
    {
        public string type { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string timeIs { get; set; }
        public string uri { get; set; }
    }

    public class Journeyvector
    {
        public string type { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string via { get; set; }
        public string uri { get; set; }
    }

    public class Journey
    {
        public string type { get; set; }
        public DateTime startDateTime { get; set; }
        public int duration { get; set; }
        public DateTime arrivalDateTime { get; set; }
        public bool alternativeRoute { get; set; }
        public Leg[] legs { get; set; }
        public Fare fare { get; set; }
    }

    public class Fare
    {
        public string type { get; set; }
        public int totalCost { get; set; }
        public Fare1[] fares { get; set; }
        public Caveat[] caveats { get; set; }
    }

    public class Fare1
    {
        public string type { get; set; }
        public int lowZone { get; set; }
        public int highZone { get; set; }
        public int cost { get; set; }
        public string chargeProfileName { get; set; }
        public bool isHopperFare { get; set; }
        public string chargeLevel { get; set; }
        public int peak { get; set; }
        public int offPeak { get; set; }
        public Tap[] taps { get; set; }
    }

    public class Tap
    {
        public string type { get; set; }
        public string atcoCode { get; set; }
        public Tapdetails tapDetails { get; set; }
    }

    public class Tapdetails
    {
        public string type { get; set; }
        public string modeType { get; set; }
        public string validationType { get; set; }
        public string hostDeviceType { get; set; }
        public int nationalLocationCode { get; set; }
        public DateTime tapTimestamp { get; set; }
    }

    public class Caveat
    {

        public string text { get; set; }
        public string type { get; set; }
    }

    public class Leg
    {
        public string type { get; set; }
        public int duration { get; set; }
        public Instruction instruction { get; set; }
        public object[] obstacles { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public Departurepoint departurePoint { get; set; }
        public Arrivalpoint arrivalPoint { get; set; }
        public Path path { get; set; }
        public Routeoption[] routeOptions { get; set; }
        public Mode mode { get; set; }
        public object[] disruptions { get; set; }
        public object[] plannedWorks { get; set; }
        public float distance { get; set; }
        public bool isDisrupted { get; set; }
        public bool hasFixedLocations { get; set; }
        public DateTime scheduledDepartureTime { get; set; }
        public DateTime scheduledArrivalTime { get; set; }
    }

    public class Instruction
    {
        public string type { get; set; }
        public string summary { get; set; }
        public string detailed { get; set; }
        public Step[] steps { get; set; }
    }

    public class Step
    {
        public string type { get; set; }
        public string description { get; set; }
        public string turnDirection { get; set; }
        public string streetName { get; set; }
        public int distance { get; set; }
        public int cumulativeDistance { get; set; }
        public int skyDirection { get; set; }
        public string skyDirectionDescription { get; set; }
        public int cumulativeTravelTime { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public Pathattribute pathAttribute { get; set; }
        public string descriptionHeading { get; set; }
        public string trackType { get; set; }
        public int travelTime { get; set; }
    }

    public class Pathattribute
    {
        public string type { get; set; }
    }

    public class Departurepoint
    {
        public string type { get; set; }
        public string naptanId { get; set; }
        public string platformName { get; set; }
        public string icsCode { get; set; }
        public string individualStopId { get; set; }
        public string commonName { get; set; }
        public string placeType { get; set; }
        public object[] additionalProperties { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
    }

    public class Arrivalpoint
    {
        public string type { get; set; }
        public string naptanId { get; set; }
        public string platformName { get; set; }
        public string icsCode { get; set; }
        public string individualStopId { get; set; }
        public string commonName { get; set; }
        public string placeType { get; set; }
        public object[] additionalProperties { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
    }

    public class Path
    {
        public string type { get; set; }
        public string lineString { get; set; }
        public Stoppoint[] stopPoints { get; set; }
        public object[] elevation { get; set; }
    }

    public class Stoppoint
    {

        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
        public string routeType { get; set; }
        public string status { get; set; }
    }

    public class Mode
    {

        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string routeType { get; set; }
        public string status { get; set; }
        public string motType { get; set; }
        public string network { get; set; }
    }

    public class Routeoption
    {
        public string type { get; set; }
        public string name { get; set; }
        public string[] directions { get; set; }
        public Lineidentifier lineIdentifier { get; set; }
        public string direction { get; set; }
    }

    public class Lineidentifier
    {

        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
        public Crowding crowding { get; set; }
        public string routeType { get; set; }
        public string status { get; set; }
    }

    public class Crowding
    {
        public string type { get; set; }
    }

    public class Line
    {
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string modeName { get; set; }
        public object[] disruptions { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public Linestatus[] lineStatuses { get; set; }
        public object[] routeSections { get; set; }
        public Servicetype[] serviceTypes { get; set; }
        public Crowding1 crowding { get; set; }
    }

    public class Crowding1
    {
        public string type { get; set; }
    }

    public class Linestatus
    {
        public string type { get; set; }
        public int id { get; set; }
        public int statusSeverity { get; set; }
        public string statusSeverityDescription { get; set; }
        public DateTime created { get; set; }
        public object[] validityPeriods { get; set; }
    }

    public class Servicetype
    {
        public string type { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
    }

}