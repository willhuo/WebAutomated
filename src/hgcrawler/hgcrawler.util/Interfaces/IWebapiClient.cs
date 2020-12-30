using hgcrawler.common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.util
{
    public interface IWebapiClient
    {
        /// <summary>
        /// login api
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        LoginDTO Login(string uname, string pwd);
    }
}
