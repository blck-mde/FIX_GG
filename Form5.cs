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
    public partial class Form5 : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string query;
        private int userId;
        public Form5(int userId)
        {
            koneksi = new MySqlConnection("server=localhost; database=db_GG; username=root; password=;");
            InitializeComponent();
            this.userId = userId;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadMenstruasiData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void labelCountdown_Click(object sender, EventArgs e)
        {

        }


        private void LoadMenstruasiData()
        {
            if (userId == -1)
            {
                MessageBox.Show("User ID tidak ditemukan.");
                return;
            }

            try
            {
                koneksi.Open();
                string query = "SELECT tgl_terakhir_mens, siklus_mens, lama_mens FROM tbl_userinfo WHERE user_id = @user_id";
                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@user_id", userId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime terakhirMens = Convert.ToDateTime(reader["tgl_terakhir_mens"]);
                    int siklus = Convert.ToInt32(reader["siklus_mens"]);
                    int durasi = Convert.ToInt32(reader["lama_mens"]);

                    // Hitung tanggal menstruasi berikutnya
                    DateTime nextMensDate = terakhirMens.AddDays(siklus);

                    // Hitung sisa hari hingga menstruasi berikutnya
                    int daysLeft = (nextMensDate - DateTime.Today).Days;
                    if (daysLeft < 0) daysLeft = 0; // Jika sudah lewat, tampilkan 0

                    labelCountdown.Text = $"{daysLeft}"; // Update label dengan sisa hari
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data menstruasi: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }

           
        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnPeriodNow_Click(object sender, EventArgs e)
        {
            if (userId == 1)
            {
                MessageBox.Show("User ID tidak ditemukan.");
                return;
            }

            try
            {
                koneksi.Open();

                // Ambil data menstruasi terakhir dan siklus user
                string selectQuery = "SELECT tgl_terakhir_mens, siklus_mens FROM tbl_userinfo WHERE user_id = @id";
                MySqlCommand selectCmd = new MySqlCommand(selectQuery, koneksi);
                selectCmd.Parameters.AddWithValue("@id", userId);
                MySqlDataReader reader = selectCmd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime lastPeriodDate = reader.GetDateTime("tgl_terakhir_mens");
                    int siklus = reader.GetInt32("siklus_mens");
                    DateTime today = DateTime.Today;

                    int daysSinceLast = (today - lastPeriodDate).Days;

                    reader.Close();

                    // Cek apakah menstruasi datang terlalu cepat
                    if (daysSinceLast < siklus - 3) // bisa disesuaikan toleransinya
                    {
                        MessageBox.Show(
                            $"Siklus menstruasi Anda terdeteksi lebih awal ({daysSinceLast} hari dari seharusnya {siklus} hari). " +
                            "Silakan hubungi dokter untuk pemeriksaan lebih lanjut.",
                            "Peringatan Siklus Tidak Normal",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }

                    // Update tanggal terakhir menstruasi
                    string updateQuery = "UPDATE tbl_userinfo SET tgl_terakhir_mens = @today WHERE user_id = @id";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, koneksi);
                    updateCmd.Parameters.AddWithValue("@today", today);
                    updateCmd.Parameters.AddWithValue("@id", userId);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Tanggal menstruasi berhasil diperbarui!");
                    LoadMenstruasiData(); // Refresh label countdown
                }
                else
                {
                    MessageBox.Show("Data user tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            info1 info1 = new info1();
            info1.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            info2 info2 = new info2();
            info2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            info3 info3 = new info3();
            info3.ShowDialog();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            info4 info4 = new info4(); 
            info4.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            info5 info5 = new info5();
            info5.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            info6 info6 = new info6();
            info6.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            info7 info7 = new info7();  
            info7.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            info8 info8 = new info8();
            info8.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(userId);
            form5.ShowDialog();
        }
    }
}
