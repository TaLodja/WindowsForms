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
    public partial class AlarmList : Form
    {
        AlarmClock alarmClock;
        public string settingsAlarm;
        public AlarmList()
        {
            InitializeComponent();
            alarmClock = new AlarmClock();
        }
        private void buttonAddAlarm_Click(object sender, EventArgs e)
        {
            alarmClock.StartPosition = FormStartPosition.Manual;
            alarmClock.Location = new Point(this.Location.X-200, this.Location.Y+25);
            alarmClock.ShowDialog();
            if (alarmClock.ShowDialog() == DialogResult.OK)
            {
                string settingsAlarm = $"{alarmClock.alarmTime};{alarmClock.alarmRepeat}";
                listBoxAlarm.Items.Add(settingsAlarm);
            }
        }

        private void buttonDelAlarm_Click(object sender, EventArgs e)
        {
            listBoxAlarm.Items.Remove(settingsAlarm);
        }
    }
}
