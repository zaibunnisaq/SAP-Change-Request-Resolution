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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;
using System.IO;

namespace OGDCL
{
    public partial class impactform : Form
    {

        private int crId;
        private int loggedInEmployeeId;
         int roleid = 1;

        public impactform(int crId, int loggedInEmployeeId)
        {
            InitializeComponent();
            this.crId = crId;
            this.loggedInEmployeeId = loggedInEmployeeId;
            LoadCRFormDetails();
        }
        private void LoadCRFormDetails()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "SELECT * FROM CR_Form WHERE cr_id = @CrId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CrId", crId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                //    textBox1.Text = reader["cr_name"].ToString();
                //    textBox2.Text = ""; // Populate with relevant data, if available
                //    richTextBox1.Text = reader["descrip"].ToString();
                //    richTextBox2.Text = reader["duration"].ToString();
                //    richTextBox3.Text = reader["risks"].ToString();
                //    richTextBox4.Text = reader["alt_recomm"].ToString();
                //    richTextBox5.Text = reader["impact"].ToString();
                //    comboBox1.SelectedItem = reader["b_impact"].ToString();
                //    comboBox2.SelectedItem = reader["resources"].ToString();
                //    maskedTextBox1.Text = ""; // Populate with relevant data, if available
                }
            }
        }


        private void LoadComboBoxItems()
        {
            comboBox1.Items.AddRange(new string[] { "yes", "no" });
            comboBox2.Items.AddRange(new string[] { "yes", "no" });
        }


    

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private byte[] GetSignatureImageBytes()
        {
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            return new byte[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Retrieve form data from the controls
            string department = textBox2.Text;
            string employeeName = textBox1.Text;
            string scope = richTextBox1.Text;
            string duration = richTextBox2.Text;
            string risks = richTextBox3.Text;
            string recommendations = richTextBox4.Text;
            string comments = richTextBox5.Text;
            string businessImpact = comboBox1.SelectedItem?.ToString();
            string resources = comboBox2.SelectedItem?.ToString();
            string date = maskedTextBox1.Text;

            // Validate required fields
            if (string.IsNullOrEmpty(employeeName) || string.IsNullOrEmpty(scope) || string.IsNullOrEmpty(department) ||
                string.IsNullOrEmpty(businessImpact) || string.IsNullOrEmpty(resources))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Get signature image bytes if available
            byte[] signatureBytes = GetSignatureImageBytes();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update the existing CR_Form with new details
                string updateCrFormQuery = @"
            UPDATE CR_Form 
            SET impact = @Impact, 
                b_impact = @BusinessImpact, 
                resources = @Resources, 
                duration = @Duration, 
                risks = @Risks, 
                alt_recomm = @AltRecomm
            WHERE cr_id = @CrId";

                using (SqlCommand updateCommand = new SqlCommand(updateCrFormQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@Impact", comments);
                    updateCommand.Parameters.AddWithValue("@BusinessImpact", businessImpact);
                    updateCommand.Parameters.AddWithValue("@Resources", resources);
                    updateCommand.Parameters.AddWithValue("@Duration", duration);
                    updateCommand.Parameters.AddWithValue("@Risks", risks);
                    updateCommand.Parameters.AddWithValue("@AltRecomm", recommendations);
                    updateCommand.Parameters.AddWithValue("@CrId", crId); // Use the existing crId

                    updateCommand.ExecuteNonQuery();
                }

                // Insert into CRFormSignature (this assumes the signature is newly added)
                string crFormSignatureQuery = @"
            INSERT INTO CRFormSignature 
            (employee_id, cr_form_id, signature, comments)
            VALUES 
            (@EmployeeId, @CrFormId, @Signature, @Comments);";

                using (SqlCommand signatureCommand = new SqlCommand(crFormSignatureQuery, connection))
                {
                    signatureCommand.Parameters.AddWithValue("@EmployeeId", loggedInEmployeeId); // Use the logged-in employee ID
                    signatureCommand.Parameters.AddWithValue("@CrFormId", crId); // Use the existing crId
                    signatureCommand.Parameters.AddWithValue("@Signature", signatureBytes ?? (object)DBNull.Value);
                    signatureCommand.Parameters.AddWithValue("@Comments", comments);

                    try
                    {
                        int result = signatureCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Details updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update details.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
                    }
                }
            }
        }






        private void SaveSignatureToDatabase(byte[] signatureBytes)
       {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                                INSERT INTO Employee (signature) 
                                VALUES (@Signature)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Signature", signatureBytes);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Signature saved successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to save signature.");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)  //////upload signature
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Select Signature Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // Display the selected image in the PictureBox
                    pictureBox1.Image = new Bitmap(selectedFilePath);

                    // Convert the image to a byte array and store it for database insertion
                    byte[] imageBytes = File.ReadAllBytes(selectedFilePath);

                    SaveSignatureToDatabase(imageBytes);
                }
            }
        }


        private void impactform_Load(object sender, EventArgs e)
        {

            LoadComboBoxItems();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_list listf = new form_list(loggedInEmployeeId,1);
            listf.Show();
        }
    }
}

