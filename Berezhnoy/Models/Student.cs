using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berezhnoy.Models
{
    public class Student
    {

        #region Variables

        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public string department;
        public int age;
        public int course;
        public int group;
        public string city;

        #endregion

        #region Constructors

        public Student(string firstName,
                       string lastName,
                       string university,
                       string faculty,
                       string department,
                       int age,
                       int course,
                       int group,
                       string city)
        {

            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            this.city = city;

        }

        #endregion

        #region Methods

        public override string ToString()
        {

            return $"{firstName} {lastName}, {age} years old, {city} citizen, {course} coursestudent of {university}, {department} department of {faculty} faculty";

        }

        #endregion

    }

}
