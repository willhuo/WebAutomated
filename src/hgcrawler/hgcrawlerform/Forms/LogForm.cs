﻿using Dijing.SerilogExt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hgcrawlerform.Forms
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 10, 10);
            InMemorySink.OnLogReceivedEvent += InMemorySink_OnLogReceivedEvent;
            Serilog.Log.Information("日志组件初始化完成");
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void InMemorySink_OnLogReceivedEvent(object sender, string e)
        {
            richTxtLog.Invoke(new Action(() =>
            {
                if (richTxtLog.Text.Length > 200000)
                    richTxtLog.Clear();

                richTxtLog.AppendText(e + Environment.NewLine);
                richTxtLog.ScrollToCaret();
            }));
        }
    }
}
