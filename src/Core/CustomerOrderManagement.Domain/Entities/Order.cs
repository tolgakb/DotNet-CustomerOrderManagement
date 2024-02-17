using CustomerOrderManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public String Name { get; set; }

        public String Description { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
