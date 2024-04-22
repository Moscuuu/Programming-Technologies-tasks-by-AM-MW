using LibraryManagement.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1tests
{
    [TestClass]
    public class FillingFileTest
    {
        [TestMethod()]
        public void FillingFileUsersTest()
        {
            DataContext context_file = new DataContext();
            FileFilling file = new FileFilling();
            DataRepository data_file = new DataRepository (context_file, file);
            data_file.FillStatic();

            List<Users> copy = new List<Users>();
            copy.Add(new Users("Jan", "Kowalski", "1"));
            copy.Add(new Users("Adam", "Maly", "2"));
            copy.Add(new Users("Tomasz", "Sredni", "3"));
            copy.Add(new Users("Mikolaj", "Duzy", "4"));
            copy.Add(new Users("Piotr", "Nowak", "5"));
            copy.Add(new Users("Anna", "Wisniewska", "6"));

            for (int i = 0; i < copy.Count; i++)
            {
                if (!copy[i].Equals(data_file.GetUser((i + 1).ToString())))
                    Assert.Fail();
            }

        }

        [TestMethod()]
        public void FillingFileCatalogTest()
        {
            DataContext context_file = new DataContext();
            FileFilling file = new FileFilling();
            DataRepository data_file = new DataRepository(context_file, file);
            data_file.FillStatic();

            IEnumerable<Catalog> exconst = data_file.GetAllCatalogs();
            Dictionary<int, Catalog> newa = exconst.ToDictionary(x => Int32.Parse(x.Number), x => x);

            Dictionary<int, Catalog> test = new Dictionary<int, Catalog>();
            test.Add(0, new Catalog("Harry Potter", "J.K. Rowling", "0"));
            test.Add(1, new Catalog("Pan Tadeusz", "Adam Mickiewicz", "1"));
            test.Add(2, new Catalog("Lalka", "Boleslaw Prus", "2"));
            test.Add(3, new Catalog("Dziady", "Adam Mickiewicz", "3"));
            test.Add(4, new Catalog("Wiedzmin", "Andrzej Sapkowski", "4"));
            test.Add(5, new Catalog("Duma i Uprzedzenie", "Jane Austin", "5"));

            for (int i = 0; i < 6; i++)
            {
                if (!test[i].Equals(newa[i])) Assert.Fail();
            }
        }

        [TestMethod()]
        public void FillingFileStateDescriptionTest()
        {
            DataContext context_file = new DataContext();
            FileFilling file = new FileFilling();
            DataRepository data_file = new DataRepository(context_file, file);
            data_file.FillStatic();

            IEnumerable<StateDescription> exconst = data_file.GetAllStateDescriptions();
            List<StateDescription> newa = exconst.ToList<StateDescription>();
            List<StateDescription> test = new List<StateDescription>();

            Catalog K1 = new Catalog("Harry Potter", "J.K. Rowling", "0");
            Catalog K2 = new Catalog("Pan Tadeusz", "Adam Mickiewicz", "1");
            Catalog K3 = new Catalog("Lalka", "Boleslaw Prus", "2");
            Catalog K4 = new Catalog("Dziady", "Adam Mickiewicz", "3");
            Catalog K5 = new Catalog("Wiedzmin", "Andrzej Sapkowski", "4");
            Catalog K6 = new Catalog("Duma i Uprzedzenie", "Jane Austin", "5");

            DateTime date1 = DateTime.Parse("22.04.2024");

            test.Add(new StateDescription(K1, date1, 10, 11));
            test.Add(new StateDescription(K2, date1, 20, 22));
            test.Add(new StateDescription(K3, date1, 30, 33));
            test.Add(new StateDescription(K4, date1, 40, 44));
            test.Add(new StateDescription(K5, date1, 50, 55));
            test.Add(new StateDescription(K6, date1, 60, 66));

            for (int i = 0; i < 6; i++)
            {
                if (!test[i].Equals(newa[i])) Assert.Fail();
            }
        }

        [TestMethod()]
        public void FillingFileEventTest()
        {
            DataContext context_file = new DataContext();
            FileFilling file = new FileFilling();
            DataRepository data_file = new DataRepository(context_file, file);
            data_file.FillStatic();

            IEnumerable<Event> exconst = data_file.GetAllEvents();
            ObservableCollection<Event> newa = new ObservableCollection<Event>(exconst);

            ObservableCollection<Event> test = new ObservableCollection<Event>();
            Catalog K1 = new Catalog("Harry Potter", "J.K. Rowling", "0");
            Catalog K2 = new Catalog("Pan Tadeusz", "Adam Mickiewicz", "1");
            Catalog K3 = new Catalog("Lalka", "Boleslaw Prus", "2");
            Catalog K4 = new Catalog("Dziady", "Adam Mickiewicz", "3");
            Catalog K5 = new Catalog("Wiedzmin", "Andrzej Sapkowski", "4");
            Catalog K6 = new Catalog("Duma i Uprzedzenie", "Jane Austin", "5");

            DateTime date1 = DateTime.Parse("22.04.2024");

            StateDescription O1 = new StateDescription(K1, date1, 10, 11);
            StateDescription O2 = new StateDescription(K2, date1, 20, 22);
            StateDescription O3 = new StateDescription(K3, date1, 30, 33);
            StateDescription O4 = new StateDescription(K4, date1, 40, 44);
            StateDescription O5 = new StateDescription(K5, date1, 50, 55);
            StateDescription O6 = new StateDescription(K6, date1, 60, 66);

            Users W1 = new Users("Jan", "Kowalski", "1");
            Users W2 = new Users("Adam", "Maly", "2");
            Users W3 = new Users("Tomasz", "Sredni", "3");
            Users W4 = new Users("Mikolaj", "Duzy", "4");
            Users W5 = new Users("Piotr", "Nowak", "5");
            Users W6 = new Users("Anna", "Wisniewska", "6");


            test.Add(new Event(W1, O1, date1));
            test.Add(new Event(W2, O2, date1));
            test.Add(new Event(W3, O3, date1));
            test.Add(new Event(W4, O4, date1));
            test.Add(new Event(W5, O5, date1));
            test.Add(new Event(W6, O6, date1));

            for (int i = 0; i < 6; i++)
            {
                if (!test[i].Equals(newa[i])) Assert.Fail();
            }
        }
    }
}
