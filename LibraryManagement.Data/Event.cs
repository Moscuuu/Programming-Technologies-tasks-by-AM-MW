
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class Event
    {
        private Users W; //who
        private StateDescription O; //
        private DateTime shopping_date;

        public Event (Users w, StateDescription o, DateTime shopping_date)
        {
            W = w;
            O = o;
            Shopping_date = shopping_date;
        }

        public Users w { get => W; set => W = value; }
        public StateDescription o { get => O; set => O = value; }
        public DateTime Shopping_date { get => shopping_date; set => shopping_date = value; }
        public string All { get => W.All + " " + this.O.All + " " + shopping_date; }
        
        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                Event other = (Event)obj;
                return this.W.Equals(other.W) && this.shopping_date == other.shopping_date;
            }
            return base.Equals(obj);
        }
    }
}