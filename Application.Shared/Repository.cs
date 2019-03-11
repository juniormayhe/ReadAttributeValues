using System;
using System.Collections.Generic;
using System.Linq;
using Application.Attributes;
using Application.Shared.Models;

namespace Application.Shared
{
    public class Repository : IRepository
    {
        
        public IEnumerable<Customer> GetCustomers(int locationId)
        {
            LocationAttribute locationAttribute = getAttribute();

            // use translated id
            int translatedLocationId = locationAttribute.Translate(locationId);
            return getAll(translatedLocationId);
        }

        private LocationAttribute getAttribute()
        {
            Type type = this.GetType();

            //object[] concreteAttributes = type.GetMethods().Single(x => x.Name == nameof(GetCustomers)).GetCustomAttributes(typeof(LocationAttribute), false);
            object[] interfaceAttributes = type.GetMethods()[0].DeclaringType.GetInterfaces()[0].GetMethods().Single(x => x.Name == nameof(GetCustomers)).GetCustomAttributes(typeof(LocationAttribute), false);

            var locationAttribute = interfaceAttributes[0] as LocationAttribute;
            return locationAttribute;
        }

        private static IEnumerable<Customer> getAll(int translatedLocationId) { 

            // simulate database
            var list = new List<Customer> {
                new Customer { CustomerId=1, CustomerName="John Lennon", LocationId = 2 },
                new Customer { CustomerId=2, CustomerName="Yoko Ono", LocationId = 2 },
                new Customer { CustomerId=3, CustomerName="Ringo Starr", LocationId = 1 },
                new Customer { CustomerId=4, CustomerName="George Harrison", LocationId = 1 },
                new Customer { CustomerId=4, CustomerName="Paul McCartney", LocationId = 3 }
            };
            return list.Where(x => x.LocationId == translatedLocationId).ToList();
    }
}
}
