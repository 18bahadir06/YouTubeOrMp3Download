using BusinessLayer.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouTubeOrMp3Download.Controllers
{
    public class HomeController : Controller
    {
        IYoutubeService _youtubeService;

        public HomeController(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Convert(string youtubeUrl)
        {
            var mp3Data = _youtubeService.Ormp3(youtubeUrl);
            return File(mp3Data, "audio/mpeg", "downloaded.mp3");
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