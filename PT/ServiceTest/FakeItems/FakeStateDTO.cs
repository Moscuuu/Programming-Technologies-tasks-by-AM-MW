using Service.API;

namespace ServiceTest.FakeItems
{
    internal class FakeStateDTO : IStateDTO
    {
        public int ProductId { get; set; }
        public int StateId { get; set; }

        public bool Available { get; set; }

        public FakeStateDTO(int id, int productId, bool available)
        {
            this.StateId = id;
            this.ProductId = productId;
            this.Available = available;
        }
    }
}
