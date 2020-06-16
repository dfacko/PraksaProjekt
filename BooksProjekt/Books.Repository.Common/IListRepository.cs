using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;

namespace Books.Repository.Common
{
    public interface IListRepository
    {
        Task<List<ListGeneral>> GetAllListsAsync();

        Task<ListGeneral> GetListByIdAsync(Guid id);
        Task<bool> DeleteListByIdAsync(Guid id);
        Task<bool> CreateListAsync(ListGeneral newList);
        Task<bool> UpdateListAsync(ListGeneral updateList);
    }
}
