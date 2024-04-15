using LibraryManagement.Data;
using System;

namespace LibraryManagement.Data
{
    public class ConstantDataFilling : DataFill
    {
        public ConstantDataFilling() { }

        public void Fill(DataContext context)
        {
            
            context.user.Add(new Users("Jan", "Kowalski", "1"));
            context.user.Add(new Users("Adam", "Maly", "2"));
            context.user.Add(new Users("Tomasz", "Sredni", "3"));
            context.user.Add(new Users("Mikolaj", "Duzy", "4"));
            context.user.Add(new Users("Piotr", "Nowak", "5"));
            context.user.Add(new Users("Anna", "Wisniewska", "6"));

            
            context.catalogs.Add(0, new Catalog("Harry Potter", "J.K. Rowling", "0"));
            context.catalogs.Add(1, new Catalog("Pan Tadeusz", "Adam Mickiewicz", "1"));
            context.catalogs.Add(2, new Catalog("Lalka", "Boleslaw Prus", "2"));
            context.catalogs.Add(3, new Catalog("Dziady", "Adam Mickiewicz", "3"));
            context.catalogs.Add(4, new Catalog("Wiedzmin", "Andrzej Sapkowski", "4"));
            context.catalogs.Add(5, new Catalog("Duma i Uprzedzenie", "Jane Austin", "5"));

            
            for (int i = 0; i < 6; i++)
            {
                context.states.Add(new StateDescription(context.catalogs[i], DateTime.Today, i + 3, 10.99 * (i + 1)));
            }

            
            for (int i = 0; i < 6; i++)
            {
                context.events.Add(new Event(context.user[i], context.states[i], DateTime.Today));
            }

            
            context.events.Add(new Event(context.user[0], context.states[5], DateTime.Today));
            context.events.Add(new Event(context.user[1], context.states[5], DateTime.Today));
            context.events.Add(new Event(context.user[2], context.states[5], DateTime.Today));
            context.events.Add(new Event(context.user[3], context.states[5], DateTime.Today));

        }

    }
}