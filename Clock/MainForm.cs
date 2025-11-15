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

        private void timer_Tick(object sender, EventArgs e)         //Обработчик событий
        {
            //labelTime.Text = DateTime.Now.ToString("HH:mm:ss"); //24-часовой формат
            labelTime.Text = DateTime.Now.ToString
                (
                "hh:mm:ss tt", //mm - minutes
                System.Globalization.CultureInfo.InvariantCulture       //AM/PM fix
                );  //12-часовой формат
            if (checkBoxShowDate.Checked)
                labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";   //MM - Month
            if (checkBoxShowWeekday.Checked)
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        void SetVisibility(bool visible)
        {
            checkBoxShowDate.Visible = visible;
            checkBoxShowWeekday.Visible = visible;
            buttonHideControls.Visible = visible;
            this.FormBorderStyle = visible? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
            this.TransparencyKey = visible? Color.Empty : this.BackColor;
            this.ShowInTaskbar = visible;
        }
        private void buttonHideControls_Click(object sender, EventArgs e)
        {
            SetVisibility(false);
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            SetVisibility(true);
        }
    }
}
