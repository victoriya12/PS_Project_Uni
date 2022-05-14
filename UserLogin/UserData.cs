using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> users;
        public static List<User> testUsers 
        { 
            get 
            {
                ResetTestUserData();
                return users;
            }
            set { }
        }
       
        static private void ResetTestUserData()
        {
            if (users == null)
            {
                users = new List<User>();

                User firstStudent=new User();
                firstStudent.Username = "STUDENT1";
                firstStudent.Password = "1234s";
                firstStudent.FakNum = "12121910";
                firstStudent.Role = 4;
                firstStudent.Created = DateTime.Now;
                firstStudent.ActiveTime = DateTime.MaxValue;

                users.Add(firstStudent);

                User secondStudent = new User();
                secondStudent.Username = "STUDENT2";
                secondStudent.Password = "1234s";
                secondStudent.FakNum = "12121910";
                secondStudent.Role = 4;
                secondStudent.Created = DateTime.Now;
                secondStudent.ActiveTime = DateTime.MaxValue;

                users.Add(secondStudent);

                User firstAdmin = new User();
                secondStudent.Username = "ADMIN";
                secondStudent.Password = "1234a";
                secondStudent.FakNum = "121219";
                secondStudent.Role = 1;
                secondStudent.Created = DateTime.Now;
                secondStudent.ActiveTime = DateTime.MaxValue;

                users.Add(firstAdmin);

            }
            
        }
         public static User IsUserPassCorrect(string username, string password)
        {
            User user = (from users in testUsers
                         where users.Username.Equals(username)
                         && users.Password.Equals(password)
                         select users).First();
            return user;
        }

        public static void SetUserActiveTo(string username, DateTime date)
        {
            foreach(User user in testUsers)
            {
                if (user.Username.Equals(username))
                {
                    user.ActiveTime = date;
                }
            }
            Logger.LogActivity("Промяна на активност на " + username);

        }
        public static void AssignUserRole(string username, UserRoles role)
        {
            foreach (User user in testUsers)
            {
                if (user.Username.Equals(username))
                {
                    user.Role = Convert.ToInt32(role);
                }

            }
            Logger.LogActivity("Промяна на роля на " + username);
        }



    }
}
