using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;
using Books.Models.Common;
using Books.Repository;
using Books.Repository.Common;

namespace Books.Service.Common
{
    public interface IListService
    {
        Task<List<ListGeneral>> GetAllListsAsync();

        Task<ListGeneral> GetListByIdAsync(Guid id);
        Task<bool> DeleteListByIdAsync(Guid id);
        Task<bool> CreateListAsync(ListGeneral newList);
        Task<bool> UpdateListAsync(ListGeneral updateList);
    }
}
