using System;
using System.ComponentModel.DataAnnotations;

namespace DiscordiaHub.Management.Models
{
    public class Population
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlayerCount { get; set; }

        [Required]
        public int AdminCount { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public string Server { get; set; }
    }
}