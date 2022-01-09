using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Interface
{
    public interface IStudent
    {
        void SaveStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        void UpdateContext();   //For Unit-Of-Work
    }
}
