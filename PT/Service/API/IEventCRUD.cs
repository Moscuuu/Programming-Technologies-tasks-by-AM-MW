using DataLayer.API;
using Service.Implementation;

namespace Service.API;

public interface IEventCRUD
{
    static IEventCRUD CreateEventCRUD(IDataRepository? dataRepository = null)
    {
        return new EventCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
    }

    Task AddEvent(int id, int stateId, int userId, string type);

    Task<IEventDTO> GetEvent(int id);

    Task UpdateEvent(int id, int stateId, int userId, string type);

    Task DeleteEvent(int id);

    Task<Dictionary<int, IEventDTO>> GetAllEvents();

    Task<int> GetEventsCount();
}
