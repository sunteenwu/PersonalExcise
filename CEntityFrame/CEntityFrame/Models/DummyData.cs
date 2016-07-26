using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntityFrame.Models
{
    public static class DummyData
    {
        public static void Initialize(SkillsContext context)
        {
            if (!context.Skills.Any())
            {
                var sailor = context.Skills.Add(new SkillLookup { Skill = "Sailor" }).Entity;
                var fisher = context.Skills.Add(new SkillLookup { Skill = "Fisherman" }).Entity;
                var smith = context.Skills.Add(new SkillLookup { Skill = "Gold Smith" }).Entity;
                var gardner = context.Skills.Add(new SkillLookup { Skill = "Gardner" }).Entity;
                var mason = context.Skills.Add(new SkillLookup { Skill = "Mason" }).Entity;

                context.Contacts.AddRange(
                    new Contact()
                    {
                        FirstName = "Jim",
                        LastName = "Sailor",
                        Email = "jim@sailor.com",
                        Skill = sailor.Skill
                    },
                    new Contact()
                    {
                        FirstName = "Jane",
                        LastName = "Sailor",
                        Email = "jane@sailor.com",
                        Skill = sailor.Skill
                    },
                    new Contact()
                    {
                        FirstName = "Bob",
                        LastName = "Fisher",
                        Email = "jim@fisher.com",
                        Skill = fisher.Skill
                    },
                    new Contact()
                    {
                        FirstName = "Susanne",
                        LastName = "Smith",
                        Email = "susanne@smith.com",
                        Skill = smith.Skill
                    },
                    new Contact()
                    {
                        FirstName = "James",
                        LastName = "Gardner",
                        Email = "james@gardner.com",
                        Skill = gardner.Skill
                    },
                    new Contact()
                    {
                        FirstName = "Perry",
                        LastName = "Mason",
                        Email = "perry@mason.com",
                        Skill = mason.Skill
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
