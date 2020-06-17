using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Books.Models;
using Books.Service.Common;
using Autofac;

namespace Books.WebApi.Controllers
{
    public class BooksCommentController : ApiController
    {

        #region Constructor
        public BooksCommentController(IBooksCommentService service)
        {
            this.Service = service;
        }

        #endregion
        protected IBooksCommentService Service { get; private set; }

        //Get all comments from all books
        [HttpGet]
        [Route("api/BooksComment")]
        public async Task<HttpResponseMessage> GetBooksCommentsAsync()
        {
            var allComments = await Service.GetBooksCommentsAsync();
            if (allComments != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, allComments);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }

        // delete comments from id comment (todo id book)
        [HttpDelete]
        [Route("api/BooksComment/{id}")]
        public async Task<HttpResponseMessage> DeleteBooksCommentsByIdAsync(Guid id)
        {
            if (await Service.DeleteBooksCommentsByIdAsync(id) == true) 
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }

        //Get all comments for book
        [HttpGet]
        [Route("api/BookComments/{id}")]
        public async Task<HttpResponseMessage> GetBooksCommentsByIdAsync(Guid id)
        {
            var allCommentsFromBook = await Service.GetBooksCommentsByIdAsync(id);
            if (allCommentsFromBook != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, allCommentsFromBook);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");


        }
    }
}
