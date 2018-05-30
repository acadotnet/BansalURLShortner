using BansalURLShortner.Models;
using BansalURLShortner.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BansalURLShortner.Controllers
{
    //[RoutePrefix("ShortenURL")]
    public class HomeController : Controller
    {
        protected readonly IHomeServices _homeService;

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);
        //    Debug.Print("Host:" + Request.Url.Host); // Accessible here
        //    if (Request.Url.Host == "localhost")
        //    {
        //        // Do what you want for localhost
        //        Console.WriteLine(Request.Url.Host);
        //    }
        //}

        public HomeController(IHomeServices homeService)
        {
            _homeService = homeService;
            //if (Request.Url.Host == "localhost")
            //{
            //    // Do what you want for localhost
            //    Console.WriteLine(Request.Url.Host);
            //}
        }

        public ActionResult Index()
        {
            string queryParameter;
            var URLClickObject = new URLClick();

            var requestedUrl = Request.Url.AbsoluteUri.Split('?');
            if (requestedUrl.Length > 1)
            {
                queryParameter = requestedUrl[1];
                URLClickObject = _homeService.GetURL(queryParameter);
                _homeService.UpdateURLClicks(URLClickObject);
                return Redirect(URLClickObject.URL.OriginalURL);
            }

            return View();
        }

        //[Route("Edit", Name ="CreateShortURL")]
        public ActionResult Edit()
        {
            var longUrl = new URL();
            
            return View(longUrl);
        }
        
        [HttpPost]
        //[Route("Edit", Name ="CreateShortURLPost")]
        public ActionResult Edit(URL model)
        {
            model.ShortURL = _homeService.CreateURL(model.OriginalURL.ToLower());

            var savedUrl = new URL();

            savedUrl = _homeService.LoadUrlToDatabase(model);

            return View(savedUrl);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}