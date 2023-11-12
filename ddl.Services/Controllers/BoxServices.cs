using ddl.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Services.Controllers
{
    public static class BoxServices
    {
        public static void AddBox(Box box)
        {
            DataBase.boxes.Add(box);
        }
        public static bool NullControl(Box box)
        {
            if(box!=null)
            {
                return true;
            }
            return false;
        }
        public static Box GetById(int id)
        {
            return DataBase.boxes.FirstOrDefault(x => x.Id == id);
        }
        public static void RemoveBox(int id)
        {
            DataBase.boxes.Remove(GetById(id));
        }
    }
}
