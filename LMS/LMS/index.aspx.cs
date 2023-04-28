using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LMS.User;
namespace LMS
{
    public partial  class WebForm1 : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
       
        }
        public void Button1_Click(object sender, EventArgs e)
        {
            

            string uname = uid.Text;
            string password = pass1.Text;

            if (IsValidAdminCredentials(uname, password))
            {
                Label3.Text = "Admin Login successful!";
                Response.AddHeader("REFRESH", "0;URL=Admin/AdminPanel.aspx");
            }
            else if (IsValidUserCredentials(uname, password))
            {
                Label3.Text = "User Login successful!";
                Response.Redirect("User/UserPanel.aspx?uid=" + this.uid.Text);
            }
            else
            {
                Label3.Text = "Login failed. Invalid username or password.";
            }

            Console.ReadLine();
        }

            static bool IsValidAdminCredentials(string uname, string password)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True"))
                    {
                        connection.Open();

                          using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM login WHERE uname = @uname AND password = @password AND user_type = 'admin'", connection))
                            {
                                command.Parameters.AddWithValue("@uname", uname);
                                command.Parameters.AddWithValue("@password", password);

                                int count = (int)command.ExecuteScalar();
                                return count > 0;
                            }
                     }
            }

            static bool IsValidUserCredentials(string uname, string password)
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True"))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM login WHERE uname = @uname AND password = @password AND user_type = 'user'", connection))
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