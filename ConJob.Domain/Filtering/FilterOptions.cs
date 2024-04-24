using ConJob.Domain.Constant;

namespace ConJob.Domain.Filtering
{
    public class FilterOptions
    {
        public string SearchTerm { get; set; } = string.Empty;
        public int Page { get; set; } = CJConstant.CURRENT_PAGE;
        public int Limit { get; set; } = CJConstant.PAGE_LIMIT;
        public string? OrderBy { get; set; }
    }
}
