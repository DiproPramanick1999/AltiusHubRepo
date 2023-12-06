using AltiusHubTestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltiusHubTestRepository
{
    public interface IRepository
    {
        Task<InvoiceHeader> CreateInvoiceHeaderByJSON(InvoiceHeader invoice);
        Task<Boolean> DeleteInvoiceHeaderByJSON(InvoiceHeader invoice);
        Task<Boolean> UpdateInvoiceHeaderByJSON(InvoiceHeader invoice);
        Task<InvoiceHeader> GetInvoiceHeaderByJSON(int Id);
        Task<List<InvoiceHeader>> GetAllHeader();

    }
}
