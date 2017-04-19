using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusSystem.Models;

namespace CampusSystem.Data.Utility.Services
{
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
                return ctx.Rooms.Include("Students").Where(r => r.CampusId == campus.Id).ToList();
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
