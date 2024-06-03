using Service.API;

namespace ServiceTest.FakeItems
{
    internal class FakeEventDTO : IEventDTO
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public int UserId { get; set; }
        public DateTime EventDate { get; }
        public string Type { get; set; }

        public FakeEventDTO(int id, int stateId, int userId, string type)
        {
            this.Id = id;
            this.StateId = stateId;
            this.UserId = userId;
            this.EventDate = DateTime.Now;
            this.Type = type;
        }
    }
}
