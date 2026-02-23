namespace EventManagement.Api.Models
{

    public class Registration
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public DateTime RegisteredAt { get; set; } =  DateTime.UtcNow;
        public string Status { get; set; }
    }
}