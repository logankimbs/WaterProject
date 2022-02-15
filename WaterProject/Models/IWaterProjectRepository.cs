using System;
using System.Linq;

namespace WaterProject.Models
{
    public interface IWaterProjectRepository
    {
        IQueryable<ProjectModel> Projects { get; }
    }
}
