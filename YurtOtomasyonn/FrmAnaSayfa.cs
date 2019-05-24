using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtOtomasyonn
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            FrmOgrenciEkle frmOgrEkle = new FrmOgrenciEkle();
            frmOgrEkle.ShowDialog();
        }
    }
}
