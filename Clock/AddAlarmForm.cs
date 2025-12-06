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

namespace Clock
{
    public partial class AddAlarmForm : Form
    {
        Form parent;
        public Alarm Alarm { get; private set; }
        OpenFileDialog fileDialog;
        public AddAlarmForm()
        {
            InitializeComponent();
            dtpDate.Enabled = cbUseDate.Checked;
            fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files |*.mp3;*.flacc|MP-3 file (*.mp3)|*.mp3|Flac files (*.flacc)|*.flacc";
            Alarm = new Alarm();
        }
        public AddAlarmForm(Form parent) : this()
        {
            this.parent = parent;
            this.StartPosition = FormStartPosition.Manual;
        }
        private void cbUseDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = cbUseDate.Checked;
            clbWeekDays.Enabled = !cbUseDate.Checked;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
            lblFile.Text = fileDialog.FileName;
        }

        private void AddAlarmForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(parent.Location.X - 50, parent.Location.Y + 50);
            //if (Alarm.Date != DateTime.MinValue)
            //{
            //    dtpDate.Value = Alarm.Date;
            //}
        }

        private void clbWeekDays_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Weekdays");
            string weekdays = "";
            string indexes = "";
            for (int i = 0; i < (sender as CheckedListBox).CheckedItems.Count; i++)
            {
                weekdays += (sender as CheckedListBox).CheckedItems[i] + "\t";
                indexes += (sender as CheckedListBox).CheckedIndices[i] + "\t";
                //Console.Write((sender as CheckedListBox).SelectedIndices[i] + "\t");
            }
            //MessageBox.Show($"{clbWeekDays.ToString()}");
            //MessageBox.Show($"{weekdays}\n{indexes}");
        }
        public int[] WeekdaysToArray()
        {
            List<int> days = new List<int>();
            foreach (int i in clbWeekDays.CheckedIndices)
            {
                days.Add(i);
            }
            return days.ToArray();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Alarm.Date = dtpDate.Enabled ? dtpDate.Value : DateTime.MinValue;
            Alarm.Time = dtpTime.Value;
            Alarm.WeekdaysFromArray(WeekdaysToArray());
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Sounds");
            Alarm.Filename = (lblFile.Text!="File") ?  lblFile.Text : $"{Directory.GetCurrentDirectory()}\\Nickelback-Savin_Me.mp3";
        }
    }
}
