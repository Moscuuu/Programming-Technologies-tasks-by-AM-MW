using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class State : IState
    {

        public State(int stateId, int productId, bool available)
        {
            this.stateId = stateId;
            this.productId = productId;
            this.available = available;
        }

        public int productId { get; set; }
        public int stateId { get; set; }

        public bool available { get; set; }
    }
}
