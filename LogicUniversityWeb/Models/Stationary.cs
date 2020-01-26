using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class Stationary
    {
        public string ItemID { get; set; }
        public string CategoryID { get; set; }
        public string ItemName { get; set; }
        public string RequiredQuantity { get; set; }
        public string UOM { get; set; }
        public string ReorderLevel { get; set; }
        public string ReorderQuantity { get; set; }
        public string PrioritySupplier1 { get; set; }
        public string PrioritySupplier2 { get; set; }
        public string PrioritySupplier3 { get; set; }
    }
}