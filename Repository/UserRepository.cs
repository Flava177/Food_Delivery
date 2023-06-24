using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<User> GetAllUsers(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.UserName)
               .ToList();

        public User GetUser(string userId, bool trackChanges)
        {
            var user = FindByCondition(c => c.Id.Equals(userId), trackChanges)
                .SingleOrDefault();

            return user == null ? throw new Exception("restaurant not found.") : user;
        }
    }


}
