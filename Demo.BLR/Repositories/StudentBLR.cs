using Demo.BLR.Interface;
using Demo.BLR.Mapper;
using Demo.BLR.Models;
using Demo.DAL.Interface;
using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLR.Repositories
{
    public class StudentBLR : IStudentBLR
    {
        private readonly IStudent _StdRepo;
        private readonly StudentMapper _stdMapper;
        public StudentBLR(IStudent studentBLR)
        {
            this._StdRepo = studentBLR;
            this._stdMapper = new StudentMapper();

        }

        #region SaveStudent
        public void SaveStudent(StudentDTO stdVM)
        {
            Student std = _stdMapper.DtoToModel(stdVM);

            if (stdVM.ID > 0)
            {
                _StdRepo.UpdateStudent(std);
            }
            else
            {
                _StdRepo.SaveStudent(std);
            }
            _StdRepo.UpdateContext();
        }
        #endregion

        #region DeleteStudent
        public void DeleteStudent(int id)
        {
            _StdRepo.DeleteStudent(id);
            _StdRepo.UpdateContext();
        }
        #endregion

        #region GetAllStudents
        public IEnumerable<StudentDTO> GetAllStudents()
        {
            var studentList = _StdRepo.GetAllStudents();
            var StudentListOutput = studentList.Select(x =>
            {
                return _stdMapper.ModelToDto(x);
            });

            return StudentListOutput;
        }
        #endregion

        #region GetStudent
        public StudentDTO GetStudent(int id)
        {
            Student student = _StdRepo.GetStudent(id);
            StudentDTO studentOutput = _stdMapper.ModelToDto(student);
            return studentOutput;
        }
        #endregion
    }
}
