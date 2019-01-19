using CustomerManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        IEnumerable<Customer> Get();
    }
}
