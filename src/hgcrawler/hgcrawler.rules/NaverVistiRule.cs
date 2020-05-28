using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.rules
{
    /// <summary>
    /// naver访问规则
    /// </summary>
    public class NaverVistiRule
    {
        Random _ra;

        public NaverVistiRule()
        {
            if(_ra==null)
                _ra = new Random();
        }

        
        public string SearchKeys { get; set; }
        public int WaitSecsMinInSearch { get; set; }
        public int WaitSecsMaxInSearch { get; set; }
        public int WaitSecsInSearch
        {
            get
            {
                return _ra.Next(WaitSecsMinInSearch, WaitSecsMaxInSearch);
            }
        }


        public string ProductKeys { get; set; }
        public int WaitSecsMinInProduct { get; set; }
        public int WaitSecsMaxInProduct { get; set; }
        public int WaitSecsInProduct
        {
            get
            {
                return _ra.Next(WaitSecsMinInProduct, WaitSecsMaxInProduct);
            }
        }


        public string PriceKeys { get; set; }
        public int WaitSecsMinInPrice { get; set; }
        public int WaitSecsMaxInPrice { get; set; }
        public int WaitSecsInPrice
        {
            get
            {
                return _ra.Next(WaitSecsMinInPrice, WaitSecsMaxInPrice);
            }
        }

        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
    }
}
