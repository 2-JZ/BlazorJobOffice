using BlazorApp.Models;
using BlazorApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InvoiceService : IInvoiceService
{
    private IHttpService _httpService;

    public InvoiceService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    // Fetch all invoices
    public Task<IEnumerable<Invoice>> GetAll()
    {
        return _httpService.Get<IEnumerable<Invoice>>("/Invoices");
    }

    // Fetch invoices by customer ID (if you want to filter by customer)
    public Task<IEnumerable<Invoice>> GetByCustomer(int customerId)
    {
        return _httpService.Get<IEnumerable<Invoice>>($"/Invoices/byCustomer/{customerId}");
    }

    // Fetch a single invoice by its ID
    public Task<Invoice> GetById(int id)
    {
        return _httpService.Get<Invoice>($"/Invoices/{id}");
    }

    // Create a new invoice
    public async Task<int> Create(Invoice invoice)
    {
        var result = await _httpService.Post<Invoice>("/Invoices/addInvoice", invoice);
        return result.Id;
    }

    // Update an existing invoice
    public async Task<int> Update(Invoice invoice)
    {
        var result = await _httpService.Put<Invoice>($"/Invoices/{invoice.Id}", invoice);
        return result.Id;
    }

    // Delete an invoice by ID
    public async Task<int> Delete(int id)
    {
        await _httpService.Delete($"/Invoices/{id}");
        return id;
    }
}
