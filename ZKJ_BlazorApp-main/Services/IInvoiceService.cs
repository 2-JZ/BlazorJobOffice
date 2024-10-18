namespace BlazorApp.Services
{
    using BlazorApp.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAll();
        Task<IEnumerable<Invoice>> GetByCustomer(int customerId);
        Task<Invoice> GetById(int id);
        Task<int> Create(Invoice invoice);
        Task<int> Update(Invoice invoice);
        Task<int> Delete(int id);
    }

}
