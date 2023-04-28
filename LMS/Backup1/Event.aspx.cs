using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LMS
{
    public partial class Event : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


          // string date = edate1.SelectedDate.ToShortDateString();
            
            
            string connectionString = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertSql = "INSERT INTO event (ename, eceo, ecoordinator, eabout,edate) " +
                                   "VALUES (@ename, @eceo, @ecoordinator, @eabout, @edate)";

                using (SqlCommand command = new SqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@ename", ename1.Text);
                    command.Parameters.AddWithValue("@eceo", eceo1.Text);
                    command.Parameters.AddWithValue("@ecoordinator", ecoordinator1.Text);
                    command.Parameters.AddWithValue("@eabout", eabout1.Text);
                    command.Parameters.AddWithValue("@edate", edate1.SelectedDate.ToShortDateString());

                    int rowsAffected = command.ExecuteNonQuery();
                    Label1.Text=("Rows inserted: " + rowsAffected);
             
                }
            }
             
        }
    }
}