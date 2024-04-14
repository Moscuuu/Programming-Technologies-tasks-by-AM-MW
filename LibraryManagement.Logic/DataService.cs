using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data;
namespace LibraryManagement.Logic
{
    public class DataService
    {
        private DataRepository _repository;

        public DataService(DataRepository repository)
        {
            _repository = repository;
        }

        
    }
}