
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
            SetVisibility(false);
            tsmiAutostart.Checked = (regKey().GetValue("Clock") != null);
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
        void SaveSettingsApp()
        {
            string filePath = @"C:\Users\Владелец\source\repos\WindowsForms\Clock\Settings.ini";
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine($"{tsmiTopmost.Checked}");
            sw.WriteLine($"{tsmiShowDate.Checked}");
            sw.WriteLine($"{tsmiShowWeekday.Checked}");
            sw.WriteLine($"{tsmiShowControls.Checked}");
            //sw.WriteLine($"{labelTime.Font.Name}");
            //sw.WriteLine($"{labelTime.Font.Size}");
            sw.WriteLine($"{labelTime.ForeColor.ToArgb()}");
            sw.WriteLine($"{labelTime.BackColor.ToArgb()}");
            sw.WriteLine($"{tsmiAutostart.Checked}");
            sw.WriteLine($"{this.Location.X}");
            sw.WriteLine($"{this.Location.Y}");
            sw.Close();
        }
        void LoadSettings()
        {
            string filePath = @"C:\Users\Владелец\source\repos\WindowsForms\Clock\Settings.ini";
            StreamReader sr = new StreamReader(filePath);
            tsmiTopmost.Checked = bool.Parse( sr.ReadLine() );
            tsmiShowDate.Checked = bool.Parse( sr.ReadLine() );
            tsmiShowWeekday.Checked = bool.Parse( sr.ReadLine() );
            tsmiShowControls.Checked = bool.Parse( sr.ReadLine() );
            //string fontName = sr.ReadLine();
            //double fontSize = Convert.ToDouble(sr.ReadLine());
            labelTime.ForeColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
            labelTime.BackColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
            tsmiAutostart.Checked = bool.Parse(sr.ReadLine());
            int x = Convert.ToInt32(sr.ReadLine());
            int y = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            //this.Location = new Point(x, y);
            //labelTime.Font = new Font(fontName, fontSize);
            checkBoxShowDate.Checked = tsmiShowDate.Checked;
            checkBoxShowWeekday.Checked = tsmiShowWeekday.Checked;
            this.TopMost = tsmiTopmost.Checked;
            SetVisibility(tsmiShowControls.Checked);
        }
        private void buttonHideControls_Click(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked = false);

        private void labelTime_DoubleClick(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked = true);

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            SaveSettingsApp();
            this.Close();
        }

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
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width - 8, 0);
        }

        private void tsmiChooseFont_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
        }

        private RegistryKey regKey()
        {
            return Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }
        private void tsmiAutostart_Click(object sender, EventArgs e)
        {
            if (tsmiAutostart.Checked)
            {
                regKey().SetValue("Clock", Application.ExecutablePath.ToString());
                MessageBox.Show("Ключ сохранен", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else regKey().DeleteValue("Clock", false);
        }
    }
}
