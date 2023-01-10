using Domain.HrModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HrModuleEvents.Interfaces
{
    public interface IUserRepository
    {
        List<User> RefreshData();
        User AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User userId);
    }
}
