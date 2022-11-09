using AlkemyWallet.Entities.Paged;

namespace AlkemyWallet.Core.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PageResourceParameters filter, string route);
    }
}
