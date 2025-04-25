using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace FinalProject_vispro
{
    public partial class FormRegist : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormRegist()
        {
            alamat = "server=localhost; database=db_GG; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click_1(object sender, EventArgs e)
        {

        }

        private void RdBtnKemerahan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FormRegist_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tbl_user");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.LoggedInUserId == 0)
            {
                MessageBox.Show("User belum login! Silakan login atau daftar terlebih dahulu.");
                return;
            }

            string tipeKulit = GetSelectedRadioButtonText(PanelJenisKulit);
            string masalahKulit = GetSelectedRadioButtonText(PanelMasalahKulit);
            DateTime tglTerakhirMens = dateTimeMens.Value;

            int siklusMens, lamaMens;
            if (!int.TryParse(comboBoxSiklus.SelectedItem?.ToString(), out siklusMens))
            {
                MessageBox.Show("Silakan pilih siklus menstruasi yang valid.");
                return;
            }
            if (!int.TryParse(comboBoxLangsung.SelectedItem?.ToString(), out lamaMens))
            {
                MessageBox.Show("Silakan pilih lama menstruasi yang valid.");
                return;
            }

            try
            {
                koneksi.Open();

                string query = "INSERT INTO tbl_userinfo (user_id, tipe_kulit, masalah_kulit, tgl_terakhir_mens, siklus_mens, lama_mens) " +
                               "VALUES (@user_id, @tipe_kulit, @masalah_kulit, @tgl_terakhir_mens, @siklus_mens, @lama_mens)";

                using (MySqlCommand cmd = new MySqlCommand(query, koneksi))
                {
                    cmd.Parameters.AddWithValue("@user_id", Form1.LoggedInUserId);
                    cmd.Parameters.AddWithValue("@tipe_kulit", tipeKulit);
                    cmd.Parameters.AddWithValue("@masalah_kulit", masalahKulit);
                    cmd.Parameters.AddWithValue("@tgl_terakhir_mens", tglTerakhirMens);
                    cmd.Parameters.AddWithValue("@siklus_mens", siklusMens);
                    cmd.Parameters.AddWithValue("@lama_mens", lamaMens);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                {
                    koneksi.Close();
                }
            }
        }


        private string GetSelectedRadioButtonText(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return string.Empty;
        }

        private void JenisKulit_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formSignUp formSignUp = new formSignUp();
            formSignUp.Show();
        }

        private void rdKulitKering_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PanelMasalahKulit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbJerawat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdHiperpigmentasi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
