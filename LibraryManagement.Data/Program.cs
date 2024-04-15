
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    class Program
    {
        static void Main(string[] args)
        {

            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();
            DataService service = new DataService(data);


            Console.ReadKey();
        }
    }
}