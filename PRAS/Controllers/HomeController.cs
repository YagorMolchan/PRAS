using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRAS.Interfaces;
using PRAS.Models;
using PRAS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRAS.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewRepository _newRepo;

        public HomeController(INewRepository newRepo)
        {
            _newRepo = newRepo;
        }

        public IActionResult Index()
        {
            int pageSize = 6;
            var count = _newRepo.News.Count();
            var news = _newRepo.GetNews(pageSize);            
            return View(news);
        }

        public async Task<IActionResult> GetAllNews(int page = 1)
        {
            int pageSize = 6;
            var count = _newRepo.News.Count();
            var news = _newRepo.GetNews(page, pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            NewListViewModel model = new NewListViewModel
            {
                PageViewModel = pageViewModel,
                News = news
            };

            return View(model);
        }

        public IActionResult GetNew(int id)
        {
            var n = _newRepo.GetNew(id);
            ViewBag.ReturnUrl = Request.Headers["Referrer"].ToString();
            return View(n);
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(7) }
            );

            return LocalRedirect(returnUrl);
        }

        
    }
}
