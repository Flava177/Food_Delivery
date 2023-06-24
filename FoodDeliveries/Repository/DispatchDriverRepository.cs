using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class DispatchDriverRepository : RepositoryBase<DispatchDriver>, IDispatchDriverRepository
    {
        public DispatchDriverRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<DispatchDriver> GetAllDrivers(bool trackChanges) =>
            FindAll(trackChanges)
               .OrderBy(c => c.FullName)
               .ToList();

        public DispatchDriver GetDriver(Guid dispatchDriverId, bool trackChanges)
        {
            var driver = FindByCondition(c => c.Id.Equals(dispatchDriverId), trackChanges)
                .SingleOrDefault() ?? throw new Exception("driver not found.");
            return driver;
        }
    }
}
