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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;
using System.Security.Cryptography;

namespace HotelManagementSystem.User_Control
{
    public partial class UserControlSetting : UserControl
    {
        private string ID = "";

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

        void Tablo_Veri_Getir(string vn)
        {
            Tablo_Ac(vn);
            Veri_Adaptor.Fill(Veri_Seti, vn);
            dataGridViewUser.DataSource = Veri_Seti.Tables[vn];
            Tablo_Kapat();
        }
        //-----------veritabanı foksiyonları bitiş

        public UserControlSetting()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            tabControlUser.SelectedTab = tabPageAddUser;
        }

        public void Clear1()
        {
            textBoxUsername1.Clear();
            textBoxPassword1.Clear();
            ID = "";
        }

        private void tabPageAddUser_Leave(object sender, EventArgs e)
        {
            Clear();
            Clear1();
        }

        private void tabPageSearchUser_Enter(object sender, EventArgs e)
        {
            Tablo_Veri_Getir("Users");
        }

        private void tabPageSearchUser_Leave(object sender, EventArgs e)
        {
            textBoxSearchUsername.Clear();
        }

        private void tabPageUpdateAndDeleteUser_Leave(object sender, EventArgs e)
        {
            Clear1();
        }


        // Yeni kullanıcı kontrol ederek ekleme
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPassword.Text == "")
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    {
                        Veritabani_Baglanti.Open();

                        // Kullanıcı adının veritabanında var olup olmadığını kontrol et
                        if (!KullaniciVarMi(Veritabani_Baglanti, textBoxUsername.Text))
                        {
                            // Kullanıcı adı veritabanında yoksa ekle
                            Ekle(Veritabani_Baglanti, textBoxUsername.Text, textBoxPassword.Text);
                            MessageBox.Show(textBoxUsername.Text + " kullanıcı adı başarılı bir şekilde eklendi.", "Kullanıcı Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(textBoxUsername.Text + " kullanıcı adı zaten var.", "Kullanıcı Adı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                finally
                {
                    Veritabani_Baglanti.Close();
                }
            }
        }

        static void Ekle(OleDbConnection connection, string kullaniciAdi, string sifre)
        {
            string sorgu = "INSERT INTO Users (kullaniciAdi, sifre) VALUES (@KullaniciAdi, @Sifre)";
            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                command.Parameters.AddWithValue("@Sifre", sifre);
                command.ExecuteNonQuery();
            }
        }

        static bool KullaniciVarMi(OleDbConnection connection, string kullaniciAdi)
        {
            string sorgu = "SELECT COUNT(*) FROM Users WHERE kullaniciAdi = @KullaniciAdi";
            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                int kullaniciSayisi = (int)command.ExecuteScalar();
                return kullaniciSayisi > 0;
            }
        }

        //kullanıcı güncelleme
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
                if (textBoxUsername1.Text == "" || textBoxPassword1.Text == "")
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    Veritabani_Baglanti.Open();
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;

                    Veri_Komutu.CommandText = "UPDATE Users SET sifre = ?, kullaniciAdi = ? WHERE Kimlik = ?";
                    Veri_Komutu.Parameters.AddWithValue("@sifre", textBoxPassword1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@kullaniciAdi", textBoxUsername1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@Kimlik", ID);

                    try
                    {
                        int affectedRows = Veri_Komutu.ExecuteNonQuery();
                        //ExecuteNonQuery() metodu, eğer bir satır güncellenmişse, affectedRows değeri 1 olacaktır.

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Kullanıcı bilgileri başarılı bir şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear1();
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme başarısız. Belirtilen kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Veritabani_Baglanti.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce tablodan satırı seçin.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // kayıtlı kullanıcıyı silme
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
                if (textBoxUsername1.Text == "" || textBoxPassword1.Text == "")
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    DialogResult result = MessageBox.Show(textBoxUsername1.Text + " adlı kullanıcıyı silmek istediğinize emin misiniz?", "Kullanıcıyı Silmek", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {
                        Veritabani_Baglanti.Open();
                        OleDbCommand Veri_Komutu = new OleDbCommand();
                        Veri_Komutu.Connection = Veritabani_Baglanti;

                        Veri_Komutu.CommandText = "DELETE FROM Users WHERE Kimlik = ?";
                        Veri_Komutu.Parameters.AddWithValue("@Kimlik", ID);

                        try
                        {
                            int affectedRows = Veri_Komutu.ExecuteNonQuery();
                            //ExecuteNonQuery() metodu, eğer bir satır silinmişse, affectedRows değeri 1 olacaktır.

                            if (affectedRows > 0)
                            {
                                MessageBox.Show(textBoxUsername1.Text + " kullanıcı adı başarılı bir şekilde silindi.", "Kullanıcı Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Belirtilen kullanıcı adı bulunamadı.", "Kullanıcı Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            Veritabani_Baglanti.Close();
                        }
                        Clear1();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce tablodan satırı seçin.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //tabloda seçilen satırdaki "kullanıcı adı" ve "parola" bilgilerini, güncelleme alanına aktarma/gösterme
        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewUser.Rows[e.RowIndex];
                ID = row.Cells[0].Value.ToString();
                textBoxUsername1.Text = row.Cells[1].Value.ToString(); // seçilen satırdaki kullanıcı ad verisini aktar
                textBoxPassword1.Text = row.Cells[2].Value.ToString(); // seçilen satırdaki parola verisini aktar
            }
        }


        // textbox'dan girilen kullanıcı adını, dataGridViewUser'da görüntüleme
        private void textBoxSearchUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Veritabani_Baglanti.Open();

                // textBoxSearchUsername boşsa tüm tabloyu göstersin. Eğer doluysa kullanıcı adını arasın
                if (string.IsNullOrEmpty(textBoxSearchUsername.Text))
                {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Users", Veritabani_Baglanti);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewUser.DataSource = dataTable;
                }
                else
                {
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;
                    Veri_Komutu.CommandText = "SELECT * FROM Users WHERE kullaniciAdi = ?";
                    Veri_Komutu.Parameters.AddWithValue("@kullaniciAdi", textBoxSearchUsername.Text);

                    OleDbDataReader reader = Veri_Komutu.ExecuteReader();

                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Load(reader);

                    dataGridViewUser.DataSource = dataTable;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Veritabani_Baglanti.Close();
            }
        }
    }
}
