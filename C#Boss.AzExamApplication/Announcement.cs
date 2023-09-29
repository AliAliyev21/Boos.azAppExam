using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Boss.AzExamApplication
{
    public class Announcement
    {
        public int Id { get; set; }
        public int AnnouncementId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DatePosted { get; set; }
        public decimal Salary { get; set; }
        public string? Location { get; set; }

        public Announcement() { }

        public Announcement(string title, string description, DateTime datePosted, decimal salary, string location)
        {
            Id = ++AnnouncementId;
            Title = title;
            Description = description;
            DatePosted = datePosted;
            Salary = salary;
            Location = location;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nAnnouncementId : {AnnouncementId}\nTitle : {Title}\nDescription : {Description}\nDatePosted : {DatePosted}\nSalary : {Salary}\nLocation : {Location}";
        }

        public void ShowAnnouncement()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("= > = >Announcement Info< = < =");
            Console.WriteLine($"Id : {Id}");
            Console.ResetColor();
            Console.WriteLine($"Title : {Title}");
            Console.WriteLine($"Description : {Description}");
            Console.WriteLine($"Date Posted : {DatePosted}");
            Console.WriteLine($"Salary : {Salary}");
            Console.WriteLine($"Location : {Location}");
        }
    }
}

