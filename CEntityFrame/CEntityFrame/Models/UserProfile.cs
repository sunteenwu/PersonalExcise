using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CEntityFrame.Models
{
    public class UserProfile
    {
        [DataMember(Name = "uid"), Key]
        public string UserId { get; set; }
        [DataMember(Name = "em")]
        public string Email { get; set; }
        [DataMember(Name = "fn")]
        public string FullName { get; set; }
        [IgnoreDataMember]
        public List<Friendship> Friendships { get; set; }
    }
}
