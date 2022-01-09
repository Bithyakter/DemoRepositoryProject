using Demo.BLR.Models;
using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLR.Mapper
{
    public class StudentMapper
    {
        #region DtoToModel
        public Student DtoToModel(StudentDTO dto)
        {
            Student std = new Student();
            std.ID = dto.ID;
            std.FirstName = dto.FirstName;
            std.LastName = dto.LastName;
            std.Email = dto.Email;
            std.EnrollmentNo = dto.EnrollmentNo;
            std.AddedDate = dto.AddedDate; 
            std.ModifiedDate = dto.ModifiedDate;           
            std.IPAddress = dto.IPAddress;

            return std;
        }
        #endregion

        #region ModelToDto
        public StudentDTO ModelToDto(Student model)
        {
            StudentDTO dto = new StudentDTO();
            dto.ID = model.ID;
            dto.FirstName = model.FirstName;
            dto.LastName = model.LastName;
            dto.Name = model.FirstName + " " + model.LastName;
            dto.Email = model.Email;  
            dto.EnrollmentNo= model.EnrollmentNo;
            dto.ModifiedDate = model.ModifiedDate;
            dto.AddedDate = model.AddedDate;
            dto.IPAddress = model.IPAddress;

            return dto; 
        }
        #endregion
    }
}
