using hgcrawler.common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.common.Options
{
    public class UrlEndPointsOption
    {
        static string PCUrl { get; set; } = "https://www.naver.com/";
        static string MobileUrl { get; set; } = "https://m.naver.com/";


        public static string EngineUrl(VisitRuleTypeEnum visitRuleType)
        {
            switch (visitRuleType)
            {
                case VisitRuleTypeEnum.PC:return PCUrl;
                case VisitRuleTypeEnum.Mobile:return MobileUrl;
                default:return PCUrl;
            }
        }
    }
}
