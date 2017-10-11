using System;
using DiscordiaHub.Management.Bans.Models;

namespace DiscordiaHub.Management.Bans.Services
{
    public interface IBanService
    {
        void AddBan(BanAddModel model);
        void AddJobban(JobbanAddModel model);
        void LiftBan(BanLiftModel ban);
    }
}
