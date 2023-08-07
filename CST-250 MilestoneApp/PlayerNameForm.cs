using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_250_MilstoneApp
{
    public partial class PlayerNameForm : Form
    {
        public PlayerNameForm(string time)
        {
            InitializeComponent();
            TimeLabel.Text += time;
        }

        //close the form 
        private void EnterButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
