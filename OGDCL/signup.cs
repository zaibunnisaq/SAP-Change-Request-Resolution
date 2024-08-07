using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;
            string name = textBox4.Text;
            string empID = textBox5.Text;
            //string modules = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Use only the columns needed for sign-up
                string query = "INSERT INTO Employee (empID,emp_name, username, passwd) VALUES (@EmpID, @EmpName, @Username, @Password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmpID", empID);
                    command.Parameters.AddWithValue("@EmpName", name);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                   // command.Parameters.AddWithValue("@Modules", modules);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Sign up successful!");
                            admin Admin = new admin();
                            Admin.Show();

                        }
                        else
                        {
                            MessageBox.Show("Sign up failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }

                }
            }
        }


       // private void PopulateComboBox()
        //{
        //    comboBox1.Items.Add("Finance");
        //    comboBox1.Items.Add("Security");
        //    comboBox1.Items.Add("Operations");

        //    // Optionally set the default selected item
        //    comboBox1.SelectedIndex = 0;
        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}
