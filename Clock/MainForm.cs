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
            SetVisibility(false);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => tsmiShowDate.Checked = checkBoxShowDate.Checked;
        void SetVisibility(bool visible)
        {
            checkBoxShowDate.Visible = visible;
            checkBoxShowWeekday.Visible = visible;
            buttonHideControls.Visible = visible;
            this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
            this.TransparencyKey = visible ? Color.Empty : this.BackColor;
            this.ShowInTaskbar = visible;
        }
        //void ChooseColor(object sender)
        //{
        //    colorDialog.ShowDialog();
        //    ((sender = tsmiForegroundColor) ? labelTime.ForeColor : labelTime.BackColor) = colorDialog.Color;
        //}
        private void buttonHideControls_Click(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked = false);

        private void labelTime_DoubleClick(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked = true);

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
        }

        private void tsmiQuit_Click(object sender, EventArgs e) => this.Close();

        private void tsmiTopmost_Click(object sender, EventArgs e) =>
            this.TopMost = tsmiTopmost.Checked;

        private void tsmiShowDate_Click(object sender, EventArgs e) =>
            checkBoxShowDate.Checked = tsmiShowDate.Checked;

        private void checkBoxShowDate_CheckedChanged(object sender, EventArgs e) => 
            tsmiShowDate.Checked = checkBoxShowDate.Checked;

        private void tsmiShowWeekday_Click(object sender, EventArgs e) =>
            checkBoxShowWeekday.Checked = tsmiShowWeekday.Checked;

        private void checkBoxShowWeekday_CheckedChanged(object sender, EventArgs e)
        {
            tsmiShowWeekday.Checked = (sender as CheckBox).Checked;     // as - оператор преобразования типов
            //tsmiShowWeekday.Checked = ((CheckBox)sender).Checked;
        }

        private void tsmiShowControls_Click(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked);

        private void tsmiForegroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            labelTime.ForeColor = colorDialog.Color;
        }

        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            labelTime.BackColor = colorDialog.Color;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width-8, 0);
            this.labelTime.Size = new Size(this.Width-8, this.labelTime.Height);
        }
    }
}
