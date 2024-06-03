using Presentation.Model.API;
using Service.API;

namespace Presentation.Model.Implementation;

internal class EventModelOperation : IEventModelOperation
{
    private IEventCRUD _eventCRUD;

    public EventModelOperation(IEventCRUD? eventCrud = null)
    {
        this._eventCRUD = eventCrud ?? IEventCRUD.CreateEventCRUD();
    }

    private IEventModel Map(IEventDTO even)
    {
        return new EventModel(even.Id, even.StateId, even.UserId, even.Type);
    }

    public async Task AddEvent(int id, int stateId, int userId, string type)
    {
        await this._eventCRUD.AddEvent(id, stateId, userId, type);
    }

    public async Task<IEventModel> GetEvent(int id, string type)
    {
        return this.Map(await this._eventCRUD.GetEvent(id));
    }

    public async Task UpdateEvent(int id, int stateId, int userId, string type)
    {
        await this._eventCRUD.UpdateEvent(id, stateId, userId, type);
    }

    public async Task DeleteEvent(int id)
    {
        await this._eventCRUD.DeleteEvent(id);
    }

    public async Task<Dictionary<int, IEventModel>> GetAllEvents()
    {
        Dictionary<int, IEventModel> result = new Dictionary<int, IEventModel>();

        foreach (IEventDTO even in (await this._eventCRUD.GetAllEvents()).Values)
        {
            result.Add(even.Id, this.Map(even));
        }

        return result;
    }

    public async Task<int> GetEventsCount()
    {
        return await this._eventCRUD.GetEventsCount();
    }
}
