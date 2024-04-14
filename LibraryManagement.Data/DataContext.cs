using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DataContext
    {
        public List<Users> user = new List<Users>();
        public Dictionary<int, Catalog> catalogs = new Dictionary<int, Catalog>();
        public ObservableCollection<Event> events = new ObservableCollection<Event>();
        public List<State> states = new List<State>();  
    }
}