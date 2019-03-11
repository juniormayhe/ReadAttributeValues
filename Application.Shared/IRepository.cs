using System.Collections.Generic;
using Application.Attributes;
using Application.Shared.Models;

namespace Application.Shared
{
    public interface IRepository
    {
        [Location]
        IEnumerable<Customer> GetCustomers(int locationId);
    }
}