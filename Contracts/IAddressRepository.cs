using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAllAddresses(bool trackChanges);
        Address GetAddress(Guid addressId, bool trackChanges);

        void CreateAddress(Address address);
    }
}