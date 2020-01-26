using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class RequisitionDetails
    {
        public string RequisitionDetailID { get; set; }
        public int RequisitionID { get; set; }
        public string ItemID { get; set; }
        public string RequisitionQuantity { get; set; }
    }
}