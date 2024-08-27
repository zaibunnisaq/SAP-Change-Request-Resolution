namespace OGDCL
{
    partial class approve_form
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
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cRFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oGDCLDataSet = new OGDCL.OGDCLDataSet();
            this.cR_FormTableAdapter = new OGDCL.OGDCLDataSetTableAdapters.CR_FormTableAdapter();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.moduleIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submittedbyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.altrecommDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.risksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourcesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bimpactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioritycrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cRFormBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oGDCLDataSet1 = new OGDCL.OGDCLDataSet1();
            this.cR_FormTableAdapter1 = new OGDCL.OGDCLDataSet1TableAdapters.CR_FormTableAdapter();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.cRFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oGDCLDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cRFormBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oGDCLDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(426, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 54);
            this.label3.TabIndex = 107;
            this.label3.Text = "Approve Form";
            // 
            // richTextBox5
            // 
            this.richTextBox5.Location = new System.Drawing.Point(288, 533);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(406, 36);
            this.richTextBox5.TabIndex = 116;
            this.richTextBox5.Text = "";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(812, 548);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 26);
            this.maskedTextBox1.TabIndex = 115;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(539, 448);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 26);
            this.textBox2.TabIndex = 114;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(264, 446);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 26);
            this.textBox1.TabIndex = 113;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(745, 548);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 21);
            this.label13.TabIndex = 112;
            this.label13.Text = "Date:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(189, 543);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 21);
            this.label12.TabIndex = 111;
            this.label12.Text = "Comments:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(431, 448);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 21);
            this.label10.TabIndex = 109;
            this.label10.Text = "Department:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(189, 448);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 21);
            this.label9.TabIndex = 108;
            this.label9.Text = "Name:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(923, 619);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 40);
            this.button1.TabIndex = 118;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(468, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 32);
            this.label1.TabIndex = 119;
            this.label1.Text = "Forms Submitted";
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(264, 395);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(155, 26);
            this.textBox3.TabIndex = 122;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 121;
            this.label2.Text = "Form ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // moduleIDDataGridViewTextBoxColumn
            // 
            this.moduleIDDataGridViewTextBoxColumn.DataPropertyName = "moduleID";
            this.moduleIDDataGridViewTextBoxColumn.HeaderText = "moduleID";
            this.moduleIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.moduleIDDataGridViewTextBoxColumn.Name = "moduleIDDataGridViewTextBoxColumn";
            this.moduleIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "statusID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "statusID";
            this.statusIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // submittedbyDataGridViewTextBoxColumn
            // 
            this.submittedbyDataGridViewTextBoxColumn.DataPropertyName = "submitted_by";
            this.submittedbyDataGridViewTextBoxColumn.HeaderText = "submitted_by";
            this.submittedbyDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.submittedbyDataGridViewTextBoxColumn.Name = "submittedbyDataGridViewTextBoxColumn";
            this.submittedbyDataGridViewTextBoxColumn.Width = 150;
            // 
            // altrecommDataGridViewTextBoxColumn
            // 
            this.altrecommDataGridViewTextBoxColumn.DataPropertyName = "alt_recomm";
            this.altrecommDataGridViewTextBoxColumn.HeaderText = "alt_recomm";
            this.altrecommDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.altrecommDataGridViewTextBoxColumn.Name = "altrecommDataGridViewTextBoxColumn";
            this.altrecommDataGridViewTextBoxColumn.Width = 150;
            // 
            // risksDataGridViewTextBoxColumn
            // 
            this.risksDataGridViewTextBoxColumn.DataPropertyName = "risks";
            this.risksDataGridViewTextBoxColumn.HeaderText = "risks";
            this.risksDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.risksDataGridViewTextBoxColumn.Name = "risksDataGridViewTextBoxColumn";
            this.risksDataGridViewTextBoxColumn.Width = 150;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "duration";
            this.durationDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.Width = 150;
            // 
            // resourcesDataGridViewTextBoxColumn
            // 
            this.resourcesDataGridViewTextBoxColumn.DataPropertyName = "resources";
            this.resourcesDataGridViewTextBoxColumn.HeaderText = "resources";
            this.resourcesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.resourcesDataGridViewTextBoxColumn.Name = "resourcesDataGridViewTextBoxColumn";
            this.resourcesDataGridViewTextBoxColumn.Width = 150;
            // 
            // bimpactDataGridViewTextBoxColumn
            // 
            this.bimpactDataGridViewTextBoxColumn.DataPropertyName = "b_impact";
            this.bimpactDataGridViewTextBoxColumn.HeaderText = "b_impact";
            this.bimpactDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.bimpactDataGridViewTextBoxColumn.Name = "bimpactDataGridViewTextBoxColumn";
            this.bimpactDataGridViewTextBoxColumn.Width = 150;
            // 
            // taskDataGridViewTextBoxColumn
            // 
            this.taskDataGridViewTextBoxColumn.DataPropertyName = "task";
            this.taskDataGridViewTextBoxColumn.HeaderText = "task";
            this.taskDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.taskDataGridViewTextBoxColumn.Name = "taskDataGridViewTextBoxColumn";
            this.taskDataGridViewTextBoxColumn.Width = 150;
            // 
            // impactDataGridViewTextBoxColumn
            // 
            this.impactDataGridViewTextBoxColumn.DataPropertyName = "impact";
            this.impactDataGridViewTextBoxColumn.HeaderText = "impact";
            this.impactDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.impactDataGridViewTextBoxColumn.Name = "impactDataGridViewTextBoxColumn";
            this.impactDataGridViewTextBoxColumn.Width = 150;
            // 
            // prioritycrDataGridViewTextBoxColumn
            // 
            this.prioritycrDataGridViewTextBoxColumn.DataPropertyName = "priority_cr";
            this.prioritycrDataGridViewTextBoxColumn.HeaderText = "priority_cr";
            this.prioritycrDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.prioritycrDataGridViewTextBoxColumn.Name = "prioritycrDataGridViewTextBoxColumn";
            this.prioritycrDataGridViewTextBoxColumn.Width = 150;
            // 
            // reasonDataGridViewTextBoxColumn
            // 
            this.reasonDataGridViewTextBoxColumn.DataPropertyName = "reason";
            this.reasonDataGridViewTextBoxColumn.HeaderText = "reason";
            this.reasonDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.reasonDataGridViewTextBoxColumn.Name = "reasonDataGridViewTextBoxColumn";
            this.reasonDataGridViewTextBoxColumn.Width = 150;
            // 
            // descripDataGridViewTextBoxColumn
            // 
            this.descripDataGridViewTextBoxColumn.DataPropertyName = "descrip";
            this.descripDataGridViewTextBoxColumn.HeaderText = "descrip";
            this.descripDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.descripDataGridViewTextBoxColumn.Name = "descripDataGridViewTextBoxColumn";
            this.descripDataGridViewTextBoxColumn.Width = 150;
            // 
            // modulesDataGridViewTextBoxColumn
            // 
            this.modulesDataGridViewTextBoxColumn.DataPropertyName = "modules";
            this.modulesDataGridViewTextBoxColumn.HeaderText = "modules";
            this.modulesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.modulesDataGridViewTextBoxColumn.Name = "modulesDataGridViewTextBoxColumn";
            this.modulesDataGridViewTextBoxColumn.Width = 150;
            // 
            // crnameDataGridViewTextBoxColumn
            // 
            this.crnameDataGridViewTextBoxColumn.DataPropertyName = "cr_name";
            this.crnameDataGridViewTextBoxColumn.HeaderText = "cr_name";
            this.crnameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.crnameDataGridViewTextBoxColumn.Name = "crnameDataGridViewTextBoxColumn";
            this.crnameDataGridViewTextBoxColumn.Width = 150;
            // 
            // cridDataGridViewTextBoxColumn
            // 
            this.cridDataGridViewTextBoxColumn.DataPropertyName = "cr_id";
            this.cridDataGridViewTextBoxColumn.HeaderText = "cr_id";
            this.cridDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cridDataGridViewTextBoxColumn.Name = "cridDataGridViewTextBoxColumn";
            this.cridDataGridViewTextBoxColumn.ReadOnly = true;
            this.cridDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cridDataGridViewTextBoxColumn,
            this.crnameDataGridViewTextBoxColumn,
            this.modulesDataGridViewTextBoxColumn,
            this.descripDataGridViewTextBoxColumn,
            this.reasonDataGridViewTextBoxColumn,
            this.prioritycrDataGridViewTextBoxColumn,
            this.impactDataGridViewTextBoxColumn,
            this.taskDataGridViewTextBoxColumn,
            this.bimpactDataGridViewTextBoxColumn,
            this.resourcesDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.risksDataGridViewTextBoxColumn,
            this.altrecommDataGridViewTextBoxColumn,
            this.submittedbyDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.moduleIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cRFormBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(22, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1069, 167);
            this.dataGridView1.TabIndex = 120;
            // 
            // cRFormBindingSource1
            // 
            this.cRFormBindingSource1.DataMember = "CR_Form";
            this.cRFormBindingSource1.DataSource = this.oGDCLDataSet1;
            // 
            // oGDCLDataSet1
            // 
            this.oGDCLDataSet1.DataSetName = "OGDCLDataSet1";
            this.oGDCLDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cR_FormTableAdapter1
            // 
            this.cR_FormTableAdapter1.ClearBeforeFill = true;
            // 
            // button3
            // 
            this.button3.Image = global::OGDCL.Properties.Resources.left__5_;
            this.button3.Location = new System.Drawing.Point(3, 588);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 71);
            this.button3.TabIndex = 148;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::OGDCL.Properties.Resources.OGDCL_logo1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(977, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 126);
            this.panel2.TabIndex = 83;
            // 
            // approve_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1122, 686);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Name = "approve_form";
            this.Text = "Manager_form";
            this.Load += new System.EventHandler(this.approve_form_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.cRFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oGDCLDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cRFormBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oGDCLDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private OGDCLDataSet oGDCLDataSet;
        private System.Windows.Forms.BindingSource cRFormBindingSource;
        private OGDCLDataSetTableAdapters.CR_FormTableAdapter cR_FormTableAdapter;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn submittedbyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn altrecommDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn risksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourcesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bimpactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioritycrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private OGDCLDataSet1 oGDCLDataSet1;
        private System.Windows.Forms.BindingSource cRFormBindingSource1;
        private OGDCLDataSet1TableAdapters.CR_FormTableAdapter cR_FormTableAdapter1;
    }
}