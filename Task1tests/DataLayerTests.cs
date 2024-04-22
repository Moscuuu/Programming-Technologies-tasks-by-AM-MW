
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data;

namespace Task1tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        #region Users
        [TestMethod()]
        public void AddUserTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            Users W = new Users("Bartek", "Jurczewski", "100");
            data.AddUser(W);
            if (!W.Equals(context.user[context.user.Count() - 1])) Assert.Fail();
        }

        [TestMethod()]
        public void GetUserTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            Users W = new Users("Jan", "Kowalski", "1");
            if (!W.Equals(data.GetUser(W.Id))) Assert.Fail();
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            IEnumerable<Users> xconstant = data.GetAllUsers();
            List<Users> newa = xconstant.ToList<Users>();

            List<Users> test = new List<Users>();
            test.Add(new Users("Jan", "Kowalski", "1"));
            test.Add(new Users("Adam", "Maly", "2"));
            test.Add(new Users("Tomasz", "Sredni", "3"));
            test.Add(new Users("Mikolaj", "Duzy", "4"));
            test.Add(new Users("Piotr", "Nowak", "5"));
            test.Add(new Users("Anna", "Wisniewska", "6"));

            for (int i = 0; i < 6; i++)
            {
                if (!test[i].Equals(newa[i])) Assert.Fail();
            }
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.AddUser(new Users("Martyna", "Skiba", "1"));
            data.DeleteUser("1");
            bool flaga = false;
            if (context.user.Count == 0) flaga = true;
            if (!flaga) Assert.Fail();
        }

        #endregion
        #region Catalog
        [TestMethod()]
        public void AddCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            //data.FillStatic(); //counter is not initialized

            Catalog K = new Catalog("TestBook", "TestAutor", "6");
            data.AddCatalog(K);
            if (!K.Equals(data.GetCatalog(0))) Assert.Fail();
        }
       
        [TestMethod()]
        public void GetCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();


            Catalog K = new Catalog("Harry Potter", "J.K. Rowling", "0");
            if (!K.Equals(data.GetCatalog(0))) Assert.Fail();
        }

        [TestMethod()]
        public void GetAllCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();


            IEnumerable<Catalog> xconstant = data.GetAllCatalogs();
            Dictionary<int, Catalog> newa = xconstant.ToDictionary(x => Int32.Parse(x.Number), x => x);

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
        public void DeleteCatalogTest()
        {

            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.AddCatalog(new Catalog("Harry", "Potter", "1"));
            data.DeleteCatalog(0);
            if (context.catalogs.Count == 0)
            {
                return;
            }
            else Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCatalogTest1()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.AddCatalog(new Catalog("beka", "beka", "1"));
            data.AddStateDescription(new StateDescription(data.GetCatalog(0), DateTime.Today, 1, 10));
            try
            {
                data.DeleteCatalog(0);
            }
            catch
            {
                return;
            }
            Assert.Fail();


        }
        #endregion
        #region Events

        [TestMethod()]
        public void AddEventTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            Users W = new Users("Bartek", "Jurczewski", "100");
            Catalog K = new Catalog("TestBook", "TestAutor", "200");
            DateTime date1 = DateTime.Now;
            StateDescription O = new StateDescription(K, date1, 10, 30.00);
            Event Z = new Event(W, O, date1);
            data.AddEvent(Z);
            if (!Z.Equals(context.events[context.events.Count() - 1])) Assert.Fail();
        }

        [TestMethod()]
        public void GetEventTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            Users W = new Users("Jan", "Kowalski", "1");
            Catalog K = new Catalog("Harry Potter", "J.K. Rowling", "0");
            DateTime date1 = DateTime.Today;
            StateDescription O = new StateDescription(K, date1, 3, 10.99);
            Event Z = new Event(W, O, date1);

            if (!Z.Equals(data.GetEvent(0))) Assert.Fail();
        }

        [TestMethod()]
        public void GetAllEventsTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            IEnumerable<Event> xconstant = data.GetAllEvents();
            ObservableCollection<Event> newa = new ObservableCollection<Event>(xconstant);

            ObservableCollection<Event> test = new ObservableCollection<Event>();
            Catalog K1 = new Catalog("Harry Potter", "J.K. Rowling", "0");
            Catalog K2 = new Catalog("Pan Tadeusz", "Adam Mickiewicz", "1");
            Catalog K3 = new Catalog("Lalka", "Boleslaw Prus", "2");
            Catalog K4 = new Catalog("Dziady", "Adam Mickiewicz", "3");
            Catalog K5 = new Catalog("Wiedzmin", "Andrzej Sapkowski", "4");
            Catalog K6 = new Catalog("Duma i Uprzedzenie", "Jane Austin", "5");

            DateTime date1 = DateTime.Today;

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

        [TestMethod()]
        public void DeleteEventTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            Event z = new Event(new Users("A", "B", "1"), new StateDescription(new Catalog("C", "D", "1"), DateTime.Today, 2, 10), DateTime.Today);
            data.AddEvent(z);
            data.DeleteEvent(z);
            if (context.events.Count == 0)
            {
                return;
            }
            else Assert.Fail();

        }


        #endregion
        #region StateDescrition 

        [TestMethod()]
        public void AddStateDescritionTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            Catalog K = new Catalog("TestBook", "TestAutor", "200");
            DateTime date1 = DateTime.Now;
            StateDescription O = new StateDescription(K, date1, 10, 30.00);
            data.AddStateDescription(O);
            if (!O.Equals(context.states[context.states.Count() - 1])) Assert.Fail();
        }

        [TestMethod()]
        public void GetStateDescritionTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            Catalog K = new Catalog("Harry Potter", "J.K. Rowling", "0");
            DateTime date1 = DateTime.Today;
            StateDescription O = new StateDescription(K, date1, 10, 30.00);

            if (!O.Equals(data.GetStateDescription(0))) Assert.Fail();
        }

        [TestMethod()]
        public void GetAllStateDescritionsTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.FillStatic();

            IEnumerable<StateDescription> xconstants = data.GetAllStateDescriptions();
            List<StateDescription> newa = xconstants.ToList<StateDescription>();

            List<StateDescription> test = new List<StateDescription>();

            Catalog K1 = new Catalog("Harry Potter", "J.K. Rowling", "0");
            Catalog K2 = new Catalog("Pan Tadeusz", "Adam Mickiewicz", "1");
            Catalog K3 = new Catalog("Lalka", "Boleslaw Prus", "2");
            Catalog K4 = new Catalog("Dziady", "Adam Mickiewicz", "3");
            Catalog K5 = new Catalog("Wiedzmin", "Andrzej Sapkowski", "4");
            Catalog K6 = new Catalog("Duma i Uprzedzenie", "Jane Austin", "5");

            DateTime date1 = DateTime.Today;

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
        public void DeleteStateDescritionTest()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            data.AddStateDescription(new StateDescription(new Catalog("A", "B", "0"), DateTime.Today, 1, 2));
            data.DeleteStateDescription(0);
            if (context.states.Count == 0)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteStateDescritionTest1()
        {
            DataContext context = new DataContext();
            ConstantDataFilling constants = new ConstantDataFilling();
            DataRepository data = new DataRepository(context, constants);
            StateDescription statedesc = new StateDescription(new Catalog("A", "B", "0"), DateTime.Today, 1, 2);
            Users wykaz = new Users("C", "D", "1");
            data.AddEvent(new Event(wykaz, statedesc, DateTime.Today));
            data.AddStateDescription(statedesc);
            try
            {
                data.DeleteStateDescription(0);
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }
        #endregion
    }
}