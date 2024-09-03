using System.Web;
using System.Web.Mvc;

namespace YouTubeOrMp3Download
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
