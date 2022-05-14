using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
     public class StudentData
    {
        private List<Student> TestStudents;

        public StudentData()
        {
            TestStudents = new List<Student>();
            TestStudents.Add(student());
        }

        public List<Student> getStudents()
        {
            return this.TestStudents;
        }

        private void setStudents(List<Student> students)
        {
            this.TestStudents = students;
        }

        private Student student()
        {
            Student student = new Student("Виктория", "Димитрова", "Караджова", 
                "ФКСТ", "КСИ", "бакалавър", "заверил",
                "121219108", 3, 9, 31);

            return student;
        }

    }
}
