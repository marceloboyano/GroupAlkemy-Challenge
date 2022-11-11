using AlkemyWallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
        internal void AddHeader(HttpResponse response, string? urlBase)
        {
            string? UrlPrev = (HasPrevious) ? CreateUrl(urlBase, CurrentPage - 1) : null;
            string? UrlNext = (HasNext) ? CreateUrl(urlBase, CurrentPage + 1) : null;
            var metadata = new { CurrentPage, UrlPrev, UrlNext, TotalPages, PageSize };
            response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        }

        private string CreateUrl(string urlBase, int page)
        {
            return urlBase + (urlBase.Contains("?") ? "&" : "?") + "page=" + page;
        }

    }
}
