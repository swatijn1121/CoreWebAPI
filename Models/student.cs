using System;

namespace CoreWebApi.Models
{
    public class Student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
    }
}