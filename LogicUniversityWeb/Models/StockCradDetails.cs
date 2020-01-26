using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class StockCradDetails
    {
        public string StockCardDetailsID { get; set; }
        public string DisbursementID { get; set; }
        public string StockCardID { get; set; }
        public int Balance { get; set; }
    }
}