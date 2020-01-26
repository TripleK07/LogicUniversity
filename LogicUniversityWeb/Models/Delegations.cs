using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class Delegations
    {
        public string DelegationID { get; set; }
        public string DeptID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}