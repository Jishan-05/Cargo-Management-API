namespace CargoManagementSystem.DTOs
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public string? FeedbackText { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
