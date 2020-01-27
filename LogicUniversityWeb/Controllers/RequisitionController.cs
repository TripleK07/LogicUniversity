using LogicUniversityWeb.Models;
using LogicUniversityWeb.Models.ViewModel;
using LogicUniversityWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogicUniversityWeb.Controllers
{
    public class RequisitionController : Controller
    {
        List<RequisitionViewModel> req = new List<RequisitionViewModel>();
        Requisition reqService = new Requisition();

        // GET: Requisition
        public ActionResult Index()
        {
            req = reqService.GetAllRequisition("All");

            return View(req);
        }
        public ActionResult GetFilteredRequisition(String filterReq)
        {
            req = reqService.GetAllRequisition(filterReq);

            return View("Index", req);
        }

        [HttpPost]
        public JsonResult ApproveAjax(int id, string status)
        {
            try
            {
                bool res = reqService.Approve(id, status);

                if (res)
                    return Json(new { Success = "true", Message = "Updated to " + status + " Successfully." }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Success = "false", Message = "Updated to " + status + " Failed." }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception)
            {
                return Json(new { Success = "false", Message = "Updated to " + status + " Failed." }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int id)
        {
            RequisitionDetailViewModel model = reqService.GetRequisitionDetail(id);
            return View(model);
        }
    }
}
