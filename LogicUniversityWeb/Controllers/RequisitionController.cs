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


        //public ActionResult Approve(int id)
        //{
        //    reqService.Approve(id, "Approved");
        //    req = reqService.GetAllRequisition("All");
        //    return View("Index", req);
        //}

        //public ActionResult Reject(int id)
        //{
        //    reqService.Approve(id, "Rejected");
        //    req = reqService.GetAllRequisition("All");
        //    return View("Index", req);
        //}

        //public ActionResult None(int id)
        //{
        //    reqService.Approve(id, "None");
        //    req = reqService.GetAllRequisition("All");
        //    return View("Index", req);
        //}

        [HttpPost]
        public JsonResult ApproveAjax(int id, string status)
        {
            reqService.Approve(id, status);
            
            var result  = new { Success = "true", Message = "" + status + " Successfully." };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
