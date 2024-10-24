using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace AutoGarageWeb.Models
{
    public class Home
    {
        public string TotalInspection { get; set; }
        public string TotalProductionYear { get; set; }
        public string TotalCountry { get; set; }
        public string TotalCarOption { get; set; }
        public string TotalExterior { get; set; }
        public string AcAndEngineCooling { get; set; }
        public string TotalElectricalSystems { get; set; }
        public string TotalBrakingAndSafety { get; set; }
        public string TotalChassisCondition { get; set; }
        public string TotalSteeringSystem { get; set; }
        public string TotalRoadTest { get; set; }
        public string TotalPowerTrain { get; set; }
        public string TotalHistoryAndRecord { get; set; }
        public string TotalACAndEngineCooling { get; set; }
       
        public DataSet GetDashboardDetails()
        {          
            DataSet ds = Connection.ExecuteQuery("GetDashboardDetails");
            return ds;
        }


     }
 }

 