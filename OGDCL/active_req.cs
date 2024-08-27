using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class active_req : Form
    {
        private int loggedInEmployeeId;
        public active_req(int employeeId)
        {
            InitializeComponent();
            ConfigureListView();
            this.loggedInEmployeeId = employeeId;
        }
        private void active_req_Load(object sender, EventArgs e)
        {
            LoadDataIntoListView();
        }
        private void ConfigureListView()
        {
            // Set the view to show details.
            listView1.View = View.Details;

            // Add columns with headers.
            listView1.Columns.Add("Form ID", 100);
            listView1.Columns.Add("Form Name", 150);
            listView1.Columns.Add("Comments", 200);
            listView1.Columns.Add("Status", 100);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Employee Name", 150);

            // Optional: Set the ListView to be full row select
            listView1.FullRowSelect = true;
        }


        private void LoadDataIntoListView()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = @"
                SELECT 
                    CF.cr_id,
                    CF.cr_name,
                    CS.comments,
                    S.status_descp,
                    CS.signature_date,
                    E.emp_name
                FROM 
                    CR_Form CF
                INNER JOIN 
                    CRFormSignature CS ON CF.cr_id = CS.cr_form_id
                INNER JOIN 
                    Employee E ON CS.employee_id = E.empID
                INNER JOIN 
                    Status S ON CF.statusID = S.statusID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["cr_id"].ToString());
                    item.SubItems.Add(reader["cr_name"].ToString());
                    item.SubItems.Add(reader["comments"].ToString());
                    item.SubItems.Add(reader["status_descp"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["signature_date"]).ToString("yyyy-MM-dd"));
                    item.SubItems.Add(reader["emp_name"].ToString());

                    listView1.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection change if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin admin = new admin(loggedInEmployeeId);
            admin.Show();
        }
    }
}
