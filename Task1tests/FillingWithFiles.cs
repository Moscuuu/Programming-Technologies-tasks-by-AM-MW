using LibraryManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1tests
{
    public class FileFilling : DataFill
    {
        public FileFilling() { }

        public void Fill(DataContext context)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Users.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                context.user.Add(new Users(words[0], words[1], words[2]));

            }
            lines = System.IO.File.ReadAllLines(@"Catalog.txt");
            int i = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                context.catalogs.Add(i, new Catalog(words[0], words[1], words[2]));
                i++;
            }

            lines = System.IO.File.ReadAllLines(@"StateDescription.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');

                foreach (Catalog k in context.catalogs.Values)
                {
                    if (k.Number == words[0]) context.states.Add(new StateDescription(k, DateTime.Parse(words[1]), Int32.Parse(words[2]), Double.Parse(words[3])));
                }
            }


            lines = System.IO.File.ReadAllLines(@"Event.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                Catalog K = new Catalog("", "", "");
                Users W = new Users("", "", "");
                StateDescription O = new StateDescription(K, DateTime.Now, 0, 0.0);
                foreach (Users ww in context.user)
                {
                    if (ww.Id == words[0])
                    {
                        W = ww;
                        break;
                    }
                }

                foreach (Catalog kk in context.catalogs.Values)
                {
                    if (kk.Number == words[1])
                    {
                        K = kk;
                        break;
                    }
                }

                foreach (StateDescription oo in context.states)
                {
                    if (oo.K1.Number == K.Number && oo.Shopping_date == DateTime.Parse(words[2]))
                    {
                        O = oo;
                        break;
                    }
                }
                context.events.Add(new Event(W, O, DateTime.Parse(words[3])));
            }
        }
    }
}
