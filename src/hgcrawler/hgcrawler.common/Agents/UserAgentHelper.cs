using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hgcrawler.common.Agents
{
    public class UserAgentHelper
    {
        Random _ra;
        public List<string> PCUserAgentList { get; set; } = new List<string>();
        public List<string> MobileUserAgentList { get; set; } = new List<string>();


        public UserAgentHelper()
        {
            Init();
        }
        public string GetRandomUserAgent(UserAgentTypeEnum userAgentType=UserAgentTypeEnum.PCUserAgent)
        {
            if(userAgentType==UserAgentTypeEnum.PCUserAgent)
            {
                var count = PCUserAgentList.Count;
                return PCUserAgentList[_ra.Next(0, count - 1)];
            }
            else
            {
                var count = MobileUserAgentList.Count;
                return MobileUserAgentList[_ra.Next(0, count - 1)];
            }
        }


        private void Init()
        {
            if (_ra == null)
                _ra = new Random();

            var pcUserAgentFilename = Path.Combine("Agents", "pcuseragents.txt");
            var mobileUserAgentFilename = Path.Combine("Agents", "mobileuseragents.txt");
            
            if (File.Exists(pcUserAgentFilename))
            {
                var lines = File.ReadAllLines(pcUserAgentFilename);
                PCUserAgentList.AddRange(lines);
                Serilog.Log.Warning("pc user agent load success, count={0}", PCUserAgentList.Count);
            }
            else
            {
                Serilog.Log.Warning("pc user agent file not find,{0}", pcUserAgentFilename);
            }

            if (File.Exists(mobileUserAgentFilename))
            {
                var lines = File.ReadAllLines(pcUserAgentFilename);
                MobileUserAgentList.AddRange(lines);
                Serilog.Log.Warning("mobile user agent load success, count={0}", PCUserAgentList.Count);
            }
            else
            {
                Serilog.Log.Warning("mobile user agent file not find,{0}", mobileUserAgentFilename);
            }
        }
    }

    public enum UserAgentTypeEnum
    {
        PCUserAgent=1,
        MobileUserAgent=2
    }
}
