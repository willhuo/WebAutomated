using Dijing.Appsettings;
using Dijing.Common.Core.Enums;
using Dijing.Common.Core.Utility;
using Dijing.SerilogExt;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace hgcrawler
{
    /// <summary>
    /// 自动配置
    /// </summary>
    public class Init
    {
        /// <summary>
        /// 自动配置
        /// </summary>
        public static void AutoConfig()
        {
            EnvironmentHelper.GetInstance().OSPlatfrom = OSPlatfromEnum.Windows;
            SetEncoding();
            InitLog.SetLog(RunModeEnum.Debug);
            InitLicense();
            if (EnvironmentHelper.GetInstance().OSPlatfrom == OSPlatfromEnum.Windows)
                InitUI();
            IngoreCtrlC();
            ErrorHandle();

        }        
        private static void InitLicense()
        {
            RegisterHelper.Default.CheckLicense("5bd223e6654368182ab0284c1d4032e8", true);
            if (!File.Exists("machinecode.dat"))
                RegisterHelper.Default.GenerateMachineCodeFile();
        }
        private static void InitUI()
        {
            var curAssembly = System.Reflection.Assembly.GetEntryAssembly();
            var attributes = curAssembly.GetCustomAttributes(typeof(System.Reflection.AssemblyFileVersionAttribute), false);
            var fileVersionAttribute = (System.Reflection.AssemblyFileVersionAttribute)attributes.First();
            var version = fileVersionAttribute.Version;
            Console.Title = $"{Console.Title}[{version}]";

            RemoveCloseButton();
        }
        private static void RemoveCloseButton()
        {
            EnvironmentHelper.GetInstance().RemoveCurrentConsoleWindowMenu();
        }
        private static void IngoreCtrlC()
        {
            //忽略ctr+c退出程序
            Console.TreatControlCAsInput = true;
            Console.CancelKeyPress += Console_CancelKeyPress;
        }
        private static void SetEncoding()
        {
            //中文支持       
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (EnvironmentHelper.GetInstance().OSPlatfrom == OSPlatfromEnum.Windows)
                Console.OutputEncoding = Encoding.GetEncoding("GB2312");
            else
                Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
        }
        private static void ErrorHandle()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        }


        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Serilog.Log.Warning("ctrl+c can not support to exist application,pls use taskmgr to exist application");
            return;
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Serilog.Log.Warning($"CurrentDomain_UnhandledException,{0}", e);
        }
        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Serilog.Log.Warning($"CurrentDomain_ProcessExit,{0}", e);
        }
    }
}
