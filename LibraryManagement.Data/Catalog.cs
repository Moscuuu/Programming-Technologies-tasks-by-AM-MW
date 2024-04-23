
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class Catalog
    {
        private string title;
        private string author;
        private string number;

        public Catalog(string title, string author, string number)
        {
            this.title = title;
            this.author = author;
            this.number = number;
        }

        public string Tytul { get => title; set => title = value; }
        public string Number { get => number; set => number = value; }
        public string Autor { get => author; set => author = value; }
        public string All { get => number + " " + title + " " + author; }

        public override bool Equals(object obj)
        {
            Catalog other = obj as Catalog;
            return number == other.number;
        }
    }
}
