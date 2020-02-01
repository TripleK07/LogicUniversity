using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LogicUniversityWeb.Models.ViewModel
{
    public class StaffViewModel : Users
    {
        public Users CurrentRep { get; set; }
        public Int32 SelectedNewRep { get; set; }
        public IEnumerable<Users> UserList { get; set; }
    }
}