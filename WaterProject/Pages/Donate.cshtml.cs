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

        public DonateModel(IWaterProjectRepository repository, Basket b)
        {
            Repository = repository;
            Basket = b;
        }

        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int projectId, string returnUrl)
        {
            ProjectModel project = Repository.Projects
                .FirstOrDefault(project => project.ProjectID == projectId);

            Basket.AddItem(project, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int projectId, string returnUrl)
        {
            Basket.RemoveItem(Basket.Items.First(x => x.Project.ProjectID == projectId).Project);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
