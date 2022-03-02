using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WaterProject.Models
{
    public class EFDonationRepository : IDonationRepository
    {
        private ProjectContext context;

        public EFDonationRepository(ProjectContext temp)
        {
            context = temp;
        }

        public IQueryable<Donation> Donations => context.Donations
            .Include(x => x.Lines)
            .ThenInclude(x => x.Project);

        public void SaveDonation(Donation donation)
        {
            context.AttachRange(donation.Lines.Select(x => x.Project));

            if (donation.DonationId == 0)
            {
                context.Donations.Add(donation);
            }

            context.SaveChanges();
        }
    }
}
