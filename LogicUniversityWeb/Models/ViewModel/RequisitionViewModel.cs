using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models.ViewModel
{
    public class RequisitionViewModel : RequisitionList
    {
        [DisplayName("Department Name")]
        public String DepartmentName { get; set; }

        [DisplayName("Submitted User")]
        public String UserName { get; set; }
    }
}