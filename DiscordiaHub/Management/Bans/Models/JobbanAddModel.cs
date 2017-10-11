using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordiaHub.Management.Models;

namespace DiscordiaHub.Management.Bans.Models
{
    public class JobbanAddModel : BanAddModel
    {
       

        public string Job { get; set; }

        public JobbanAddModel(TimeSpan duration, Player banTarget, string banReason, string server, bool perma, string job,
            Player bannedBy = null, string ip = null, string cid = null) : base(duration, banTarget, banReason, server,
            perma, bannedBy, ip, cid)
        {
            Job = job;
        }
    }
}
