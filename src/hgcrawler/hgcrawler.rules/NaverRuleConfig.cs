using hgcrawler.common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.rules
{
    /// <summary>
    /// 访问配置规则+浏览器配置规则
    /// </summary>
    public class NaverRuleConfig
    {
        /// <summary>
        /// 最大翻页
        /// </summary>
        public int PageMax { get; set; }







        /// <summary>
        /// 访问类型，PC/Mobile
        /// </summary>
        public VisitRuleTypeEnum VisitRuleType { get; set; }

        /// <summary>
        /// ua更换模式
        /// </summary>
        public ChangeModeEnum UserAgentChangeMode { get; set; }
    }
}
