using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementEventHandler.Repositories
{
    public interface ICustomerRepository
    {
        Task SaveAsync(Customer customer);
        IEnumerable<Customer> Get();
    }
}
