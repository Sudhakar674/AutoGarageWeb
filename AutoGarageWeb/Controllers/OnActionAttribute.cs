﻿using System;
using System.Reflection;
using System.Web.Mvc;

namespace AutoGarageWeb.Filter
{
    public class SimpleAttribute
    {
    }
    public class OnActionAttribute : ActionMethodSelectorAttribute
    {
        public string ButtonName { get; set; }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var req = controllerContext.RequestContext.HttpContext.Request;
            return !string.IsNullOrEmpty(req.Form[this.ButtonName]);
        }
    }


}