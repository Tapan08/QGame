using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPatelQGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Designbtn_Click(object sender, EventArgs e)
        {
           DesignForm dForm = new DesignForm();

            dForm.Show();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Playbtn_Click(object sender, EventArgs e)
        {
           PlayForm pForm = new PlayForm();

            pForm.Show();
        }
    }
}
