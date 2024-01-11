using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUTODEALERN.DAL;
using AUTODEALERN.Interface;
using AUTODEALERN.Model;

namespace AD
{
    internal class Program
    {
        static void Main(string[] args)
        {
      

            var _context = new ADContext();
            var menu = new MainMenu(_context);
            menu.Run();
            Console.ReadKey();

        }
    }
}
