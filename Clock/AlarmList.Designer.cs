namespace Clock
{
    partial class AlarmList
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
            this.labelAlarmList = new System.Windows.Forms.Label();
            this.buttonAddAlarm = new System.Windows.Forms.Button();
            this.buttonDelAlarm = new System.Windows.Forms.Button();
            this.listBoxAlarm = new System.Windows.Forms.ListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAlarmList
            // 
            this.labelAlarmList.AutoSize = true;
            this.labelAlarmList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAlarmList.Location = new System.Drawing.Point(29, 13);
            this.labelAlarmList.Name = "labelAlarmList";
            this.labelAlarmList.Size = new System.Drawing.Size(276, 31);
            this.labelAlarmList.TabIndex = 1;
            this.labelAlarmList.Text = "Список будильников";
            // 
            // buttonAddAlarm
            // 
            this.buttonAddAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddAlarm.Location = new System.Drawing.Point(29, 301);
            this.buttonAddAlarm.Name = "buttonAddAlarm";
            this.buttonAddAlarm.Size = new System.Drawing.Size(276, 46);
            this.buttonAddAlarm.TabIndex = 2;
            this.buttonAddAlarm.Text = "Добавить будильник";
            this.buttonAddAlarm.UseVisualStyleBackColor = true;
            this.buttonAddAlarm.Click += new System.EventHandler(this.buttonAddAlarm_Click);
            // 
            // buttonDelAlarm
            // 
            this.buttonDelAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelAlarm.Location = new System.Drawing.Point(29, 353);
            this.buttonDelAlarm.Name = "buttonDelAlarm";
            this.buttonDelAlarm.Size = new System.Drawing.Size(276, 46);
            this.buttonDelAlarm.TabIndex = 3;
            this.buttonDelAlarm.Text = "Удалить будильник";
            this.buttonDelAlarm.UseVisualStyleBackColor = true;
            this.buttonDelAlarm.Click += new System.EventHandler(this.buttonDelAlarm_Click);
            // 
            // listBoxAlarm
            // 
            this.listBoxAlarm.FormattingEnabled = true;
            this.listBoxAlarm.Location = new System.Drawing.Point(29, 48);
            this.listBoxAlarm.Name = "listBoxAlarm";
            this.listBoxAlarm.Size = new System.Drawing.Size(276, 238);
            this.listBoxAlarm.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(100, 418);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(131, 46);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // AlarmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 476);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxAlarm);
            this.Controls.Add(this.buttonDelAlarm);
            this.Controls.Add(this.buttonAddAlarm);
            this.Controls.Add(this.labelAlarmList);
            this.MaximizeBox = false;
            this.Name = "AlarmList";
            this.Text = "AlarmList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelAlarmList;
        private System.Windows.Forms.Button buttonAddAlarm;
        private System.Windows.Forms.Button buttonDelAlarm;
        private System.Windows.Forms.ListBox listBoxAlarm;
        private System.Windows.Forms.Button buttonOK;
    }
}