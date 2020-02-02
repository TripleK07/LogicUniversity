using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using LogicUniversityWeb.Models;
using LogicUniversityWeb.Services;
using LogicUniversityWeb.Models.ViewModel;


namespace LogicUniversityWeb.Controllers
{
    public class DepartmentHeadController : Controller
    {

        List<DelegationViewModel> dv = new List<DelegationViewModel>();
        DepartmentHead dh = new DepartmentHead();
        // GET: DepartmentHead
        public ActionResult Index()
        {
            dv = dh.GetAllDelegation("All");
            return View(dv);
        }

        //For Changing STAFF to REPRESENTATIVE

        // show current representative and staff
        List<StaffViewModel> sv = new List<StaffViewModel>();
        public ActionResult CurrentRep()
        {
            StaffViewModel model = new StaffViewModel();
            model.CurrentRep = dh.FindCurrentRepresentative();
            model.UserList = dh.GetAllDeptStaff("All").AsEnumerable();

            return View(model);
        }

        public JsonResult apiCurrentRep()
        {
            StaffViewModel model = new StaffViewModel();
            model.CurrentRep = dh.FindCurrentRepresentative();
            model.UserList = dh.GetAllDeptStaff("All").AsEnumerable();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public RedirectToRouteResult Assign(FormCollection form)
        {
            try
            {
                int CurrentUserId = Convert.ToInt32(Request.Form["CurrentRep.UserID"].ToString());
                int NewUserId = Convert.ToInt32(Request.Form["SelectedNewRep"].ToString());
                
                bool res = dh.Assign(CurrentUserId, NewUserId);

                return RedirectToAction("CurrentRep");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}