using hgcrawler.common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.rules
{
    public class NaverRuleConfig
    {
        public VisitRuleTypeEnum VisitRuleType { get; set; }
        public ChangeModeEnum UserAgentChangeMode { get; set; }
    }
}
