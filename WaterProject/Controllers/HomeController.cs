using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterProjectRepository Repository;

        public HomeController(IWaterProjectRepository repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;
            var pageData = new ProjectsViewModel
            {
                Projects = Repository.Projects
                            .OrderBy(p => p.ProjectName)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize),
                PageInfo = new PageInformation
                {
                    NumOfProjects = Repository.Projects.Count(),
                    ProjectsPerPage = pageSize,
                    CurrrentPage = pageNum
                }
            };

            return View(pageData);
        }
    }
}
