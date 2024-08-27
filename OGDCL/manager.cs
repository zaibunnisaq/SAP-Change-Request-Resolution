using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class manager : Form
    {

        private int loggedInEmployeeId;
        private int roleid = 2;
        public manager(int employeeId)
        {
            InitializeComponent();
            this.loggedInEmployeeId = employeeId;
            //this.roleid = roleId;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void manager_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            profile_management pfm = new profile_management(loggedInEmployeeId, roleid);
            pfm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_list fl = new form_list(loggedInEmployeeId, roleid);   // make a new fprm list for this
            fl.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                string deleteQuery = "DELETE FROM Employee WHERE empID = @empID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@empID", loggedInEmployeeId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your account has been deleted successfully.");

                            // Step 3: Log out the user and redirect to the login form
                            this.Hide();
                            Form1 loginForm = new Form1(); // Assuming Form1 is your login form
                            loginForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error deleting your account. Please try again.");
                        }
                    }
                }
            }
            else
            {
                // If the user cancels the deletion, do nothing
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            active_req listf = new active_req(loggedInEmployeeId);
            listf.Show();
            this.Hide();
        }
    }
}
