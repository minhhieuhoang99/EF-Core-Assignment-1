using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models{
    [Table("Student")]
    public class Student{
        [Key]
        public int Id{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}

        public string City{get;set;}
        public string State{get;set;}

        //public Class ClassId{get;set;}
    }
}