namespace CampusSystem.Client
{
    using System.Linq;
    using CampusSystem.Client.Methods;
    using CampusSystem.Data;
    using CampusSystem.Models;

    class Startup
    {
        static void Main(string[] args)
        {
            //TODO: CREATE TRIGGER FOR ADDING ROOM IN CAMPUS

            CampusSystemContext ctx = new CampusSystemContext();
            ctx.Database.Initialize(true);

            InitialFill.FillIndividualData(ctx);

            #region Add already existing room in campus
            //ctx.Campuses.Add(new Campus
            //{
            //    Number = "3",
            //    UniversityId = 2
            //});
            //ctx.SaveChanges();

            //ctx.Rooms.Add(new Room
            //{
            //    Number = "101",
            //    CampusId = 1
            //});
            //ctx.SaveChanges(); 
            #endregion

            #region Get Obligations For Campus
            //var name = "Sofia University";
            //var obligationsByCampus = ctx.Campuses.Where(c => c.University.Name == name)
            //    .Sum(c => c.Rooms.Sum(r => r.Students.Sum(s => s.Obligations)));
            //    System.Console.WriteLine(obligationsByCampus);
            #endregion

            #region Get Obligations For Room
            //var number = "101";
            //var obligationsByRoom = ctx.Rooms.Where(r => r.Number == number)
            //    .Sum(r => r.Students.Sum(s => s.Obligations));
            //System.Console.WriteLine(obligationsByRoom); 
            #endregion

            #region Get all students obligations
            //ctx.Students.ToList().Select(s => new
            //{
            //    s.FullName,
            //    s.Obligations
            //})
            //    .ToList()
            //    .ForEach(s => System.Console.WriteLine($"{s.FullName} obligations: {s.Obligations} leva."));
            #endregion

            #region Get All Unsigned Guests
            //ctx.Guests.Where(g => g.DateLeft == null).ToList().Select(g => new
            //{
            //    g.FullName,
            //    studentName=g.StudentVisited.FullName
            //}).ToList().ForEach(g =>
            //{
            //    System.Console.WriteLine($"{g.FullName} has probably not unsigned and {g.studentName} should be charged extra!");
            //});
            #endregion

            #region Get All Active Students By Room
            //var roomId = 1;
            //ctx.Students.Where(s => s.RoomId == roomId && s.IsActive == true).ToList().ForEach(s =>
            //{
            //    System.Console.WriteLine($"{s.FullName} is living in room {s.Room.Number} and has {s.Obligations} debt!");
            //});
            #endregion

            #region Students By Room In Campus
            //var roomNumber = "101";
            //var campusName = "Softuni";
            //ctx.Campuses.FirstOrDefault(c => c.University.Name == campusName)
            //    .Rooms
            //    .FirstOrDefault(r => r.Number == roomNumber)
            //    .Students.Count(); 
            #endregion


        }
    }
}
