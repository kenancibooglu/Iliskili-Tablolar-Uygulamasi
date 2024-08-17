using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TONG9CH\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;");
        // datasette oluşturduğumuz table ile ilişkili
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand ("Select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulub.DisplayMember = "KULUPAD";
            cmbkulub.ValueMember = "KULUPID";
            cmbkulub.DataSource = dt;
            baglanti.Close();






        }

        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {
            
           
            ds.OgrenciEkle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulub.SelectedValue.ToString()), c);
            MessageBox.Show("Ogrenci Eklendi");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void cmbkulub_SelectedIndexChanged(object sender, EventArgs e)
        {
           // txtid.Text = cmbkulub.SelectedValue.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtid.Text));
            MessageBox.Show("Öğrenci Silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbkulub.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            c = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            switch (c)
            {
                case "Erkek":
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    break;
                case "Kadın":
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    break;
            }



        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelleme(txtad.Text, txtsoyad.Text,byte.Parse(cmbkulub.SelectedValue.ToString()), c,int.Parse( txtid.Text));


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtara.Text);
        }
    }
}
