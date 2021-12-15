using CRUDLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace CRUDWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        CollegeEntities OE = new CollegeEntities();

        // api/Students/
        public IQueryable<Student> Get()
        {
            return OE.Students;
        }

        // api/Students/1
        public Student Get(int id)
        {
            Student student = OE.Students.Find(id);
            return student;
        }

        // ../api/department
        public void Put(int id, Student student)
        {
            OE.Entry(student).State = System.Data.Entity.EntityState.Modified;
            OE.SaveChanges();
        }

        // ../api/department
        public void Delete(int id)
        {
            Student student = OE.Students.Find(id);
            OE.Students.Remove(student);
            OE.SaveChanges();
        }

        // ..api/Students/
        public void Post(Student student)
        {
            OE.Students.Add(student);
            OE.SaveChanges();
        }
    }
}