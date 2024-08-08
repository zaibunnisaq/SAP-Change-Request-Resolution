using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            comboBox1.Items.Add("SAP FI");
            comboBox1.Items.Add("SAP CO");
            comboBox1.Items.Add("SAP FM");
            comboBox1.Items.Add("SAP JVA");
            comboBox1.Items.Add("SAP PS");
            comboBox1.Items.Add("SAP REFX");
            comboBox1.Items.Add("SAP PM");
            comboBox1.Items.Add("SAP MM");
            comboBox1.Items.Add("SAP HCM");
            comboBox1.Items.Add("SAP SD");
            comboBox1.Items.Add("SAP MDG");
            comboBox1.Items.Add("SAP ABAP");
            comboBox1.Items.Add("SAP BASIS");

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

           // comboBox1.SelectedIndex = 0; // This will select the first item by default
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;
            string name = textBox4.Text;
            string empID = textBox5.Text; // Manually input empID
            string role = "Power User";
            string selectedModule = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(empID) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(name))
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
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert into Employee table
                    string employeeQuery = @"INSERT INTO Employee (empID, emp_name, username, passwd, roleID) 
                                             VALUES (@EmpID, @EmpName, @Username, @Password, 
                                                     (SELECT roleID FROM Role WHERE role_name = @RoleName))";

                    SqlCommand employeeCommand = new SqlCommand(employeeQuery, connection, transaction);
                    employeeCommand.Parameters.AddWithValue("@EmpID", empID); // Using input empID
                    employeeCommand.Parameters.AddWithValue("@EmpName", name);
                    employeeCommand.Parameters.AddWithValue("@Username", username);
                    employeeCommand.Parameters.AddWithValue("@Password", password);
                    employeeCommand.Parameters.AddWithValue("@RoleName", role);

                    employeeCommand.ExecuteNonQuery();

                    // Insert into EmployeeModule table
                    string moduleQuery = @"INSERT INTO EmployeeModule (empID, moduleID, roleID)
                                           VALUES (@EmpID, 
                                                   (SELECT moduleID FROM Modules WHERE module_name = @SelectedModule),
                                                   (SELECT roleID FROM Role WHERE role_name = @RoleName))";

                    SqlCommand moduleCommand = new SqlCommand(moduleQuery, connection, transaction);
                    moduleCommand.Parameters.AddWithValue("@EmpID", empID);
                    moduleCommand.Parameters.AddWithValue("@SelectedModule", selectedModule);
                    moduleCommand.Parameters.AddWithValue("@RoleName", role);

                    moduleCommand.ExecuteNonQuery();

                    // Commit the transaction
                    transaction.Commit();

                    MessageBox.Show("Sign up successful!");
                    admin Admin = new admin();
                    Admin.Show();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
