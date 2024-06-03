using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class Event : IEvent
    {
        public Event(int eventId, int stateId, int userId, string type)
        {
            this.eventId = eventId;
            this.stateId = stateId;
            this.userId = userId;
            this.eventDate = DateTime.Now;
            this.type = type;
        }

        public int eventId { get; set; }
        public int stateId { get; set; }
        public int userId { get; set; }
        public DateTime eventDate { get; }
        public string type { get; set; }
    }
}
