using System;
using System.Linq;

namespace WaterProject.Models
{
    public interface IWaterProjectRepository
    {
        IQueryable<ProjectModel> Projects { get; }

        public void SaveProject(ProjectModel p);
        public void CreateProject(ProjectModel p);
        public void DeleteProject(ProjectModel p);
    }
}
