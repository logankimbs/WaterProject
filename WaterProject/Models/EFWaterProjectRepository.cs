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

        public void SaveProject(ProjectModel p)
        {
            Context.SaveChanges();
        }

        public void CreateProject(ProjectModel p)
        {
            Context.Add(p);
            Context.SaveChanges();
        }

        public void DeleteProject(ProjectModel p)
        {
            Context.Remove(p);
            Context.SaveChanges();
        }
    }
}
