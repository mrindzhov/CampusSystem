namespace CampusSystem.Data.Utility.Services
{
    using System.Linq;
    using CampusSystem.Models;

    public class CampusService
    {
        public static Campus GetCampus(string campusNumber)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Campuses.FirstOrDefault(c => c.Number.Equals(campusNumber));
            }

        }

        public static void AddCampus(Campus camp)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                for (int i = 1; i < 7; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        string roomFloor = i.ToString();
                        string roomNum = j.ToString();
                        if (roomNum.Length == 1)
                        {
                            roomNum = $"0{roomNum}";
                        }
                        camp.Rooms.Add(new Room
                        {
                            Number = $"{roomFloor}{roomNum}"
                        });
                    }
                }
                ctx.Campuses.Add(camp);
                ctx.SaveChanges();
            }
        }
    }
}
