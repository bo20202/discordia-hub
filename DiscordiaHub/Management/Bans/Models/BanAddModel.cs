using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordiaHub.Management.Models;

namespace DiscordiaHub.Management.Bans.Models
{
    public class BanAddModel
    {
        public BanAddModel(TimeSpan duration, Player banTarget, string banReason, string server, bool perma, Player bannedBy = null,
            string ip = null, string cid = null)
        {
            Duration = duration;
            BanTarget = banTarget;
            BanReason = banReason;
            BannedBy = bannedBy;
            Ip = ip;
            Cid = cid;
            Server = server;
            Permaban = perma;
        }

        public TimeSpan Duration { get; }
        public Player BanTarget { get; }
        public string BanReason { get; }
        public Player BannedBy { get; set; }
        public string Ip { get; set; }
        public string Cid { get; set; }
        public string Server { get; set; }
        public bool Permaban { get; set; }
    }
}
