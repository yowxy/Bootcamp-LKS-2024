namespace BromoairlinessV1
{
    partial class TiketSaya
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.transaksiHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transaksiHeaderDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kodepenerbangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maskapai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bndarakeberangkatab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bndaratujuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalKberangjatanb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Waktukeberangkatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusTerakhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiHeaderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BromoairlinessV1.Properties.Resources.chevron_left_solid_72;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiket Saya";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Semua tiket anda yang aktif akan tampil disini";
            // 
            // transaksiHeaderBindingSource
            // 
            this.transaksiHeaderBindingSource.DataSource = typeof(BromoairlinessV1.TransaksiHeader);
            // 
            // transaksiHeaderDataGridView
            // 
            this.transaksiHeaderDataGridView.AutoGenerateColumns = false;
            this.transaksiHeaderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.transaksiHeaderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transaksiHeaderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.Kodepenerbangan,
            this.Maskapai,
            this.Bndarakeberangkatab,
            this.Bndaratujuan,
            this.TanggalKberangjatanb,
            this.Waktukeberangkatan,
            this.StatusTerakhir});
            this.transaksiHeaderDataGridView.DataSource = this.transaksiHeaderBindingSource;
            this.transaksiHeaderDataGridView.Location = new System.Drawing.Point(12, 91);
            this.transaksiHeaderDataGridView.Name = "transaksiHeaderDataGridView";
            this.transaksiHeaderDataGridView.Size = new System.Drawing.Size(1104, 220);
            this.transaksiHeaderDataGridView.TabIndex = 4;
            this.transaksiHeaderDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.transaksiHeaderDataGridView_CellFormatting);
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AkunID";
            this.dataGridViewTextBoxColumn2.HeaderText = "AkunID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TanggalTransaksi";
            this.dataGridViewTextBoxColumn3.HeaderText = "TanggalTransaksi";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "JadwalPenerbanganID";
            this.dataGridViewTextBoxColumn4.HeaderText = "JadwalPenerbanganID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "JumlahPenumpang";
            this.dataGridViewTextBoxColumn5.HeaderText = "JumlahPenumpang";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TotalHarga";
            this.dataGridViewTextBoxColumn6.HeaderText = "TotalHarga";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "KodePromoID";
            this.dataGridViewTextBoxColumn7.HeaderText = "KodePromoID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Akun";
            this.dataGridViewTextBoxColumn8.HeaderText = "Akun";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "JadwalPenerbangan";
            this.dataGridViewTextBoxColumn9.HeaderText = "JadwalPenerbangan";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "KodePromo";
            this.dataGridViewTextBoxColumn10.HeaderText = "KodePromo";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TransaksiDetail";
            this.dataGridViewTextBoxColumn11.HeaderText = "TransaksiDetail";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // Kodepenerbangan
            // 
            this.Kodepenerbangan.DataPropertyName = "ID";
            this.Kodepenerbangan.HeaderText = "Kode Penerbangan";
            this.Kodepenerbangan.Name = "Kodepenerbangan";
            // 
            // Maskapai
            // 
            this.Maskapai.DataPropertyName = "ID";
            this.Maskapai.HeaderText = "Maskapai";
            this.Maskapai.Name = "Maskapai";
            // 
            // Bndarakeberangkatab
            // 
            this.Bndarakeberangkatab.DataPropertyName = "ID";
            this.Bndarakeberangkatab.HeaderText = "Bandara Keberangkatan";
            this.Bndarakeberangkatab.Name = "Bndarakeberangkatab";
            // 
            // Bndaratujuan
            // 
            this.Bndaratujuan.DataPropertyName = "ID";
            this.Bndaratujuan.HeaderText = "Bandara Tujuan";
            this.Bndaratujuan.Name = "Bndaratujuan";
            // 
            // TanggalKberangjatanb
            // 
            this.TanggalKberangjatanb.DataPropertyName = "ID";
            this.TanggalKberangjatanb.HeaderText = "Tanggal keberangkatan";
            this.TanggalKberangjatanb.Name = "TanggalKberangjatanb";
            // 
            // Waktukeberangkatan
            // 
            this.Waktukeberangkatan.DataPropertyName = "ID";
            this.Waktukeberangkatan.HeaderText = "Waktu Keberangkatan";
            this.Waktukeberangkatan.Name = "Waktukeberangkatan";
            // 
            // StatusTerakhir
            // 
            this.StatusTerakhir.DataPropertyName = "ID";
            this.StatusTerakhir.HeaderText = "Status Terakhir";
            this.StatusTerakhir.Name = "StatusTerakhir";
            // 
            // TiketSaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 450);
            this.Controls.Add(this.transaksiHeaderDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TiketSaya";
            this.Text = "TiketSaya";
            this.Load += new System.EventHandler(this.TiketSaya_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiHeaderDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource transaksiHeaderBindingSource;
        private System.Windows.Forms.DataGridView transaksiHeaderDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kodepenerbangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maskapai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bndarakeberangkatab;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bndaratujuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalKberangjatanb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Waktukeberangkatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusTerakhir;
    }
}