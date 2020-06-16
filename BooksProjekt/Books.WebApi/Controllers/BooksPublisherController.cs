using Books.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Books.Models;
using Autofac;

namespace Books.WebApi.Controllers
{
    public class BooksPublisherController : ApiController
    {
        #region Constructor
        public BooksPublisherController(IBooksPublisherService service)
        {
            this.Service = service;
        }
 
        #endregion
        protected IBooksPublisherService Service { get; private set; }

        [HttpGet]
        [Route("api/BooksPublisher")]
        public async Task<HttpResponseMessage> GetBooksPublishersAsync()
        {
            var allPublishers = await Service.GetBooksPublishersAsync();
            if (allPublishers != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, allPublishers);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }

        [HttpDelete]
        [Route("api/BooksPublisher/{id}")]
        public async Task<HttpResponseMessage> DeleteBooksPublisherByIdAsync(Guid id)
        {
            if (await Service.DeleteBooksPublisherByIdAsync(id)==true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }
        [HttpPost]
        [Route("api/BooksPublisher")]
        public async Task<HttpResponseMessage> CreateBooksPublisherByIdAsync([FromBody] BooksPublisher booksPublisher )
        {
            if (booksPublisher != null)
            {
                await Service.CreateBooksPublisherByIdAsync(booksPublisher);
                return Request.CreateResponse(HttpStatusCode.OK, "Item added");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to add");
        }
        [HttpPut]
        [Route("api/BooksPublisher/{id}")]
        public async Task<HttpResponseMessage> UpdateBooksPublisherByIdAsync([FromBody] BooksPublisher booksPublisher)
        {
            if (booksPublisher != null)
            {
                await Service.UpdateBooksPublisherByIdAsync(booksPublisher);
                return Request.CreateResponse(HttpStatusCode.OK, "Update done");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Problem with item");
        }



        //// GET: api/BooksPublisher
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/BooksPublisher/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/BooksPublisher
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/BooksPublisher/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/BooksPublisher/5
        //public void Delete(int id)
        //{
        //}
    }
}
