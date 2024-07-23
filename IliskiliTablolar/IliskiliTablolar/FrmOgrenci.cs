using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IliskiliTablolar
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        // datasette oluşturduğumuz table ile ilişkili
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            string c = "";
            if(radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if(radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
            ds.OgrenciEkle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulub.Text), c);
            MessageBox.Show("Ogrenci Eklendi");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }
    }
}
