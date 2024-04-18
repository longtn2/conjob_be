namespace ConJob.Entities
{
    public abstract class BaseModel
    {
        public int change_on {  get; set; }
        public DateTime create_on { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public bool is_deleted {  get; set; }
    }
}
