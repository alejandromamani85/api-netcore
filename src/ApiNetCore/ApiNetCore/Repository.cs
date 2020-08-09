using ApiNetCore.Models;
using Foundation.ObjectHydrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore
{
    public class Repository
    {
        public static Repository Instance { get; } = new Repository();
        public IList<CustomerDTO> Customers { get; set; }

        public Repository()
        {
            Hydrator<CustomerDTO> hydrator = new Hydrator<CustomerDTO>();
            Customers = hydrator.GetList(5);

            Random random = new Random();

            Hydrator<OrderDTO> hydratorOrder = new Hydrator<OrderDTO>();

            foreach (var customer in Customers)
            {
                customer.Orders = hydratorOrder.GetList(random.Next(1, 3));
            }
        }
    }
}
