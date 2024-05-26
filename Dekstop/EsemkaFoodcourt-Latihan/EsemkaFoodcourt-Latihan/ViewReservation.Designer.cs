namespace EsemkaFoodcourt_Latihan
{
    partial class ViewReservation
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
            System.Windows.Forms.Label customerEmailLabel;
            System.Windows.Forms.Label customerFirstNameLabel;
            System.Windows.Forms.Label customerLastNameLabel;
            System.Windows.Forms.Label customerPhoneNumberLabel;
            System.Windows.Forms.Label reservationDateLabel;
            System.Windows.Forms.Label label1;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reservationDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservationDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.customerEmailTextBox = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.customerFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.customerLastNameTextBox = new System.Windows.Forms.TextBox();
            this.customerPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.reservationDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            customerEmailLabel = new System.Windows.Forms.Label();
            customerFirstNameLabel = new System.Windows.Forms.Label();
            customerLastNameLabel = new System.Windows.Forms.Label();
            customerPhoneNumberLabel = new System.Windows.Forms.Label();
            reservationDateLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reservationDetailsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationDetailsBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // customerEmailLabel
            // 
            customerEmailLabel.AutoSize = true;
            customerEmailLabel.Location = new System.Drawing.Point(14, 31);
            customerEmailLabel.Name = "customerEmailLabel";
            customerEmailLabel.Size = new System.Drawing.Size(82, 13);
            customerEmailLabel.TabIndex = 0;
            customerEmailLabel.Text = "Customer Email:";
            // 
            // customerFirstNameLabel
            // 
            customerFirstNameLabel.AutoSize = true;
            customerFirstNameLabel.Location = new System.Drawing.Point(14, 57);
            customerFirstNameLabel.Name = "customerFirstNameLabel";
            customerFirstNameLabel.Size = new System.Drawing.Size(107, 13);
            customerFirstNameLabel.TabIndex = 2;
            customerFirstNameLabel.Text = "Customer First Name:";
            // 
            // customerLastNameLabel
            // 
            customerLastNameLabel.AutoSize = true;
            customerLastNameLabel.Location = new System.Drawing.Point(14, 83);
            customerLastNameLabel.Name = "customerLastNameLabel";
            customerLastNameLabel.Size = new System.Drawing.Size(108, 13);
            customerLastNameLabel.TabIndex = 4;
            customerLastNameLabel.Text = "Customer Last Name:";
            // 
            // customerPhoneNumberLabel
            // 
            customerPhoneNumberLabel.AutoSize = true;
            customerPhoneNumberLabel.Location = new System.Drawing.Point(14, 109);
            customerPhoneNumberLabel.Name = "customerPhoneNumberLabel";
            customerPhoneNumberLabel.Size = new System.Drawing.Size(128, 13);
            customerPhoneNumberLabel.TabIndex = 6;
            customerPhoneNumberLabel.Text = "Customer Phone Number:";
            // 
            // reservationDateLabel
            // 
            reservationDateLabel.AutoSize = true;
            reservationDateLabel.Location = new System.Drawing.Point(17, 69);
            reservationDateLabel.Name = "reservationDateLabel";
            reservationDateLabel.Size = new System.Drawing.Size(39, 13);
            reservationDateLabel.TabIndex = 3;
            reservationDateLabel.Text = "search";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(17, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(156, 24);
            label1.TabIndex = 5;
            label1.Text = "View Reservation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(9, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(341, 146);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reservationDetailsDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(13, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 268);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Menu Ordered";
            // 
            // reservationDetailsDataGridView
            // 
            this.reservationDetailsDataGridView.AutoGenerateColumns = false;
            this.reservationDetailsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reservationDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reservationDetailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.price,
            this.Subtotal,
            this.dataGridViewTextBoxColumn6});
            this.reservationDetailsDataGridView.DataSource = this.reservationDetailsBindingSource;
            this.reservationDetailsDataGridView.Location = new System.Drawing.Point(6, 19);
            this.reservationDetailsDataGridView.Name = "reservationDetailsDataGridView";
            this.reservationDetailsDataGridView.Size = new System.Drawing.Size(763, 220);
            this.reservationDetailsDataGridView.TabIndex = 0;
            this.reservationDetailsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.reservationDetailsDataGridView_CellFormatting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ReservationID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ReservationID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MenuID";
            this.dataGridViewTextBoxColumn3.HeaderText = "MenuID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Menus";
            this.dataGridViewTextBoxColumn5.HeaderText = "Menus";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Qty";
            this.dataGridViewTextBoxColumn4.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // price
            // 
            this.price.DataPropertyName = "ID";
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "ID";
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Reservations";
            this.dataGridViewTextBoxColumn6.HeaderText = "Reservations";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // reservationDetailsBindingSource
            // 
            this.reservationDetailsBindingSource.DataSource = typeof(EsemkaFoodcourt_Latihan.ReservationDetails);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(customerEmailLabel);
            this.groupBox3.Controls.Add(this.customerEmailTextBox);
            this.groupBox3.Controls.Add(customerFirstNameLabel);
            this.groupBox3.Controls.Add(this.customerFirstNameTextBox);
            this.groupBox3.Controls.Add(customerLastNameLabel);
            this.groupBox3.Controls.Add(this.customerLastNameTextBox);
            this.groupBox3.Controls.Add(customerPhoneNumberLabel);
            this.groupBox3.Controls.Add(this.customerPhoneNumberTextBox);
            this.groupBox3.Location = new System.Drawing.Point(423, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 148);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Table";
            // 
            // customerEmailTextBox
            // 
            this.customerEmailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "CustomerEmail", true));
            this.customerEmailTextBox.Location = new System.Drawing.Point(148, 28);
            this.customerEmailTextBox.Name = "customerEmailTextBox";
            this.customerEmailTextBox.Size = new System.Drawing.Size(225, 20);
            this.customerEmailTextBox.TabIndex = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EsemkaFoodcourt_Latihan.Reservations);
            // 
            // customerFirstNameTextBox
            // 
            this.customerFirstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "CustomerFirstName", true));
            this.customerFirstNameTextBox.Location = new System.Drawing.Point(148, 54);
            this.customerFirstNameTextBox.Name = "customerFirstNameTextBox";
            this.customerFirstNameTextBox.Size = new System.Drawing.Size(225, 20);
            this.customerFirstNameTextBox.TabIndex = 3;
            // 
            // customerLastNameTextBox
            // 
            this.customerLastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "CustomerLastName", true));
            this.customerLastNameTextBox.Location = new System.Drawing.Point(148, 80);
            this.customerLastNameTextBox.Name = "customerLastNameTextBox";
            this.customerLastNameTextBox.Size = new System.Drawing.Size(225, 20);
            this.customerLastNameTextBox.TabIndex = 5;
            // 
            // customerPhoneNumberTextBox
            // 
            this.customerPhoneNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "CustomerPhoneNumber", true));
            this.customerPhoneNumberTextBox.Location = new System.Drawing.Point(148, 106);
            this.customerPhoneNumberTextBox.Name = "customerPhoneNumberTextBox";
            this.customerPhoneNumberTextBox.Size = new System.Drawing.Size(225, 20);
            this.customerPhoneNumberTextBox.TabIndex = 7;
            // 
            // reservationDateDateTimePicker
            // 
            this.reservationDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource1, "ReservationDate", true));
            this.reservationDateDateTimePicker.Location = new System.Drawing.Point(73, 69);
            this.reservationDateDateTimePicker.Name = "reservationDateDateTimePicker";
            this.reservationDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.reservationDateDateTimePicker.TabIndex = 4;
            this.reservationDateDateTimePicker.ValueChanged += new System.EventHandler(this.reservationDateDateTimePicker_ValueChanged);
            // 
            // ViewReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 608);
            this.Controls.Add(label1);
            this.Controls.Add(reservationDateLabel);
            this.Controls.Add(this.reservationDateDateTimePicker);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewReservation";
            this.Text = "ViewReservation";
            this.Load += new System.EventHandler(this.ViewReservation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reservationDetailsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationDetailsBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView reservationDetailsDataGridView;
        private System.Windows.Forms.BindingSource reservationDetailsBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox customerEmailTextBox;
        private System.Windows.Forms.TextBox customerFirstNameTextBox;
        private System.Windows.Forms.TextBox customerLastNameTextBox;
        private System.Windows.Forms.TextBox customerPhoneNumberTextBox;
        private System.Windows.Forms.DateTimePicker reservationDateDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}