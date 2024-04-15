using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class StateDescription
    {
        private Catalog K;
        private DateTime shopping_date;
        private int quantity;
        private double price;

        public StateDescription(Catalog k, DateTime shopping_date, int quantity, double price)
        {
            K = k;
            this.shopping_date = shopping_date;
            this.quantity = quantity;
            this.price = price;
        }

        public Catalog K1 { get { return K; } set => K = value; }
        public DateTime Shopping_date { get => shopping_date; set => shopping_date = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public string All { get => this.K.All + " " + Shopping_date + " " + Quantity + " " + Price; }
        public override bool Equals(object obj)
        {
            if (obj is StateDescription)
            {
                StateDescription other = (StateDescription)obj;
                return this.K.Equals(other.K) && this.shopping_date == other.shopping_date;
            }
            return base.Equals(obj);
        }
    }
}