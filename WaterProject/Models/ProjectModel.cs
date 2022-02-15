using System;
using System.ComponentModel.DataAnnotations;

namespace WaterProject.Models
{
    public class ProjectModel
    {
        [Key]
        [Required]
        public long ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string ProjectRegionalProgram { get; set; }
        public int ProjectImpact { get; set; }
        public string ProjectPhase { get; set; }
        public string ProjectFunctionalityStatus { get; set; }
    }
}
