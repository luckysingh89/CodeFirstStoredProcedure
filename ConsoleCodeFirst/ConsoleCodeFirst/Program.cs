using ConsoleCodeFirst.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            HelperMethods hpMT = new HelperMethods();
            var entity = hpMT.GetPeopleEntity("Test");
            if (entity != null && entity.Count > 0)
            {
                foreach (var item in entity)
                {
                    Console.WriteLine(item.Id + " --- " + item.Name);
                }
            }
            Console.ReadLine();
        }
    }
}
