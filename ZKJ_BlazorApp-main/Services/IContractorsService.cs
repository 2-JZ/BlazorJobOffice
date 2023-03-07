namespace BlazorApp.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp.Models;

    public interface IContractorsService
    {
        Task<IEnumerable<Contractors>> GetAll();
        Task<int> Create(Contractors contractor);
        Task<int> Delete(int Id);
        Task<int> Update(Contractors contractor);
        Task<Contractors> GetById(int Id);
    }
}