﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserDto(Guid Id, string FullName, string Email, string PhoneNumber, string Password);
}
