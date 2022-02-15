using System;
using System.Linq;

namespace WaterProject.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<ProjectModel> Projects { get; set; }
        public PageInformation PageInfo { get; set; }

    }
}
