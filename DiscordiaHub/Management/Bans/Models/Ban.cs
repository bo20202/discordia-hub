using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscordiaHub.Management.Models;

namespace DiscordiaHub.Management.Bans.Models
{
    public class Ban
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Server { get; set; }
        
        [Required]
        public string Type { get; set; }

        [Required]
        public string Ip { get; set; }

        [Required]
        public string Cid { get; set; }

        [Required]
        public string Reason { get; set; }
        
        [DefaultValue(null)]
        public string Job { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public DateTime ExpirationTime { get; set; }

        [DefaultValue(null)]
        public bool? Unbanned { get; set; }

        [DefaultValue(null)]
        public DateTime? UnbannedTime { get; set; }

        [ForeignKey(nameof(Target))]
        public int? TargetId { get; set; }
        [ForeignKey(nameof(BannedBy))]
        public int? BannedById { get; set; }
        [ForeignKey(nameof(UnbannedBy))]
        public int? UnbannedById { get; set; }

        public Player Target { get; set; }
        public Player BannedBy { get; set; }
        public Player UnbannedBy { get; set; }
    }
}