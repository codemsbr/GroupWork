using ddl.Core.Entities;
using ddl.Core.Enums;
using ddl.Exceptions;
using ddl.Exceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ddl.Services.Controllers
{
    public static class UserServices
    {
        public static void Add(User value)
        {
            if ( NullController(value) && UserLoginController(value.Login) && UserPasswordController(value.Password))
                DataBase.users.Add(value);
        }

        public static bool SignIn(User user)
        {
            if (!DataBase.users.Any(x => x.Login == user.Login && x.Password == user.Password))
                throw new InvalidUserNotFound(ExceptionMessage.InvalidUserNotFoundMessage);
            return true;
            ///todo: SignIn Sign Tamala return $"Xos Geldiniz {Name} {SurName}"; => yazisini ekrana veer
            /// end;

        }

        public static void GetAll()
        {
            DataBase.users.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public static User GetUserById(int id)
        {
            User user = DataBase.users.Find(x => x.Id == id);
            if(NullController(user))
                return user;
            return null;
        }

        public static bool UserAdminController(User user)
        {
            if (NullController(user))
              return GetUserById(user.Id).UserType == UserTypeEnum.Admin;
            return false;
        }

        public static void CorrectUserType(User value)
        {
            if (NullController(value))
                GetUserById(value.Id).UserType = ControllerServices.UserType();
        }

        public static void RemoveUser(User value)
        {
            if (NullController(value))
                DataBase.users.Remove(GetUserById(value.Id));
        }

        static bool UserLoginController(string login)
        {
            if (login.Contains('@'))
                login = login.Split("@").First();
            
            bool loginController = login.Length > 3 && login.Length < 16;        
            return loginController ? loginController : throw new InvalidUserLoginException(ExceptionMessage.InvalidUserLoginMessage);
        }

        static bool UserPasswordController(string password)
        {
            Regex regex = new Regex("@\"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,16}$\"");
            bool passwordController = regex.IsMatch(password);
            
            return passwordController ? passwordController : throw new InvalidUserPaswordException(ExceptionMessage.InvalidUserPasswordMessage);
        }
       
        static bool NullController(User value)
        {
            return value != null ? true :
            throw new InvalidUserNotFound(ExceptionMessage.InvalidUserNotFoundMessage);
        }
    }
}
