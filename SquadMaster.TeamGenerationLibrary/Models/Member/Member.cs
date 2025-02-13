using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.Models.Member
{
    public class Member : IMember
    {
        public Member()
        {
            // Generate ID while loading members from the file
            ID = Guid.NewGuid().ToString();

            Name = Resources.DefaultMemberName;

            Mobile = Array.Empty<String>();
        }

        public string ID { get; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public Gender Gender { get; set; }

        public string[] Mobile { get; set; }

        public Game PreferredGames { get; set; }

        public Department Department { get; set; }

        public string Email { get; set; }

        // Calculate Age of the Member based on Date of Birth
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - Dob.Year;

                try
                {
                    // Adjust if the birthday hasn't occurred yet this year
                    if (Dob.Date > today.AddYears(-age))
                    {
                        age--;
                    }
                }
                catch (Exception ex) when (ex is ArgumentOutOfRangeException)
                {
                }
                catch (Exception)
                {
                }
                return age;
            }
        }

        public override string ToString()
        {
            StringBuilder member = new();
            member.AppendLine($"ID: {ID}");
            member.AppendLine($"Name: {Name}");
            member.AppendLine($"Dob: {Dob}");
            member.AppendLine($"Gender: {Gender}");
            member.AppendLine($"Preferred Games: {PreferredGames}");
            member.AppendLine($"Department: {Department}");
            member.AppendLine($"Age: {Age}");
            member.AppendLine($"Email: {Email}");
            return member.ToString();
        }
    }
}
