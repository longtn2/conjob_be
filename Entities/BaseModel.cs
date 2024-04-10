namespace ConJob.Entities
{
    public abstract class BaseModel
    {
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
