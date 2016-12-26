using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MvcDataBase.Code;

namespace MvcDataBase.Code
{
    public class DBHelperFactory
    {
        private DBHelper helper;
        public  DBHelper GetHelperInstance(string DBName)
        {
            //string ConStr = ConfigurationManager.ConnectionStrings[DBName].ToString();
            string ConStr = @"Data Source=DESKTOP-1LIGADL;Initial Catalog=Test;User ID=sa";
            if(helper!=null)
            {
                return helper;
            }
            else
            {
                helper = new DBHelper(ConStr);
                return helper;
            }
            
        }
    }
}