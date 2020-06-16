using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Service.Common;
using Books.Models;
using Books.Models.Common;
using Books.Repository;
using Books.Repository.Common;


namespace Book.Service
{
    public class ListService : IListService
    {

        public ListService(IListRepository repository)
        {
            this.Repository = repository;
        }
        protected IListRepository Repository { get; set; }


        public async Task<List<ListGeneral>> GetAllListsAsync()
        {
            return await Repository.GetAllListsAsync();
        }


        public async Task<ListGeneral> GetListByIdAsync(Guid id)
        {
            return await Repository.GetListByIdAsync(id);
        }


        public async Task<bool> DeleteListByIdAsync(Guid id)
        {
            return await Repository.DeleteListByIdAsync(id);
        }


        public async Task<bool> CreateListAsync(ListGeneral newList)
        {
            return await Repository.CreateListAsync(newList);
        }


        public async Task<bool> UpdateListAsync(ListGeneral updateList)
        {
            return await Repository.UpdateListAsync(updateList);
        }
    }
}
