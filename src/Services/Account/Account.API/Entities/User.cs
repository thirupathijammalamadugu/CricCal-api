namespace Account.API.Entities
{
    public class User
    {
        public int Id { get; set; }

        public Guid? UserId {get;set;} = Guid.NewGuid();
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
