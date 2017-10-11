using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordiaHub.Management.Models
{
    public class PollVote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [ForeignKey(nameof(Poll))]
        public int PollId { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(Option))]
        public int OptionId { get; set; }

        public Poll Poll { get; set; }
        public Player Player { get; set; }
        public PollOption Option { get; set; }
    }
}