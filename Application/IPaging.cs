namespace Application
{
    public interface IPaging
    {
        string? SearchTerm { get; }
        string? SortColumn { get; }
        string? SortOrder { get; }
        int Page { get; }
        int PageSize { get; }
    }
}
