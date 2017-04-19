namespace CampusSystem.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CampusSystem.Models;

    public class Helper
    {
        public static void InitDb()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                ctx.Database.Initialize(true);
            }
        }
        public static List<Room> GetRooms()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Rooms.ToList();
            }
        }

        public static List<Room> GetRoomsByCampus(Campus campus)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Rooms.Where(r => r.CampusId == campus.Id).ToList();
            }
        }

        public static decimal GetTotalTakingsForCampus(int id)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Campuses.FirstOrDefault(c => c.Id == id).Students.Sum(s => s.Obligations);
            }
        }

        public static IEnumerable<University> GetUniversities()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Universities.ToList();
            }
        }

        public static List<Town> GetTowns()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Towns.ToList();
            }
        }

        public static void AddRoomToCampus(Room room)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                ctx.Rooms.Add(room);
                ctx.SaveChanges();
            }
        }

        public static Room getRoomInCampusByNumber(string roomNumber, int campusId)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Campuses.FirstOrDefault(c => c.Id == campusId).Rooms.FirstOrDefault(r => r.Number == roomNumber);
            }

        }

        public static List<Guest> GetAllUnsignedGuestsForCampus(int id)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Campuses.FirstOrDefault(c => c.Id == id).Guests.Where(g => g.DateLeft == null).ToList();
            }
        }

        public static void AddStudent(Student student)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }

        public static University GetUniversityByName(string uniName)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Universities.FirstOrDefault(u => u.Name == uniName);
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

        public static string GetTotalObligationsByRoom(string v)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Rooms.FirstOrDefault(r => r.Number == v).Students.Sum(s => s.Obligations).ToString();
            }
        }

        public static List<Student> GetStudents()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Students.ToList();
            }
        }

        public static List<Guest> GetAllUnsignedGuests()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Guests.Where(g => g.DateLeft == null).ToList();
            }
        }

        public static int GetStudentsInRoom(string selectedItem)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Students.Where(s => s.Room.Number == selectedItem).Count();
            }

        }

        public static Campus GetCampus(string campusNumber)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Campuses.FirstOrDefault(c => c.Number.Equals(campusNumber));
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

        public static Student GetStudentByRoomAndName(string roomNumber, string student)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Students.FirstOrDefault();
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
