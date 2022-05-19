using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZealandMarketPlace.Models;

public class Review
{
    [Key]
    public int ReviewId { get; set; }
    
    [ForeignKey("ApplicationUser")]
    public int WriterId { get; set; }
    
    
    [ForeignKey("ApplicationUser")]
    public int ReceiverId { get; set; }
    
    [Required]
    public string ReviewText { get; set; }
    
    [Required]
    public int Rating { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    // public virtual ApplicationUser ApplicationUser { get; set; }
    
}