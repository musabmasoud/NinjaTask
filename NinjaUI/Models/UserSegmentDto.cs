namespace NinjaUI.Models
{
    public class UserSegmentDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public Guid SegmentId { get; set; }
        public string SegmentName { get; set; }
        public string? Description { get; set; }
    }
}
