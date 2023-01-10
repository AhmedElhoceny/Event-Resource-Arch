using DataAccess.HrModuleEvents.Interfaces;
using EventResourceArch;
using Events.HrModule;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HrModuleEvents.Reposities
{
    public class UserEventsRepository : IUserEventsRepository
    {
        private readonly IMongoCollection<UserEvent> _userEvents;

        public UserEventsRepository(EventsDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userEvents = database.GetCollection<UserEvent>(settings.EventsCollectionName);
        }
        public UserEvent Create(UserEvent Event)
        {
            _userEvents.InsertOne(Event);
            return Event;
        }

        public List<UserEvent> GetUserEvents()
        {
            return _userEvents.Find(eve => true).ToList();
        }

        public void Remove(string id)
        {
            _userEvents.DeleteOne(id);
        }
    }
}
