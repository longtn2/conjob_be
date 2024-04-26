namespace ConJob.Domain.Filtering
{
    public class FilterJobs
    {
        public string search_term { get; set; } = string.Empty;
        public string location { get; set; } = "";
        public int page { get; set; } = 1;
        public int limit { get; set; } = 10;
    }
}
