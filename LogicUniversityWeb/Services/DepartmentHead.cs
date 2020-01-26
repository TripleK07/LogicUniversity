using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using LogicUniversityWeb.Models;
using System.Web.Configuration;
using System.Diagnostics;
using LogicUniversityWeb.Services;

namespace LogicUniversityWeb.Services
{
    public class DepartmentHead:DataLink
    {

        public DataTable GetAllDelegation()
        {
            DataTable dt = new DataTable();
             using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Delegation", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}