using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;


namespace LMS.Admin
{
    public partial class Report : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=PANDA\SQLEXPRESS;Initial Catalog=LMS;Integrated Security=True";
        private Table table;
        public void Page_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM LeaveDetail ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
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
       

        protected void Unnamed1_Click(object sender, EventArgs e)
        { 
            GenerateReport();
        }

        private void GenerateReport()
        {
            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command to select the data from the table
                SqlCommand command = new SqlCommand("SELECT StudentId, StudentName, Department, Class, LeaveType, LeaveFrom, LeaveTo, ApplicationStatus FROM LeaveDetail", connection);

                // Execute the command and get the results
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Create a CSV file to write the results to
                string filePath = @"C:\Users\Panda\Desktop\MySpace\BCASEM-6\Project\LMS\LeaveDetailReport.csv";
                StreamWriter streamWriter = new StreamWriter(filePath);

                // Write the column headers to the CSV file
                streamWriter.WriteLine("Student Id,Student Name,Department,Class,Leave Type,Leave From,Leave To,Application Status");

                // Loop through the rows and write the data to the CSV file
                foreach (DataRow row in dataTable.Rows)
                {
                    string studentId = row["StudentId"].ToString();
                    string studentName = row["StudentName"].ToString();
                    string department = row["Department"].ToString();
                    string className = row["Class"].ToString();
                    string leaveType = row["LeaveType"].ToString();
                    string leaveFrom = Convert.ToDateTime(row["LeaveFrom"]).ToString("dd/MM/yyyy");
                    string leaveTo = Convert.ToDateTime(row["LeaveTo"]).ToString("dd/MM/yyyy");
                    string applicationStatus = row["ApplicationStatus"].ToString();

                    string line = studentId + "," + studentName + "," + department + "," + className + "," + leaveType + "," + leaveFrom + "," + leaveTo + "," + applicationStatus;
                    streamWriter.WriteLine(line);
                }

                // Close the stream writer and the connection
                streamWriter.Close();
                connection.Close();

            }
        }
    }
}
