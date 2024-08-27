using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class forml_list2 : Form
    {
        private int loggedInEmployeeId;

        public forml_list2(int employeeId)
        {
            InitializeComponent();
            this.loggedInEmployeeId = employeeId;
            InitializeListView();
        }

        private void forml_list2_Load(object sender, EventArgs e)
        {
            LoadApprovedForms();
        }

        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("CR ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("CR Name", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Modules", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Description", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Reason", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Priority", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Impact", 150, HorizontalAlignment.Left);
            listView1.FullRowSelect = true;
        }

        private void LoadApprovedForms()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = @"
                SELECT 
                    cr.cr_id, 
                    cr.cr_name, 
                    cr.modules, 
                    cr.descrip, 
                    cr.reason, 
                    cr.priority_cr, 
                    cr.impact 
                FROM 
                    CR_Form cr
                JOIN 
                    Status s ON cr.statusID = s.statusID
                WHERE 
                    s.status_descp = 'Approved by Manager'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                listView1.Items.Clear(); // Clear previous items

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["cr_id"].ToString());
                    item.SubItems.Add(reader["cr_name"].ToString());
                    item.SubItems.Add(reader["modules"].ToString());
                    item.SubItems.Add(reader["descrip"].ToString());
                    item.SubItems.Add(reader["reason"].ToString());
                    item.SubItems.Add(reader["priority_cr"].ToString());
                    item.SubItems.Add(reader["impact"].ToString());

                    listView1.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the selected form ID from the ListView
                textBox3.Text = listView1.SelectedItems[0].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string formId = textBox3.Text;
                string comments = richTextBox5.Text;
                string cfoName = textBox4.Text;
                string date = maskedTextBox1.Text;

                if (string.IsNullOrEmpty(formId) || string.IsNullOrEmpty(comments) || string.IsNullOrEmpty(cfoName) || string.IsNullOrEmpty(date))
                {
                    MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UpdateFormStatus(formId, "Approved by CFO", comments, cfoName, date);
            }
            else
            {
                MessageBox.Show("Please select a form to approve.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFormStatus(string formId, string newStatus, string comments, string cfoName, string date)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get the status ID for the 'Approved by CFO' status
                string statusQuery = "SELECT statusID FROM Status WHERE status_descp = @status";
                int statusId;
                using (SqlCommand statusCommand = new SqlCommand(statusQuery, connection))
                {
                    statusCommand.Parameters.AddWithValue("@status", newStatus);
                    var result = statusCommand.ExecuteScalar();

                    if (result != null)
                    {
                        statusId = (int)result;
                    }
                    else
                    {
                        // Insert the status if it doesn't exist and get the new status ID
                        string insertStatusQuery = "INSERT INTO Status (status_descp, update_date) OUTPUT INSERTED.statusID VALUES (@status, GETDATE())";
                        using (SqlCommand insertStatusCommand = new SqlCommand(insertStatusQuery, connection))
                        {
                            insertStatusCommand.Parameters.AddWithValue("@status", newStatus);
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

                // Insert into the CRFormSignature table with the CFO's comments, name, and date
                string insertSignatureQuery = "INSERT INTO CRFormSignature (employee_id, cr_form_id, comments, signature_date) VALUES (@employeeID, @formID, @comments, @signature_date)";
                using (SqlCommand insertSignatureCommand = new SqlCommand(insertSignatureQuery, connection))
                {
                    insertSignatureCommand.Parameters.AddWithValue("@employeeID", loggedInEmployeeId);
                    insertSignatureCommand.Parameters.AddWithValue("@formID", formId);
                    insertSignatureCommand.Parameters.AddWithValue("@comments", comments);
                    insertSignatureCommand.Parameters.AddWithValue("@signature_date", date);
                    insertSignatureCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Form approved by CFO successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Refresh the ListView to reflect changes
            LoadApprovedForms();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string formId = textBox1.Text;

            if (string.IsNullOrEmpty(formId))
            {
                MessageBox.Show("Please enter a valid Form ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the form ID exists
                string checkFormQuery = "SELECT COUNT(*) FROM CR_Form WHERE cr_id = @formID";
                using (SqlCommand checkFormCommand = new SqlCommand(checkFormQuery, connection))
                {
                    checkFormCommand.Parameters.AddWithValue("@formID", formId);
                    int formExists = (int)checkFormCommand.ExecuteScalar();

                    if (formExists == 0)
                    {
                        MessageBox.Show("Form ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Get the status ID for "Rejected by CFO"
                string statusQuery = "SELECT statusID FROM Status WHERE status_descp = 'Rejected by CFO'";
                int statusId;
                using (SqlCommand statusCommand = new SqlCommand(statusQuery, connection))
                {
                    var result = statusCommand.ExecuteScalar();

                    if (result != null)
                    {
                        statusId = (int)result;
                    }
                    else
                    {
                        // Insert the status if it doesn't exist and get the new status ID
                        string insertStatusQuery = "INSERT INTO Status (status_descp, update_date) OUTPUT INSERTED.statusID VALUES ('Rejected by CFO', GETDATE())";
                        using (SqlCommand insertStatusCommand = new SqlCommand(insertStatusQuery, connection))
                        {
                            statusId = (int)insertStatusCommand.ExecuteScalar();
                        }
                    }
                }

                // Update the CR_Form with the new "Rejected by CFO" status
                string updateFormQuery = "UPDATE CR_Form SET statusID = @statusID WHERE cr_id = @formID";
                using (SqlCommand updateFormCommand = new SqlCommand(updateFormQuery, connection))
                {
                    updateFormCommand.Parameters.AddWithValue("@statusID", statusId);
                    updateFormCommand.Parameters.AddWithValue("@formID", formId);
                    updateFormCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Form rejected by CFO successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Refresh the ListView to reflect changes
            LoadApprovedForms();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
S