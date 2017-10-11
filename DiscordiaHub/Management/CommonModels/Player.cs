using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordiaHub.Management.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Ckey { get; set; }

        [Required]
        public DateTime Registered { get; set; }

        [Required]
        public DateTime FirstSeen { get; set; }

        [Required]
        public DateTime LastSeen { get; set; }

        [Required]
        public string Ip { get; set; }

        [Required]
        public string Cid { get; set; }

        [Required]
        [DefaultValue("player")]
        public string Rank { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Flags { get; set; }

        [Required]
        public string ByondVersion { get; set; }

        [DefaultValue(null)]
        [MaxLength(16)]
        public string Country { get; set; }
    }
}
