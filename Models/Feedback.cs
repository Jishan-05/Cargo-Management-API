using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("feedback")]
public partial class Feedback
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("feedback_text", TypeName = "text")]
    public string? FeedbackText { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("Feedbacks")]
    public virtual Customer? CreatedByNavigation { get; set; }
}
