using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private string username;
        private string password;
        private string message;
        public static UserRoles CurrentUserRole { get; private set; }
        public static string CurrentUserName { get; private set; }

        public delegate void ActionOnError(string errorMsg);
        private ActionOnError actionOnError;

        public LoginValidation(string userName, string pass, ActionOnError actionOnError)
        {
            this.username = userName;
            this.password = pass;
            this.actionOnError = actionOnError;
        }

        public bool ValidateUserInput( ref User user)
        {
            

            Boolean emptyUserName;
            emptyUserName=username.Equals(string.Empty);
            if (emptyUserName)
            {
                message = "Не е посочено потребителско име";
                actionOnError(message);
                return false;

            }
            Boolean emptyPassword;
            emptyPassword = password.Equals(string.Empty);
            if (emptyPassword)
            {
                message = "Не е посочена парола";
                actionOnError(message);
                return false;
            }
            if (this.username.Length < 5 )
            {
                message = "Потребителското име не е над 5 символа.";
                actionOnError(message);
                return false;
            }
            if (this.password.Length < 5)
            {
                message = "Паролата не е над 5 символа.";
                actionOnError(message);
                return false;
            }

            user = UserData.IsUserPassCorrect(this.username, this.password);

            if (user == null)
            {
                this.message = "Не съществува потребител със зададените потребителско име и парола";
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            CurrentUserName = this.username;
            CurrentUserRole = (UserRoles)user.Role;
            Logger.LogActivity("Успешен Login");

            return true;
            
            
        }

    }
}
