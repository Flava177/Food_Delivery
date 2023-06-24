using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class DispatchDriverService : IDispatchDriverService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public DispatchDriverService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<DispatchDriverDto> GetAllDrivers(bool trackChanges)
        {

            var drivers = _repository.DispatchDriver.GetAllDrivers(trackChanges);

            var driversDto = drivers.Select(c =>

            new DispatchDriverDto(c.Id, c.FullName, c.PhoneNumber)).ToList();

            return driversDto;

        }

        public DispatchDriverDto GetDriver(Guid id, bool trackChanges)
        {
            var driver = _repository.DispatchDriver.GetDriver(id, trackChanges);

            var driverDto = new DispatchDriverDto(
            id,
            driver.FullName,
            driver.PhoneNumber
            );

            return driverDto;
        }


        public DispatchDriverDto CreateDriver(DispatchDriverForCreationDto dispatchDriver)
        {
            var dispatchDriverEntity = new DispatchDriver
            {
                Id = Guid.NewGuid(),
                FullName = dispatchDriver.FullName,
                PhoneNumber = dispatchDriver.PhoneNumber
            };

            _repository.DispatchDriver.CreateDriver(dispatchDriverEntity);
            _repository.Save();

            var dispatchDriverDto = new DispatchDriverDto(

                Id:dispatchDriverEntity.Id,
                Fullname: dispatchDriverEntity.FullName,
                PhoneNumber: dispatchDriverEntity.PhoneNumber

                );
            return dispatchDriverDto;
        }
    }
}
