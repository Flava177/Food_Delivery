using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserService : IUserService 
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public UserService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
        {

            var users = _repository.User.GetAllUsers(trackChanges);

            var usersDto = users.Select(c =>

            new UserDto(c.Id, c.FullName, c.PhoneNumber, c.Email, c.Password)).ToList();

            return usersDto;

        }
    }
}
