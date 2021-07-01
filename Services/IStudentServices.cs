using System;
using System.Collections.Generic;
using EFCore.Models;
namespace EFCore.Services{
    public interface IStudentServices{
        List<Student> GetStudent();
        int Add(Student student);
        void Edit(Student student);
        int Delete(int id);
    }
}