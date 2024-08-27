using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class approve_form : Form
    {
        private int loggedInEmployeeId;

        public approve_form(int employeeId)
        {
            InitializeComponent();
            this.loggedInEmployeeId = employeeId;
            LoadDataIntoDataGridView();
        }

     
        private void LoadDataIntoDataGridView()
        {
            // Load the CR_Form data into the DataGridView
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = @"
                SELECT cr_id, cr_name, modules, descrip, reason, priority_cr, impact 
                FROM CR_Form 
                WHERE statusID IS NULL OR statusID <> 
                (SELECT statusID FROM Status WHERE status_descp = 'Rejected')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string formId = textBox3.Text; // Assuming textBox3 is for the form ID
            string comments = textBox1.Text; // Assuming textBox1 is for the comments
            string date = maskedTextBox1.Text; // Assuming maskedTextBox1 is for the date

            if (string.IsNullOrEmpty(formId))
            {
                MessageBox.Show("Please enter a valid Form ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Prompt the user to approve or reject the form
            var result = MessageBox.Show($"Do you want to approve the Form ID {formId}?", "Change Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Update the form status to 'Approved'
                UpdateFormStatus(formId, comments, date);
            }
            else
            {
                // Update the form status to 'Rejected'
                UpdateFormStatus(formId,  comments, date);
            }
        }

        private void UpdateFormStatus(string formId,string comments, string date)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Determine role-based status description
                string roleBasedStatus = "";
                string roleQuery = "SELECT roleID FROM Employee WHERE empID = @employeeID";
                using (SqlCommand roleCommand = new SqlCommand(roleQuery, connection))
                {
                    roleCommand.Parameters.AddWithValue("@employeeID", loggedInEmployeeId);
                    var roleResult = roleCommand.ExecuteScalar();

                    if (roleResult != null)
                    {
                        int roleId = (int)roleResult;
                        switch (roleId)
                        {
                            case 1:
                                roleBasedStatus = "Approved by Power User";
                                break;
                            case 2:
                                roleBasedStatus = "Approved by Manager";
                                break;
                            default:
                                roleBasedStatus = "Approved";
                                break;
                        }
                    }
                }

                // Check if the status already exists, otherwise insert it
                string statusQuery = "SELECT statusID FROM Status WHERE status_descp = @status";
                int statusId;
                using (SqlCommand statusCommand = new SqlCommand(statusQuery, connection))
                {
                    statusCommand.Parameters.AddWithValue("@status", roleBasedStatus);
                    var result = statusCommand.ExecuteScalar();

                    if (result != null)
                    {
                        statusId = (int)result;
                    }
                    else
                    {
                        // Insert the new status and get the status ID
                        string insertStatusQuery = "INSERT INTO Status (status_descp, update_date) OUTPUT INSERTED.statusID VALUES (@status, GETDATE())";
                        using (SqlCommand insertStatusCommand = new SqlCommand(insertStatusQuery, connection))
                        {
                            insertStatusCommand.Parameters.AddWithValue("@status", roleBasedStatus);
                            statusId = (int)insertStatusCommand.ExecuteScalar();
                        }
                    }
                }

                // Update the CR_Form with the new status
                string updateFormQuery = "UPDATE CR_Form SET statusID = @statusID WHERE cr_id = @formID";
                using (SqlCommand updateFormCommand = new SqlCommand(updateFormQuery, connection))
                {
                    updateFormCommand.Parameters.AddWithValue("@statusID", statusId);
                    updateFormCommand.Parameters.AddWithValue("@formID", formId);
                    updateFormCommand.ExecuteNonQuery();
                }

                // Insert into the CRFormSignature table with the date
                string insertSignatureQuery = "INSERT INTO CRFormSignature (employee_id, cr_form_id, comments, signature_date) VALUES (@employeeID, @formID, @comments, @signature_date)";
                using (SqlCommand insertSignatureCommand = new SqlCommand(insertSignatureQuery, connection))
                {
                    insertSignatureCommand.Parameters.AddWithValue("@employeeID", loggedInEmployeeId);
                    insertSignatureCommand.Parameters.AddWithValue("@formID", formId);
                    insertSignatureCommand.Parameters.AddWithValue("@comments", comments);
                    insertSignatureCommand.Parameters.AddWithValue("@signature_date", date);
                    insertSignatureCommand.ExecuteNonQuery();
                }

                MessageBox.Show($"Form status updated to: {roleBasedStatus}.");
            }

            // Refresh the DataGridView
            LoadDataIntoDataGridView();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            // Navigate to another form (e.g., manager form)
            manager mg = new manager(loggedInEmployeeId);
            mg.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changes in the comments box
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Handle text changes in the form ID box
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Handle input rejection in the masked text box for the date
        }

        private void approve_form_Load_1(object sender, EventArgs e)
        {

        }
    }
}
