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
    public partial class admin : Form
    {
        private int loggedInEmployeeId;
        private int roleid = 1;
        
        public admin(int employeeId)
        {
            InitializeComponent();
            this.loggedInEmployeeId = employeeId;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            CR_form crform = new CR_form();
            crform.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_list listf = new form_list(loggedInEmployeeId, roleid);
            listf.Show();
            this.Hide();
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            profile_management pf = new profile_management(loggedInEmployeeId, roleid);
            pf.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Step 1: Confirm the deletion
            var confirmResult = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Begin a transaction
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Step 2: Delete related records in EmployeeModule
                        string deleteEmployeeModuleQuery = "DELETE FROM EmployeeModule WHERE empID = @empID";
                        using (SqlCommand deleteEmployeeModuleCmd = new SqlCommand(deleteEmployeeModuleQuery, connection, transaction))
                        {
                            deleteEmployeeModuleCmd.Parameters.AddWithValue("@empID", loggedInEmployeeId);
                            deleteEmployeeModuleCmd.ExecuteNonQuery();
                        }

                        // Step 3: Delete related records in CRFormSignature
                        string deleteCRFormSignatureQuery = "DELETE FROM CRFormSignature WHERE employee_id = @empID";
                        using (SqlCommand deleteCRFormSignatureCmd = new SqlCommand(deleteCRFormSignatureQuery, connection, transaction))
                        {
                            deleteCRFormSignatureCmd.Parameters.AddWithValue("@empID", loggedInEmployeeId);
                            deleteCRFormSignatureCmd.ExecuteNonQuery();
                        }

                        // Step 4: Delete the employee record
                        string deleteEmployeeQuery = "DELETE FROM Employee WHERE empID = @empID";
                        using (SqlCommand deleteEmployeeCmd = new SqlCommand(deleteEmployeeQuery, connection, transaction))
                        {
                            deleteEmployeeCmd.Parameters.AddWithValue("@empID", loggedInEmployeeId);
                            deleteEmployeeCmd.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();

                        MessageBox.Show("Your account has been deleted successfully.");

                        this.Hide();
                        Form1 loginForm = new Form1(); // Assuming Form1 is your login form
                        loginForm.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show("Error deleting your account. Please try again.\n" + ex.Message);
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

        private void button2_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.Show();
            this.Hide();
        }
    }
}
