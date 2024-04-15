
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DataService
    {
        private DataRepository data;

        public DataService(DataRepository data)
        {
            this.data = data;
        }

        #region Displaying

        public void Display(IEnumerable<Users> user)
        {
            List<Users> newa = user.ToList<Users>();

            for (int i = 0; i < user.Count(); i++)
            {
                Console.WriteLine(newa[i].All);
            }
        }

        public void Display(IEnumerable<Catalog> thing)
        {
            Dictionary<int, Catalog> newa = thing.ToDictionary(x => Int32.Parse(x.Number), x => x);

            for (int i = 0; i < thing.Count(); i++)
            {
                Console.WriteLine(newa[i].All);
            }
        }

        public void Display(IEnumerable<StateDescription> thing)
        {
            List<StateDescription> newa = thing.ToList<StateDescription>();

            for (int i = 0; i < thing.Count(); i++)
            {
                Console.WriteLine(newa[i].All);
            }
        }

        public void Display(IEnumerable<Event> thing)
        {
            ObservableCollection<Event> newa = new ObservableCollection<Event>(thing);

            for (int i = 0; i < thing.Count(); i++)
            {
                Console.WriteLine(newa[i].All);
            }
        }

        #endregion

        #region Searching
        public List<Users> SearchUsers(string phrase)
        {
            List<Users> all = this.data.GetAllUsers().ToList<Users>();
            List<Users> newa = new List<Users>();
            String tmp = "";
            for (int i = 0; i < this.data.GetAllUsers().Count(); i++)
            {
                tmp = all[i].All;
                if (tmp.Contains(phrase)) newa.Add(all[i]);
            }
            return newa;
        }

        public Dictionary<int, Catalog> SearchCatalog(string phrase)
        {
            Dictionary<int, Catalog> all = this.data.GetAllCatalogs().ToDictionary(x => Int32.Parse(x.Number), x => x);
            Dictionary<int, Catalog> newa = new Dictionary<int, Catalog>();
            String tmp = "";
            int index = 0;
            for (int i = 0; i < this.data.GetAllUsers().Count(); i++)
            {
                tmp = all[i].All;
                if (tmp.Contains(phrase))
                {
                    newa.Add(index, all[i]);
                    index++;
                }
            }
            return newa;
        }

        public List<StateDescription> SearchStateDescriptions(double min, double maks)
        {
            List<StateDescription> all = this.data.GetAllStateDescriptions().ToList();
            List<StateDescription> newa = new List<StateDescription>();

            for (int i = 0; i < this.data.GetAllUsers().Count(); i++)
            {
                if (all[i].Price > min && all[i].Price < maks) newa.Add(all[i]);
            }
            return newa;
        }

        public ObservableCollection<Event> SearchEvents(DateTime start, DateTime end)
        {
            ObservableCollection<Event> all = new ObservableCollection<Event>(this.data.GetAllEvents());
            ObservableCollection<Event> nowa = new ObservableCollection<Event>();

            for (int i = 0; i < this.data.GetAllUsers().Count(); i++)
            {
                if (all[i].Shopping_date > start && all[i].Shopping_date < end) nowa.Add(all[i]);
            }
            return nowa;
        }
        #endregion

        #region linked
        public IEnumerable<Event> EventsForUser(Users W)
        {
            ObservableCollection<Event> all = new ObservableCollection<Event>(this.data.GetAllEvents());
            ObservableCollection<Event> nowa = new ObservableCollection<Event>();

            foreach (var zz in all)
            {
                if (zz.w.Equals(W)) nowa.Add(zz);
            }

            return (IEnumerable<Event>)nowa;
        }

        public IEnumerable<Event> EventsForStateDescrpiton(StateDescription O)
        {
            ObservableCollection<Event> all = new ObservableCollection<Event>(this.data.GetAllEvents());
            ObservableCollection<Event> newa = new ObservableCollection<Event>();

            foreach (var zz in all)
            {
                if (zz.o.Equals(O)) newa.Add(zz);
            }

            return (IEnumerable<Event>)newa;
        }
        public IEnumerable<StateDescription> StateDescriptionForCatalog(Catalog K)
        {
            List<StateDescription> all = this.data.GetAllStateDescriptions().ToList<StateDescription>();
            List<StateDescription> newa = new List<StateDescription>();

            foreach (var oo in all)
            {
                if (oo.K1.Equals(K)) newa.Add(oo);
            }

            return (IEnumerable<StateDescription>)newa;
        }
        #endregion

        #region Adding
        public void AddUser(Users W) => this.data.AddUser(W);
        public void AddCatalog(Catalog K) => this.data.AddCatalog(K);
        public void AddEvent(Event Z) => this.data.AddEvent(Z);
        public void AddStateDescription(StateDescription O) => this.data.AddStateDescription(O);
        #endregion

        #region Creating
        public void AddUser(string firstName, string lastName, string id) => this.data.AddUser(new Users(firstName, lastName, id));
        public void AddCatalog(string tytul, string autor, string numer) => this.data.AddCatalog(new Catalog(tytul, autor, numer));
        public void AddEvent(Users w, StateDescription o, DateTime data_zakupu) => this.data.AddEvent(new Event(w, o, data_zakupu));
        public void AddStateDescription(Catalog k, DateTime data_zakupu, int ilosc, double cena) => this.data.AddStateDescription(new StateDescription(k, data_zakupu, ilosc, cena));
        #endregion
    }
}