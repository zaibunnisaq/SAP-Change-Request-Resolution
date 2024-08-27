namespace OGDCL
{
    partial class profile_management
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cRFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oGDCLDataSet = new OGDCL.OGDCLDataSet();
            this.cR_FormTableAdapter = new OGDCL.OGDCLDataSetTableAdapters.CR_FormTableAdapter();
            this.name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.savechanges = new System.Windows.Forms.Button();
            this.newpassagain = new System.Windows.Forms.TextBox();
            this.enternewpass = new System.Windows.Forms.TextBox();
            this.empid = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dept = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cRFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oGDCLDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cRFormBindingSource
            // 
            this.cRFormBindingSource.DataMember = "CR_Form";
            this.cRFormBindingSource.DataSource = this.oGDCLDataSet;
            // 
            // oGDCLDataSet
            // 
            this.oGDCLDataSet.DataSetName = "OGDCLDataSet";
            this.oGDCLDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cR_FormTableAdapter
            // 
            this.cR_FormTableAdapter.ClearBeforeFill = true;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(156, 180);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(57, 21);
            this.name.TabIndex = 139;
            this.name.Text = "Name:";
            this.name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(575, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 32);
            this.label1.TabIndex = 137;
            this.label1.Text = "Change Password";
            // 
            // savechanges
            // 
            this.savechanges.BackColor = System.Drawing.Color.DodgerBlue;
            this.savechanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savechanges.ForeColor = System.Drawing.Color.White;
            this.savechanges.Location = new System.Drawing.Point(778, 488);
            this.savechanges.Name = "savechanges";
            this.savechanges.Size = new System.Drawing.Size(162, 40);
            this.savechanges.TabIndex = 136;
            this.savechanges.Text = "Save Changes";
            this.savechanges.UseVisualStyleBackColor = false;
            this.savechanges.Click += new System.EventHandler(this.savechanges_Click);
            // 
            // newpassagain
            // 
            this.newpassagain.Location = new System.Drawing.Point(723, 363);
            this.newpassagain.Name = "newpassagain";
            this.newpassagain.Size = new System.Drawing.Size(217, 26);
            this.newpassagain.TabIndex = 132;
            // 
            // enternewpass
            // 
            this.enternewpass.Location = new System.Drawing.Point(723, 274);
            this.enternewpass.Name = "enternewpass";
            this.enternewpass.Size = new System.Drawing.Size(217, 26);
            this.enternewpass.TabIndex = 131;
            // 
            // empid
            // 
            this.empid.AutoSize = true;
            this.empid.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empid.Location = new System.Drawing.Point(155, 368);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(103, 21);
            this.empid.TabIndex = 129;
            this.empid.Text = "Employee ID";
            this.empid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(551, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 21);
            this.label10.TabIndex = 127;
            this.label10.Text = "Current Password:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(551, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 21);
            this.label9.TabIndex = 126;
            this.label9.Text = "New Password";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(396, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 54);
            this.label3.TabIndex = 125;
            this.label3.Text = "Manage Profile";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::OGDCL.Properties.Resources.OGDCL_logo1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(964, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 126);
            this.panel2.TabIndex = 123;
            // 
            // dept
            // 
            this.dept.AutoSize = true;
            this.dept.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dept.Location = new System.Drawing.Point(156, 270);
            this.dept.Name = "dept";
            this.dept.Size = new System.Drawing.Size(102, 21);
            this.dept.TabIndex = 141;
            this.dept.Text = "Department:";
            this.dept.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 142;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 143;
            this.label4.Text = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 144;
            this.label5.Text = "label5";
            // 
            // button1
            // 
            this.button1.Image = global::OGDCL.Properties.Resources.left__5_;
            this.button1.Location = new System.Drawing.Point(23, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 71);
            this.button1.TabIndex = 145;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // profile_management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1105, 651);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dept);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savechanges);
            this.Controls.Add(this.newpassagain);
            this.Controls.Add(this.enternewpass);
            this.Controls.Add(this.empid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Name = "profile_management";
            this.Text = "profile_management";
            this.Load += new System.EventHandler(this.profile_management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cRFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oGDCLDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource cRFormBindingSource;
        private OGDCLDataSet oGDCLDataSet;
        private OGDCLDataSetTableAdapters.CR_FormTableAdapter cR_FormTableAdapter;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savechanges;
        private System.Windows.Forms.TextBox newpassagain;
        private System.Windows.Forms.TextBox enternewpass;
        private System.Windows.Forms.Label empid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}