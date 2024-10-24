using AutoGarageWeb.Filter;
using AutoGarageWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AutoGarageWeb.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult CarMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetCarListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                    model.CarName = ds.Tables[0].Rows[0]["CarName"].ToString();
                    model.ModelNumber = ds.Tables[0].Rows[0]["ModelNumber"].ToString();
                    model.EngeenType = ds.Tables[0].Rows[0]["EngeenType"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CarMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult CarMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveCarMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CarMaster", "Master");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CarMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult CarMaster(Master model, string Id, string com)
        {
            try
            {

                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateCarMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CarMaster", "Master");
        }

        public ActionResult CarListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetCarListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.Company = dr["Company"].ToString();
                    obj.CarName = dr["CarName"].ToString();
                    obj.ModelNumber = dr["ModelNumber"].ToString();
                    obj.EngeenType = dr["EngeenType"].ToString();
                    lst.Add(obj);
                }
                model.CarMasterlst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CarListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult CarListMaster(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetCarListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.Company = dr["Company"].ToString();
                    obj.CarName = dr["CarName"].ToString();
                    obj.ModelNumber = dr["ModelNumber"].ToString();
                    obj.EngeenType = dr["EngeenType"].ToString();
                    lst.Add(obj);
                }
                model.CarMasterlst = lst;
            }
            return View(model);
        }
        public ActionResult DeleteCarMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteCarMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CarListMaster", "Master");
        }

        public ActionResult BrakingAndSafetyMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetBrakingAndSafetyListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.BrakingAndSafety = ds.Tables[0].Rows[0]["BrakingAndSafety"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("BrakingAndSafetyMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult BrakingAndSafetyMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveBrakingAndSafetyMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("BrakingAndSafetyMaster", "Master");
        }

        public ActionResult BrakingAndSafetyListMaster()
        {

            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetBrakingAndSafetyListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.BrakingAndSafety = dr["BrakingAndSafety"].ToString();
                    lst.Add(obj);
                }
                model.BrakingAndSafetylst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("BrakingAndSafetyListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult BrakingAndSafetyListMaster(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetBrakingAndSafetyListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.BrakingAndSafety = dr["BrakingAndSafety"].ToString();
                    lst.Add(obj);
                }
                model.BrakingAndSafetylst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("BrakingAndSafetyMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult BrakingAndSafetyMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateBrakingAndSafetyMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("BrakingAndSafetyMaster", "Master");
        }

        public ActionResult DeleteBrakingAndSafetyMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteBrakingAndSafetyMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("BrakingAndSafetyListMaster", "Master");
        }

        public ActionResult CarOptionMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetCarOptionListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.CarOption = ds.Tables[0].Rows[0]["CarOption"].ToString();
                }
            }
            return View(model);
         }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CarOptionMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult CarOptionMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveCarOptionMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CarOptionMaster", "Master");
        }

        public ActionResult CarOptionListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetCarOptionListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.CarOption = dr["CarOption"].ToString();
                    lst.Add(obj);
                }
                model.CarOptionlst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CarOptionListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult CarOptionListMaster(Master model)
        {          
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetCarOptionListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.CarOption = dr["CarOption"].ToString();
                    lst.Add(obj);
                }
                model.CarOptionlst = lst;
            }
            return View(model);
        }

        public ActionResult DeleteCarOptionMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteCarOptionMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CarOptionListMaster", "Master");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CarOptionMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult CarOptionMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateCarOptionMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CarOptionMaster", "Master");
        }

        public ActionResult ChassisConditionMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetChassisConditionListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.ChassisCondition = ds.Tables[0].Rows[0]["ChassisCondition"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ChassisConditionMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult ChassisConditionMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveChassisConditionMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ChassisConditionMaster", "Master");
        }

        public ActionResult ChassisConditionListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetChassisConditionListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.ChassisCondition = dr["ChassisCondition"].ToString();
                    lst.Add(obj);
                }
                model.ChassisConditionlst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ChassisConditionListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult ChassisConditionListMaster(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetChassisConditionListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.ChassisCondition = dr["ChassisCondition"].ToString();
                    lst.Add(obj);
                }
                model.ChassisConditionlst = lst;
            }
            return View(model);
        }

        public ActionResult DeleteChassisConditionMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteChassisConditionMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ChassisConditionListMaster", "Master");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ChassisConditionMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult ChassisConditionMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateChassisConditionMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ChassisConditionMaster", "Master");
        }

        public ActionResult CountryMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetCountryListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.CountryName = ds.Tables[0].Rows[0]["CountryName"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CountryMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult CountryMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveCountryMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CountryMaster", "Master");
        }

        public ActionResult CountryListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetCountryListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.CountryName = dr["CountryName"].ToString();
                    lst.Add(obj);
                }
                model.Countrylst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CountryListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult CountryListMaster(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetCountryListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.CountryName = dr["CountryName"].ToString();
                    lst.Add(obj);
                }
                model.Countrylst = lst;
            }
            return View(model);
        }

        public ActionResult DeleteCountryMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteCountryMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CountryListMaster", "Master");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("CountryMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult CountryMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateCountryMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("CountryMaster", "Master");
        }

        public ActionResult ElectricalSystemsMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetElectricalSystemsListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.ElectricalSystems = ds.Tables[0].Rows[0]["ElectricalSystems"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ElectricalSystemsMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult ElectricalSystemsMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveElectricalSystemsMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ElectricalSystemsMaster", "Master");
        }

        public ActionResult ElectricalSystemsListMaster()
        {
            Master model=new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetElectricalSystemsListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.ElectricalSystems = dr["ElectricalSystems"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ElectricalSystemsListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult ElectricalSystemsListMaster(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetElectricalSystemsListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.ElectricalSystems = dr["ElectricalSystems"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        public ActionResult DeleteElectricalSystemsMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteElectricalSystemsMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ElectricalSystemsListMaster", "Master");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ElectricalSystemsMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult ElectricalSystemsMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateElectricalSystemsMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ElectricalSystemsMaster", "Master");
        }

        public ActionResult ExteriorMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetExteriorListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Exterior = ds.Tables[0].Rows[0]["Exterior"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ExteriorMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult ExteriorMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveExteriorMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ExteriorMaster", "Master");
        }

        public ActionResult ExteriorListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetExteriorListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.Exterior = dr["Exterior"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ExteriorListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult ExteriorListMaster(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetExteriorListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.Exterior = dr["Exterior"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ExteriorMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult ExteriorMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateExteriorMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ExteriorMaster", "Master");
        }

        public ActionResult DeleteExteriorMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteExteriorMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ExteriorListMaster", "Master");
        }

        public ActionResult HistoryAndRecordMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetHistoryAndRecordListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.HistoryAndRecord = ds.Tables[0].Rows[0]["HistoryAndRecord"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("HistoryAndRecordMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult HistoryAndRecordMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveHistoryAndRecordMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("HistoryAndRecordMaster", "Master");
        }

        public ActionResult HistoryAndRecordListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetHistoryAndRecordListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.HistoryAndRecord = dr["HistoryAndRecord"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("HistoryAndRecordListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult HistoryAndRecordListMaster(Master model)
        {       
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetHistoryAndRecordListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.HistoryAndRecord = dr["HistoryAndRecord"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("HistoryAndRecordMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult HistoryAndRecordMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateHistoryAndRecordMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("HistoryAndRecordMaster", "Master");
        }

        public ActionResult DeleteHistoryAndRecordMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteHistoryAndRecordMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("HistoryAndRecordListMaster", "Master");
        }


        public ActionResult InspectionMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetInspectionListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.InspectionName = ds.Tables[0].Rows[0]["InspectionName"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("InspectionMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult InspectionMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveInspectionMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("InspectionMaster", "Master");
        }

        public ActionResult InspectionListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetInspectionListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.InspectionName = dr["InspectionName"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("InspectionListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult InspectionListMaster(Master model)
        {          
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetInspectionListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.InspectionName = dr["InspectionName"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("InspectionMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult InspectionMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateInspectionMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("InspectionMaster", "Master");
        }

        public ActionResult DeleteInspectionMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteInspectionMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("InspectionListMaster", "Master");
        }


        public ActionResult PowerTrainMaster(Master model, string Id)
        {

            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetPowerTrainListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.PowerTrain = ds.Tables[0].Rows[0]["PowerTrain"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("PowerTrainMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult PowerTrainMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SavePowerTrainMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("PowerTrainMaster", "Master");
        }

        public ActionResult PowerTrainListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetPowerTrainListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.PowerTrain = dr["PowerTrain"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("PowerTrainListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult PowerTrainListMaster(Master model)
        {        
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetPowerTrainListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.PowerTrain = dr["PowerTrain"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("PowerTrainMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult PowerTrainMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdatePowerTrainMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("PowerTrainMaster", "Master");
        }


        public ActionResult DeletePowerTrainMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeletePowerTrainMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("PowerTrainListMaster", "Master");
        }


        public ActionResult ProductionYearMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetProductionYearListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.ProductionYear = ds.Tables[0].Rows[0]["ProductionYear"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ProductionYearMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult ProductionYearMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveProductionYearMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ProductionYearMaster", "Master");
        }

        public ActionResult ProductionYearListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetProductionYearListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.ProductionYear = dr["ProductionYear"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ProductionYearListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult ProductionYearListMaster(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetProductionYearListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.ProductionYear = dr["ProductionYear"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("ProductionYearMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult ProductionYearMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateProductionYearMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ProductionYearMaster", "Master");
        }

        public ActionResult DeleteProductionYearMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteProductionYearMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("ProductionYearListMaster", "Master");
        }

        public ActionResult RoadTestMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetRoadTestListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.RoadTest = ds.Tables[0].Rows[0]["RoadTest"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("RoadTestMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult RoadTestMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveRoadTestMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("RoadTestMaster", "Master");
        }

        public ActionResult RoadTestListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetRoadTestListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.RoadTest = dr["RoadTest"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("RoadTestListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult RoadTestListMaster(Master model)
        {
           
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetRoadTestListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.RoadTest = dr["RoadTest"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("RoadTestMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult RoadTestMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateRoadTestMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("RoadTestMaster", "Master");
        }


        public ActionResult DeleteRoadTestMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteRoadTestMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("RoadTestListMaster", "Master");
        }

        public ActionResult SteeringSystemMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetSteeringSystemListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.SteeringSystem = ds.Tables[0].Rows[0]["SteeringSystem"].ToString();
                }
            }
            return View(model);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("SteeringSystemMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult SteeringSystemMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveSteeringSystemMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("SteeringSystemMaster", "Master");
        }

        public ActionResult SteeringSystemListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetSteeringSystemListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.SteeringSystem = dr["SteeringSystem"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("SteeringSystemListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult SteeringSystemListMaster(Master model)
        {
            
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetSteeringSystemListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.SteeringSystem = dr["SteeringSystem"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("SteeringSystemMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult SteeringSystemMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateSteeringSystemMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("SteeringSystemMaster", "Master");
        }

        public ActionResult DeleteSteeringSystemMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteSteeringSystemMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("SteeringSystemListMaster", "Master");
        }

        public ActionResult AcAndEngineCoolingMaster(Master model, string Id)
        {
            if (Id != null)
            {
                model.Id = Crypto.Decrypt(Id);
                DataSet ds = model.GetAcAndEngineCoolingListMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.AcAndEngineCooling = ds.Tables[0].Rows[0]["AcAndEngineCooling"].ToString();
                }
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("AcAndEngineCoolingMaster")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult AcAndEngineCoolingMaster(Master model)
        {
            try
            {
                model.CreatedBy = "1";
                DataSet ds = model.SaveAcAndEngineCoolingMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Message"] = "Record Saved Successfully !!.";
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("AcAndEngineCoolingMaster", "Master");
        }


        public ActionResult AcAndEngineCoolingListMaster()
        {
            Master model = new Master();
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetAcAndEngineCoolingListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.AcAndEngineCooling = dr["AcAndEngineCooling"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("AcAndEngineCoolingListMaster")]
        [OnAction(ButtonName = "btnsearch")]
        public ActionResult AcAndEngineCoolingListMaster(Master model)
        {           
            List<Master> lst = new List<Master>();
            DataSet ds = model.GetAcAndEngineCoolingListMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Idencrypt = Crypto.Encrypt(dr["Id"].ToString());
                    obj.Id = dr["Id"].ToString();
                    obj.AcAndEngineCooling = dr["AcAndEngineCooling"].ToString();
                    lst.Add(obj);
                }
                model.lst = lst;
            }
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("AcAndEngineCoolingMaster")]
        [OnAction(ButtonName = "btnupdate")]
        public ActionResult AcAndEngineCoolingMaster(Master model, string Id, string com)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.UpdateAcAndEngineCoolingMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Updated Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("AcAndEngineCoolingMaster", "Master");
        }


        public ActionResult DeleteAcAndEngineCoolingMaster(Master model, string Id)
        {
            try
            {
                if (Id != null)
                {
                    model.Id = Crypto.Decrypt(Id);
                    DataSet ds = model.DeleteAcAndEngineCoolingMaster();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                        {
                            TempData["Message"] = "Record Deleted Successfully !!.";
                        }
                        else
                        {
                            TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        TempData["Message"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("AcAndEngineCoolingListMaster", "Master");
        }



    }
}