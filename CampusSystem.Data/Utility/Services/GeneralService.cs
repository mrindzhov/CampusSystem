namespace CampusSystem.Data.Utility.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using CampusSystem.Models;

    public class GeneralService
    {
        public static void InitDb()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                ctx.Database.Initialize(true);
            }
        }

        public static decimal GetTotalTakingsForCampus(int campusId)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Campuses.FirstOrDefault(c => c.Id == campusId).Students.Sum(s => s.Obligations);
            }
        }

        public static IEnumerable<University> GetUniversities()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Universities.ToList();
            }
        }

        public static University GetUniversityByName(string uniName)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Universities.FirstOrDefault(u => u.Name == uniName);
            }
        }
    }
}