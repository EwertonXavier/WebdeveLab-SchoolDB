using System.Web;
using System.Web.Mvc;

namespace SchoolDB_Assignment_EwertonXavier_w2022
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
