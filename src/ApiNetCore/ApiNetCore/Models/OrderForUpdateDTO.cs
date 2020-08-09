using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Models
{
    public class OrderForUpdateDTO
    {
        //public int OrderId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        [MinLength(10, ErrorMessage = "Ship Address too short")]
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        //internal OrderDTO MapToDomain(int maxOrderId)
        //{
        //    var order = new OrderDTO();
        //    //order.OrderId = ++maxOrderId;
        //    order.CustomerId = CustomerId;
        //    order.EmployeeId = EmployeeId;
        //    order.OrderDate = OrderDate;
        //    order.RequiredDate = RequiredDate;
        //    order.ShippedDate = ShippedDate;
        //    order.ShipVia = ShipVia;
        //    order.Freight = Freight;
        //    order.ShipName = ShipName;
        //    order.ShipAddress = ShipAddress;
        //    order.ShipCity = ShipCity;
        //    order.ShipRegion = ShipRegion;
        //    order.ShipPostalCode = ShipPostalCode;
        //    order.ShipCountry = ShipCountry;
        //    return order;
        //}
    }
}
