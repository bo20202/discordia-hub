using System.Linq;
using System.Text.RegularExpressions;
using DiscordiaHub.Management.Bans.Models;
using DiscordiaHub.Management.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordiaHub.Database
{
    public class HubContext : DbContext
    {
        public HubContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Ban> Bans { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<PollTextReply> PollTextReplies { get; set; }
        public DbSet<PollVote> PollVotes { get; set; }
        public DbSet<Population> Populations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();
                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType == typeof(string) && property.FindAnnotation("MaxLength") == null)
                    {
                        property.AddAnnotation("MaxLength", 255);
                    }

                    property.Relational().ColumnName = property.Name.ToSnakeCase();
                }

                foreach (var key in entity.GetKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.Relational().Name = index.Relational().Name.ToSnakeCase();
                }
            }
        }
    }

    public static class Helpers
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}