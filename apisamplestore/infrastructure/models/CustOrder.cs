using System;
using System.Collections.Generic;

namespace infrastructure.models;

public partial class CustOrder
{
    public int? custid { get; set; }

    public DateTime? ordermonth { get; set; }

    public int? qty { get; set; }
}
