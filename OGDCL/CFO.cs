using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGDCL
{
    public partial class CFO : Form
    {
        private int loggedInEmployeeId;
        private int roleid = 4;
        public CFO(int employeeId)
        {
            InitializeComponent();
            this.loggedInEmployeeId = employeeId;
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void CFO_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            forml_list2 listf2 = new forml_list2(loggedInEmployeeId);
            listf2.Show();
            this.Hide();

        }
    }
}
