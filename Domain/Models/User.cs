namespace Domain.Models
{
    public class User
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phones { get; set; }
    }
}
