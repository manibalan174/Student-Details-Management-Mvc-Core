using StudentDetailsManagement.Core.IRepositories;
using StudentDetailsManagement.Core.IService;
using StudentDetailsManagement.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentDetailsManagement.Services.Service
{
    public class Service: IService
    {
        #region Declaration
         readonly IRepositories _Repositorie;
        #endregion

        public Service(IRepositories iRepositorie)
        {
            _Repositorie = iRepositorie;
        }

        #region Save Student Details
        public void SaveAndEditStudentDetails(StudentDetailsModal studentDetail)
        {
            _Repositorie.SaveAndEditStudentDetails(studentDetail);
        }
        #endregion

        #region listStudents Details
        public List<StudentDetailsModal> listStudents()
        {
            return _Repositorie.listStudents();
        }
        #endregion

        #region StudentDetailsReterive
        public StudentDetailsModal StudentDetailsReterive(int StudentId)
        {
            return _Repositorie.StudentDetailsReterive(StudentId);
        }
        #endregion

        #region MyRegion
        public void StudentDetailsDelete(int StudentId)
        {
             _Repositorie.StudentDetailsDelete(StudentId);
        }
        #endregion
    }
}
