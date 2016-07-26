using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntityFrame.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [StringLength(40)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(40)]
        [Required]
        public string LastName { get; set; }
        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        public string Skill { get; set; }
        public SkillLookup SkillLookup { get; set; }
    }
}
