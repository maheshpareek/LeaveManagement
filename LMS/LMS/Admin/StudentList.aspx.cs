using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LMS.Admin
{
    public partial class StudentList : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";
            string query = "SELECT * FROM StudentInfo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // create a new HTML table
                Table table = new Table();
                table.CssClass = "table";

                // create the table header row
                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.CssClass = "thead-dark";
                headerRow.Cells.Add(new TableHeaderCell { Text = "Enrolment No" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "First Name" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Middle Name" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Last Name" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Mobile No" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Department" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Academic Year" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Date of Birth" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Email" });
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
                    row.Cells.Add(new TableCell { Text = reader.GetString(5) });
                    row.Cells.Add(new TableCell { Text = reader.GetString(6) });
                    row.Cells.Add(new TableCell { Text = reader.GetDateTime(7).ToString("dd/MM/yyyy") });
                    row.Cells.Add(new TableCell { Text = reader.GetString(8) });
                    table.Rows.Add(row);
                }

                // add the table to the page
                dataContainer.Controls.Add(table);

                reader.Close();
            }
        }
    }
}