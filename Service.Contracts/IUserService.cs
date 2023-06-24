using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers(bool trackChanges);
        UserDto GetUser(string userId, bool trackChanges);

    }
}
