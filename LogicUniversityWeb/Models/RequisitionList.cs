using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class RequisitionList
    {
        public int RequisitionID { get; set; }
        public string statusOfRequest { get; set; }
        public string DateofSubmission { get; set; }
        public string Comments { get; set; }
        public string DeptID_FK { get; set; }
        public Nullable<int> UserID_FK { get; set; }
    }
}