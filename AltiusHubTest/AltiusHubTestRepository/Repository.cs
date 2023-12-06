using AltiusHubTestData;
using Microsoft.EntityFrameworkCore;

namespace AltiusHubTestRepository
{
    public class Repository : IRepository
    {
        private readonly AltiusHubDbContext altiusHubDbContext;
        public Repository(AltiusHubDbContext _altiusHubDbContext)
        {
            altiusHubDbContext = _altiusHubDbContext;
        }
        //we will make it generic by passig T instead of creating separate 
        public async Task<List<InvoiceHeader>> GetAllHeader()
        {
            return await altiusHubDbContext.InvoiceHeaders.ToListAsync();
        }
        public async Task<InvoiceHeader> GetInvoiceHeaderByJSON(int Id)
        {
            //we can query with unique id as well
            return await altiusHubDbContext.InvoiceHeaders.Where(x=>x.Id == Id).FirstOrDefaultAsync();
        }
        public async Task<Boolean> UpdateInvoiceHeaderByJSON(InvoiceHeader invoice)
        {
            try
            {
                var id = invoice.Id;//we can query with unique id as well
                var data = altiusHubDbContext.InvoiceHeaders.Where(x => x.Id == id).FirstOrDefault();
                data = invoice;
                await altiusHubDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { }
            {
                //apply logger
                return false;
            }
        }
        public async Task<Boolean> DeleteInvoiceHeaderByJSON(InvoiceHeader invoice)
        {
            try
            {
                var id = invoice.Id;//we can query with unique id as well
                                    //we would not delete the whole item we will do soft delete
                var data = altiusHubDbContext.InvoiceHeaders.Where(x => x.Id == id).FirstOrDefault();
                //data.isDeleted = true
                await altiusHubDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public async Task<InvoiceHeader> CreateInvoiceHeaderByJSON(InvoiceHeader invoice)
        {
            try
            {
                altiusHubDbContext.InvoiceHeaders.Add(invoice);
                await altiusHubDbContext.SaveChangesAsync();
                return invoice;
            }
            catch (Exception ex)
            {
                //logger
                return invoice;
            }

        }
    }
}
