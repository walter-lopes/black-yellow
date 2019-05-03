using BlackYellow.CustomerManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.CustomerManagementAPI.Repositories
{
    public interface ICartRepository
    {
        Task Save(Cart cart);

        IEnumerable<Cart> Get();
    }
}
