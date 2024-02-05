using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HotelManagementSystem
{
    public partial class FormLogin : Form
    {
        //----------veritabanı foksiyonları bölümü

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=veri_tabani.mdb");
        OleDbDataAdapter Veri_Adaptor;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;
        DataSet Veri_Seti;


        void Tablo_Ac(string tablo)
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from " + tablo, Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
        }

        void Tablo_Kapat()
        {
            Veritabani_Baglanti.Close();
        }

        void Tablo_Veri_Getir()
        {
            Tablo_Ac("Users");
            Veri_Adaptor.Fill(Veri_Seti, "Users");
            //dataGridView1.DataSource = Veri_Seti.Tables["Users"];
            Tablo_Kapat();
        }
        //-----------veritabanı foksiyonları bitiş

        public FormLogin()
        {
            InitializeComponent();
        }

        private void pictureBoxMİnimize_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxMİnimize, "Minimize");
        }

        private void pictureBoxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxClose, "Close");
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void pictureBoxMİnimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void pictureBoxShow_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxShow, "Show Password");
        }

        private void pictureBoxHide_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxHide, "Hide Password");
        }

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {
            pictureBoxShow.Hide();
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxShow.Show();
        }


        //kullanıcı giriş komutları
        private void buttonLogin_Click(object sender, EventArgs e)
        {

            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Select * from Users";
            Veri_Oku = Veri_Komutu.ExecuteReader();


            if ((textBoxUsername.Text == "") || (textBoxPassword.Text == ""))
            {
                MessageBox.Show("Lütfen boş alanı doldurun.", "Gerekli Alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool check = false;
                string kullaniciAdi = "", parola = "";
                while (Veri_Oku.Read())
                {
                    kullaniciAdi = Veri_Oku["kullaniciAdi"].ToString();
                    parola = Veri_Oku["sifre"].ToString();

                    //label1.Text = kullaniciAdi + " " +  parola;

                    if ((textBoxUsername.Text == kullaniciAdi) & (textBoxPassword.Text == parola))
                    {
                        FormHomePage fhp = new FormHomePage();
                        fhp.Username = textBoxUsername.Text;
                        textBoxUsername.Clear();
                        textBoxPassword.Clear();
                        check = true;
                        fhp.Show();
                        break;
                    }
                }
                if(check == false)
                MessageBox.Show("Kullanıcı adı veya şifre geçersiz.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Veritabani_Baglanti.Close();
        }
    }
}
