using Demo.BLR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLR.Interface
{
    public interface IStudentBLR
    {
        void SaveStudent(StudentDTO stdVM);
        IEnumerable<StudentDTO> GetAllStudents();
        StudentDTO GetStudent(int id);
        void DeleteStudent(int Id);
    }
}
