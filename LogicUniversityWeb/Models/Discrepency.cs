using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class Discrepency
    {
        public string DiscrepencyID { get; set; }
        public string StockCardID { get; set; }
        public string DiscrepancyQty { get; set; }
        public string Reason { get; set; }
        public string DisbursementID { get; set; }
    }
}