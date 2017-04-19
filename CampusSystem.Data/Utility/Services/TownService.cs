namespace CampusSystem.Data.Utility.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using CampusSystem.Models;

    public class TownService
    {

        public static List<Town> GetTowns()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Towns.ToList();
            }
        }

        public static Town GetTownByName(string townName)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                var town = ctx.Towns.FirstOrDefault(t => t.Name == townName);
                if (town == null)
                {
                    var newTown = new Town
                    {
                        Name = townName
                    };
                    ctx.Towns.Add(newTown);
                    ctx.SaveChanges();
                    return newTown;
                }
                return town;
            }
        }
    }
}
