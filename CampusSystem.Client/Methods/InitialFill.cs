namespace CampusSystem.Client.Methods
{
    using System.Linq;
    using CampusSystem.Data;
    using CampusSystem.Models;

    public static class InitialFill
    {
        public static void FillIndividualData(CampusSystemContext ctx)
        {
            ctx.Universities.Add(new University
            {
                Name = "SoftUni"
            });
            ctx.Universities.Add(new University
            {
                Name = "Sofia University"
            });
            ctx.SaveChanges();

            ctx.Campuses.Add(new Campus
            {
                Number = "1",
                UniversityId = 2
            }); ctx.SaveChanges();

            ctx.Rooms.Add(new Room
            {
                CampusId = 1,
                Number = "101",
            });
            ctx.SaveChanges();

            ctx.Students.Add(new Student
            {
                FirstName = "Pesho",
                MiddleName = "Peshov",
                LastName = "Peshovic",
                IsActive = true,
                Town = new Town
                {
                    Name = "Varna"
                },
                UniversityId = 1,
                Obligations = 44.55m,
                RoomId = 1
            });

            ctx.Students.Add(new Student
            {
                FirstName = "Ivan",
                MiddleName = "Ivanov",
                LastName = "Ivanovic",
                IsActive = true,
                UniversityId = 2,

                Town = new Town
                {
                    Name = "Montana"
                },
                Obligations = 0,
                RoomId = 1
            });
            ctx.SaveChanges();
            ctx.Students.FirstOrDefault(s => s.FirstName == "Ivan").Guests.Add(new Guest
            {
                FirstName = "Gosten",
                MiddleName = "Gostenov",
                LastName = "Gostenski",
                Town = new Town
                {
                    Name = "Stara Zagora"
                }
            });
            ctx.SaveChanges();
            ctx.Guests.Add(new Guest
            {
                FirstName = "Random",
                MiddleName = "Randomev",
                LastName = "Randomski",
                Town = new Town
                {
                    Name = "Nessebar"
                },
                StudentVisitedId = 2
            });
            ctx.SaveChanges();
        }
    }
}
