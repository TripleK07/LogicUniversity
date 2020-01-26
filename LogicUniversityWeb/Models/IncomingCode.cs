using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class IncomingCode
    {
        public string StockCardID { get; set; }
        public string SupplierID { get; set; }
        public string IncomingQty { get; set; }
        public Nullable<System.DateTime> IncomingDate { get; set; }
    }
}