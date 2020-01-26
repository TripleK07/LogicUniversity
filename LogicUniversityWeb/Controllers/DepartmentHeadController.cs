using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using LogicUniversityWeb.Models;
using LogicUniversityWeb.Services;

namespace LogicUniversityWeb.Controllers
{
    public class DepartmentHeadController : Controller
    {
        // GET: DepartmentHead
        public ActionResult Index()
        {
            DepartmentHead dh = new DepartmentHead();
            DataTable dt = dh.GetAllDelegation();
            return View("Index",dt);
        }
    }
}