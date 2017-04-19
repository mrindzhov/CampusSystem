namespace CampusSystem.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CampusSystem.Models;

    public class Helper
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

        public static string GetTotalObligationsByRoom(string v)
        {
            return ctx.Rooms.FirstOrDefault(r => r.Number == v).Students.Sum(s => s.Obligations).ToString();
        }

        public static List<Student> GetStudents()
        {
            return ctx.Students.ToList();
        }

        public static List<Guest> GetAllUnsignedGuests()
        {
            return ctx.Guests.Where(g => g.DateLeft == null).ToList();
        }

        public static int GetStudentsInRoom(string selectedItem)
        {
            return ctx.Students.Where(s => s.Room.Number == selectedItem).Count();
        }

        public static Campus GetCampus(string campusNumber)
        {
            return ctx.Campuses.FirstOrDefault(c => c.Number.Equals(campusNumber));
        }

        public static void ReleaseGuest(Guest guest)
        {
            ctx.Guests.FirstOrDefault(g => g.Id == guest.Id).DateLeft = DateTime.Now;
            ctx.SaveChanges();
        }

        public static Student GetStudentByRoomAndName(string roomNumber, string student)
        {
            return ctx.Students.FirstOrDefault();
        }

        public static void AddGuest(Guest guest)
        {
            ctx.Guests.Add(guest);
            ctx.SaveChanges();
        }

        public static Town GetTownByName(string townName)
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
