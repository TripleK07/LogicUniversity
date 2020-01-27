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
            foreach (DataRow reader in dt.Rows)
            {
                RequisitionViewModel req = new RequisitionViewModel();

                req.RequisitionID = reader[0] != DBNull.Value ? (int)reader[0] : 0;
                req.statusOfRequest = reader[1] != DBNull.Value ? (string)reader[1] : "";
                req.DateofSubmission = reader[2] != DBNull.Value ? (string)reader[2] : "";
                req.Comments = reader[3] != DBNull.Value ? (string)reader[3] : "";
                req.DeptID_FK = reader[4] != DBNull.Value ? (string)reader[4] : "";
                req.UserID_FK = reader[5] != DBNull.Value ? (int)reader[5] : 0;
                req.DepartmentName = reader[6] != DBNull.Value ? (string)reader[6] : "";
                req.UserName = reader[7] != DBNull.Value ? (string)reader[7] : "";

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

        public RequisitionDetailViewModel GetRequisitionDetail(int id)
        {
            RequisitionDetailViewModel model = new RequisitionDetailViewModel();

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
                                Inner join Users u on r.UserID_FK = u.UserID
                                WHERE r.[RequisitionID] = " + id;
                
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    model.RequisitionID = reader[0] != DBNull.Value ? (int)reader[0] : 0;
                    model.statusOfRequest = reader[1] != DBNull.Value ? (string)reader[1] : "";
                    model.DateofSubmission = reader[2] != DBNull.Value ? (string)reader[2] : "";
                    model.Comments = reader[3] != DBNull.Value ? (string)reader[3] : "";
                    model.DeptID_FK = reader[4] != DBNull.Value ? (string)reader[4] : "";
                    model.UserID_FK = reader[5] != DBNull.Value ? (int)reader[5] : 0;
                    model.DepartmentName = reader[6] != DBNull.Value ? (string)reader[6] : "";
                    model.UserName = reader[7] != DBNull.Value ? (string)reader[7] : "";
                }

                con.Close();

                con.Open();
                query = @"SELECT [RequisitionDetailID]
                              ,[RequisitionID]
                              ,s.[ItemID]
                              ,[RequisitionQuantity]
	                          ,s.ItemName
                          FROM [dbo].[RequisitionDetail] d
                          Inner join Stationery s on s.ItemID = d.ItemID
                          WHERE RequisitionID = " + id;

                cmd = new SqlCommand(query, con);
                DataTable dtl = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtl);

                foreach (DataRow row in dtl.Rows)
                {
                    RequisitionDetailsWithItem reqDtl = new RequisitionDetailsWithItem();
                    reqDtl.RequisitionDetailID = row[0] != DBNull.Value ? (String)row[0] : "0";
                    reqDtl.RequisitionID = row[1] != DBNull.Value ? (int)row[1] : 0;
                    reqDtl.ItemID = row[2] != DBNull.Value ? (String)row[2] : "0"; 
                    reqDtl.RequisitionQuantity = row[3] != DBNull.Value ? (String)row[3] : "0";
                    reqDtl.ItemName = row[4] != DBNull.Value ? (String)row[4] : "0";

                    model.ReqDetails.Add(reqDtl);
                }

                con.Close();
                
            }
            return model;
        }
    }
}