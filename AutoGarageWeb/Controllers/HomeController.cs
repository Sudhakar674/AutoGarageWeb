using AutoGarageWeb.Filter;
using AutoGarageWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AutoGarageWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Dashboard(Home model)
        {
            DataSet ds = model.GetDashboardDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ViewBag.TotalInspection = ds.Tables[0].Rows[0]["TotalInspection"].ToString();
                ViewBag.TotalProductionYear = ds.Tables[1].Rows[0]["TotalProductionYear"].ToString();
                ViewBag.TotalCountry = ds.Tables[2].Rows[0]["TotalCountry"].ToString();
                ViewBag.TotalCarOption = ds.Tables[3].Rows[0]["TotalCarOption"].ToString();
                ViewBag.TotalExterior = ds.Tables[4].Rows[0]["TotalExterior"].ToString();
                ViewBag.TotalElectricalSystems = ds.Tables[5].Rows[0]["TotalElectricalSystems"].ToString();
                ViewBag.TotalBrakingAndSafety = ds.Tables[6].Rows[0]["TotalBrakingAndSafety"].ToString();
                ViewBag.TotalChassisCondition = ds.Tables[7].Rows[0]["TotalChassisCondition"].ToString();
                ViewBag.TotalSteeringSystem = ds.Tables[8].Rows[0]["TotalSteeringSystem"].ToString();
                ViewBag.TotalACAndEngineCooling = ds.Tables[9].Rows[0]["TotalACAndEngineCooling"].ToString();
                ViewBag.TotalRoadTest = ds.Tables[10].Rows[0]["TotalRoadTest"].ToString();
                ViewBag.TotalPowerTrain = ds.Tables[11].Rows[0]["TotalPowerTrain"].ToString();
                ViewBag.TotalHistoryAndRecord = ds.Tables[12].Rows[0]["TotalHistoryAndRecord"].ToString();               
            }
            return View(model);
        }







    }
}