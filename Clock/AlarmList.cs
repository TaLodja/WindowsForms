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
        //AlarmClock alarmClock;
        AddAlarm alarmAdd;
        OpenFileDialog openFile;
        public ListViewItem newAlarm;
        public AlarmList()
        {
            InitializeComponent();
            //alarmClock = new AlarmClock();
            alarmAdd = new AddAlarm();
            openFile = new OpenFileDialog();
        }
        private void buttonAddAlarm_Click(object sender, EventArgs e)
        {
            alarmAdd.StartPosition = FormStartPosition.Manual;
            alarmAdd.Location = new Point(this.Location.X-200, this.Location.Y+25);
            alarmAdd.ShowDialog();
            //alarmClock.ShowDialog();
            //if (alarmClock.ShowDialog() == DialogResult.OK)
            //{
            //    string settingsAlarm = $"{alarmClock.alarmTime};{alarmClock.alarmRepeat}";
            //    newAlarm = new ListViewItem(settingsAlarm);
            //    //newAlarm.Text = settingsAlarm;
            //    //listView.Items.Add(newAlarm);
            //}
        }

        private void buttonDelAlarm_Click(object sender, EventArgs e)
        {
            //listView.Items.Remove(newAlarm);
        }
    }
}
