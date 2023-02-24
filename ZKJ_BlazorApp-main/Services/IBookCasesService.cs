namespace BlazorApp.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp.Models;

    public interface IBookCasesService
    {
        Task<IEnumerable<BookCase>> GetAll();
        Task<int> Create(BookCase bookCase);
        Task<int> Delete(int Id);
        Task<int> Update(BookCase bookCase);
        Task<BookCase> GetById(int Id);
    }
}