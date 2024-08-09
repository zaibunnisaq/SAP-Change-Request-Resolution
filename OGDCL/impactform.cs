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
        public impactform()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string department = textBox2.Text;
            string name = textBox1.Text;
            string scope = richTextBox1.Text;
            string duration = richTextBox2.Text;
            string risks = richTextBox3.Text;
            string recommendations = richTextBox4.Text;
            string comments = richTextBox5.Text;
            string businessImpact = comboBox1.SelectedItem.ToString();
            string resources = comboBox2.SelectedItem.ToString();
            string date = maskedTextBox1.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(scope) || string.IsNullOrEmpty(department) ||
                string.IsNullOrEmpty(businessImpact) || string.IsNullOrEmpty(resources))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Assuming you want to upload the signature image file, not create one from text
            byte[] signatureBytes = GetSignatureImageBytes();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO CR_Form 
                (cr_name, descrip, duration, risks, alt_recomm, comments, b_impact, resources, signature) 
                VALUES 
                (@Name, @Scope, @Duration, @Risks, @Recommendations, @Comments, @BusinessImpact, @Resources, @Signature)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Scope", scope);
                    command.Parameters.AddWithValue("@Duration", duration);
                    command.Parameters.AddWithValue("@Risks", risks);
                    command.Parameters.AddWithValue("@Recommendations", recommendations);
                    command.Parameters.AddWithValue("@Comments", comments);
                    command.Parameters.AddWithValue("@BusinessImpact", businessImpact);
                    command.Parameters.AddWithValue("@Resources", resources);
                    command.Parameters.AddWithValue("@Signature", (object)signatureBytes ?? DBNull.Value);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Change request added successfully!");
                            this.Hide();
                            this.Show();
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
            return null;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            admin Admin = new admin();
            Admin.Show();
        }

        private void impactform_Load(object sender, EventArgs e)
        {

        }
    }
}
