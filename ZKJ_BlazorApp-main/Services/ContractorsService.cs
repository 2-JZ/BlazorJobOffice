using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ContractorsService : IContractorsService
    {
        private IHttpService _httpService;

        public ContractorsService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<int> Create(Contractor contractor)
        {
            var result = await _httpService.Post<Contractor>("Contractors/addContractor", contractor);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _httpService.Delete($"/Contractors/{id}");
            return id;
        }

        public async Task<IEnumerable<Contractor>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Contractor>>("contractors");
        }

        public Task<Contractor> GetById(int id)
        {
            return _httpService.Get<Contractor>($"/Contractors/{id}");
        }

        public async Task<int> Update(Contractor contractor)
        {
            var result = await _httpService.Put<Contractor>($"/Contractors/{contractor.Id}", contractor);
            return result.Id;
        }
    }
}
