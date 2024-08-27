using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace OGDCL
{
    public partial class CR_form : Form
    {

        public int CRId { get; private set; }
        public CR_form()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += CheckBoxPriority_CheckedChanged;
            checkBox2.CheckedChanged += CheckBoxPriority_CheckedChanged;
        }

        private void CheckBoxPriority_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == checkBox1 && checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
            else if (sender == checkBox2 && checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string CRname = textBox4.Text;
            string modules_involved = textBox1.Text;
            string CR_desc = richTextBox1.Text;
            string CR_reason = richTextBox2.Text;
            string impact = richTextBox3.Text;
            string priority = checkBox1.Checked ? "Low" : (checkBox2.Checked ? "High" : null);

            if (string.IsNullOrEmpty(CRname) || string.IsNullOrEmpty(modules_involved) || string.IsNullOrEmpty(CR_desc) || string.IsNullOrEmpty(CR_reason) || string.IsNullOrEmpty(impact))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO CR_Form (cr_name, modules, descrip, reason, priority_cr, impact) 
                VALUES (@CRName, @Modules, @Description, @Reason, @Priority, @Impact);
                SELECT CAST(scope_identity() AS int)"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CRName", CRname);
                    command.Parameters.AddWithValue("@Modules", modules_involved);
                    command.Parameters.AddWithValue("@Description", CR_desc);
                    command.Parameters.AddWithValue("@Reason", CR_reason);
                    command.Parameters.AddWithValue("@Priority", priority);
                    command.Parameters.AddWithValue("@Impact", impact);

                    try
                    {
                        connection.Open();
                        CRId = (int)command.ExecuteScalar(); // Retrieve and store the newly inserted CR_ID

                        if (CRId > 0)
                        {
                            MessageBox.Show("Change request added successfully!");

                            this.Hide();
                            CR_form crf = new CR_form();
                            crf.Show();

                        }
                        else
                        {
                            MessageBox.Show("Failed to add change request.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
                    }
                }
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CR_form_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
        }
    }
}
