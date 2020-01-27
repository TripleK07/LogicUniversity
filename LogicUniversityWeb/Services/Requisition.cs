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
using LogicUniversityWeb.Models.ViewModel;

namespace LogicUniversityWeb.Services
{
    public class Requisition : DataLink
    {

        public List<RequisitionViewModel> ConvertToModel(DataTable dt)
        {
            List<RequisitionViewModel> model = new List<RequisitionViewModel>();
            foreach (DataRow row in dt.Rows)
            {
                RequisitionViewModel req = new RequisitionViewModel();

                req.RequisitionID = row[0] != DBNull.Value ? (int)row[0] : 0;
                req.statusOfRequest = row[1] != DBNull.Value ? (string)row[1] : "";
                req.DateofSubmission = row[2] != DBNull.Value ? (string)row[2] : "";
                req.Comments = row[3] != DBNull.Value ? (string)row[3] : "";
                req.DeptID_FK = row[4] != DBNull.Value ? (string)row[4] : "";
                req.UserID_FK = row[5] != DBNull.Value ? (int)row[5] : 0;
                req.DepartmentName = row[6] != DBNull.Value ? (string)row[6] : "";
                req.UserName = row[7] != DBNull.Value ? (string)row[7] : "";

                model.Add(req);
            }

            return model;
        }

        public List<RequisitionViewModel> GetAllRequisition(String statusFilter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                String query = @"SELECT 
                                    [RequisitionID]
                                    ,[statusOfRequest]
                                    ,[DateofSubmission]
                                    ,[Comments]
                                    ,r.[DeptID_FK] 
                                    ,r.[UserID_FK] 
	                                ,d.[Departmentname]
                                    ,u.[Username]
                                FROM [RequisitionList] r
                                Inner join Department d on r.DeptID_FK = d.DepartmentID
                                Inner join Users u on r.UserID_FK = u.UserID ";

                if(statusFilter != "All")
                {
                    query = query + " WHERE r.[statusOfRequest] = '" + statusFilter +"';";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return ConvertToModel(dt);
        }

        public bool Approve(int id, String isApproved)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                String query = @"";
                
                if(isApproved == "Approved")
                    query = @"UPDATE [RequisitionList] SET [statusOfRequest] = 'Approved' WHERE [RequisitionID] = " + id;
                else if(isApproved == "Rejected")
                    query = @"UPDATE [RequisitionList] SET [statusOfRequest] = 'Rejected' WHERE [RequisitionID] = " + id;
                else
                    query = @"UPDATE [RequisitionList] SET [statusOfRequest] = 'None' WHERE [RequisitionID] = " + id;
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();
                    con.Close();

                    if (count > 0)
                        return true;
                    else
                        return false;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}