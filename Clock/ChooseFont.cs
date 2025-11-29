using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Clock
{
    public partial class ChooseFont : Form
    {
        new public Font Font { get; set; }
        public string FontFileName { get; set; }
        public ChooseFont()
        {
            InitializeComponent();
            LoadFonts();
            comboBoxFont.SelectedIndex = 0;
            //numericUpDownFontSize.Value = 32;
        }
        public ChooseFont(string fontName, int fontSize):this()
        {
            comboBoxFont.SelectedIndex = comboBoxFont.Items.IndexOf(fontName);
            numericUpDownFontSize.Value = fontSize;
            Font = labelExample.Font;
            FontFileName = fontName;
        }
        void LoadFonts()
        {
            Console.WriteLine(Application.ExecutablePath);
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Directory.GetParent(Application.ExecutablePath));
            string directory = $"{Application.ExecutablePath}\\..\\..\\..\\Fonts";
            Directory.SetCurrentDirectory(directory);
            Console.WriteLine(Directory.GetCurrentDirectory());
            ////////////////////////////////////////////////////////////
            comboBoxFont.Items.AddRange(GetFilesByExt(Directory.GetCurrentDirectory(), "*.ttf"));
            comboBoxFont.Items.AddRange(GetFilesByExt(Directory.GetCurrentDirectory(), "*.otf"));
        }
        string[] GetFilesByExt(string directory, string format)
        {
            string[] files = Directory.GetFiles(directory, format);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Split('\\').Last();
            }
            return files;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Font = labelExample.Font;
            FontFileName = comboBoxFont.SelectedItem.ToString();
        }

        private void ChooseFont_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Application.ExecutablePath);
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewExampleFont();
        }
        void ViewExampleFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(comboBoxFont.SelectedItem.ToString());
            labelExample.Font = new Font(pfc.Families[0], (int)numericUpDownFontSize.Value);
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            ViewExampleFont();
        }
    }
}
