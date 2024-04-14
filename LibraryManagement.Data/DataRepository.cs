using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LibraryManagement.Data;
namespace LibraryManagement.Data
{

    public class DataRepository
    {
        private DataContext context;
        

        public DataRepository(DataContext context)
        {
            this.context = context;
        }

        
    }
}