using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BetaMart
{
    public partial class Form1 : Form
    {
        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\TUGAS RASDHA\XII RPL 5\UKK\BetaMart\BetaMart\BetaMart.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        void ShowData()
        {
            koneksi.Open();
            string query = "select * from Barang";
            OleDbDataAdapter data = new OleDbDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'betaMartDataSet.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.betaMartDataSet.Barang);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        void ClearText()
        {
            textID.Clear();
            textNama.Clear();
            textKode.Clear();
            textHarga.Clear();
            textStok.Clear();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Insert into Barang (namabarang, kode, harga, stok) values ('" + textNama.Text + "', '" + textKode.Text + "', '" + textHarga.Text + "', '" + textStok.Text + "')";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Tersimpan");

            ShowData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "DELETE FROM Barang WHERE ID = " + textID.Text;
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Terhapus");
            ShowData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE Barang SET namabarang = '" + textNama.Text + "', kode = '" + textKode.Text + "', harga = '" + textHarga.Text + "', stok = '" + textStok.Text + "' where ID=" + textID.Text + " ", koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Berhasil Diupdate");

            ShowData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "select * from Barang where NamaBarang='" + textBox4.Text + "'";
            OleDbDataAdapter data = new OleDbDataAdapter(perintah, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }
    }
}
