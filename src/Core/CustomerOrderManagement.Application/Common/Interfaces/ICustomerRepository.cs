﻿using CustomerOrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Common.Interfaces
{
    public interface ICustomerRepository : IGenericRepositoryAsync<Customer>
    {
    }
}
