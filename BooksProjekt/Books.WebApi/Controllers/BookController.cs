using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Books.WebApi.Models;
using System.Data;
using System.Data.SqlClient;
using Books.Models;
using Book.Service;
using Books.Service.Common;
using AutoMapper;
using System.Threading.Tasks;

namespace Books.WebApi.Controllers
{
    public class BookController : ApiController
    {
        protected IBookService bookService { get; private set; }
        protected IMapper mapper { get; private set; }

        public List<Models.Book> BookList = new List<Models.Book>();
        public List<BookModel> BookModelList = new List<BookModel>();

        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/seebooks")]
        public async Task<HttpResponseMessage> SeeBookListAsync()
        {
            BookModelList = await bookService.SeeBookListAsync();
            foreach (BookModel bookModel in BookModelList)
            {
                Models.Book book = mapper.Map<Models.Book>(bookModel);
                BookList.Add(book);
            }
            return Request.CreateResponse(HttpStatusCode.OK, BookList);
        }
    }
}
