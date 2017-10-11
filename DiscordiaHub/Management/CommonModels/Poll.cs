using System;
using System.ComponentModel.DataAnnotations;

namespace DiscordiaHub.Management.Models
{
    public class Poll
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(16)]
        [Required]
        public string Type { get; set; }
        
        [Required]
        public DateTime Start { get; set; }
        
        [Required]
        public DateTime End { get; set; }

        [Required]
        public string Question { get; set; }
    }
}