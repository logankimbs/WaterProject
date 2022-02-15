using System;
using System.Linq;

namespace WaterProject.Models
{
    public class EFWaterProjectRepository : IWaterProjectRepository
    {
        private ProjectContext Context { get; set; }

        public EFWaterProjectRepository (ProjectContext context)
        {
            Context = context;
        }

        public IQueryable<ProjectModel> Projects => Context.Projects;
    }
}
