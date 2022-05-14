using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            StudentData studentData = new StudentData();
            if (String.IsNullOrWhiteSpace(user.FakNum) || user == null)
            {
                Console.WriteLine("Не съществува такъв студент или няма попълнен факултетен номер");
                return null;
            }

            IEnumerable <Student> students = studentData.getStudents();

            foreach (Student student in students)
            {
                if (student.facultyNumber.Equals(user.FakNum))
                {
                    return student;
                }
            }

            Console.WriteLine("Несъществуващ студент");
            return null;

        }
    }
}
