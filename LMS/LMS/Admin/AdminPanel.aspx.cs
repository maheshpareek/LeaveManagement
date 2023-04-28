using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LMS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM LeaveDetail WHERE ApplicationStatus='Pending'";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int count1 = (int)command.ExecuteScalar();

                pending.Text = ("Pending leaves: "+count1);

                connection.Close();

            }

            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM LeaveDetail WHERE ApplicationStatus='Approved'";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int count2 = (int)command.ExecuteScalar();

                approved.Text = ("Approved leaves: "+count2);

                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM LeaveDetail WHERE ApplicationStatus='Rejected'";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int count3 = (int)command.ExecuteScalar();

                rejected.Text = ("Rejected leaves: " + count3);

                connection.Close();
            }

        }
    }
}