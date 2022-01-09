using Demo.DAL.Interface;
using Demo.Data.Context;
using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public class StudentRepository : IStudent
    {
        private ApplicationDBContext _db;
        private DbSet<Student> studentEntity;

        public StudentRepository(ApplicationDBContext db)
        {
            this._db = db;
            studentEntity = _db.Set<Student>();
        }

        public void SaveStudent(Student student)
        {
            _db.Entry(student).State = EntityState.Added;
            //_db.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _db.Entry(student).State = EntityState.Modified;
            //_db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
           Student student = GetStudent(id);
           studentEntity.Remove(student);
           //_db.SaveChanges();
        }

        public Student GetStudent(int id)
        {
            return studentEntity.AsNoTracking().SingleOrDefault(s => s.ID == id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return studentEntity.AsNoTracking().AsEnumerable();
        }

        public void UpdateContext()     //Use for Unit of Work
        {
            _db.SaveChanges();
        }

    }
}
