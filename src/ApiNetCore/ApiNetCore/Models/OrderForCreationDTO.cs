using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Models
{
    public class OrderForCreationDTO
    {
        //public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        internal OrderDTO ToDomain(int maxOrderId)
        {
            var order = new OrderDTO();
            order.OrderId = ++maxOrderId;
            order.CustomerId = CustomerId;
            order.EmployeeId = EmployeeId;
            order.OrderDate = OrderDate;
            order.RequiredDate = RequiredDate;
            order.ShippedDate = ShippedDate;
            order.ShipVia = ShipVia;
            order.Freight = Freight;
            order.ShipName = ShipName;
            order.ShipAddress = ShipAddress;
            order.ShipCity = ShipCity;
            order.ShipRegion = ShipRegion;
            order.ShipPostalCode = ShipPostalCode;
            order.ShipCountry = ShipCountry;
            return order;
        }
    }
}
