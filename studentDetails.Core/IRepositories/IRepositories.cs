using StudentDetailsManagement.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetailsManagement.Core.IRepositories
{
    public interface IRepositories
    {
        void SaveAndEditStudentDetails(StudentDetailsModal studentDetail);
        List<StudentDetailsModal> listStudents();
        StudentDetailsModal StudentDetailsReterive(int StudentId);
        void StudentDetailsDelete(int StudentId);
    }
}
