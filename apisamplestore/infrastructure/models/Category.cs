using System;
using System.Collections.Generic;

namespace infrastructure.models;

public partial class Category
{
    public int categoryid { get; set; }

    public string categoryname { get; set; } = null!;

    public string description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
