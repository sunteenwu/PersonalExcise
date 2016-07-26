using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntityFrame.Models
{
    public class Friendship
    {
        public string UserId { get; set; }
        public UserProfile User { get; set; }
        public string FriendId { get; set; }
        public UserProfile Friend { get; set; }
        public ulong Since { get; set; }
        public uint Rank { get; set; }
    }
}
