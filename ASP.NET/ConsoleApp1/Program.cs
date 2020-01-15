using ClassLibraryDelta.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (
            ProductContext db = new ProductContext())
            {
                Console.WriteLine("Context Close !!");
            }
           
            
        }

    }
}
