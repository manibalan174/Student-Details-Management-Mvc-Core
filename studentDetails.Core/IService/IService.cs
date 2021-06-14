using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDetailsManagement.Core.Modals;

namespace StudentDetailsManagement.Core.IService
{
    public interface IService
    {
        void SaveAndEditStudentDetails(StudentDetailsModal studentDetail);
        List<StudentDetailsModal> listStudents();
        StudentDetailsModal StudentDetailsReterive(int StudentId);
        void StudentDetailsDelete(int StudentId);
    }
}
  