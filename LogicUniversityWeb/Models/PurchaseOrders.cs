using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class PurchaseOrders
    {
        public string PurchaseOrderID { get; set; }
        public string DescriptionPurchase { get; set; }
        public string SupplierID { get; set; }
        public string ItemID { get; set; }
        public Nullable<bool> PurchaseOrderStatus { get; set; }
    }
}