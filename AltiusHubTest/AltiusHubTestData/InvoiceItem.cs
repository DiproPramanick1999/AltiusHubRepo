using System;
using System.Collections.Generic;

namespace AltiusHubTestData;

public partial class InvoiceItem
{
    public int Id { get; set; }

    public string? ItemName { get; set; }

    public double? Quantity { get; set; }

    public double? Price { get; set; }

    public double? Amount { get; set; }

    public Guid? UniqueId { get; set; }

    public int? InvoiceHeaderId { get; set; }

    public virtual InvoiceHeader? InvoiceHeader { get; set; }
}
