using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WaterProject.Models;

namespace WaterProject.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IWaterProjectRepository Repo { get; set; }

        public TypesViewComponent (IWaterProjectRepository repo)
        {
            Repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["projectType"];

            var types = Repo.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
