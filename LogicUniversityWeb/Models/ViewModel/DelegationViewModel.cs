using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models.ViewModel
{
    public class DelegationViewModel : Delegations
    {
        [DisplayName("Assign User")]
        public String UserName { get; set; }

        public String DepartmentName { get; set; }
    }
}