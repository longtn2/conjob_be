using ConJob.Domain.Constant;
using System.ComponentModel;

namespace ConJob.Domain.Filtering
{
    public class FilterOptions
    {
        public string SearchTerm { get; set; } = string.Empty;
        [DefaultValue(CJConstant.CURRENT_PAGE)]
        public int Page { get; set; }
        [DefaultValue(CJConstant.PAGE_LIMIT)]
        public int Limit { get; set; } 
        public string? OrderBy { get; set; }
    }
}
