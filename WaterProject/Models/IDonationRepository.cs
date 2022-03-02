using System;
using System.Linq;

namespace WaterProject.Models
{
    public interface IDonationRepository
    {
        IQueryable<Donation> Donations { get; }

        void SaveDonation(Donation donation);
    }
}
