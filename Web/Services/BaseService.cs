using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goody.Web.Services
{
    public abstract class BaseService
    {
        protected string connString = System.Configuration.ConfigurationManager.ConnectionStrings["Defaultconnection"].ConnectionString;
    }
}