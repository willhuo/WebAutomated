using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.common.Enums
{
    /// <summary>
    /// 切换模式枚举
    /// </summary>
    public enum ChangeModeEnum : int
    {
        /// <summary>
        /// 单个规则切换一次
        /// </summary>
        Single = 1,

        /// <summary>
        /// 一组规则切换一次
        /// </summary>
        Grouply = 2,

        /// <summary>
        /// 从不切换
        /// </summary>
        NoAction = 3
    }
}
