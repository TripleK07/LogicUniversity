using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models.ViewModel
{
    public class RequisitionDetailsWithItem : RequisitionDetails
    {
        [DisplayName("Stationery Name")]
        public String ItemName { get; set; }
    }

    public class RequisitionDetailViewModel : RequisitionViewModel
    {
        public List<RequisitionDetailsWithItem> ReqDetails { get; set; }

        public RequisitionDetailViewModel()
        {
            this.ReqDetails = new List<RequisitionDetailsWithItem>();
        }
    }
}