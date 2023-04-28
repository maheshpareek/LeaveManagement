using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LMS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string uname = uid.Text;
            string password = pass1.Text;

            if (IsValidCredentials(uname, password))
            {
                Label3.Text = "Login successful!";
                Response.AddHeader("REFRESH", "0;URL=AdminPanel.aspx");
            }
            else
            {
                Label3.Text = "Login failed. Invalid username or password.";
            }

            Console.ReadLine();
        }

        static bool IsValidCredentials(string uname, string password)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM lmslogin WHERE uname = @uname AND password = @password", connection))
                {
                    command.Parameters.AddWithValue("@uname", uname);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

     
    }
}