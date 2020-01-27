using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models.ViewModel
{


    public class RequisitionDetailViewModel : RequisitionViewModel
    {
        public List<RequisitionDetailsWithItem> ReqDetails { get; set; }

        public RequisitionDetailViewModel()
        {
            this.ReqDetails = new List<RequisitionDetailsWithItem>();
        }
    }
}