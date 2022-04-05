using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRAS.Data;
using PRAS.Interfaces;
using PRAS.Models.ViewModels;
using PRAS.Models.ViewModels.New;
using PRAS.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace PRAS.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        private readonly INewRepository _newRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(INewRepository newRepo, IWebHostEnvironment webHostEnvironment)
        {
            _newRepo = newRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int page = 1)
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

        [HttpGet]
        public IActionResult CreateOrEdit(int id = 0)
        {
            NewViewModel model = null;
            if(id == 0)
            {
                model = new NewViewModel();
                model.Id = id;
                return View(model);
            }
            else
            {
                var n = _newRepo.GetNew(id);
                if (n!=null)
                {
                    model = new NewViewModel
                    {
                        Id = n.Id,
                        Name = n.Name,
                        Description = n.Description,
                        ImagePath = n.ImagePath,
                        Text = n.Text
                    };

                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(NewViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    model.ImagePath = await UploadImage(model);
                }

                if (model.Id == 0)
                {
                    New n = new New
                    {
                        Name = model.Name,
                        Date = DateTime.Now,
                        Description = model.Description,
                        ImagePath = model.ImagePath,
                        Text = model.Text
                    };

                    await _newRepo.Create(n);                   
                }
                else if(model.Id > 0)
                {
                    New n = _newRepo.GetNew(model.Id);
                    if (n != null)
                    {
                        n.Name = model.Name;
                        n.Description = model.Description;
                        n.ImagePath = model.ImagePath;
                        n.Text = model.Text;
                        await _newRepo.Edit(n);
                    }                    
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var n = _newRepo.GetNew(id);
            if (n != null)
            {
                await _newRepo.Delete(n);
            }
            return RedirectToAction("Index");
        }


        private async Task<string> UploadImage(NewViewModel model)
        {
            string uniqueFileName = null;

            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }
            }
            return uniqueFileName;
        }



    }
}
