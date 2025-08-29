using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class CustomerDomain
    {
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        //public string companyname { get; set; } = null!;

        //public string contactname { get; set; } = null!;

        //public string contacttitle { get; set; } = null!;

        //public string address { get; set; } = null!;

        //public string city { get; set; } = null!;

        //public string? region { get; set; }

        //public string? postalcode { get; set; }

        //public string country { get; set; } = null!;

        //public string phone { get; set; } = null!;

        //public string? fax { get; set; }

        //public DateTime PredictedOrder { get; set; }
        public DateTime LastOrderDate { get; set; }
        public int DiffDays { get; set; }
        [NotMapped]
        public float AverageDays { get; set; }
        [NotMapped]
        public DateTime PredictedDate { get; set; }
    }
}
