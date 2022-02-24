using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterProject.Infrastructure;
using WaterProject.Models;

namespace WaterProject.Pages
{
    public class DonateModel : PageModel
    {
        private IWaterProjectRepository Repository { get; set; }

        public DonateModel(IWaterProjectRepository repository)
        {
            Repository = repository;
        }

        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int projectId, string returnUrl)
        {
            ProjectModel project = Repository.Projects
                .FirstOrDefault(project => project.ProjectID == projectId);

            Basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            Basket.AddItem(project, 1);
            HttpContext.Session.SetJson("basket", Basket);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
