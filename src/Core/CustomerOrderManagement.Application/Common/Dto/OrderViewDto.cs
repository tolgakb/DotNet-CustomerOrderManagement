using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Common.Dto
{
    public class OrderViewDto
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }

    }
}
