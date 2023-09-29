using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Boss.AzExamApplication
{
    public class Worker
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public decimal Salary { get; set; }
        public List<Cv>? CVs { get; set; }
        public List<Notification>? Notifications { get; set; }

        public Worker()
        {
            CVs = new List<Cv>();
            Notifications = new List<Notification>();
        }

        public Worker(string? name, string? surname, string? city, string? email, decimal salary)
        {
            Id = ++WorkerId;
            Name = name;
            Surname = surname;
            City = city;
            Email = email;
            Salary = salary;
            CVs = new List<Cv>();
            Notifications = new List<Notification>();
        }

        public override string ToString()
        {
            return $"Name : {Name},\n Surname : {Surname},\n City : {City},\n Email : {Email},\n Salary : {Salary}";
        }

        public void AddCv(Cv cv)
        {
            if (CVs != null)
            {
                CVs.Add(cv);
            }
            else
            {
                throw new ArgumentNullException("Cannot be null here");
            }
        }

        public List<Cv> FilterCvsBySkill(List<Cv> allCvs, string viewSkill)
        {

            List<Cv> filteredCvs = allCvs.Where(cv => cv.Skills.Contains(viewSkill)).ToList();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Filtered CVs for Skill : {viewSkill}");
            Console.ResetColor();
            foreach (var cv in filteredCvs)
            {
                cv.ShowCv();
                Console.WriteLine();
            }
            return filteredCvs;
        }

        public List<Cv> FilterCvsByEducation(List<Cv> allCvs, string viewEducation)
        {
            List<Cv> filteredCvs = allCvs.Where(cv => cv.Education.Contains(viewEducation)).ToList();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Filtered CVs for Education : {viewEducation}");
            Console.ResetColor();
            foreach (var cv in filteredCvs)
            {
                cv.ShowCv();
                Console.WriteLine();
            }
            return filteredCvs;
        }

        public List<Cv> FilterCvsByLanguage(List<Cv> allCvs, string viewLanguage)
        {
            List<Cv> filteredCvs = allCvs.Where(cv => cv.Education.Contains(viewLanguage)).ToList();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Filtered CVs for Language : {viewLanguage}");
            Console.ResetColor();
            foreach (var cv in filteredCvs)
            {
                cv.ShowCv();
                Console.WriteLine();
            }
            return filteredCvs;
        }

        public void AddNotification(Notification notification)
        {
            if (Notifications!=null)
            {
                Notifications.Add(notification);       
            }
        }

        public void ShowNotifications()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("= > Worker Notifications < =");
            Console.ResetColor();
            foreach (var notification in Notifications)
            {
                notification.DisplayNotification();
            }
        }

        public void ShowWorker()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("= > = >Worker Info< = < =");
            Console.WriteLine($"Id : {Id}");
            Console.ResetColor();
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Surname : {Surname}");
            Console.WriteLine($"City : {City}");
            Console.WriteLine($"Email : {Email}");
            Console.WriteLine($"Salary : {Salary}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"CVs");
            Console.ResetColor();
            if(CVs!=null && CVs.Count > 0)
            {
                foreach (var cv in CVs)
                {
                    cv.ShowCv();
                }
            }
            else
            {
                Console.WriteLine("No CVs available for this worker");
            }
        }
    }
}
