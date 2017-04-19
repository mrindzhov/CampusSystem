namespace CampusSystem.Data.Seed
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CampusSystem.Models;

    internal sealed class CampusSystemInitializer : DropCreateDatabaseAlways<CampusSystemContext>
    {

        protected override void Seed(CampusSystemContext ctx)
        {

            ctx.Universities.AddOrUpdate(u => u.Name,
                new University { Name = "SoftUni" },
                new University { Name = "Sofia University" }
                );

            ctx.SaveChanges();

            ctx.Campuses.Add(new Campus
            {
                Number = "2",
                UniversityId = 2,
                Password = "campus2"
            });
            ctx.Campuses.Add(new Campus
            {
                Number = "1",
                UniversityId = 1,
                Password = "campus1"
            });
            ctx.Campuses.Add(new Campus
            {
                Number = "3",
                UniversityId = 1,
                Password = "campus3"
            });
            ctx.SaveChanges();



            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string roomFloor = i.ToString();
                    string roomNum = j.ToString();
                    if (roomNum.Length == 1)
                    {
                        roomNum = $"0{roomNum}";
                    }
                    ctx.Rooms.Add(new Room
                    {
                        CampusId = 1,
                        Number = $"{roomFloor}{roomNum}"
                    });
                    ctx.Rooms.Add(new Room
                    {
                        CampusId = 2,
                        Number = $"{roomFloor}{roomNum}"
                    });
                    ctx.Rooms.Add(new Room
                    {
                        CampusId = 3,
                        Number = $"{roomFloor}{roomNum}"
                    });
                }
            }

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
                RoomId = 1,
                CampusId = 1
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
                RoomId = 2,
                CampusId = 2
            });

            ctx.Students.Add(new Student
            {
                FirstName = "Martin",
                MiddleName = "Martinov",
                LastName = "Martinski",
                IsActive = true,
                UniversityId = 2,

                Town = new Town
                {
                    Name = "Petrich"
                },
                Obligations = 33.42m,
                RoomId = 2,
                CampusId = 2
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
                },
                CampusId = 2
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
                StudentVisitedId = 2,
                CampusId =2
            });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}
