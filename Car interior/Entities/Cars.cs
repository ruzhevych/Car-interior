﻿namespace Car_interior.Entities
{
    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public bool Archived { get; set; }

        // ---- navigation properties
        public Category Category { get; set; }
    }
}
