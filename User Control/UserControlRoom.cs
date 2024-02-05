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
    public partial class UserControlRoom : UserControl
    {
        private string room_No = "", Free = "";

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
            dataGridViewRoom.DataSource = Veri_Seti.Tables[vn];
            Tablo_Kapat();
        }
        //-----------veritabanı foksiyonları bitiş


        public UserControlRoom()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            comboBoxType.SelectedIndex = 0;
            textBoxPhoneNo.Clear();
            radioButtonYes.Checked = false;
            radioButtonNo.Checked = false;
            tabControlRoom.SelectedTab = tabPageAddRoom;
        }

        public void Clear1()
        {
            comboBoxType1.SelectedIndex = 0;
            textBoxPhoneNo1.Clear();
            radioButtonYes1.Checked = false;
            radioButtonNo1.Checked = false;
            room_No = "";
        }

        // Yeni oda ekleme
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (radioButtonYes.Checked)
                Free = "Var";
            if (radioButtonNo.Checked)
                Free = "Yok";

            if (comboBoxType.SelectedIndex == 0 || textBoxPhoneNo.Text == "" || Free == "" )
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    {
                        Veritabani_Baglanti.Open();

                        // odanın veritabanında var olup olmadığını kontrol et
                        if (!OdaVarMi(Veritabani_Baglanti, textBoxPhoneNo.Text))
                        {
                            // oda veritabanında yoksa ekle
                            Ekle(Veritabani_Baglanti, comboBoxType.SelectedItem.ToString(), textBoxPhoneNo.Text, Free);
                            MessageBox.Show("Oda başarılı bir şekilde eklendi.", "Oda Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Oda zaten kayıtlı.", "Oda Kayıtlı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        static void Ekle(OleDbConnection connection, string odaTipi, string odaTelNo, string ucretsizServis)
        {
            string sorgu = "INSERT INTO Room (oda_tipi, oda_tel_no, ucretsiz_servis) VALUES (@OdaTipi, @OdaTelNo, @UcretsizServis)";
            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@OdaTipi", odaTipi);
                command.Parameters.AddWithValue("@OdaTelNo", odaTelNo);
                command.Parameters.AddWithValue("@UcretsizServis", ucretsizServis);
                command.ExecuteNonQuery();
            }
        }

        static bool OdaVarMi(OleDbConnection connection, string odaTelNo)
        {
            string sorgu = "SELECT COUNT(*) FROM Room WHERE oda_tel_no = @odaTelNo";
            using (OleDbCommand command = new OleDbCommand(sorgu, connection))
            {
                command.Parameters.AddWithValue("@OdaTelNo", odaTelNo);
                int kullaniciSayisi = (int)command.ExecuteScalar();
                return kullaniciSayisi > 0;
            }
        }

        private void tabPageSearchRoom_Enter(object sender, EventArgs e)
        {
            Tablo_Veri_Getir("Room");
        }

        private void tabPageSearchRoom_Leave(object sender, EventArgs e)
        {
            textBoxSearchRoomNo.Clear();
        }

        private void textBoxSearchRoomNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Veritabani_Baglanti.Open();

                // textBoxSearchRoomNo boşsa tüm tabloyu göstersin. Eğer doluysa girilen oda numarasını arasın
                if (string.IsNullOrEmpty(textBoxSearchRoomNo.Text))
                {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Room", Veritabani_Baglanti);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewRoom.DataSource = dataTable;
                }
                else
                {
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;
                    Veri_Komutu.CommandText = "SELECT * FROM Room WHERE oda_no = ?";
                    Veri_Komutu.Parameters.AddWithValue("@oda_no", textBoxSearchRoomNo.Text);

                    OleDbDataReader reader = Veri_Komutu.ExecuteReader();

                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Load(reader);

                    dataGridViewRoom.DataSource = dataTable;
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

        private void dataGridViewRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewRoom.Rows[e.RowIndex];
                room_No = row.Cells[0].Value.ToString();
                comboBoxType1.SelectedItem = row.Cells[1].Value.ToString(); // seçilen satırdaki oda_tipi verisini aktar
                textBoxPhoneNo1.Text = row.Cells[2].Value.ToString(); // seçilen satırdaki oda_tel_no verisini aktar
                Free = row.Cells[3].Value.ToString(); // seçilen satırdaki ucretsiz_servis verisini aktar
                if (Free == "Var")
                    radioButtonYes1.Checked = true;
                if (Free == "Yok")
                    radioButtonNo1.Checked = true;

            }
        }

        // oda güncelleme
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (radioButtonYes1.Checked)
                Free = "Var";
            if (radioButtonNo1.Checked)
                Free = "Yok";

            if (room_No != "")
            {
                if (comboBoxType1.SelectedIndex == 0 || textBoxPhoneNo1.Text == "" || Free == "")
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    Veritabani_Baglanti.Open();
                    OleDbCommand Veri_Komutu = new OleDbCommand();
                    Veri_Komutu.Connection = Veritabani_Baglanti;

                    Veri_Komutu.CommandText = "UPDATE Room SET oda_tipi = ?, ucretsiz_servis = ?, oda_tel_no = ? WHERE oda_no = ? ";
                    Veri_Komutu.Parameters.AddWithValue("@oda_tipi", comboBoxType1.SelectedItem.ToString());
                    Veri_Komutu.Parameters.AddWithValue("@ucretsiz_servis", Free);
                    Veri_Komutu.Parameters.AddWithValue("@oda_tel_no", textBoxPhoneNo1.Text);
                    Veri_Komutu.Parameters.AddWithValue("@oda_no", room_No);

                    try
                    {
                        int affectedRows = Veri_Komutu.ExecuteNonQuery();
                        //ExecuteNonQuery() metodu, eğer bir satır güncellenmişse, affectedRows değeri 1 olacaktır.

                        if (affectedRows > 0)
                        {
                            MessageBox.Show(room_No + " numaralı oda bilgileri başarılı bir şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme başarısız. Belirtilen oda kaydı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // oda kaydı silme
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (radioButtonYes1.Checked)
                Free = "Var";
            if (radioButtonNo1.Checked)
                Free = "Yok";

            if (room_No != "")
            {
                if (comboBoxType1.SelectedIndex == 0 || textBoxPhoneNo1.Text == "" || Free == "")
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Gerekli alan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    DialogResult result = MessageBox.Show(room_No + " numaralı oda kaydını silmek istediğinize emin misiniz?", "Oda Kaydını Silmek", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {
                        Veritabani_Baglanti.Open();
                        OleDbCommand Veri_Komutu = new OleDbCommand();
                        Veri_Komutu.Connection = Veritabani_Baglanti;

                        Veri_Komutu.CommandText = "DELETE FROM Room WHERE oda_no = ?";
                        Veri_Komutu.Parameters.AddWithValue("@oda_no", room_No);

                        try
                        {
                            int affectedRows = Veri_Komutu.ExecuteNonQuery();
                            //ExecuteNonQuery() metodu, eğer bir satır silinmişse, affectedRows değeri 1 olacaktır.

                            if (affectedRows > 0)
                            {
                                MessageBox.Show(room_No + " numaralı oda kaydı başarılı bir şekilde silindi.", "Oda Kaydı Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Belirtilen oda kaydı bulunamadı.", "Oda Kaydı Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void UserControlRoom_Load(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = 0;
            comboBoxType1.SelectedIndex = 0;
        }

        private void tabPageUpdateAndDeleteRoom_Leave(object sender, EventArgs e)
        {
            Clear1();
        }

        private void tabPageAddRoom_Leave(object sender, EventArgs e)
        {
            Clear();
            Clear1();
        }
    }
}
