using Events.HrModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HrModuleEvents.Interfaces
{
    public interface IUserEventsRepository
    {
        List<UserEvent> GetUserEvents();
        UserEvent Create(UserEvent student);
        void Remove(string id);
    }
}
