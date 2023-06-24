using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAddressService
    {
        IEnumerable<AddressDto> GetAllAddresses(bool trackChanges);
        AddressDto GetAddress(Guid addressId, bool trackChanges);

        AddressDto CreateAddress(AddressForCreationDto address);
    }
}
