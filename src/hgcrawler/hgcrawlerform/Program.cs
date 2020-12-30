using Dijing.Common.Core.Enums;
using Dijing.Common.Core.Utility;
using Dijing.SerilogExt;
using hgcrawlerform.Forms;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hgcrawlerform
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            EnvironmentHelper.GetInstance().OSPlatfrom = OSPlatfromEnum.Windows;
            InitLog.SetLog(RunModeEnum.Debug);
            Log.Warning("audiodis.client is starting up");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
