using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LMS.User
{
    public partial class ApplicationStatus : System.Web.UI.Page
    {
        
        private Table table;

        public void Page_Load(object sender, EventArgs e)
        {
            string UName = "100002";//Request.QueryString["lbl"];
            string connectionString = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";
            string query = "SELECT * FROM LeaveDetail WHERE StudentId = @UName";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UName", UName);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // create a new HTML table
                table = new Table();
                table.CssClass = "table";

                // create the table header row
                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.CssClass = "thead-dark";
                headerRow.Cells.Add(new TableHeaderCell { Text = "Student Id" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Student Name" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Department" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Class" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Leave Type" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Leave From" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Leave To" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Application Status" });
                table.Rows.Add(headerRow);


                // loop through the data and add each row to the table
                

                while (reader.Read())
                {

                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = reader.GetString(0) });
                    row.Cells.Add(new TableCell { Text = reader.GetString(1) });
                    row.Cells.Add(new TableCell { Text = reader.GetString(2) });
                    row.Cells.Add(new TableCell { Text = reader.GetString(3) });
                    row.Cells.Add(new TableCell { Text = reader.GetString(4) });
                    row.Cells.Add(new TableCell { Text = reader.GetDateTime(5).ToString("dd/MM/yyyy") });
                    row.Cells.Add(new TableCell { Text = reader.GetDateTime(6).ToString("dd/MM/yyyy") });
                    row.Cells.Add(new TableCell { Text = reader.GetString(7) });

                    table.Rows.Add(row);
                }

                // add the table to the page
                dataContainer.Controls.Add(table);

                reader.Close();
            }
        }
    }
}