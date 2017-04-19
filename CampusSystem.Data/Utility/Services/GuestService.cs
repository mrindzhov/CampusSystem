namespace CampusSystem.Data.Utility.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CampusSystem.Models;

    public class GuestService
    {
        public static List<Guest> GetAllUnsignedGuestsForCampus(int id)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Guests.Include("StudentVisited").Include("Town").Include("StudentVisited.Room").Where(g => g.CampusId == id && g.DateLeft == null).ToList();
            }
        }


        public static List<Guest> GetAllUnsignedGuests()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Guests.Where(g => g.DateLeft == null).ToList();
            }
        }

        public static void ReleaseGuest(Guest guest)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                ctx.Guests.FirstOrDefault(g => g.Id == guest.Id).DateLeft = DateTime.Now;
                ctx.SaveChanges();
            }
        }

        public static void AddGuest(Guest guest)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                ctx.Guests.Add(guest);
                ctx.SaveChanges();
            }
        }
    }
}
