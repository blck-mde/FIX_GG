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
    public partial class Form4 : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string query;
        public Form4()
        {
            koneksi = new MySqlConnection("server=localhost; database=db_GG; username=root; password=;");
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private int GetUserIdFromUsername(string username)
        {
            int userId = -1;

            try
            {
                koneksi.Open();
                string query = "SELECT user_id FROM tbl_user WHERE username = @username"; // <-- ganti id_user jadi user_id
                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@username", username);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil user ID: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }

            return userId;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.ShowDialog();
            this.Show();
        }

        private void btnSkincare_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.ShowDialog();
            this.Show();
        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {
            int userId = GetUserIdFromUsername(Form1.loggedInUsername); // Ambil user ID dari username login
            MessageBox.Show("Username: " + Form1.loggedInUsername); // Tambahan debug

            if (userId != -1)
            {
                this.Show();
                Form5 form5 = new Form5(userId); // Kirim userId ke Form5
                form5.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Gagal menemukan ID user. Silakan login ulang.");
            }
        }
    }
}
