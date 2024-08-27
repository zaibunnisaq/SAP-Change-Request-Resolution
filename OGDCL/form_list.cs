using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class form_list : Form
    {
        private int loggedInEmployeeId; // Store the logged-in employee ID
        private string currentUserRole; // Store the current user role
        private int selectedCrId; // Store the selected CR form ID
        private int roleid;

        public form_list(int employeeId, int roleId) // Accept the employee ID in the constructor
        {
            InitializeComponent();
            this.loggedInEmployeeId = employeeId; // Store the employee ID
            this.roleid = roleId;
        }

        private void form_list_Load(object sender, EventArgs e)
        {
            LoadDataIntoListView();
            HandleLogin();
        }

        private void LoadDataIntoListView()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "SELECT cr_id, cr_name, modules, descrip, reason, priority_cr, impact FROM CR_Form";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                listView1.View = View.Details;
                listView1.Columns.Clear();
                listView1.Columns.Add("ID", 50);
                listView1.Columns.Add("Name", 100);
                listView1.Columns.Add("Modules", 100);
                listView1.Columns.Add("Description", 150);
                listView1.Columns.Add("Reason", 100);
                listView1.Columns.Add("Priority", 100);
                listView1.Columns.Add("Impact", 200);

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
            }
        }

        private void HandleLogin()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT r.role_name FROM Employee e " +
                               "INNER JOIN Role r ON e.roleID = r.roleID " +
                               "WHERE e.empID = @empID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", loggedInEmployeeId);
                    currentUserRole = (string)cmd.ExecuteScalar();
                }
            }
        }

        private void OpenFormBasedOnRole()
        {
            if (currentUserRole == "Admin" || currentUserRole == "Power User")
            {
                // Open the Impact form for Admin or Power User
                impactform impactForm = new impactform(selectedCrId, loggedInEmployeeId);
                impactForm.Show();
            }
            else
            {
                // Open the Approve form for other roles
                approve_form approveForm = new approve_form(loggedInEmployeeId);
                approveForm.Show();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = listView1.SelectedItems[0];
                selectedCrId = int.Parse(selectedItem.Text); // The CR ID is in the first column
                OpenFormBasedOnRole(); // Open the appropriate form based on role
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            int formId = int.Parse(textBox1.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkStatusQuery = "SELECT statusID FROM Status WHERE status_descp = 'Rejected'";
                int rejectedStatusId;

                using (SqlCommand checkStatusCommand = new SqlCommand(checkStatusQuery, connection))
                {
                    var result = checkStatusCommand.ExecuteScalar();
                    if (result == null)
                    {
                        string insertStatusQuery = "INSERT INTO Status (status_descp, update_date) OUTPUT INSERTED.statusID VALUES ('Rejected', GETDATE())";
                        using (SqlCommand insertStatusCommand = new SqlCommand(insertStatusQuery, connection))
                        {
                            rejectedStatusId = (int)insertStatusCommand.ExecuteScalar();
                        }
                    }
                    else
                    {
                        rejectedStatusId = (int)result;
                    }
                }

                string updateFormQuery = "UPDATE CR_Form SET statusID = @statusID WHERE cr_id = @formID";
                using (SqlCommand updateFormCommand = new SqlCommand(updateFormQuery, connection))
                {
                    updateFormCommand.Parameters.AddWithValue("@statusID", rejectedStatusId);
                    updateFormCommand.Parameters.AddWithValue("@formID", formId);

                    int rowsAffected = updateFormCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Form rejected successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No form found with the provided ID.");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if (roleid == 1)
            {
                admin admin = new admin(loggedInEmployeeId);
                admin.Show();
            }
            else if (roleid == 2)
            {
                manager mg = new manager(loggedInEmployeeId);
                mg.Show();
            }
            else
            {
                MessageBox.Show("error going back");
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
