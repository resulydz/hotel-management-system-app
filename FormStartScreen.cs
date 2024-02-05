using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HotelManagementSystem
{
    public partial class FormStartScreen : Form
    {

        public FormStartScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;

            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Enabled = false;
                FormLogin fLog = new FormLogin();
                fLog.Show();
                this.Hide();
            }
        }
    }
}
