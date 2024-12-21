using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaKayıt
{
    public partial class Form1 : Form
    {
        BindingList<Hasta> hastalar = new BindingList<Hasta>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hasta hasta1 = new Hasta { Id = 1, AdSoyad = "Ayla Bak", Birim = "Göz", Tarih = DateTime.Now, Yas = 25, Sigorta = true};
            Hasta hasta2 = new Hasta { Id = 2, AdSoyad = "Nejla Durdakul", Birim = "KBB", Tarih = DateTime.Now, Yas = 40, Sigorta = false};
            Hasta hasta3 = new Hasta { Id = 3, AdSoyad = "Neriman Buket", Birim = "Dahiliye", Tarih = DateTime.Now, Yas = 55, Sigorta = true};

            hastalar.Add(hasta1);
            hastalar.Add(hasta2);
            hastalar.Add(hasta3);

            dataGridView1.DataSource = hastalar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string adSoyad = txtAdSoyad.Text;
            string birim = cmbBirim.Text;
            int yas = int.Parse(txtYas.Text);
            bool sigorta = checkBox1.Checked;
            DateTime dateTime = dtDate.Value;

            Hasta hasta = new Hasta { Id = id, AdSoyad = adSoyad, Birim = birim, Yas = yas, Sigorta = sigorta, Tarih = dateTime};

            hastalar.Add(hasta);

            txtId.Text = null;
            txtAdSoyad.Text = null;
            dateTime = DateTime.Now;
            cmbBirim.Text = null;
            txtYas.Text = null;
            checkBox1.Checked = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                txtId.Text = hasta.Id.ToString();
                txtAdSoyad.Text = hasta.AdSoyad;
                txtYas.Text = hasta.Yas.ToString();
                cmbBirim.Text= hasta.Birim;
                dtDate.Value = hasta.Tarih;
                checkBox1 .Checked = hasta.Sigorta;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                hasta.AdSoyad = txtAdSoyad.Text;
                hasta.Yas = int.Parse(txtYas.Text);
                hasta.Birim = cmbBirim.Text;
                hasta.Tarih = dtDate.Value;
                hasta.Sigorta = checkBox1 .Checked;

                dataGridView1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show(hasta.AdSoyad + "Silinsin mi?", "Randevu Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if(result == DialogResult.Yes)
                {
                    hastalar.Remove(hasta);
                    dataGridView1.Refresh();
                }


            }
        }
    }
}
