using System;
using System.Linq;
using DiscordiaHub.Database;
using DiscordiaHub.Management.Bans.Models;
using DiscordiaHub.Management.Utility;

namespace DiscordiaHub.Management.Bans.Services
{
    public class BanService : IBanService
    {
        private readonly HubContext _db;

        public BanService(HubContext dbContext)
        {
            _db = dbContext;
        }

        public void AddBan(BanAddModel model)
        {
            var ban = new Ban
            {
                BannedById = model.BannedBy.Id,
                Cid = model.Cid,
                Duration = model.Duration.Minutes,
                ExpirationTime =  DateTime.Now + model.Duration,
                Server = model.Server,
                Reason = model.BanReason,
                TargetId = model.BanTarget.Id,
                Ip = model.Ip,
                Time = DateTime.Now,
                Unbanned = false,
                Type = model.Permaban ? BanType.Permaban : BanType.Tempban
            };

            _db.Bans.Add(ban);
            _db.SaveChanges();
        }

        public void AddJobban(JobbanAddModel model)
        {
            var ban = new Ban
            {
                BannedById = model.BannedBy.Id,
                Cid = model.Cid,
                Duration = model.Duration.Minutes,
                ExpirationTime = DateTime.Now + model.Duration,
                Server = model.Server,
                Reason = model.BanReason,
                TargetId = model.BanTarget.Id,
                Ip = model.Ip,
                Time = DateTime.Now,
                Unbanned = false,
                Type = model.Permaban ? BanType.JobPermaban : BanType.JobTempban,
                Job = model.Job
            };

            _db.Bans.Add(ban);
            _db.SaveChanges();
        }

        public void LiftBan(BanLiftModel liftModel)
        {
            var ban = _db.Bans.Single(x => x.Id == liftModel.BanId);
            ban.Unbanned = true;
            ban.UnbannedById = liftModel.UnbannedById;
            ban.UnbannedTime = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
