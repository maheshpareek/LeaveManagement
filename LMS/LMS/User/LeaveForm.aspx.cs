using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace LMS.User
{
    public partial class LeaveForm : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            string UName = Request.QueryString["lbl"];

            string connectionString = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";
            string query = "SELECT * FROM StudentInfo WHERE EnrolmentNo = @UName";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(UName))
                {
                    command.Parameters.AddWithValue("@UName", UName);
                }
                else
                {
                    // handle case where uname parameter is not provided
                }
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentId.Text = reader.GetString(0);
                        StudentName.Text = reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3);
                        Department.Text = reader.GetString(5);
                        Class.Text = reader.GetString(6) + " " + reader.GetString(5);
                    }
                }
                else
                {
                    // handle case where no rows are returned
                }

                reader.Close();
            }
            // Calender



        }



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            cal11.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            cal2.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }

        protected void Unnamed13_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO LeaveDetail(StudentId, StudentName, Department, Class, LeaveType, LeaveFrom, LeaveTo, ApplicationStatus) VALUES(@StudentId, @StudentName, @Department, @Class, @LeaveType, @LeaveFrom, @LeaveTo, @ApplicationStatus)");
                cmd.Parameters.AddWithValue("@StudentId", StudentId.Text);
                cmd.Parameters.AddWithValue("@StudentName", StudentName.Text);
                cmd.Parameters.AddWithValue("@Department", Department.Text);
                cmd.Parameters.AddWithValue("@Class", Class.Text);
                cmd.Parameters.AddWithValue("@LeaveType", LeaveType.SelectedItem.Text);
                DateTime leaveFromDate, leaveToDate;
                if (DateTime.TryParse(cal11.Text, out leaveFromDate))
                {
                    cmd.Parameters.AddWithValue("@LeaveFrom", leaveFromDate);
                }
                if (DateTime.TryParse(cal2.Text, out leaveToDate))
                {
                    cmd.Parameters.AddWithValue("@LeaveTo", leaveToDate);
                }
                cmd.Parameters.AddWithValue("@ApplicationStatus", "Pending");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
