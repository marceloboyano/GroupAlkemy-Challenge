namespace AlkemyWallet.Entities.Paged;

public class PageResourceParameters
{
    private const int maxPageSize = 10;
    private int _pageSize = 2;
    public int UserID { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > maxPageSize ? maxPageSize : value;
    }
}