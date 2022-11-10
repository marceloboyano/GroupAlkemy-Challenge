using AlkemyWallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlkemyWallet.Core.Helper
{
    public class PageListed
    {

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        private bool HasPrevious => (CurrentPage > 1);
        private bool HasNext => (CurrentPage < TotalPages);

        public PageListed(int pageNumber, int pageSize, int totalPages)
        {
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = totalPages;
        }
        internal void AddHeader(HttpResponse response, IUrlHelper url)
        {
            var UrlPrev = (HasPrevious) ? url.Link("GetTransactions", new { Page = CurrentPage - 1 }) : null;
            var UrlNext = (HasNext) ? url.Link("GetTransactions", new { Page = CurrentPage + 1 }) : null;
            var metadata = new
            { CurrentPage, UrlPrev, UrlNext, TotalPages, PageSize };
            response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        }
    }
}
