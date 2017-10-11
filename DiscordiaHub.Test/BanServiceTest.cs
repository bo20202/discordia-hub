using System;
using System.Linq;
using DiscordiaHub.Database;
using DiscordiaHub.Management.Bans.Models;
using DiscordiaHub.Management.Bans.Services;
using DiscordiaHub.Management.Models;
using DiscordiaHub.Management.Utility;
using DiscordiaHub.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiscordiaHub.Tests
{
    public class BanServiceTest
    {
        [Fact]
        public void CanInsertRegularBan()
        {
            var options = Utility.CreateNewContextOptions(nameof(CanInsertRegularBan));
            using (var context = new HubContext(options))
            {
                (var admin, var banTarget) = PrepareDatabase(context);

                var service = new BanService(context);

                var banAddModel = new BanAddModel(TimeSpan.FromDays(150),
                    context.Players.Single(x => x.Id == banTarget.Id), "Griefer", "byond://discordia.space:2011", false,
                    admin, banTarget.Ip, banTarget.Cid);

                service.AddBan(banAddModel);

                var ban = context.Bans.FirstOrDefault();

                Assert.NotNull(ban);
                Assert.Equal(ban.BannedById, admin.Id);
                Assert.Equal(ban.Duration, banAddModel.Duration.Minutes);
                Assert.Equal(ban.Server, banAddModel.Server);
                Assert.Equal(ban.Reason, banAddModel.BanReason);
                Assert.Equal(ban.Type, BanType.Tempban);
                Assert.Null(ban.Job);
                Assert.Equal(ban.TargetId, banTarget.Id);

            }
        }

        [Fact]
        public void CanInsertPermaban()
        {

            var options = Utility.CreateNewContextOptions(nameof(CanInsertPermaban));
            using (var context = new HubContext(options))
            {
                (var admin, var banTarget) = PrepareDatabase(context);
                var service = new BanService(context);

                var banAddModel = new BanAddModel(TimeSpan.FromDays(150),
                    context.Players.Single(x => x.Id == banTarget.Id), "Griefer", "byond://discordia.space:2011", true,
                    admin, banTarget.Ip, banTarget.Cid);

                service.AddBan(banAddModel);

                var ban = context.Bans.FirstOrDefault();

                Assert.NotNull(ban);
                Assert.Equal(ban.BannedById, admin.Id);
                Assert.Equal(ban.TargetId, banTarget.Id);
                Assert.Equal(ban.Duration, banAddModel.Duration.Minutes);
                Assert.Equal(ban.Server, banAddModel.Server);
                Assert.Equal(ban.Reason, banAddModel.BanReason);
                Assert.Equal(ban.Type, BanType.Permaban);
                Assert.Null(ban.Job);
            }
        }

        [Fact]
        public void CanInsertRegularJobban()
        {
            var options = Utility.CreateNewContextOptions(nameof(CanInsertRegularJobban));
            using (var context = new HubContext(options))
            {
                (var admin, var banTarget) = PrepareDatabase(context);
                var service = new BanService(context);
                var jobbanAddModel = new JobbanAddModel(TimeSpan.FromDays(600), banTarget, "Griefer",
                    "byond://discordia.space:9999", false, "Medic", admin, banTarget.Ip, banTarget.Cid);

                service.AddJobban(jobbanAddModel);

                var jobban = context.Bans.FirstOrDefault();

                Assert.NotNull(jobban);
                Assert.Equal(jobban.Type, BanType.JobTempban);
                Assert.Equal(jobban.Job, jobbanAddModel.Job);
                Assert.Equal(jobban.Duration, jobbanAddModel.Duration.Minutes);
            }
        }

        private static (Player admin, Player banTarget) PrepareDatabase(HubContext context)
        {

            var admin = new Player()
            {
                ByondVersion = "511",
                Cid = "112315121",
                Ckey = "bo20202",
                Country = "Russia",
                FirstSeen = DateTime.Now - TimeSpan.FromDays(15),
                Flags = 11,
                Ip = "127.0.0.1",
                LastSeen = DateTime.Now,
                Rank = "Admin",
                Registered = DateTime.Now - TimeSpan.FromDays(150)
            };
            var banTarget = new Player()
            {
                ByondVersion = "511",
                Cid = "124125121",
                Ckey = "jshepard",
                Country = "Russia",
                FirstSeen = DateTime.Now - TimeSpan.FromMinutes(15),
                Flags = 0,
                Ip = "127.0.0.2",
                LastSeen = DateTime.Now,
                Rank = "Player",
                Registered = DateTime.Now - TimeSpan.FromMinutes(15)
            };
            context.Players.Add(admin);
            context.Players.Add(banTarget);
            context.SaveChanges();


            return (admin, banTarget);
        }
    }
}
