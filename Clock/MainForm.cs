using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //labelTime.Text = DateTime.Now.ToString("HH:mm:ss"); //24-часовой формат
            labelTime.Text = DateTime.Now.ToString
                (
                "hh:mm:ss tt", 
                System.Globalization.CultureInfo.InvariantCulture       //AM/PM fix
                );  //12-часовой формат
        }
    }
}
