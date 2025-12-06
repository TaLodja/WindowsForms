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
using System.Globalization;

namespace Clock
{
    public partial class MainForm : Form
    {
        ColorDialog backgroundDialog;
        ColorDialog foregroundDialog;
        ChooseFont fontDialog;
        AlarmsForm alarms;
        Alarm nextAlarm;
        int nextAlarm_index;
        public MainForm()
        {
            InitializeComponent();
            SetVisibility(false);
            axWindowsMediaPlayer.Visible = false;
            backgroundDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();
            fontDialog = new ChooseFont();
            alarms = new AlarmsForm(this);
            LoadSettingsApp();
            //LoadAlarms();
            this.Location = new Point
                (
                    Screen.PrimaryScreen.Bounds.Width - this.labelTime.Width - 150,
                    50
                );
            tsmiTopmost.Checked = this.TopMost = true;
            tsmiAutostart.Checked = (regKey().GetValue("Clock") != null);
            axWindowsMediaPlayer.Visible = false;
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
                //labelTime.Text += $"\n{DateTime.Now.ToString("ddd", new CultureInfo("ru-RU"))}";
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
            notifyIcon.Text = labelTime.Text;
            nextAlarm = FindNextAlarm();
            if (
                nextAlarm != null &&
                (nextAlarm.Date == DateTime.MinValue ? nextAlarm.ContainsDay(DateTime.Now.DayOfWeek) : CompareDates(nextAlarm.Date, DateTime.Now)) &&
                CompareTimes(nextAlarm.Time, DateTime.Now)
                )
            {
                System.Threading.Thread.Sleep(1000);
                PlayAlarm();
                //if (nextAlarm.Date != DateTime.MinValue) alarms.AlarmsList.Items.Remove(alarms.AlarmsList.Items[FindNextAlarmIndex()]);
            }
            if (alarms.AlarmsList.Items.Count > 0) nextAlarm = FindNextAlarm();
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
            FileInfo fInfo = new FileInfo(pathApp);
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
        void LoadAlarms()
        {
            string filename = $"{Application.ExecutablePath}\\..\\..\\..\\AlarmList.ini";
            FileInfo fInfo = new FileInfo(filename);
            if (fInfo.Length != 0 || fInfo.Exists)
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                string sr_alarm = sr.ReadLine();
                string[] sr_alarmItems = sr_alarm.Split(';');
                Alarm ararmLoaded = new Alarm
                    (
                    (sr_alarmItems[0] == "Repeat") ? new DateTime() : new DateTime(Convert.ToInt32(sr_alarmItems[0])),
                    new DateTime(Convert.ToInt32(sr_alarmItems[1])),
                    Convert.ToByte(sr_alarmItems[2]),
                    sr_alarmItems[3]
                    );
                MessageBox.Show("Будильники загружены");
                alarms.AlarmsList.Items.Add(ararmLoaded);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("Будильники не загружены");
                return;
            }
        }
        Alarm FindNextAlarm()
        {
            //Alarm[] actualAlarm;
            //for (int i=0; i<alarms.AlarmsList.Items.Count; i++)
            //{
            //    string AlarmDateTime = $"{(alarms.AlarmsList.Items[i] as Alarm).Date} {(alarms.AlarmsList.Items[i] as Alarm).Time}";
            //    actualAlarm[i] = alarms.AlarmsList.Items.Cast<Alarm>().Where(a => a.Time < DateTime.Now)
            //}
            return alarms.AlarmsList.Items.Cast<Alarm>().ToArray().Min();
        }
        bool CompareDates(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
        }
        bool CompareTimes(DateTime date1, DateTime date2)
        {
            return date1.Hour == date2.Hour && date1.Minute == date2.Minute && date1.Second == date2.Second;
        }
        bool CompareAlarms(DateTime date1, DateTime date2)
        {
            
            return (DateTime.Compare(date1, date2) > 0);
        }
        void PlayAlarm()
        {
            axWindowsMediaPlayer.URL = nextAlarm.Filename;
            axWindowsMediaPlayer.settings.volume = 32;
            axWindowsMediaPlayer.Ctlcontrols.play();
            axWindowsMediaPlayer.Visible = true;
            btnAlarmsClose.Visible = true;
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
            bool console = tsmiShowConsole.Checked ? AllocConsole() : FreeConsole();
            //bool console = (sender as ToolStripMenuItem).Checked ? AllocConsole() : FreeConsole();
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
            alarms.ShowDialog();
        }

        private void btnAlarmClose_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.stop();
            btnAlarmsClose.Visible = false;
            axWindowsMediaPlayer.Visible = false;
        }
    }
}
