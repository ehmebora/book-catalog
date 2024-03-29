﻿namespace BookCatalog.API.DTOs
{
    public class BookDTO : BaseEntityDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PublicDateUtc { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
    }
}
