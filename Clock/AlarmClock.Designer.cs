namespace Clock
{
    partial class AlarmClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHours = new System.Windows.Forms.Label();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.labelSetAlarm = new System.Windows.Forms.Label();
            this.labelRepeat = new System.Windows.Forms.Label();
            this.checkedListBoxRepeat = new System.Windows.Forms.CheckedListBox();
            this.buttonLoadMelody = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMelodyFileName = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownHours
            // 
            this.numericUpDownHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownHours.Location = new System.Drawing.Point(12, 134);
            this.numericUpDownHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownHours.Name = "numericUpDownHours";
            this.numericUpDownHours.Size = new System.Drawing.Size(101, 38);
            this.numericUpDownHours.TabIndex = 0;
            this.numericUpDownHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownMinutes
            // 
            this.numericUpDownMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownMinutes.Location = new System.Drawing.Point(178, 134);
            this.numericUpDownMinutes.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownMinutes.Name = "numericUpDownMinutes";
            this.numericUpDownMinutes.Size = new System.Drawing.Size(97, 38);
            this.numericUpDownMinutes.TabIndex = 1;
            this.numericUpDownMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(135, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = ":";
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHours.Location = new System.Drawing.Point(39, 111);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(52, 20);
            this.labelHours.TabIndex = 5;
            this.labelHours.Text = "Hours";
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinutes.Location = new System.Drawing.Point(192, 111);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(65, 20);
            this.labelMinutes.TabIndex = 6;
            this.labelMinutes.Text = "Minutes";
            // 
            // labelSetAlarm
            // 
            this.labelSetAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSetAlarm.Location = new System.Drawing.Point(6, 26);
            this.labelSetAlarm.Name = "labelSetAlarm";
            this.labelSetAlarm.Size = new System.Drawing.Size(269, 72);
            this.labelSetAlarm.TabIndex = 8;
            this.labelSetAlarm.Text = "Настройка будильнника";
            this.labelSetAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRepeat
            // 
            this.labelRepeat.AutoSize = true;
            this.labelRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRepeat.Location = new System.Drawing.Point(13, 184);
            this.labelRepeat.Name = "labelRepeat";
            this.labelRepeat.Size = new System.Drawing.Size(154, 31);
            this.labelRepeat.TabIndex = 9;
            this.labelRepeat.Text = "Повторять:";
            // 
            // checkedListBoxRepeat
            // 
            this.checkedListBoxRepeat.CheckOnClick = true;
            this.checkedListBoxRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxRepeat.FormattingEnabled = true;
            this.checkedListBoxRepeat.Location = new System.Drawing.Point(30, 218);
            this.checkedListBoxRepeat.Name = "checkedListBoxRepeat";
            this.checkedListBoxRepeat.Size = new System.Drawing.Size(227, 196);
            this.checkedListBoxRepeat.TabIndex = 10;
            // 
            // buttonLoadMelody
            // 
            this.buttonLoadMelody.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadMelody.Location = new System.Drawing.Point(6, 424);
            this.buttonLoadMelody.Name = "buttonLoadMelody";
            this.buttonLoadMelody.Size = new System.Drawing.Size(274, 40);
            this.buttonLoadMelody.TabIndex = 12;
            this.buttonLoadMelody.Text = "Настроить мелодию";
            this.buttonLoadMelody.UseVisualStyleBackColor = true;
            this.buttonLoadMelody.Click += new System.EventHandler(this.buttonLoadMelody_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Выбрана мелодия";
            // 
            // labelMelodyFileName
            // 
            this.labelMelodyFileName.AutoSize = true;
            this.labelMelodyFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMelodyFileName.Location = new System.Drawing.Point(6, 487);
            this.labelMelodyFileName.Name = "labelMelodyFileName";
            this.labelMelodyFileName.Size = new System.Drawing.Size(52, 16);
            this.labelMelodyFileName.TabIndex = 14;
            this.labelMelodyFileName.Text = "Melody";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(9, 520);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(127, 36);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(154, 520);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 36);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AlarmClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 568);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelMelodyFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonLoadMelody);
            this.Controls.Add(this.checkedListBoxRepeat);
            this.Controls.Add(this.labelRepeat);
            this.Controls.Add(this.labelSetAlarm);
            this.Controls.Add(this.labelMinutes);
            this.Controls.Add(this.labelHours);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownMinutes);
            this.Controls.Add(this.numericUpDownHours);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AlarmClock";
            this.Text = "AlarmClock";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.Label labelSetAlarm;
        private System.Windows.Forms.Label labelRepeat;
        private System.Windows.Forms.CheckedListBox checkedListBoxRepeat;
        private System.Windows.Forms.Button buttonLoadMelody;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMelodyFileName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}