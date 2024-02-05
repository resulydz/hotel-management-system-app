using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.User_Control
{
    public partial class UserControlClient : UserControl
    {
        private string client_ID = "";

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
            dataGridViewClient.DataSource = Veri_Seti.Tables[vn];
            Tablo_Kapat();
        }
        //-----------veritabanı foksiyonları bitiş

        public UserControlClient()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhoneNo.Clear();
            textBoxAddress.Clear();
            tabControlClient.SelectedTab = tabPageAddClient;
        }

        public void Clear1()
        {
            textBoxFirstName1.Clear();
            textBoxLastName1.Clear();
            textBoxPhoneNo1.Clear();
            textBoxAddress1.Clear();
            client_ID = "";
        }

        // Yeni müşteri kontrol ederek ekleme
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == "" || textBoxLastName.Text == "" || 
                textBoxPhoneNo.Text == "" || textBoxAddress.Text == "")
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    {
                        Veritabani_Baglanti.Open();

                        // müşterinin veritabanında var olup olmadığını kontrol et
                        if (!MusteriVarMi(Veritabani_Baglanti, textBoxPhoneNo.Text))
                        {
                            // müşteri veritabanında yoksa ekle
                            Ekle(Veritabani_Baglanti, textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNo.Text, textBoxAddress.Text);
                            MessageBox.Show(textBoxFirstName.Text + " isimli müşteri başarılı bir şekilde eklendi.", "Müşteri Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show(textBoxPhoneNo.Text + " numaralı müşteri zaten kayıtlı.", "Müşteri Var", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
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

        static void Ekle(OleDbConnection connection, string ad, string soyad, string telefon, string adres)
        {
            string sorgu = "INSERT INTO Client (adi, soyadi, telefon_no, adres) VALUES (@Adi, @Soyadi, @Telefon_No, @Adres)";
            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@Adi", ad);
                command.Parameters.AddWithValue("@Soyadi", soyad);
                command.Parameters.AddWithValue("@Telefon_No", telefon);
                command.Parameters.AddWithValue("@Adres", adres);
                command.ExecuteNonQuery();
            }
        }

        static bool MusteriVarMi(OleDbConnection connection, string telefon)
        {
            string sorgu = "SELECT COUNT(*) FROM Client WHERE telefon_no = @Telefon_No";
            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@Telefon_No", telefon);
                int kullaniciSayisi = (int)command.ExecuteScalar();
                return kullaniciSayisi > 0;
            }
        }

        private void tabPageAddClient_Leave(object sender, EventArgs e)
        {
            Clear();
            Clear1();
        }

        private void tabPageSearchClient_Enter(object sender, EventArgs e)
        {
            Tablo_Veri_Getir("Client");
        }

        private void tabPageSearchClient_Leave(object sender, EventArgs e)
        {
            textBoxSearchPhoneNo.Clear();
        }

        private void textBoxSearchPhoneNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Veritabani_Baglanti.Open();

                // textBoxSearchPhoneNo boşsa tüm tabloyu göstersin. Eğer doluysa girilen telefon numarasını arasın
                if (string.IsNullOrEmpty(textBoxSearchPhoneNo.Text))
                {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Client", Veritabani_Baglanti);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewClient.DataSource = dataTable;
                }
                else
                {
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;
                    Veri_Komutu.CommandText = "SELECT * FROM Client WHERE telefon_no = ?";
                    Veri_Komutu.Parameters.AddWithValue("@telefon_no", textBoxSearchPhoneNo.Text);

                    OleDbDataReader reader = Veri_Komutu.ExecuteReader();

                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Load(reader);

                    dataGridViewClient.DataSource = dataTable;
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

        // nüşteri güncelleme
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(client_ID != "")
            {
                if (textBoxFirstName1.Text == "" || textBoxLastName1.Text == "" ||
                textBoxPhoneNo1.Text == "" || textBoxAddress1.Text == "")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Veritabani_Baglanti.Open();
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;

                    Veri_Komutu.CommandText = "UPDATE Client SET adi = @adi, soyadi = @soyadi, adres = @adres, telefon_no = @telefon_no WHERE Kimlik = @Kimlik";

                    Veri_Komutu.Parameters.AddWithValue("@adi", textBoxFirstName1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@soyadi", textBoxLastName1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@adres", textBoxAddress1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@telefon_no", textBoxPhoneNo1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@Kimlik", client_ID);


                    try
                    {
                        int affectedRows = Veri_Komutu.ExecuteNonQuery();
                        //ExecuteNonQuery() metodu, eğer bir satır güncellenmişse, affectedRows değeri 1 olacaktır.

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Müşteri bilgileri başarılı bir şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme başarısız. Belirtilen müşteri kaydı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Lütfen önce tablodan satırı seçin.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // kayıtlı müşteriyi silme
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (client_ID != "")
            {
                if (textBoxFirstName1.Text == "" || textBoxLastName1.Text == "" ||
               textBoxPhoneNo1.Text == "" || textBoxAddress1.Text == "")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show(textBoxFirstName1.Text + " adlı müşteri kaydını silmek istediğinize emin misiniz?", "Müşteri Kaydını Silmek", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {
                        Veritabani_Baglanti.Open();
                        OleDbCommand Veri_Komutu = new OleDbCommand();
                        Veri_Komutu.Connection = Veritabani_Baglanti;

                        Veri_Komutu.CommandText = "DELETE FROM Client WHERE Kimlik = ?";
                        Veri_Komutu.Parameters.AddWithValue("@Kimlik", client_ID);

                        try
                        {
                            int affectedRows = Veri_Komutu.ExecuteNonQuery();
                            //ExecuteNonQuery() metodu, eğer bir satır silinmişse, affectedRows değeri 1 olacaktır.

                            if (affectedRows > 0)
                            {
                                MessageBox.Show(textBoxFirstName1.Text + " isimli müşteri kaydı başarılı bir şekilde silindi.", "Müşteri Kaydı Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Belirtilen müşteri kaydı bulunamadı.", "Müşteri Kaydı Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tabPageUpdateAndDeleteClient_Leave(object sender, EventArgs e)
        {
            Clear1();
        }

        //tabloda seçilen satırdaki "ad", "soyad", "telefon" ve "adres" bilgilerini, güncelleme alanına aktarma/gösterme
        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewClient.Rows[e.RowIndex];
                client_ID = row.Cells[0].Value.ToString();
                textBoxFirstName1.Text = row.Cells[1].Value.ToString(); // seçilen satırdaki ad verisini aktar
                textBoxLastName1.Text = row.Cells[2].Value.ToString(); // seçilen satırdaki soyad verisini aktar
                textBoxPhoneNo1.Text = row.Cells[3].Value.ToString(); // seçilen satırdaki telefon verisini aktar
                textBoxAddress1.Text = row.Cells[4].Value.ToString(); // seçilen satırdaki adres verisini aktar
            }
        }
    }
}
