using hgcrawler.common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.util
{
    public class WebapiClient:IWebapiClient
    {
        /// <summary>
        /// login api
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        public LoginDTO Login(string uname, string pwd)
        {
            try
            {
                //TODO:login logic
                if (uname == "admin" && pwd == "admin")
                    return new LoginDTO();
                else
                    return default;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "login error");
                return default;
            }
        }        
    }
}
