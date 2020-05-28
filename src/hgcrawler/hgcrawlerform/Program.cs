using Dijing.SerilogExt;
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
            var sink = new InMemorySink();
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
#if RELEASE
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
#endif
            .Enrich.FromLogContext()
            //.WriteTo.Console()
            .WriteTo.Sink(sink)
            .WriteTo.File("logs" + Path.DirectorySeparatorChar + "log-.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
            .CreateLogger();            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm());
        }
    }
}
