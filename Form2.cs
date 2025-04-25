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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FinalProject_vispro
{
    public partial class formSignUp : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public formSignUp()
        {
            alamat = "server=localhost; database=db_GG; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNama.Text != "" && txtUsername.Text != "" && txtEmail.Text != "" && txtNomor.Text != "" && txtPassword.Text != "")
                {
                    string query = "INSERT INTO tbl_user (nama_lengkap, username, email, nomor_telepon, password) " +
                                   "VALUES (@nama, @username, @email, @nomor, @password);";

                    using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
                    {
                        perintah.Parameters.AddWithValue("@nama", txtNama.Text);
                        perintah.Parameters.AddWithValue("@username", txtUsername.Text);
                        perintah.Parameters.AddWithValue("@email", txtEmail.Text);
                        perintah.Parameters.AddWithValue("@nomor", txtNomor.Text);
                        perintah.Parameters.AddWithValue("@password", txtPassword.Text);

                        koneksi.Open();
                        int res = perintah.ExecuteNonQuery();
                        long userId = perintah.LastInsertedId; // 👈 Ambil user_id terakhir
                        koneksi.Close();

                        if (res == 1)
                        {
                            // Simpan user_id ke Form1 (global static)
                            Form1.LoggedInUserId = (int)userId;
                            Form1.loggedInUsername = txtUsername.Text;

                            MessageBox.Show("Insert Data Sukses!");

                            // Lanjut ke form regist
                            FormRegist formregist = new FormRegist();
                            formregist.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Gagal Insert Data!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak Lengkap!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}

