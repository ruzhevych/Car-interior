namespace Car_interior.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // ---- navigation properties
        public ICollection<Cars> Cars { get; set; } // One to Many
    }
}
