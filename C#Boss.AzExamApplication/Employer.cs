using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Boss.AzExamApplication
{
    public class Employer
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public List<Worker>? Workers { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Announcement> Announcements { get; set; }

        public Employer()
        {
            Workers = new List<Worker>();
            Notifications = new List<Notification>();
            Announcements = new List<Announcement>();
        }

        public Employer(string name, string surname, string city, string phone, int age)
        {
            Id = ++EmployerId;
            Name = name;
            Surname = surname;
            City = city;
            Phone = phone;
            Age = age;
            Workers = new List<Worker>();
            Notifications = new List<Notification>();
            Announcements = new List<Announcement>();
        }


        public void AddAnnouncement(Announcement announcement)
        {
            Announcements.Add(announcement);
        }

        public void RemoveAnnouncement(Announcement announcement)
        {
            Announcements.Remove(announcement);
        }

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        public void ShowNotifications()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("= > Employer Notifications < =");
            Console.ResetColor();
            foreach (var notification in Notifications)
            {
                notification.DisplayNotification();
            }
        }

        public void ShowEmployer()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("= > = > Employer Info < = < =");
            Console.WriteLine($"Id : {Id}");
            Console.ResetColor();
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Surname : {Surname}");
            Console.WriteLine($"City : {City}");
            Console.WriteLine($"Phone : {Phone}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine("Workers :");
            if (Workers != null)
            {
                foreach (var worker in Workers)
                {
                    worker.ShowWorker();
                }
            }
            else
            {
                throw new ArgumentNullException("No workers available for this employer");
            }
        }
    }
}
