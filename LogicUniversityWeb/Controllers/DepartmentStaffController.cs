using LogicUniversityWeb.Models;
using LogicUniversityWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogicUniversityWeb.Controllers
{
    public class DepartmentStaffController : Controller
    {
        DepartmentStaff deptStaffService = new DepartmentStaff();
        // GET: DepartmentStaff
        public ActionResult Index()
        {
            Departments deptInfo = deptStaffService.FindUserDepartmentByUserId(1);

            return View(deptInfo);
        }


        [HttpPost]
        public JsonResult Update(int id, string point)
        {
            try
            {
                bool res = deptStaffService.UpdateCollectionPoint(id, point);

                if (res)
                    return Json(new { Success = "true", Message = "Update Successfully." }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Success = "false", Message = "Update Failed" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = "false", Message = "Update Failed" }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}