using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LMS.Admin
{
    public partial class ApplicationList : System.Web.UI.Page
    {
        // declare the table variable at the class level
        private Table table;

        public void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";
            string query = "SELECT * FROM LeaveDetail WHERE ApplicationStatus <> @status";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", "Approved");
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
                headerRow.Cells.Add(new TableHeaderCell { Text = "Leave ID" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Update Status" });
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
                    row.Cells.Add(new TableCell { Text = reader.GetInt32(8).ToString() });
                    
                    

                    TableCell updateCell = new TableCell();
                    CheckBox approveCheckBox = new CheckBox();
                    approveCheckBox.Text = "Approve";
                    approveCheckBox.ID = "chkApprove_" + reader.GetInt32(8).ToString();
                    updateCell.Controls.Add(approveCheckBox);
                    CheckBox rejectCheckBox = new CheckBox();
                    rejectCheckBox.Text = "Reject";
                    rejectCheckBox.ID = "chkReject_" + reader.GetInt32(8).ToString();
                    updateCell.Controls.Add(rejectCheckBox);

                    row.Cells.Add(updateCell);
                    table.Rows.Add(row);
                }
                
                // add the table to the page
                dataContainer.Controls.Add(table);

                reader.Close();
            }
        }

        public void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";
            string query = "UPDATE LeaveDetail SET ApplicationStatus = @status WHERE LeaveID  = @leaveId";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // get the table control from the page
                Table table = dataContainer.Controls.OfType<Table>().FirstOrDefault();

                // loop through the rows in the table
                foreach (TableRow row in table.Rows)
                {
                    // get the leave ID for the row
                    string leaveId = row.Cells[8].Text;
                    
                    // check if the approve checkbox is checked
                    CheckBox approveCheckBox = row.FindControl("chkApprove_" + leaveId) as CheckBox;
                    if (approveCheckBox != null && approveCheckBox.Checked)
                    {
                        
                        // update the leave status to approved
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@status", "Approved");
                        command.Parameters.AddWithValue("@leaveId", leaveId);
                        command.ExecuteNonQuery();
                    }

                    // check if the reject checkbox is checked
                    CheckBox rejectCheckBox = row.FindControl("chkReject_" + leaveId) as CheckBox;
                    if (rejectCheckBox != null && rejectCheckBox.Checked)
                    {
                        // update the leave status to rejected
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@status", "Rejected");
                        command.Parameters.AddWithValue("@leaveId", leaveId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}

