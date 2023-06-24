using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class StatusRepository : RepositoryBase<OrderStatus>, IStatus
    {
        public StatusRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<OrderStatus> GetAllStatuses(bool trackChanges) =>
           FindAll(trackChanges)
       .OrderBy(c => c.StatusValue)
       .ToList();


        public OrderStatus GetStatus(int statusId, bool trackChanges)
        {
            var status = FindByCondition(c => c.Id.Equals(statusId), trackChanges)
                .SingleOrDefault() ?? throw new Exception("Status not found.");
            return status;
        }
    }
}
