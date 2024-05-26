namespace BromoairlinessV1
{
    partial class DaftarAkunForm
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
            System.Windows.Forms.Label namaLabel;
            System.Windows.Forms.Label nomorTeleponLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label tanggalLahirLabel;
            System.Windows.Forms.Label usernameLabel;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.namaTextBox = new System.Windows.Forms.TextBox();
            this.nomorTeleponTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.tanggalLahirDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.akunBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            namaLabel = new System.Windows.Forms.Label();
            nomorTeleponLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            tanggalLahirLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.akunBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Daftar Akun";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Daftar diri anda untuk menggunakn bromo airliness";
            // 
            // namaLabel
            // 
            namaLabel.AutoSize = true;
            namaLabel.Location = new System.Drawing.Point(15, 105);
            namaLabel.Name = "namaLabel";
            namaLabel.Size = new System.Drawing.Size(38, 13);
            namaLabel.TabIndex = 3;
            namaLabel.Text = "Nama:";
            // 
            // namaTextBox
            // 
            this.namaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.akunBindingSource, "Nama", true));
            this.namaTextBox.Location = new System.Drawing.Point(104, 102);
            this.namaTextBox.Name = "namaTextBox";
            this.namaTextBox.Size = new System.Drawing.Size(200, 20);
            this.namaTextBox.TabIndex = 4;
            // 
            // nomorTeleponLabel
            // 
            nomorTeleponLabel.AutoSize = true;
            nomorTeleponLabel.Location = new System.Drawing.Point(15, 131);
            nomorTeleponLabel.Name = "nomorTeleponLabel";
            nomorTeleponLabel.Size = new System.Drawing.Size(83, 13);
            nomorTeleponLabel.TabIndex = 5;
            nomorTeleponLabel.Text = "Nomor Telepon:";
            // 
            // nomorTeleponTextBox
            // 
            this.nomorTeleponTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.akunBindingSource, "NomorTelepon", true));
            this.nomorTeleponTextBox.Location = new System.Drawing.Point(104, 128);
            this.nomorTeleponTextBox.Name = "nomorTeleponTextBox";
            this.nomorTeleponTextBox.Size = new System.Drawing.Size(200, 20);
            this.nomorTeleponTextBox.TabIndex = 6;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(15, 157);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(56, 13);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.akunBindingSource, "Password", true));
            this.passwordTextBox.Location = new System.Drawing.Point(104, 154);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(200, 20);
            this.passwordTextBox.TabIndex = 8;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // tanggalLahirLabel
            // 
            tanggalLahirLabel.AutoSize = true;
            tanggalLahirLabel.Location = new System.Drawing.Point(15, 184);
            tanggalLahirLabel.Name = "tanggalLahirLabel";
            tanggalLahirLabel.Size = new System.Drawing.Size(75, 13);
            tanggalLahirLabel.TabIndex = 9;
            tanggalLahirLabel.Text = "Tanggal Lahir:";
            // 
            // tanggalLahirDateTimePicker
            // 
            this.tanggalLahirDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.akunBindingSource, "TanggalLahir", true));
            this.tanggalLahirDateTimePicker.Location = new System.Drawing.Point(104, 180);
            this.tanggalLahirDateTimePicker.Name = "tanggalLahirDateTimePicker";
            this.tanggalLahirDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.tanggalLahirDateTimePicker.TabIndex = 10;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(15, 209);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(58, 13);
            usernameLabel.TabIndex = 11;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.akunBindingSource, "Username", true));
            this.usernameTextBox.Location = new System.Drawing.Point(104, 206);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(200, 20);
            this.usernameTextBox.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "Daftar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BromoairlinessV1.Properties.Resources.Logo_Rect___Without_Tagline;
            this.pictureBox1.Location = new System.Drawing.Point(418, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 201);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // akunBindingSource
            // 
            this.akunBindingSource.DataSource = typeof(BromoairlinessV1.Akun);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sudah punya akun?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(124, 298);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Login";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // DaftarAkunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 320);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(namaLabel);
            this.Controls.Add(this.namaTextBox);
            this.Controls.Add(nomorTeleponLabel);
            this.Controls.Add(this.nomorTeleponTextBox);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(tanggalLahirLabel);
            this.Controls.Add(this.tanggalLahirDateTimePicker);
            this.Controls.Add(usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DaftarAkunForm";
            this.Text = "DaftarAkunForm";
            this.Load += new System.EventHandler(this.DaftarAkunForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.akunBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource akunBindingSource;
        private System.Windows.Forms.TextBox namaTextBox;
        private System.Windows.Forms.TextBox nomorTeleponTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.DateTimePicker tanggalLahirDateTimePicker;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}