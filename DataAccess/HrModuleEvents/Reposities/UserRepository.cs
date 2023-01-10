using DataAccess.HrModuleEvents.Interfaces;
using Domain.HrModule;
using Events.HrModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HrModuleEvents.Reposities
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserEventsRepository _userEvents;

        public UserRepository(IUserEventsRepository userEvents)
        {
            _userEvents = userEvents;
        }
        public User AddUser(User user)
        {
            var userEvent = new UserEvent() { EventTime = DateTime.Now , EventType = EventType.Craete , Id = Guid.NewGuid() , User = user };
            _userEvents.Create(userEvent);
            return user;
        }

        public void DeleteUser(User user)
        {
            var userEvent = new UserEvent() { EventTime = DateTime.Now, EventType = EventType.Delete, Id = Guid.NewGuid(), User = user };
            _userEvents.Create(userEvent);
        }

        public List<User> RefreshData()
        {
            var UserDataList = new List<User>();
            var userEvents = _userEvents.GetUserEvents();
            foreach (var Event in userEvents)
            {
                if (Event.EventType == EventType.Craete)
                    UserDataList.Add(Event.User);
                else if (Event.EventType == EventType.Delete)
                    UserDataList.Remove(Event.User);
                else if (Event.EventType == EventType.Update)
                {
                    UserDataList.Remove(UserDataList.FirstOrDefault(userItem => userItem.Id == Event.User.Id)!);
                    UserDataList.Add(Event.User);
                }
                else
                    continue;
            }
            return UserDataList;
        }

        public User UpdateUser(User user)
        {
            var userEvent = new UserEvent() { EventTime = DateTime.Now, EventType = EventType.Update, Id = Guid.NewGuid(), User = user };
            _userEvents.Create(userEvent);
            return user;
        }
    }
}
