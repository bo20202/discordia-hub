using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordiaHub.Management.Models
{
    public class PollTextReply
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Time { get; set; }

        public string Text { get; set; }

        [ForeignKey(nameof(Player))]
        public int? PlayerId { get; set; }
        [ForeignKey(nameof(Poll))]
        public int? PollId { get; set; }

        public Player Player { get; set; }
        public Poll Poll { get; set; }
    }
}