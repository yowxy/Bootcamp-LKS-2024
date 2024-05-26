namespace EsemkaPolling
{
    partial class PemungutanSuara_Admin_
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butt = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Caleg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pollIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isClosedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pollOptionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pollResponsesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pollBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.optionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pollIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pollDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pollResponsesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pollOptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollOptionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(22, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EsemkaPolling";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Option Text";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource2, "OptionText", true));
            this.textBox2.Location = new System.Drawing.Point(84, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 20);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIDDataGridViewTextBoxColumn,
            this.pollIDDataGridViewTextBoxColumn,
            this.optionTextDataGridViewTextBoxColumn,
            this.butt,
            this.pollDataGridViewTextBoxColumn,
            this.pollResponsesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pollOptionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(19, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(406, 152);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // butt
            // 
            this.butt.HeaderText = "Del";
            this.butt.Name = "butt";
            this.butt.ReadOnly = true;
            this.butt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.butt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.butt.Text = "Delete";
            this.butt.UseColumnTextForButtonValue = true;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Question", true));
            this.textBox1.Location = new System.Drawing.Point(100, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pemilihan Umum";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pollIDDataGridViewTextBoxColumn1,
            this.adminIDDataGridViewTextBoxColumn,
            this.questionDataGridViewTextBoxColumn,
            this.isClosedDataGridViewTextBoxColumn,
            this.Caleg,
            this.createdAtDataGridViewTextBoxColumn,
            this.adminDataGridViewTextBoxColumn,
            this.pollOptionsDataGridViewTextBoxColumn,
            this.pollResponsesDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.pollBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(41, 273);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(606, 152);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // Caleg
            // 
            this.Caleg.HeaderText = "Jumlah Caleg";
            this.Caleg.Name = "Caleg";
            this.Caleg.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(545, 244);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(505, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pollIDDataGridViewTextBoxColumn1
            // 
            this.pollIDDataGridViewTextBoxColumn1.DataPropertyName = "PollID";
            this.pollIDDataGridViewTextBoxColumn1.HeaderText = "PollID";
            this.pollIDDataGridViewTextBoxColumn1.Name = "pollIDDataGridViewTextBoxColumn1";
            this.pollIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.pollIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // adminIDDataGridViewTextBoxColumn
            // 
            this.adminIDDataGridViewTextBoxColumn.DataPropertyName = "AdminID";
            this.adminIDDataGridViewTextBoxColumn.HeaderText = "AdminID";
            this.adminIDDataGridViewTextBoxColumn.Name = "adminIDDataGridViewTextBoxColumn";
            this.adminIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.adminIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionDataGridViewTextBoxColumn
            // 
            this.questionDataGridViewTextBoxColumn.DataPropertyName = "Question";
            this.questionDataGridViewTextBoxColumn.HeaderText = "Question";
            this.questionDataGridViewTextBoxColumn.Name = "questionDataGridViewTextBoxColumn";
            this.questionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isClosedDataGridViewTextBoxColumn
            // 
            this.isClosedDataGridViewTextBoxColumn.DataPropertyName = "IsClosed";
            this.isClosedDataGridViewTextBoxColumn.HeaderText = "IsClosed";
            this.isClosedDataGridViewTextBoxColumn.Name = "isClosedDataGridViewTextBoxColumn";
            this.isClosedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            this.createdAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // adminDataGridViewTextBoxColumn
            // 
            this.adminDataGridViewTextBoxColumn.DataPropertyName = "Admin";
            this.adminDataGridViewTextBoxColumn.HeaderText = "Admin";
            this.adminDataGridViewTextBoxColumn.Name = "adminDataGridViewTextBoxColumn";
            this.adminDataGridViewTextBoxColumn.ReadOnly = true;
            this.adminDataGridViewTextBoxColumn.Visible = false;
            // 
            // pollOptionsDataGridViewTextBoxColumn
            // 
            this.pollOptionsDataGridViewTextBoxColumn.DataPropertyName = "PollOptions";
            this.pollOptionsDataGridViewTextBoxColumn.HeaderText = "PollOptions";
            this.pollOptionsDataGridViewTextBoxColumn.Name = "pollOptionsDataGridViewTextBoxColumn";
            this.pollOptionsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pollOptionsDataGridViewTextBoxColumn.Visible = false;
            // 
            // pollResponsesDataGridViewTextBoxColumn1
            // 
            this.pollResponsesDataGridViewTextBoxColumn1.DataPropertyName = "PollResponses";
            this.pollResponsesDataGridViewTextBoxColumn1.HeaderText = "PollResponses";
            this.pollResponsesDataGridViewTextBoxColumn1.Name = "pollResponsesDataGridViewTextBoxColumn1";
            this.pollResponsesDataGridViewTextBoxColumn1.ReadOnly = true;
            this.pollResponsesDataGridViewTextBoxColumn1.Visible = false;
            // 
            // pollBindingSource
            // 
            this.pollBindingSource.DataSource = typeof(EsemkaPolling.Poll);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EsemkaPolling.Poll);
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = typeof(EsemkaPolling.PollOption);
            // 
            // optionIDDataGridViewTextBoxColumn
            // 
            this.optionIDDataGridViewTextBoxColumn.DataPropertyName = "OptionID";
            this.optionIDDataGridViewTextBoxColumn.HeaderText = "OptionID";
            this.optionIDDataGridViewTextBoxColumn.Name = "optionIDDataGridViewTextBoxColumn";
            this.optionIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.optionIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // pollIDDataGridViewTextBoxColumn
            // 
            this.pollIDDataGridViewTextBoxColumn.DataPropertyName = "PollID";
            this.pollIDDataGridViewTextBoxColumn.HeaderText = "PollID";
            this.pollIDDataGridViewTextBoxColumn.Name = "pollIDDataGridViewTextBoxColumn";
            this.pollIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pollIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // optionTextDataGridViewTextBoxColumn
            // 
            this.optionTextDataGridViewTextBoxColumn.DataPropertyName = "OptionText";
            this.optionTextDataGridViewTextBoxColumn.HeaderText = "OptionText";
            this.optionTextDataGridViewTextBoxColumn.Name = "optionTextDataGridViewTextBoxColumn";
            this.optionTextDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pollDataGridViewTextBoxColumn
            // 
            this.pollDataGridViewTextBoxColumn.DataPropertyName = "Poll";
            this.pollDataGridViewTextBoxColumn.HeaderText = "Poll";
            this.pollDataGridViewTextBoxColumn.Name = "pollDataGridViewTextBoxColumn";
            this.pollDataGridViewTextBoxColumn.ReadOnly = true;
            this.pollDataGridViewTextBoxColumn.Visible = false;
            // 
            // pollResponsesDataGridViewTextBoxColumn
            // 
            this.pollResponsesDataGridViewTextBoxColumn.DataPropertyName = "PollResponses";
            this.pollResponsesDataGridViewTextBoxColumn.HeaderText = "PollResponses";
            this.pollResponsesDataGridViewTextBoxColumn.Name = "pollResponsesDataGridViewTextBoxColumn";
            this.pollResponsesDataGridViewTextBoxColumn.ReadOnly = true;
            this.pollResponsesDataGridViewTextBoxColumn.Visible = false;
            // 
            // pollOptionBindingSource
            // 
            this.pollOptionBindingSource.DataSource = typeof(EsemkaPolling.PollOption);
            // 
            // PemungutanSuara_Admin_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PemungutanSuara_Admin_";
            this.Text = "PemungutanSuara_Admin_";
            this.Load += new System.EventHandler(this.PemungutanSuara_Admin__Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollOptionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource pollOptionBindingSource;
        private System.Windows.Forms.BindingSource pollBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn pollIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn adminIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isClosedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caleg;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adminDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pollOptionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pollResponsesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pollIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn butt;
        private System.Windows.Forms.DataGridViewTextBoxColumn pollDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pollResponsesDataGridViewTextBoxColumn;
    }
}