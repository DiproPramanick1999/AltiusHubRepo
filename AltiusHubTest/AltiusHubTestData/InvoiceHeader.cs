using System;
using System.Collections.Generic;

namespace AltiusHubTestData;

public class InvoiceHeader
{
    public int Id { get; set; }

    public Guid InvoiceUniqueId { get; set; }

    public DateTime? Date { get; set; }

    public int? InvoiceNumber { get; set; }

    public string? BillingAddress { get; set; }

    public string? ShippingAddress { get; set; }

    public string? Gstin { get; set; }

    public double? TotalAmout { get; set; }

    public virtual ICollection<InvoiceBillsSundry> InvoiceBillsSundries { get; set; } = new List<InvoiceBillsSundry>();

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
