using HotelManagementSystem.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class FormHomePage : Form
    {
        public string Username;

        public FormHomePage()
        {
            InitializeComponent();
        }

        private void MovePanel(Control btn)
        {
            panelSlide.Top = btn.Top;
            panelSlide.Height = btn.Height;
        }

        private void linkLabelLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Çıkış Yapmak", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == result)
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo turkishCulture = new CultureInfo("tr-TR");
            labelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt", turkishCulture);
        }

        private void FormHomePage_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labelUsername.Text = Username;
            buttonClient.PerformClick();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            MovePanel(buttonClient);
            userControlSetting1.Hide();
            userControlClient1.Clear();
            userControlClient1.Show();
            userControlRoom1.Hide();
            userControlReservation1.Hide();
        }

        private void buttonRoom_Click(object sender, EventArgs e)
        {
            MovePanel(buttonRoom);
            userControlSetting1.Hide();
            userControlClient1.Hide();
            userControlRoom1.Clear();
            userControlRoom1.Show();
            userControlReservation1.Hide();
        }

        private void buttonReservation_Click(object sender, EventArgs e)
        {
            MovePanel(buttonReservation);
            userControlSetting1.Hide();
            userControlClient1.Hide();
            userControlRoom1.Hide();
            userControlReservation1.Clear();
            userControlReservation1.Show();
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            MovePanel(buttonSetting);
            userControlSetting1.Clear();
            userControlSetting1.Show();
            userControlClient1.Hide();
            userControlRoom1.Hide();
            userControlReservation1.Hide();
        }

    }
}
