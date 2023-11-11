using ddl.Core.Entities;
using ddl.Core.Enums;
using ddl.Exceptions;
using ddl.Exceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Services.Controllers
{
    public static class ControllerServices
    {
        public static void LoginMenu()
        {
            Console.WriteLine("1.Sing In");
            Console.WriteLine("2.Sing Up");
            Console.Write("Enter User Answer : ");
        }
        
        public static void UserSignIn()
        {
            Console.Write("Enter UserName or Email : ");
            string login = Console.ReadLine();

            Console.Write("Enter User PassWord : ");
            string password = Console.ReadLine();


        }

        public static void UserMenuMembers()
        {
            Console.WriteLine("1.Pizzalara Bax.");
            Console.WriteLine("2.Sifaris ver");
            Console.Write("Enter User Answer : ");
        }

        public static void UserMenuAdmins()
        {
            Console.WriteLine("1.Pizzalara Bax.");
            Console.WriteLine("2.Sifaris ver");
            Console.WriteLine("3.Pizzalar");
            Console.WriteLine("4.Userler");
            Console.Write("Enter User Answer : ");
        }

        public static void CrudMenu()
        {
            Console.WriteLine("1.Hamisina bax");
            Console.WriteLine("2.Elave et");
            Console.WriteLine("3.Düzelis et");
            Console.WriteLine("4.Sil");
        }

        public static void CreateUser()
        {
            Console.Write("Enter User Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter User Sur Name : ");
            string surName = Console.ReadLine();

            Console.Write("Enter UserName or Email : ");
            string login = Console.ReadLine();

            Console.Write("Enter User PassWord : ");
            string password = Console.ReadLine();

            UserServices.Add(new User(name, surName, login, password, UserType()));
        }

        public static void CreateProduct()
        {
            Console.Write("Enter Pizza Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Pizza Price : ");
            float price = Convert.ToSingle(Console.ReadLine());

            ProductServices.Add(new Product(name, price));
        }

        public static UserTypeEnum UserType()
        {
            UserTypeMenu();
            int userAnswer = Convert.ToInt32(Console.ReadLine());
            
            if (userAnswer > 3)
                throw new InvalidUserTypeEnumException(ExceptionMessage.InvalidUserTypeEnumMessage);

            return (UserTypeEnum)userAnswer;
        }
        
        static void UserTypeMenu()
        {
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.Member");
            Console.Write("Enter User Answer : ");
        }

    }
}
