using EFCore.Models;
using System.Collections.Generic;
using System.Linq;
namespace EFCore.Services
{
    public class StudentServices : IStudentServices
    {
        StudentContext studentContext;
        public StudentServices(StudentContext _studentContext)
        {
            studentContext = _studentContext;
        }
        public int Delete(int id)
        {
            int result = 0;
            if (studentContext != null)
            {
                var exitsingStudent = studentContext.Students.Find(id);
                if (exitsingStudent != null)
                {
                    studentContext.Students.Remove(exitsingStudent);
                    result = studentContext.SaveChanges();
                }
                return result;
            }
            return result;
        }
        public List<Student> GetStudent()
        {
            if (studentContext != null)
            {
                return studentContext.Students.ToList();
            }
            return null;
        }
        public int Add(Student student)
        {
            if (studentContext != null)
            {
                studentContext.Students.Add(student);
                studentContext.SaveChanges();
                return student.Id;
            }
            return 0;
        }
        public void Edit(Student student)
        {
            if (studentContext != null)
            {
                studentContext.Students.Update(student);
                studentContext.SaveChanges();
            }
        }
    }
}
