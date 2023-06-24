using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDispatchDriverService
    {
        IEnumerable<DispatchDriverDto> GetAllDrivers(bool trackChanges);
        DispatchDriverDto GetDriver(Guid dispatchDriverId, bool trackChanges);
        DispatchDriverDto CreateDriver(DispatchDriverForCreationDto driver);
    }
}
