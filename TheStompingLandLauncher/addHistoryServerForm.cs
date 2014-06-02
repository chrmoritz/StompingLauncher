using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TheStompingLandLauncher
{
    public partial class addHistoryServerForm : Form
    {
        public addHistoryServerForm()
        {
            InitializeComponent();
        }

        private void TBaddServerIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }
    }
}
