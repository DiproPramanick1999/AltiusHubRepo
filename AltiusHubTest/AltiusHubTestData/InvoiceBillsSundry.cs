using System;
using System.Collections.Generic;

namespace AltiusHubTestData;

public partial class InvoiceBillsSundry
{
    public int Id { get; set; }

    public Guid UniqueId { get; set; }

    public decimal? Amount { get; set; }

    public int? InvoiceHeaderId { get; set; }

    public virtual InvoiceHeader? InvoiceHeader { get; set; }
}
