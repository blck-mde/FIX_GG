using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FinalProject_vispro
{
    public partial class Form6 : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string query;
        public Form6()
        {
            koneksi = new MySqlConnection("server=localhost; database=db_GG; username=root; password=;");
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string loggedInUsername = Form1.loggedInUsername;

            query = @"
        SELECT 
            u.username, 
            u.nama_lengkap, 
            ui.tipe_kulit, 
            ui.masalah_kulit, 
            ui.tgl_terakhir_mens, 
            ui.siklus_mens
        FROM tbl_user u
        LEFT JOIN tbl_userinfo ui ON u.user_id = ui.user_id
        WHERE u.username = @username";

            ds.Clear();

            try
            {
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                perintah.Parameters.AddWithValue("@username", loggedInUsername);
                adapter = new MySqlDataAdapter(perintah);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                lblUsername.Text = row["username"].ToString();
                lblNama.Text = row["nama_lengkap"].ToString();
                lblSkinType.Text = row["tipe_kulit"]?.ToString() ?? "Belum Diisi";
                lblMasalahKulit.Text = row["masalah_kulit"]?.ToString() ?? "Belum Diisi";

                if (row["tgl_terakhir_mens"] != DBNull.Value && row["siklus_mens"] != DBNull.Value)
                {
                    DateTime tglTerakhirMens = Convert.ToDateTime(row["tgl_terakhir_mens"]);
                    int siklusMens = Convert.ToInt32(row["siklus_mens"]);

                    DateTime nextPeriod = tglTerakhirMens.AddDays(siklusMens);
                    int daysRemaining = (nextPeriod - DateTime.Today).Days;

                    if (daysRemaining < 0)
                    {
                        lblPeriodTracker.Text = "Periode sedang berlangsung / terlambat";
                    }
                    else
                    {
                        lblPeriodTracker.Text = daysRemaining + "";
                    }
                }
                else
                {
                    lblPeriodTracker.Text = "Belum Diisi";
                }
            }
            else
            {
                MessageBox.Show("Profil tidak ditemukan.");
            }
        }



        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblNama_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
