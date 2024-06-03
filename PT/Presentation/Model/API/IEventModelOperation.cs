using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IEventModelOperation
{
    static IEventModelOperation CreateModelOperation(IEventCRUD? eventCrud = null)
    {
        return new EventModelOperation(eventCrud ?? IEventCRUD.CreateEventCRUD());
    }

    Task AddEvent(int id, int stateId, int userId, string type);

    Task<IEventModel> GetEvent(int id, string type);

    Task UpdateEvent(int id, int stateId, int userId, string type);

    Task DeleteEvent(int id);

    Task<Dictionary<int, IEventModel>> GetAllEvents();

    Task<int> GetEventsCount();
}
