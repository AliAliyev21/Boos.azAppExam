using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Boss.AzExamApplication
{
    public class Cv
    {
        public int Id { get; set; }
        public int CvId {  get; set; }
        public string? Name { get; set; }
        public string? Education { get; set; }
        public string? Companies { get; set; }
        public string? Experience { get; set; }
        public string? Skills { get; set; }
        public string? Certifications { get; set; }
        public string? Languages { get; set; }
        public string? Interests {  get; set; }
        public string? LinkedIn { get; set; }
        public string? GitLink {  get; set; }

        public Cv() { }

        public Cv(int id,string? name, string? education,
            string? companies, string? experience,
            string? skills, string? certifications,
            string? languages, string? ınterests,
            string? linkedIn, string? gitLink)
        {
            Id = ++CvId;
            Id = id;
            Name = name;
            Education = education;
            Companies = companies;
            Experience = experience;
            Skills = skills;
            Certifications = certifications;
            Languages = languages;
            Interests = ınterests;
            LinkedIn = linkedIn;
            GitLink = gitLink;
        }

        public override string ToString()
        {
            return $"ID: {Id}\nName : {Name}\nEducation : {Education}\nCompanies : {Companies}\nExperience : {Experience}\nSkills : {Skills}\nCertifications : {Certifications}\nLanguages : {Languages}\nInterests : {Interests}\nLinkedIn : {LinkedIn}\nGitHub : {GitLink}\n";
        }

        public void ShowCv()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("= > = >Cv Info< = < =");
            Console.WriteLine($"Id : {Id}");
            Console.ResetColor();
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Education : {Education}");
            Console.WriteLine($"Companies : {Companies}");
            Console.WriteLine($"Experience : {Experience}");
            Console.WriteLine($"Skills : {Skills}");
            Console.WriteLine($"Certifications : {Certifications}");
            Console.WriteLine($"Languages : {Languages}");
            Console.WriteLine($"Interests : {Interests}");
            Console.WriteLine($"LinkedIn : {LinkedIn}");
            Console.WriteLine($"GitLink : {GitLink}");
        }
    }
}

