using StudentDetailsManagement.Core.IRepositories;
using StudentDetailsManagement.Core.Modals;
using StudentDetailsManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetailsManagement.Resource.Repositories
{
    public class Repositories : IRepositories
    {
        #region Save And Update StudentDetails
        public void SaveAndEditStudentDetails(StudentDetailsModal studentDetailProperties)
        {
            try
            {
                if (studentDetailProperties != null)
                {
                    if (studentDetailProperties.StudentId == 0)  
                    {
                        // insert Function
                        using (var entites = new StudentDetailsContext())
                        {
                            StudentDetails dBStudenDetails = new StudentDetails();
                            //insert the datas in our porperties to database properties
                            dBStudenDetails.FisrtName = studentDetailProperties.FisrtName;
                            dBStudenDetails.LastName = studentDetailProperties.LastName;
                            dBStudenDetails.DateOfBirth = studentDetailProperties.DateOfBirth;
                            dBStudenDetails.Age = studentDetailProperties.StudentAge;
                            dBStudenDetails.FavoriteSubject = studentDetailProperties.FavoriteSubject;
                            dBStudenDetails.InterestedCourse = studentDetailProperties.InterestedCourse;
                            dBStudenDetails.MathsMark = studentDetailProperties.MathsMark;
                            dBStudenDetails.ChemistryMark = studentDetailProperties.ChemistryMark;
                            dBStudenDetails.ComputerScienceMark = studentDetailProperties.ComputerScienceMark;
                            dBStudenDetails.CreatedTimeStamp = DateTime.Now;
                            dBStudenDetails.UpdatedTimeStamp = DateTime.Now;
                            dBStudenDetails.IsDeleted = false;
                            entites.StudentDetails.Add(dBStudenDetails); //Add the properties to database
                            entites.SaveChanges();
                        }
                    }
                    else
                    {
                        // Update Function
                        using (var entites = new StudentDetailsContext())
                        {
                            var dbStudentdetails = entites.StudentDetails.Where(x => x.StudentId == studentDetailProperties.StudentId && x.IsDeleted == false).SingleOrDefault();
                            // StudentDetails dBStudenDetails = new StudentDetails();
                            //Update the datas in our porperties to database properties
                            dbStudentdetails.FisrtName = studentDetailProperties.FisrtName;
                            dbStudentdetails.LastName = studentDetailProperties.LastName;
                            dbStudentdetails.DateOfBirth = studentDetailProperties.DateOfBirth;
                            dbStudentdetails.Age = studentDetailProperties.StudentAge;
                            dbStudentdetails.FavoriteSubject = studentDetailProperties.FavoriteSubject;
                            dbStudentdetails.InterestedCourse = studentDetailProperties.InterestedCourse;
                            dbStudentdetails.MathsMark = studentDetailProperties.MathsMark;
                            dbStudentdetails.ChemistryMark = studentDetailProperties.ChemistryMark;
                            dbStudentdetails.ComputerScienceMark = studentDetailProperties.ComputerScienceMark;
                            dbStudentdetails.UpdatedTimeStamp = DateTime.Now;
                            dbStudentdetails.IsDeleted = false;
                            entites.SaveChanges(); // Update are Modify Datas in Database
                        }
                    }
                }
               
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion


        #region List Students Details
        public List<StudentDetailsModal> listStudents()
        {
            List<StudentDetailsModal> StudentlistDetails = new List<StudentDetailsModal>();   // Create List
            try
            {
                using (var entites = new StudentDetailsContext())
                {
                   // var dbStudentDetails = entites.StudentDetails.Where(x => x.IsDeleted == false).OrderByDescending(x => x.StudentId).ToList(); //Check condition in datatbase table
                    //var dbStudentDetails= from S in entites.StudentDetails
                    //                      where S.IsDeleted == false
                    //                      select(S.StudentId,S.FisrtName,S.LastName,S.FavoriteSubject,S.MathsMark,S.ChemistryMark,S.ComputerScienceMark)
                    var query = from student in entites.StudentDetails
                                where student.IsDeleted == false
                                select student;
                    var dbStudentDetails = query.ToList();

                    if (dbStudentDetails != null)
                    {
                        foreach (var item in dbStudentDetails)
                        {
                            StudentDetailsModal StudentDetailsPropteries = new StudentDetailsModal();
                            StudentDetailsPropteries.StudentId = item.StudentId;
                            StudentDetailsPropteries.FisrtName = item.FisrtName;
                            StudentDetailsPropteries.LastName = item.LastName;
                            StudentDetailsPropteries.DateOfBirth = Convert.ToDateTime(item.DateOfBirth);
                            StudentDetailsPropteries.StudentAge = item.Age;
                            StudentDetailsPropteries.FavoriteSubject = item.FavoriteSubject;
                            StudentDetailsPropteries.InterestedCourse = item.InterestedCourse;
                            StudentDetailsPropteries.MathsMark = item.MathsMark;
                            StudentDetailsPropteries.ChemistryMark = item.ChemistryMark;
                            StudentDetailsPropteries.ComputerScienceMark = item.ComputerScienceMark;
                            StudentDetailsPropteries.Average = (StudentDetailsPropteries.MathsMark + StudentDetailsPropteries.ChemistryMark + StudentDetailsPropteries.ComputerScienceMark) / 3;
                            StudentlistDetails.Add(StudentDetailsPropteries); /// Add Properties Values to List
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return StudentlistDetails;
        }
        #endregion


        #region MyRegion  Reterive Student Details
        public StudentDetailsModal StudentDetailsReterive(int StudentId)
        {
            StudentDetailsModal StudentProperties = new StudentDetailsModal();
            try
            {

                using (var entites = new StudentDetailsContext())
                {
                    var dbStudentDetails = entites.StudentDetails.Where(x => x.StudentId == StudentId && x.IsDeleted == false).SingleOrDefault();
                    if (dbStudentDetails != null)
                    {
                        StudentProperties.StudentId = dbStudentDetails.StudentId;
                        StudentProperties.FisrtName = dbStudentDetails.FisrtName;
                        StudentProperties.LastName = dbStudentDetails.LastName;
                        StudentProperties.DateOfBirth = Convert.ToDateTime(dbStudentDetails.DateOfBirth);
                        StudentProperties.StudentAge = dbStudentDetails.Age;
                        StudentProperties.FavoriteSubject = dbStudentDetails.FavoriteSubject;
                        StudentProperties.InterestedCourse = dbStudentDetails.InterestedCourse;
                        StudentProperties.MathsMark = dbStudentDetails.MathsMark;
                        StudentProperties.ChemistryMark = dbStudentDetails.ChemistryMark;
                        StudentProperties.ComputerScienceMark = dbStudentDetails.ComputerScienceMark;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return StudentProperties;
        }
        #endregion


        #region Student Details Delete
        public void StudentDetailsDelete(int StudentId)
        {
            try
            {
                using (var entites = new StudentDetailsContext())
                {
                    var dbStudentDetails = entites.StudentDetails.Where(x => x.StudentId == StudentId).SingleOrDefault();
                    if (dbStudentDetails != null)
                    {
                        dbStudentDetails.IsDeleted = true;
                        dbStudentDetails.UpdatedTimeStamp = DateTime.Now;
                        entites.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
