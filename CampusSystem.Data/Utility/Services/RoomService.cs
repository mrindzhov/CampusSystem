using System;
namespace CampusSystem.Data.Utility.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using CampusSystem.Models;

    public class RoomService
    {
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
                return ctx.Rooms.Include("Students").Where(r => r.CampusId == campus.Id).OrderBy(r => r.Number).ToList();
            }
        }
        public static void AddRoomToCampus(Room room)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                if (!ctx.Rooms.Any(r => r.Number == room.Number && r.CampusId == room.CampusId))
                {
                    ctx.Rooms.Add(room);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Cannot add already existing room to campus.");
                }
            }
        }

        public static string GetTotalObligationsByRoom(string roomNumber)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Rooms.FirstOrDefault(r => r.Number == roomNumber).Students.Sum(s => s.Obligations).ToString();
            }
        }


        public static Room getRoomInCampusByNumber(string roomNumber, int campusId)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Campuses.FirstOrDefault(c => c.Id == campusId).Rooms.FirstOrDefault(r => r.Number == roomNumber);
            }
        }
        public static int GetStudentsInRoom(string roomNumber)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Students.Where(s => s.Room.Number == roomNumber).Count();
            }
        }
        //TO DO !!!
        public static Student GetStudentByRoomAndName(string roomNumber, string student)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Students.FirstOrDefault(s => s.Room.Number == roomNumber && s.FullName == student);
            }
        }

    }
}
