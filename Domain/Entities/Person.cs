namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PublicDateUtc { get; set; } = DateTime.Now;

        //Reference
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
