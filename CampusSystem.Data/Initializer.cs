namespace CampusSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using CampusSystem.Models;

    public class Initializer
    {

        private static CampusSystemContext ctx = new CampusSystemContext();
        public static void InitDb()
        {
            ctx.Database.Initialize(true);
        }
        public static List<Room> GetRooms()
        {
            return ctx.Rooms.ToList();
        }
    }
}
