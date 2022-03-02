using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        public virtual void AddItem(ProjectModel proj, int quantity)
        {
            BasketLineItem line = Items
                .Where(project => project.Project.ProjectID == proj.ProjectID)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Project = proj,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(ProjectModel Proj)
        {
            Items.RemoveAll(x => x.Project.ProjectID == Proj.ProjectID);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(project => project.Quantity * 25);
            return sum;
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public ProjectModel Project { get; set; }
        public int Quantity { get; set; }
    }
}
