using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordiaHub.Management.Models
{
    public class PollOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

        [Required]
        [ForeignKey(nameof(Poll))]
        public int PollId { get; set; }

        public Poll Poll { get; set; }
    }
}