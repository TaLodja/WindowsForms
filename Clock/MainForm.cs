using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Text;
using Microsoft.Win32;

namespace Clock
{
    public partial class MainForm : Form
    {
        ColorDialog backgroundDialog;
        ColorDialog foregroundDialog;
        ChooseFont fontDialog;
        AlarmList alarmList;
        public MainForm()
        {
            InitializeComponent();
            backgroundDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();
            fontDialog = new ChooseFont();
            alarmList = new AlarmList();
            SetVisibility(false);
            LoadSettingsApp();
            this.Location = new Point
                (
                    Screen.PrimaryScreen.Bounds.Width - this.labelTime.Width - 150,
                    50
                );
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
            string pathApp = $"{Application.ExecutablePath}\\..\\..\\..\\Settings.ini";
            StreamWriter sw = new StreamWriter(pathApp);
            sw.WriteLine($"{tsmiTopmost.Checked}");
            sw.WriteLine($"{tsmiShowDate.Checked}");
            sw.WriteLine($"{tsmiShowWeekday.Checked}");
            //sw.WriteLine($"{tsmiShowControls.Checked}");
            //sw.WriteLine($"{tsmiShowConsole.Checked}");
            sw.WriteLine($"{fontDialog.FontFileName}");
            sw.WriteLine($"{(int)labelTime.Font.Size}");
            sw.WriteLine($"{labelTime.ForeColor.ToArgb()}");
            sw.WriteLine($"{labelTime.BackColor.ToArgb()}");
            sw.WriteLine($"{tsmiAutostart.Checked}");
            sw.Close();
        }
        void LoadSettingsApp()
        {
            string pathApp = $"{Application.ExecutablePath}\\..\\..\\..\\Settings.ini";
            FileInfo fInfo = new FileInfo( pathApp );
            if (fInfo.Length != 0 || fInfo.Exists)
            {
                StreamReader sr = new StreamReader(pathApp);
                tsmiTopmost.Checked = bool.Parse(sr.ReadLine());
                tsmiShowDate.Checked = bool.Parse(sr.ReadLine());
                tsmiShowWeekday.Checked = bool.Parse(sr.ReadLine());
                //tsmiShowControls.Checked = bool.Parse(sr.ReadLine());
                //tsmiShowConsole.Checked = bool.Parse(sr.ReadLine());
                string fontName = sr.ReadLine();
                int fontSize = Convert.ToInt32(sr.ReadLine());
                labelTime.ForeColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
                labelTime.BackColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
                tsmiAutostart.Checked = bool.Parse(sr.ReadLine());
                sr.Close();
                checkBoxShowDate.Checked = tsmiShowDate.Checked;
                checkBoxShowWeekday.Checked = tsmiShowWeekday.Checked;
                this.TopMost = tsmiTopmost.Checked;
                SetVisibility(tsmiShowControls.Checked);
                fontDialog = new ChooseFont(fontName, fontSize);
                labelTime.Font = fontDialog.Font;
            }
            else return;
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

        private void checkBoxShowDate_CheckedChanged(object sender,
            EventArgs e) => tsmiShowDate.Checked = checkBoxShowDate.Checked;

        private void tsmiShowWeekday_Click(object sender, EventArgs e) =>
            checkBoxShowWeekday.Checked = tsmiShowWeekday.Checked;

        private void checkBoxShowWeekday_CheckedChanged(object sender, EventArgs e)
        {
            tsmiShowWeekday.Checked = (sender as CheckBox).Checked;     // as - оператор преобразования типов
            //tsmiShowWeekday.Checked = ((CheckBox)sender).Checked;
        }

        private void tsmiShowControls_Click(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked);

        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            if (backgroundDialog.ShowDialog() == DialogResult.OK)
                labelTime.BackColor = backgroundDialog.Color;
        }

        private void tsmiForegroundColor_Click(object sender, EventArgs e)
        {
            if (foregroundDialog.ShowDialog() == DialogResult.OK)
                labelTime.ForeColor = foregroundDialog.Color;
        }
        private void tsmiChooseFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
                labelTime.Font = fontDialog.Font;
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        private void tsmiShowConsole_CheckedChanged(object sender, EventArgs e)
        {
            bool console = (sender as ToolStripMenuItem).Checked ? AllocConsole() : FreeConsole();
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

        private void tsmiAlarms_Click(object sender, EventArgs e)
        {
            alarmList.StartPosition = FormStartPosition.Manual;
            alarmList.Location = new Point(this.Location.X - alarmList.Width, this.Location.Y);
            alarmList.ShowDialog();
        }
    }
}
