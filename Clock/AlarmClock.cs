using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clock
{
    public partial class AlarmClock : Form
    {
        public string alarmTime { get; set; }
        public string alarmRepeat { get; set; }
        public string melodyFileName { get; set; }
        OpenFileDialog chooseMusic;
        public AlarmClock()
        {
            InitializeComponent();
            checkedListBoxRepeat.Items.Clear();
            checkedListBoxRepeat.Items.AddRange(new string[] { "One time", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            chooseMusic = new OpenFileDialog();
        }
        //void SetAlarmTime()
        //{ 
        //    alarmTime = $"{TimeForm(numericUpDownHours)}:{TimeForm(numericUpDownMinutes)}:00";
        //}
            
        void DellCheckWeekDayBox()
        {
            CheckedListBox.CheckedItemCollection collection = checkedListBoxRepeat.CheckedItems;
            foreach (int i in collection)
                checkedListBoxRepeat.Items.RemoveAt(i);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //SetAlarmTime();

            alarmTime = $"{TimeForm(numericUpDownHours)}:{TimeForm(numericUpDownMinutes)}:00";
            FillCheckWeekDayBox();
            //DellCheckWeekDayBox();
        }
        string TimeForm(object sender)
        {
            string time = (sender as NumericUpDown).Value.ToString();
            time = ((sender as NumericUpDown).Value < 10) ? $"0{time}" : time;
            return time;
        }
        void FillCheckWeekDayBox()
        {
                alarmRepeat = checkedListBoxRepeat.CheckedItems[0].ToString();
                for (int i = 1; i < checkedListBoxRepeat.CheckedItems.Count; i++)
                    alarmRepeat += $",{checkedListBoxRepeat.SelectedItems[i]}";
        }

        private void buttonLoadMelody_Click(object sender, EventArgs e)
        {
            chooseMusic.ShowDialog();
        }
    }
}
