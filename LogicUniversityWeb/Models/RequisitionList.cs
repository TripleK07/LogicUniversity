using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models
{
    public class RequisitionList
    {
        [Required]
        public int RequisitionID { get; set; }

        [DisplayName("Status")]
        public string statusOfRequest { get; set; }

        [DisplayName("Date of submission")]
        public string DateofSubmission { get; set; }
        public string Comments { get; set; }
        public string DeptID_FK { get; set; }
        public Nullable<int> UserID_FK { get; set; }
    }
}