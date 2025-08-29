using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class ResponseDomain
    {
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
        public List<CustomerDomain> customers { get; set; }
        public List<OrderDomain> orders { get; set; }

    
    }
}
