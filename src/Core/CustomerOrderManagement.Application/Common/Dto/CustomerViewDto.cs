using CustomerOrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Common.Dto
{
    public class CustomerViewDto
    {
        public Guid Id { get; set; }

        public String? FirstName { get; set; }

        public String? LastName { get; set; }

        public String? Email { get; set; }

        public String? Phone { get; set; }

        public String? Address { get; set; }

        public String? City { get; set; }

        public String? Country { get; set; }

        //public ICollection<Order> Orders { get; set; }

        //public Guid UserId { get; set; }
        //public User User { get; set; }
    }
}
