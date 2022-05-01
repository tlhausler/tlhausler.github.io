using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MVCTitle45MCA.Models;
using MVCTitle45MCA.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Title45MCADB;
using Title45MCADB.Entities;

namespace MVCTitle45MCA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Title45ViewModel titleVM = new Title45ViewModel();
            using (var ctx = new MCADbContext())
            {
                //set SelectedTitleList to a list of distinct Title values.
                 titleVM.SelectListTitle = ctx.Title45Items.Select(x => x.Title).Distinct().Select(t => new SelectListItem { 
                    Text = t, 
                    Value = t
                 }).ToList();
            }
            return View(titleVM);
        }

        [HttpPost]
        public IActionResult Chapter(Title45ViewModel titleVM)
        {

            List<Title45> laws = null;
            List<Title45> titles = new List<Title45>();

            // Clean data of extra whitespace and store in local variable
            string trimmedSelectedTitle = titleVM.SelectedTitle.Trim();
            using (var ctx = new MCADbContext())
            {
                // fill local list with all database items
                laws = ctx.Title45Items.ToList();
            }

            for(int x = 0; x < laws.Count; x++)
            {
                string trimmedTitle = laws[x].Title.Trim();
                // find the title45 object in the laws list that matches our SelectedTitle and add to titles list.
                if (trimmedTitle == trimmedSelectedTitle)
                {
                    titles.Add(laws[x]);
                }
            }

            // Go through the titles list and select distinct chapter names and return them to the SelectListChapter for titleVM
            titleVM.SelectListChapter = titles.Select(x => x.Chapter).Distinct().Select(x => new SelectListItem
            {
                Text = x,
                Value = x
            }).ToList();
      
            return View(titleVM);
        }

        [HttpPost]
        public IActionResult Part(Title45ViewModel titleVM)
        {
            List<Title45> laws = null;
            List<Title45> titles = new List<Title45>();

            // Clean data of extra whitespace and store in local variable
            string trimmedSelectedChap = titleVM.SelectedChapter.Trim();
            using (var ctx = new MCADbContext())
            {
                laws = ctx.Title45Items.ToList();
            }

            for (int x = 0; x < laws.Count; x++)
            {
                string trimmedChap = laws[x].Chapter.Trim();

                // find the title45 object in the laws list that matches our SelectedChapter and add to titles list.
                if (trimmedChap == trimmedSelectedChap)
                {
                    titles.Add(laws[x]);
                }
            }

            // Go through the titles list and select distinct part names and return them to the SelectListPart for titleVM
            titleVM.SelectListPart = titles.Select(x => x.Part).Distinct().Select(x => new SelectListItem
            {
                Text = x,
                Value = x
            }).ToList();

            return View(titleVM);
        }

        [HttpPost]
        public IActionResult Section(Title45ViewModel titleVM)
        {
            List<Title45> laws = null;
            List<Title45> titles = new List<Title45>();

            // Clean data of extra whitespace and store in local variable
            string trimmedSelectedPart = titleVM.SelectedPart.Trim();
            using (var ctx = new MCADbContext())
            {
                laws = ctx.Title45Items.ToList();
            }

            for (int x = 0; x < laws.Count; x++)
            {
                string trimmedPart = laws[x].Part.Trim();

                // fill local list with all database items
                if (trimmedPart == trimmedSelectedPart)
                {
                    titles.Add(laws[x]);
                }
            }

            // Go through the titles list and select distinct section names and return them to the SelectListSection for titleVM
            titleVM.SelectListSection = titles.Select(x => x.Section).Distinct().Select(x => new SelectListItem
            {
                Text = x,
                Value = x
            }).ToList();

            return View(titleVM);
        }

        [HttpPost]
        public IActionResult Content(Title45ViewModel titleVM)
        {
            List<Title45> laws = null;
            List<Title45> titles = new List<Title45>();

            // Clean data of extra whitespace and store in local variable
            string trimmedSelectedSection = titleVM.SelectedSection.Trim();
            using (var ctx = new MCADbContext())
            {
                laws = ctx.Title45Items.ToList();
            }

            for (int x = 0; x < laws.Count; x++)
            {
                string trimmedSection = laws[x].Section.Trim();

                // Since content is unique, SelectedContent is set to the content relating to the selected section
                if (trimmedSection == trimmedSelectedSection)
                {
                    titleVM.SelectedContent = laws[x].Content;
                }
            }

            return View(titleVM);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
