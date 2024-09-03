using BusinessLayer.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace YoutubeOrMp3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IYoutubeService _youtubeService;

        public HomeController(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Convert(string youtubeUrl)
        {
            try
            {
                var result = await _youtubeService.ConvertYoutubeToMp3(youtubeUrl);
                return Content(result, "application/json");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}