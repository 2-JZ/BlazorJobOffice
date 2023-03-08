namespace BlazorApp.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp.Models;

    public interface IContractorsService
    {
        Task<IEnumerable<Contractor>> GetAll();
        Task<int> Create(Contractor contractor);
        Task<int> Delete(int id);
        Task<int> Update(Contractor contractor);
        Task<Contractor> GetById(int id);
    }
}