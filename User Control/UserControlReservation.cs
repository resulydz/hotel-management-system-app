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
    public partial class UserControlReservation : UserControl
    {
        private string RID = "", No;

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
            dataGridViewReservation.DataSource = Veri_Seti.Tables[vn];
            Tablo_Kapat();
        }
        //-----------veritabanı foksiyonları bitiş

        public UserControlReservation()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            comboBoxType.SelectedIndex = 0;
            comboBoxNo.SelectedIndex = 0;
            textBoxClientID.Clear();
            dateTimePickerIn.Value = DateTime.Now;
            dateTimePickerOut.Value = DateTime.Now;
            tabControlReservation.SelectedTab = tabPageAddReservation;
        }

        private void UserControlReservation_Load(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = 0;
            comboBoxNo.SelectedIndex = 0;
            comboBoxType1.SelectedIndex = 0;
            comboBoxNo1.SelectedIndex = 0;
        }

        private void tabPageAddReservation_Leave(object sender, EventArgs e)
        {
            Clear();
            Clear1();
        }

        // rezervasyon ekleme
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null || comboBoxNo.SelectedItem == null || textBoxClientID.Text == "")
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    {
                        Veritabani_Baglanti.Open();

                        // rezervasyonun veritabanında var olup olmadığını kontrol et
                        if (!RezervasyonVarMi(Veritabani_Baglanti, comboBoxNo.SelectedItem.ToString()))
                        {
                            // rezervasyon veritabanında yoksa ekle
                            Ekle(Veritabani_Baglanti, comboBoxType.SelectedItem.ToString(), comboBoxNo.SelectedItem.ToString(), textBoxClientID.Text, dateTimePickerIn.Text, dateTimePickerOut.Text);
                            MessageBox.Show(comboBoxNo.SelectedItem.ToString() + " numaralı oda için rezervasyon başarılı bir şekilde eklendi.", "Rezervasyon Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show(comboBoxNo.SelectedItem.ToString() + " numaralı odanin rezervasyonu zaten var.", "Rezervasyon Var", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        static void Ekle(OleDbConnection connection, string odaTipi, string odaNo, string musteriID, string girisTarihi, string cikisTarihi)
        {
            string sorgu = "INSERT INTO Reservation (oda_tipi, oda_no, musteri_ID, giris_tarihi, cikis_tarihi) VALUES (@Oda_Tipi, @Oda_No, @Musteri_ID, @Giris_Tarihi, Cikis_Tarihi)";
            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@Oda_Tipi", odaTipi);
                command.Parameters.AddWithValue("@Oda_No", odaNo);
                command.Parameters.AddWithValue("@Musteri_ID", musteriID);
                command.Parameters.AddWithValue("@Giris_Tarihi", girisTarihi);
                command.Parameters.AddWithValue("@Cikis_Tarihi", cikisTarihi);
                command.ExecuteNonQuery();
            }
        }

        static bool RezervasyonVarMi(OleDbConnection connection, string odaNo)
        {
            string sorgu = "SELECT COUNT(*) FROM Reservation WHERE oda_no = @Oda_No";
            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@Oda_No", odaNo);
                int kullaniciSayisi = (int)command.ExecuteScalar();
                return kullaniciSayisi > 0;
            }
        }

        private void tabPageSearchReservation_Enter(object sender, EventArgs e)
        {
            Tablo_Veri_Getir("Reservation");
        }

        private void tabPageSearchReservation_Leave(object sender, EventArgs e)
        {
            textBoxSearchClientID.Clear();
        }

        private void textBoxSearchClientID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Veritabani_Baglanti.Open();

                // textBoxSearchClientID boşsa tüm tabloyu göstersin. Eğer doluysa girilen telefon numarasını arasın
                if (string.IsNullOrEmpty(textBoxSearchClientID.Text))
                {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Reservation", Veritabani_Baglanti);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewReservation.DataSource = dataTable;
                }
                else
                {
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;
                    Veri_Komutu.CommandText = "SELECT * FROM Reservation WHERE musteri_ID = ?";
                    Veri_Komutu.Parameters.AddWithValue("@musteri_ID", textBoxSearchClientID.Text);

                    OleDbDataReader reader = Veri_Komutu.ExecuteReader();

                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Load(reader);

                    dataGridViewReservation.DataSource = dataTable;
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


        //tabloda seçilen satırdaki bilgileri, güncelleme alanına aktarma/gösterme
        private void dataGridViewReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewReservation.Rows[e.RowIndex];
                RID = row.Cells[0].Value.ToString();
                comboBoxType1.SelectedItem = row.Cells[1].Value.ToString(); // seçilen satırdaki oda tipi verisini aktar
                comboBoxNo1.SelectedItem = row.Cells[2].Value.ToString(); // seçilen satırdaki oda no verisini aktar
                textBoxClientID1.Text = row.Cells[3].Value.ToString(); // seçilen satırdaki müteri ID verisini aktar
                dateTimePickerIn1.Text = row.Cells[4].Value.ToString(); // seçilen satırdaki giriş tarihi verisini aktar
                dateTimePickerOut1.Text = row.Cells[5].Value.ToString(); // seçilen satırdaki çıkı tarihi verisini aktar
            }
        }

        // rezervasyon güncelleme
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (RID != "")
            {
                Veritabani_Baglanti.Open();
                OleDbCommand Veri_Komutu = new OleDbCommand();
                Veri_Komutu.Connection = Veritabani_Baglanti;

                if (!RezervasyonVarMi(Veritabani_Baglanti, comboBoxNo1.SelectedItem.ToString()))
                {
                    // daha önce rezervasyon veritabanında yoksa güncelle
                    Veri_Komutu.CommandText = "UPDATE Reservation SET oda_tipi = @oda_tipi, oda_no = @oda_no, musteri_ID = @musteri_ID, giris_tarihi = @giris_tarihi, cikis_tarihi = @cikis_tarihi WHERE Kimlik = @Kimlik";

                    Veri_Komutu.Parameters.AddWithValue("@oda_tipi", comboBoxType1.SelectedItem.ToString());
                    Veri_Komutu.Parameters.AddWithValue("@oda_no", comboBoxNo1.SelectedItem.ToString());
                    Veri_Komutu.Parameters.AddWithValue("@musteri_ID", textBoxClientID1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@giris_tarihi", dateTimePickerIn1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@cikis_tarihi", dateTimePickerOut1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@Kimlik", RID);
                    Clear1();
                }
                else
                {
                    MessageBox.Show(comboBoxNo.SelectedItem.ToString() + " numaralı odanin rezervasyonu zaten var.", "Rezervasyon Var", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                try
                {
                    int affectedRows = Veri_Komutu.ExecuteNonQuery();
                    //ExecuteNonQuery() metodu, eğer bir satır güncellenmişse, affectedRows değeri 1 olacaktır.

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Rezervasyon bilgileri başarılı bir şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız. Belirtilen Rezervasyon kaydı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Lütfen önce tablodan satırı seçin.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // rezervasyon iptal etme
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (RID != "")
            {
                DialogResult result = MessageBox.Show("Rezervasyon kaydını iptal etmek istediğinize emin misiniz?", "Rezervasyon Kaydını Silmek", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    Veritabani_Baglanti.Open();
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;

                    Veri_Komutu.CommandText = "DELETE FROM Reservation WHERE Kimlik = ?";
                    Veri_Komutu.Parameters.AddWithValue("@Kimlik", RID);

                    try
                    {
                        int affectedRows = Veri_Komutu.ExecuteNonQuery();
                        //ExecuteNonQuery() metodu, eğer bir satır silinmişse, affectedRows değeri 1 olacaktır.

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Rezervasyon kaydı başarılı bir şekilde iptal edildi.", "Rezervasyon İptal Edildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen rezervasyon kaydı bulunamadı.", "Rezervasyon Kaydı Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tabPageUpdateAndCancelReservation_Leave(object sender, EventArgs e)
        {
            Clear1();
        }

        // comboBoxType'den seçilen oda tipinden, Room veri tablosunda kaç tane aynı oda tipinden
        // varsa o odaların oda_no larını comboBoxNo'ya atar
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem != null)
            {
                try
                {
                    Veritabani_Baglanti.Open();
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;
                    Veri_Komutu.CommandText = "SELECT oda_no FROM Room WHERE oda_tipi = @odaTipi";

                    Veri_Komutu.Parameters.AddWithValue("@odaTipi", comboBoxType.SelectedItem.ToString());

                    OleDbDataReader reader = Veri_Komutu.ExecuteReader();

                    comboBoxNo.Items.Clear();

                    while (reader.Read())
                    {
                        comboBoxNo.Items.Add(reader["oda_no"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    Veritabani_Baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // comboBoxType1'den seçilen oda tipinden, Room veri tablosunda kaç tane aynı oda tipinden
        // varsa o odaların oda_no larını comboBoxNo1'e atar
        private void comboBoxType1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxType1.SelectedItem != null)
            {
                try
                {
                    Veritabani_Baglanti.Open();
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;
                    Veri_Komutu.CommandText = "SELECT oda_no FROM Room WHERE oda_tipi = @odaTipi";

                    Veri_Komutu.Parameters.AddWithValue("@odaTipi", comboBoxType1.SelectedItem.ToString());

                    OleDbDataReader reader = Veri_Komutu.ExecuteReader();

                    comboBoxNo1.Items.Clear();

                    while (reader.Read())
                    {
                        comboBoxNo1.Items.Add(reader["oda_no"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    Veritabani_Baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Clear1()
        {
            comboBoxType1.SelectedIndex = 0;
            comboBoxNo1.SelectedIndex = 0;
            textBoxClientID1.Clear();
            dateTimePickerIn1.Value = DateTime.Now;
            dateTimePickerOut1.Value = DateTime.Now;
            RID = "";
        }
    }
}
