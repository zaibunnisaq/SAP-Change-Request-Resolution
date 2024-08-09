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
    public partial class approve_form : Form
    {
        public approve_form()
        {
            InitializeComponent();
        }

        private void Manager_form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oGDCLDataSet.CR_Form' table. You can move, or remove it, as needed.
            this.cR_FormTableAdapter.Fill(this.oGDCLDataSet.CR_Form);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
