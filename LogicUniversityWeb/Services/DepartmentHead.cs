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
using LogicUniversityWeb.Models.ViewModel;


namespace LogicUniversityWeb.Services
{
    public class DepartmentHead:DataLink
    {


        public List<DelegationViewModel> ConvertToModel(DataTable dt)
        {
            List<DelegationViewModel> model = new List<DelegationViewModel>();
            foreach (DataRow row in dt.Rows)
            {
                DelegationViewModel delegation = new DelegationViewModel();

                //delegation.DelegationID = (row[0] != null || row[0] != DBNull.Value) ? Convert.ToInt32(row[0]) : 0;
                // delegation.DelegationID = (int)row[0];
                delegation.DelegationID = row[0] != DBNull.Value ? (string)row[0] : "";
                delegation.StartDate = Convert.ToDateTime(row[1]);
                delegation.EndDate = Convert.ToDateTime(row[2]);
                delegation.DeptID = (string)row[3];
                delegation.UserID = (int)row[4];
                delegation.DepartmentName = (string)row[5];
                delegation.UserName = (string)row[6];
                model.Add(delegation);
                // delegation.DeptID = row[3] != DBNull.Value ? (string)row[3] : "";
                // delegation.UserID = row[4] != DBNull.Value ? (int)row[4] : 0;


                // delegation.DepartmentName = row[5] != DBNull.Value ? (string)row[5] : "";
                // delegation.UserName = row[6] != DBNull.Value ? (string)row[6] : "";


            }

            return model;
        }



        public List<DelegationViewModel> GetAllDelegation(String statusFilter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                String query = @"SELECT 
                                    [DelegationID]
                                    ,[StartDate]
                                    ,[EndDate]
                                    ,d.[DeptID] 
                                    ,u.[UserID] 
	                                ,dp.[DepartmentName]
                                    ,u.[Username]
                                FROM [Delegation] d
                                Inner join Users u on d.UserID = u.UserID
                                Inner join Department dp on dp.DepartmentID = u.DeptID_FK ";

                /*  if (statusFilter != "All")
                  {
                      query = query + " WHERE r.[statusOfRequest] = '" + statusFilter + "';";
                  }*/

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return ConvertToModel(dt);
        }


        // For Representative Assign
        public Users FindCurrentRepresentative()
        {
            Users u = new Users();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                String query = @" SELECT *
                                FROM [Users] u
                                 WHERE u.role  ='DeptRep' ";

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    u.UserID = reader[0] != DBNull.Value ? (int)reader[0] : throw new Exception("No user found");
                    u.Username = reader[1] != DBNull.Value ? (String)reader[1] : "";
                    u.Passcode = reader[2] != DBNull.Value ? (String)reader[2] : "";
                    u.EmailID = reader[3] != DBNull.Value ? (String)reader[3] : "";
                    u.role = reader[4] != DBNull.Value ? (String)reader[4] : "";
                    u.SessionID = reader[5] != DBNull.Value ? (String)reader[5] : "";
                    //dept.FaxNo = reader[6] != DBNull.Value ? (String)reader[6] : "";
                }

            }
            return u;
        }
        public List<Users> GetAllDeptStaff(String statusFilter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                String query = @"SELECT 
                                    [UserID]
                                    ,[Username]
                                    ,[role]
                                    FROM  Users 
                                    WHERE role='DeptStaff' ";
                /*  if (statusFilter != "All")
                  {
                      query = query + " WHERE r.[statusOfRequest] = '" + statusFilter + "';";
                  }*/

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return ConvertToStaffModel(dt);
        }
        public List<Users> ConvertToStaffModel(DataTable dt)
        {
            List<Users> model = new List<Users>();
            foreach (DataRow row in dt.Rows)
            {
                Users staff = new Users();
                staff.UserID = (row[0] != null || row[0] != DBNull.Value) ? Convert.ToInt32(row[0]) : 0;
               // staff.UserID = row[0] != DBNull.Value ? (string)row[0] : "";
                staff.Username = row[1] != DBNull.Value ? (string)row[1] : "";
                staff.role = row[2] != DBNull.Value ? (string)row[2] : "";
                
                model.Add(staff);
            

            }

            return model;
        }

        public bool Assign(int CurrentUserId, int NewUserId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                String query = @" UPDATE Users Set Role = 'DeptStaff' WHERE UserID = " + CurrentUserId + ";" + Environment.NewLine;
                query = query + " UPDATE Users Set Role = 'DeptRep'  WHERE UserID = " + NewUserId;

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int count = cmd.ExecuteNonQuery();
                con.Close();

                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}