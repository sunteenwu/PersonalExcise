using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntityFrame.Models
{
    public class SkillLookup
    {
        [Key]
        public string Skill { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
