using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class Form1 : Form
    {
        private int loggedInEmployeeId;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT empID, roleID FROM Employee WHERE username = @Username AND passwd = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int employeeId = Convert.ToInt32(reader["empID"]);
                                int roleId = Convert.ToInt32(reader["roleID"]);

                                MessageBox.Show("Login successful!");

                                this.loggedInEmployeeId = employeeId;

                                // Redirect based on role
                                RedirectUser(roleId);
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
                    }
                }
            }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup signupForm = new signup();
            signupForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
