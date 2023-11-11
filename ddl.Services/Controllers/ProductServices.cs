using ddl.Core.Entities;
using ddl.Exceptions.Exceptions;
using ddl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Services.Controllers
{
    public static class ProductServices
    {
        public static void Add(Product product)
        {
            if (NullContoller(product))
                DataBase.products.Add(product);
        }

        public static Product GetProductById(int id)
        {
            Product product = DataBase.products.Find(x => x.Id == id);
            return NullContoller(product) ? product : null; 
        }
    
        public static void UpdateProductName(Product product)
        {
            if (NullContoller(product))
            {
                Console.Write("Enter Name : ");
                GetProductById(product.Id).Name = Console.ReadLine();
            }
        }

        public static void UpdateProductPrice(Product product)
        {
            if (NullContoller(product))
            {
                Console.WriteLine("Enter Price : ");
                GetProductById(product.Id).Price = Convert.ToSingle(Console.ReadLine());
            }
        }

        public static void RemoveProduct(Product product)
        {
            if (NullContoller(product))
                DataBase.products.Remove(GetProductById(product.Id));
        }

        public static void GetAll()
        {
            DataBase.products.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        static bool NullContoller(Product product)
        {
            return product != null ? true :
            throw new InvalidUserNotFound(ExceptionMessage.InvalidUserNotFoundMessage);
        }
    }
}
