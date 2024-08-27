using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class profile_management : Form
    {
        private int loggedInEmployeeId;
        private int roleId;


        public profile_management(int employeeId, int roleid)
        {
            InitializeComponent();
            this.loggedInEmployeeId = employeeId;
            this.roleId = roleid;
        }

        private void profile_management_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "SELECT empID, emp_name, deptname, roleID FROM Employee " +
                           "INNER JOIN Department ON Employee.deptID = Department.deptID " +
                           "WHERE empID = @empID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@empID", loggedInEmployeeId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label2.Text = reader["emp_name"].ToString();   // Label for Employee Name
                            label4.Text = reader["deptname"].ToString();   // Label for Department Name
                            label5.Text = reader["empID"].ToString();      // Label for Employee ID

                           // roleId = Convert.ToInt32(reader["roleID"]);    // Store the role ID
                        }
                        else
                        {
                            MessageBox.Show("No data found for the given employee ID.");
                        }
                    }
                }
            }
        }


        private void savechanges_Click(object sender, EventArgs e)
        {
            string currentPassword = enternewpass.Text; // Assuming enternewpass is your TextBox for Current Password
            string newPassword = newpassagain.Text;     // Assuming newpassagain is your TextBox for New Password

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter both the current and new passwords.");
                return;
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if the current password is correct
                string query = "SELECT COUNT(1) FROM Employee WHERE empID = @empID AND passwd = @currentPassword";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", loggedInEmployeeId);
                    cmd.Parameters.AddWithValue("@currentPassword", currentPassword);

                    int userCount = (int)cmd.ExecuteScalar();

                    if (userCount == 1)
                    {
                        // Current password is correct, proceed to update the password
                        string updateQuery = "UPDATE Employee SET passwd = @newPassword WHERE empID = @empID";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@newPassword", newPassword);

                            if (currentPassword == newPassword)
                            {
                                MessageBox.Show("new password can not be same as new password");
                            }

                            updateCmd.Parameters.AddWithValue("@empID", loggedInEmployeeId);

                            int rowsAffected = updateCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Error updating password.");
                            }
                        }
                    }
                    else
                    {
                        // Current password is incorrect
                        MessageBox.Show("Current password is incorrect.");
                    }
                }
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void RedirectUser(int roleId)
        {
            Form nextForm = null;

            switch (roleId)
            {
                case 1: // Power User
                    nextForm = new admin(loggedInEmployeeId);
                    break;
                case 2: // Manager ERP
                    nextForm = new manager(loggedInEmployeeId);
                    break;
                case 3: // CIO
                    nextForm = new CIO(loggedInEmployeeId);
                    break;
                case 4: // CFO
                    nextForm = new CFO(loggedInEmployeeId);
                    break;
                default:
                    MessageBox.Show("Unknown role. Cannot proceed.");
                    return;
            }

            if (nextForm != null)
            {
                this.Hide();
                nextForm.ShowDialog();
                this.Close();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            RedirectUser(roleId);
            this.Hide();
        }
    }
}
