using System.Web;
using System.Web.Mvc;

namespace Assessment_9_Winters_Coming
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
