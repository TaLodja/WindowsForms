namespace Clock
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxShowDate = new System.Windows.Forms.CheckBox();
            this.checkBoxShowWeekday = new System.Windows.Forms.CheckBox();
            this.buttonHideControls = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTopmost = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowWeekday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowControls = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelTime.ContextMenuStrip = this.contextMenuStrip;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(12, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(210, 51);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "labelTime";
            this.labelTime.DoubleClick += new System.EventHandler(this.labelTime_DoubleClick);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // checkBoxShowDate
            // 
            this.checkBoxShowDate.AutoSize = true;
            this.checkBoxShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowDate.Location = new System.Drawing.Point(12, 208);
            this.checkBoxShowDate.Name = "checkBoxShowDate";
            this.checkBoxShowDate.Size = new System.Drawing.Size(176, 29);
            this.checkBoxShowDate.TabIndex = 1;
            this.checkBoxShowDate.Text = "Показать дату";
            this.checkBoxShowDate.UseVisualStyleBackColor = true;
            this.checkBoxShowDate.CheckedChanged += new System.EventHandler(this.checkBoxShowDate_CheckedChanged);
            // 
            // checkBoxShowWeekday
            // 
            this.checkBoxShowWeekday.AutoSize = true;
            this.checkBoxShowWeekday.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowWeekday.Location = new System.Drawing.Point(13, 244);
            this.checkBoxShowWeekday.Name = "checkBoxShowWeekday";
            this.checkBoxShowWeekday.Size = new System.Drawing.Size(256, 29);
            this.checkBoxShowWeekday.TabIndex = 2;
            this.checkBoxShowWeekday.Text = "Показать день недели";
            this.checkBoxShowWeekday.UseVisualStyleBackColor = true;
            this.checkBoxShowWeekday.CheckedChanged += new System.EventHandler(this.checkBoxShowWeekday_CheckedChanged);
            // 
            // buttonHideControls
            // 
            this.buttonHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHideControls.Location = new System.Drawing.Point(13, 305);
            this.buttonHideControls.Name = "buttonHideControls";
            this.buttonHideControls.Size = new System.Drawing.Size(305, 77);
            this.buttonHideControls.TabIndex = 3;
            this.buttonHideControls.Text = "Скрыть элементы управления";
            this.buttonHideControls.UseVisualStyleBackColor = true;
            this.buttonHideControls.Click += new System.EventHandler(this.buttonHideControls_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Clock SPU-411";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTopmost,
            this.toolStripSeparator1,
            this.tsmiShowDate,
            this.tsmiShowWeekday,
            this.tsmiShowControls,
            this.toolStripSeparator2,
            this.tsmiQuit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 148);
            // 
            // tsmiTopmost
            // 
            this.tsmiTopmost.CheckOnClick = true;
            this.tsmiTopmost.Name = "tsmiTopmost";
            this.tsmiTopmost.Size = new System.Drawing.Size(180, 22);
            this.tsmiTopmost.Text = "Topmost";
            this.tsmiTopmost.Click += new System.EventHandler(this.tsmiTopmost_Click);
            // 
            // tsmiShowDate
            // 
            this.tsmiShowDate.CheckOnClick = true;
            this.tsmiShowDate.Name = "tsmiShowDate";
            this.tsmiShowDate.Size = new System.Drawing.Size(180, 22);
            this.tsmiShowDate.Text = "Show date";
            this.tsmiShowDate.Click += new System.EventHandler(this.tsmiShowDate_Click);
            // 
            // tsmiShowWeekday
            // 
            this.tsmiShowWeekday.CheckOnClick = true;
            this.tsmiShowWeekday.Name = "tsmiShowWeekday";
            this.tsmiShowWeekday.Size = new System.Drawing.Size(180, 22);
            this.tsmiShowWeekday.Text = "Show weekday";
            this.tsmiShowWeekday.Click += new System.EventHandler(this.tsmiShowWeekday_Click);
            // 
            // tsmiShowControls
            // 
            this.tsmiShowControls.CheckOnClick = true;
            this.tsmiShowControls.Name = "tsmiShowControls";
            this.tsmiShowControls.Size = new System.Drawing.Size(180, 22);
            this.tsmiShowControls.Text = "Show controls";
            this.tsmiShowControls.Click += new System.EventHandler(this.tsmiShowControls_Click);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(180, 22);
            this.tsmiQuit.Text = "Quit";
            this.tsmiQuit.Click += new System.EventHandler(this.tsmiQuit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 417);
            this.Controls.Add(this.buttonHideControls);
            this.Controls.Add(this.checkBoxShowWeekday);
            this.Controls.Add(this.checkBoxShowDate);
            this.Controls.Add(this.labelTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Clock_SPU_411";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox checkBoxShowDate;
        private System.Windows.Forms.CheckBox checkBoxShowWeekday;
        private System.Windows.Forms.Button buttonHideControls;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiTopmost;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowWeekday;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowControls;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

