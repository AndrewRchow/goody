namespace Goody.Web.Services
{
    public abstract class BaseService
    {
        protected string connString = System.Configuration.ConfigurationManager.ConnectionStrings["Defaultconnection"].ConnectionString;
    }
}