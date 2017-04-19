namespace CampusSystem.Data.Utility.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using CampusSystem.Models;

    public class StudentService
    {

        public static void AddStudent(Student student)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }

        public static List<Student> GetStudents()
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Students.Include("Room").Include("Guests").Include("Town").Include("University").Include("Campus").ToList();
            }
        }

        public static List<Student> GetStudentsByCampus(int campusId)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Students.Include("Room").Include("Guests").
                    Include("Town").Include("University")
                    .Include("Campus").Where(s => s.CampusId == campusId).ToList();
            }
        }

        public static Student GetStudentById(int studentId)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                return ctx.Students.FirstOrDefault(st => st.Id == studentId);
            }
        }

        public static void PayObligationsById(int studentId)
        {
            using (CampusSystemContext ctx = new CampusSystemContext())
            {
                var student = ctx.Students.FirstOrDefault(st => st.Id == studentId);
                student.Obligations = 0;
                ctx.Entry(student).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
