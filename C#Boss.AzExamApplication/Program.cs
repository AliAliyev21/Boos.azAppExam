using System.Text.Json;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Globalization;

namespace C_Boss.AzExamApplication
{
    public class Program
    {

        #region MyMenuFunctions
        public static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t  = > = > = > Welcome To Boos.az < = < = < =\n");
            Console.ResetColor();
            Console.WriteLine("Employer  [1]\t\t\t\t\tWorker  [2]\n\t\t\t   Back  [3]");
        }

        public static void EmployerMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\t= > = > Employer Menu < = < =");
            Console.ResetColor();
            Console.WriteLine("Show All CVs         [1]");
            Console.WriteLine("Show All Workers     [2]");
            Console.WriteLine("Show Announcement    [3]");
            Console.WriteLine("Add Announcement     [4]");
            Console.WriteLine("Remove Announcement  [5]");
            Console.WriteLine("Show Notifications   [6]");
            Console.WriteLine("Back to Main Menu    [0]");
        }

        public static void WorkerMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\t= > = > Worker Menu < = < =");
            Console.ResetColor();
            Console.WriteLine("Show Announcement          [1]");
            Console.WriteLine("Apply for an Announcement  [2]");
            Console.WriteLine("Show Notifications         [3]");
            Console.WriteLine("Create my Cv               [4]");
            Console.WriteLine("Show All Cv                [5]");
            Console.WriteLine("Filters                    [6]");
            Console.WriteLine("Back to Main Menu          [0]");
        }
        #endregion

        static void Main(string[] args)
        {
            List<Cv> cvs = new List<Cv>
            {
                new Cv
                {
                    Id=1,
                    Name="Jonh Jonhlu",
                    Education="Computer Science",
                    Companies="Microsoft",
                    Experience="10 year",
                    Skills="C#,C++,Java,Python,Php",
                    Certifications="Microsoft Certified",
                    Languages="English",
                    Interests="Write Code",
                    LinkedIn="linkedin.com/johnjonhlu",
                    GitLink="github.com/jonhjonhlu",
                },
                new Cv
                {
                    Id=2,
                    Name="Eva Wilson",
                    Education="Computer Science",
                    Companies="Nasa",
                    Experience="15 year",
                    Skills="FullStack",
                    Certifications="Nasa Certified",
                    Languages="English,Spanish",
                    Interests="Tennis",
                    LinkedIn="linkedin.com/evawilson",
                    GitLink="github.com/evawilson",
                },
            };

            List<Announcement> announcements = new List<Announcement>
            {
                new Announcement
                {
                    Id = 1,
                    Title="Software Engineer",
                    Description="Join our software development team",
                    DatePosted=DateTime.Now,
                    Salary=60000,
                    Location="San Francisco",
                },
                new Announcement
                {
                    Id = 2,
                    Title="Hardware Engineer",
                    Description="Hardware design position available",
                    DatePosted=DateTime.Now,
                    Salary=50000,
                    Location="New York",
                },
                new Announcement
                {
                    Id = 3,
                    Title="Marketing Manager",
                    Description="Lead our marketing efforts",
                    DatePosted=DateTime.Now,
                    Salary=40000,
                    Location="Los Angeles",
                },
                new Announcement
                {
                    Id = 4,
                    Title="Financial Analyst",
                    Description="Join our finance department",
                    DatePosted=DateTime.Now,
                    Salary=45000,
                    Location="Chicago",
                },
                new Announcement
                {
                    Id = 5,
                    Title="Mechanical Designer",
                    Description="Design mechanical systems",
                    DatePosted=DateTime.Now,
                    Salary=55000,
                    Location="Canada",
                },
            };

            List<Worker> workers = new List<Worker>
            {
                new Worker
                {
                    Name = "John",
                    Surname = "Doe",
                    City = "New York",
                    Email = "john@example.com",
                    Salary = 75000
                },
                new Worker
                {
                    Name = "Eva",
                    Surname = "Wilson",
                    City = "San Francisco",
                    Email = "eva@example.com",
                    Salary = 80000
                },
            };

            List<Employer> employers = new List<Employer>
            {
                new Employer
                {
                    Id=1,
                    Name="Elon",
                    Surname="Musk",
                    City="United State",
                    Phone="123-456-789",
                    Age=38,
                },
                new Employer
                {
                    Id=1,
                    Name="Bil",
                    Surname="Gates",
                    City="United State",
                    Phone="987-654-321",
                    Age=55,
                },
            };

            List<Notification> notifications = new List<Notification> { };

            Employer employer = new Employer();
            Worker worker = new Worker();

            #region MyCVSJsonFileWriteAndRead
            static void WriteJsonCv(List<Cv> cvs)
            {
                var serializer = new JsonSerializer();
                try
                {
                    using (var sw = new StreamWriter("cvs.json"))
                    {
                        using (var jw = new JsonTextWriter(sw))
                        {
                            jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                            serializer.Serialize(jw, cvs);
                        }
                    }
                    Console.WriteLine("CVs successfully written to cvs.json.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error writing to file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error serializing CVs to JSON: {ex.Message}");
                }
            }

            static List<Cv> ReadJsonCv()
            {
                var serializer = new JsonSerializer();
                List<Cv> cvs = new List<Cv>();

                try
                {
                    using (var sr = new StreamReader("cvs.json"))
                    {
                        using (var jr = new JsonTextReader(sr))
                        {
                            cvs = serializer.Deserialize<List<Cv>>(jr);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("CVs successfully read from cvs.json.");
                    Console.ResetColor();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The 'cvs.json' file was not found.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON data: {ex.Message}");
                }
                return cvs;
            }

            if (!File.Exists("cvs.json"))
            {
                WriteJsonCv(cvs);
            }

            cvs = ReadJsonCv();
            foreach (var item in cvs)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region MyANNOUNCEMENTJsonFileWriteAndRead

            static void WriteJsonAnnouncement(List<Announcement> announcements)
            {
                var serializer = new JsonSerializer();
                try
                {
                    using (var sw = new StreamWriter("announcement.json"))
                    {
                        using (var jw = new JsonTextWriter(sw))
                        {
                            jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                            serializer.Serialize(jw, announcements);
                        }
                    }
                    Console.WriteLine("Announcement successfully written to announcement.json.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error writing to file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error serializing Announcement to JSON: {ex.Message}");
                }
            }

            static List<Announcement> ReadJsonAnnouncement()
            {
                var serializer = new JsonSerializer();
                List<Announcement> announcements = new List<Announcement>();

                try
                {
                    using (var sr = new StreamReader("announcement.json"))
                    {
                        using (var jr = new JsonTextReader(sr))
                        {
                            announcements = serializer.Deserialize<List<Announcement>>(jr);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Announcements successfully read from announcement.json.");
                    Console.ResetColor();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The 'announcement.json' file was not found.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON data: {ex.Message}");
                }
                return announcements;
            }

            if (!File.Exists("announcement.json"))
            {
                WriteJsonAnnouncement(announcements);
            }

            announcements = ReadJsonAnnouncement();
            foreach (var item in announcements)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region MyWORKERJsonFileWriteAndRead
            static void WriteJsonWorker(List<Worker> workers)
            {
                var serializer = new JsonSerializer();
                try
                {
                    using (var sw = new StreamWriter("workers.json"))
                    {
                        using (var jw = new JsonTextWriter(sw))
                        {
                            jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                            serializer.Serialize(jw, workers);
                        }
                    }
                    Console.WriteLine("Workers successfully written to workers.json.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error writing to file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error serializing Workers to JSON: {ex.Message}");
                }
            }

            static List<Worker> ReadJsonWorker()
            {
                var serializer = new JsonSerializer();
                List<Worker> workers = new List<Worker>();

                try
                {
                    using (var sr = new StreamReader("workers.json"))
                    {
                        using (var jr = new JsonTextReader(sr))
                        {
                            workers = serializer.Deserialize<List<Worker>>(jr);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Workers successfully read from workers.json.");
                    Console.ResetColor();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The 'workers.json' file was not found.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON data: {ex.Message}");
                }
                return workers;
            }

            if (!File.Exists("workers.json"))
            {
                WriteJsonWorker(workers);
            }

            workers = ReadJsonWorker();
            foreach (var item in workers)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region MyEMPLOYERJsonFileAndRead
            static void WriteJsonEmployer(List<Employer> employers)
            {
                var serializer = new JsonSerializer();
                try
                {
                    using (var sw = new StreamWriter("employers.json"))
                    {
                        using (var jw = new JsonTextWriter(sw))
                        {
                            jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                            serializer.Serialize(jw, employers);
                        }
                    }
                    Console.WriteLine("Employers successfully written to employers.json.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error writing to file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error serializing Employers to JSON: {ex.Message}");
                }
            }

            static List<Employer> ReadJsonEmployer()
            {
                var serializer = new JsonSerializer();
                List<Employer> employers = new List<Employer>();

                try
                {
                    using (var sr = new StreamReader("employers.json"))
                    {
                        using (var jr = new JsonTextReader(sr))
                        {
                            employers = serializer.Deserialize<List<Employer>>(jr);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Employers successfully read from employers.json.");
                    Console.ResetColor();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The 'employers.json' file was not found.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON data: {ex.Message}");
                }
                return employers;
            }

            if (!File.Exists("employers.json"))
            {
                WriteJsonEmployer(employers);
            }

            //employers = ReadJsonEmployer();
            //foreach (var item in employers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region MyNOTIFICATIONJsonFileWriteAndRead
            static void WriteJsonNotification(List<Notification> notifications)
            {
                var serializer = new JsonSerializer();
                try
                {
                    using (var sw = new StreamWriter("notifications.json"))
                    {
                        using (var jw = new JsonTextWriter(sw))
                        {
                            jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                            serializer.Serialize(jw, notifications);
                        }
                    }
                    Console.WriteLine("notifications successfully written to notifications.json.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error writing to file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error serializing notifications to JSON: {ex.Message}");
                }
            }

            static List<Notification> ReadJsonNotification()
            {
                var serializer = new JsonSerializer();
                List<Notification> notifications = new List<Notification>();

                try
                {
                    using (var sr = new StreamReader("notifications.json"))
                    {
                        using (var jr = new JsonTextReader(sr))
                        {
                            notifications = serializer.Deserialize<List<Notification>>(jr);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Notifications successfully read from notifications.json.");
                    Console.ResetColor();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The 'notifications.json' file was not found.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON data: {ex.Message}");
                }
                return notifications;
            }

            if (!File.Exists("notifications.json"))
            {
                WriteJsonNotification(notifications);
            }

            //notifications = ReadJsonNotification();
            //foreach (var item in notifications)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            string user = "ali";
            string pass = "123";
            Console.Write("Please enter username : ");
            string userName = Console.ReadLine();
            Console.Write("Please enter passworrd : ");
            string userPassworrd = Console.ReadLine();
            if (userName == user && userPassworrd == pass)
            {
                while (true)
                {
                    Console.Clear();
                    MainMenu();
                    Console.Write("Please choice : ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.Clear();
                        while (true)
                        {
                            EmployerMenu();
                            Console.Write("Employer please select : ");
                            string selectEmployer = Console.ReadLine();
                            if (selectEmployer == "1")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > All CVs < = < = < =");
                                Console.ResetColor();
                                foreach (var cv in cvs)
                                {
                                    cv.ShowCv();
                                    Console.WriteLine();
                                }
                            }
                            else if (selectEmployer == "2")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > All Workers < = < = < =");
                                Console.ResetColor();
                                foreach (var item in workers)
                                {
                                    item.ShowWorker();
                                    Console.WriteLine();
                                }
                            }
                            else if (selectEmployer == "3")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > All Announcement < = < = < =");
                                Console.ResetColor();
                                foreach (var announcement in announcements)
                                {
                                    announcement.ShowAnnouncement();
                                    Console.WriteLine();
                                }
                            }
                            else if (selectEmployer == "4")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > Add Announcement < = < = < =");
                                Console.ResetColor();
                                Console.Write("Title : ");
                                string title = Console.ReadLine();
                                Console.Write("Description : ");
                                string description = Console.ReadLine();
                                Console.Write("Salary : ");
                                decimal salary;
                                while (!decimal.TryParse(Console.ReadLine(), out salary))
                                {
                                    Console.Write("Invalid input. Please enter a valid decimal value for Salary : ");
                                }
                                Console.Write("Location : ");
                                string location = Console.ReadLine();
                                var newAnnouncement = new Announcement(title, description, DateTime.Now, salary, location);
                                announcements.Add(newAnnouncement);
                                //Json file yazildi
                                WriteJsonAnnouncement(announcements);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Announcement added successfully!");
                                Console.ResetColor();
                            }
                            else if (selectEmployer == "5")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > Remove Announcement < = < = < =");
                                Console.ResetColor();
                                Console.WriteLine("Existing Announcements");
                                foreach (var announcement in announcements)
                                {
                                    Console.WriteLine($"{announcement.Id} : {announcement.Title}");
                                }
                                Console.Write("Enter the ID of the announcement to remove : ");
                                if (int.TryParse(Console.ReadLine(), out int removeAnnouncementId))
                                {
                                    var announcementToRemove = announcements.FirstOrDefault(a => a.Id == removeAnnouncementId);
                                    if (announcementToRemove != null)
                                    {
                                        announcements.Remove(announcementToRemove);
                                        //Json file dan silindi
                                        WriteJsonAnnouncement(announcements);
                                        Console.WriteLine("Announcement removed successfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Announcement with the specified ID not found!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid ID");
                                }
                            }
                            else if (selectEmployer == "6")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > Show Notifications < = < = < =");
                                Console.ResetColor();
                                foreach (var notification in employer.Notifications)
                                {
                                    notification.DisplayNotification();
                                    Console.WriteLine();
                                }

                                Console.Write("Enter the ID of the notification you want to take action on (Accept/Reject) : ");
                                if (int.TryParse(Console.ReadLine(), out int actionNotificationId))
                                {
                                    var notificationToAction = employer.Notifications.FirstOrDefault(n => n.Id == actionNotificationId);
                                    if (notificationToAction != null)
                                    {
                                        Console.Write("Do you want to Accept (A) or Reject (R) this application? :");
                                        string action = Console.ReadLine().ToUpper();
                                        if (action == "A")
                                        {
                                            notificationToAction.MarkAsRead();                                     
                                            //Json file qeyd olundu
                                            WriteJsonNotification(notifications);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Application accepted successfully!");
                                            Console.ResetColor();
                                        }
                                        else if (action == "R")
                                        {
                                            notificationToAction.MarkAsRead();
                                            //Json file qeyd olundu
                                            WriteJsonNotification(notifications);
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Application rejected!");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid action. Please enter 'A' for Accept or 'R' for Reject.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Notification with the specified ID not found!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid ID");
                                }
                            }
                            else if (selectEmployer == "0")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please try again");
                            }
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.Clear();
                        while (true)
                        {
                            WorkerMenu();
                            Console.Write("Worker please select : ");
                            string selectWorker = Console.ReadLine();
                            if (selectWorker == "1")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > Show Announcement < = < = < =");
                                Console.ResetColor();
                                foreach (var announcement in announcements)
                                {
                                    announcement.ShowAnnouncement();
                                    Console.WriteLine();
                                }
                            }
                            else if (selectWorker == "2")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > Apply for an Announcement < = < = < =");
                                Console.WriteLine("Available Announcements");
                                Console.ResetColor();
                                foreach (var announcement in announcements)
                                {
                                    announcement.ShowAnnouncement();
                                    Console.WriteLine();
                                }

                                Console.Write("Enter the ID of the announcement you want to apply for : ");
                                if (int.TryParse(Console.ReadLine(), out int applyAnnouncementId))
                                {
                                    var announcementToApply = announcements.FirstOrDefault(a => a.Id == applyAnnouncementId);
                                    if (announcementToApply != null)
                                    {
                                        var notification = new Notification($"Worker {worker.Name} has applied for the announcement {announcementToApply.Title}", DateTime.Now, false);

                                        //Json file qeyd olundu
                                        WriteJsonNotification(notifications);
                                        employer.AddNotification(notification);

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Application sent successfully!");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Announcement with the specified ID not found!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                                }
                            }
                            else if (selectWorker == "3")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > Show Notifications < = < = < =");
                                Console.ResetColor();
                                foreach (var notification in employer.Notifications)
                                {
                                    notification.DisplayNotification();
                                    Console.WriteLine();
                                }
                            }
                            else if (selectWorker == "4")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > Create my CV < = < = < =");
                                Console.ResetColor();

                                Console.Write("Enter your Name : ");
                                string name = Console.ReadLine();

                                Console.Write("Enter your Education : ");
                                string education = Console.ReadLine();

                                Console.Write("Enter your Companies : ");
                                string companies = Console.ReadLine();

                                Console.Write("Enter your Experience : ");
                                string experience = Console.ReadLine();

                                Console.Write("Enter your Skills (comma-separated) : ");
                                string skills = Console.ReadLine();

                                Console.Write("Enter your Certifications : ");
                                string certifications = Console.ReadLine();

                                Console.Write("Enter your Languages (comma-separated) : ");
                                string languages = Console.ReadLine();

                                Console.Write("Enter your Interests : ");
                                string interests = Console.ReadLine();

                                Console.Write("Enter your LinkedIn profile link : ");
                                string linkedIn = Console.ReadLine();

                                Console.Write("Enter your GitHub profile link : ");
                                string gitLink = Console.ReadLine();

                                int lastCvId=2;
                                int newCvId = ++lastCvId;

                                var newCv = new Cv(newCvId, name, education,companies, experience, skills, certifications, languages, interests, linkedIn,gitLink);                                
                                cvs.Add(newCv);
                                //Json file qeyd olundu
                                WriteJsonCv(cvs);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("CV created and added successfully!");
                                Console.ResetColor();
                            }
                            else if (selectWorker == "5")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t= > = > = > All CVs < = < = < =");
                                Console.ResetColor();
                                foreach (var cv in cvs)
                                {
                                    cv.ShowCv();
                                    Console.WriteLine();
                                }
                            }
                            else if (selectWorker == "6")
                            {
                                Console.Clear();
                                Console.WriteLine("Choose a filter option:");
                                Console.WriteLine("1. Filter by Education");
                                Console.WriteLine("2. Filter by Language");
                                Console.WriteLine("3. Filter by Skill");
                                Console.Write("Enter your choice (1/2/3) : ");
                                string choiceFilter = Console.ReadLine();
                                if (choiceFilter == "1")
                                {
                                    Console.Write("Enter the education name to filter by the education you want to display : ");
                                    string viewEducation = Console.ReadLine();
                                    var filteredCvsByEducation = worker.FilterCvsByEducation(cvs, viewEducation);
                                    if (filteredCvsByEducation.Count == 0)
                                    {
                                        Console.WriteLine("No CVs match the specified education");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Filtered CVs for education : " + viewEducation);
                                        foreach (var cv in filteredCvsByEducation)
                                        {
                                            cv.ShowCv();
                                            Console.WriteLine();
                                        }
                                    }
                                }
                                else if (choiceFilter == "2")
                                {
                                    Console.Write("Enter the language name to filter by the language you want to display : ");
                                    string viewLanguage = Console.ReadLine();
                                    var filteredCvsByLanguage = worker.FilterCvsByLanguage(cvs, viewLanguage);
                                    if (filteredCvsByLanguage.Count == 0)
                                    {
                                        Console.WriteLine("No CVs match the specified language");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Filtered CVs for language : " + viewLanguage);
                                        foreach (var cv in filteredCvsByLanguage)
                                        {
                                            cv.ShowCv();
                                            Console.WriteLine();
                                        }
                                    }
                                }
                                else if (choiceFilter == "3")
                                {
                                    Console.Write("Enter the skill name to filter by the skill you want to display : ");
                                    string viewSkill = Console.ReadLine();
                                    var filteredCvsBySkill = worker.FilterCvsBySkill(cvs, viewSkill);
                                    if (filteredCvsBySkill.Count == 0)
                                    {
                                        Console.WriteLine("No CVs match the specified skill");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Filtered CVs for skill : " + viewSkill);
                                        foreach (var cv in filteredCvsBySkill)
                                        {
                                            cv.ShowCv();
                                            Console.WriteLine();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3");
                                }
                                Console.WriteLine("Press ENTER to continue");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (selectWorker == "0")
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please try again");
                            }

                        }
                    }
                    else if (choice == "3")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Exiting program.....!");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
            }
            else
            {
                Console.WriteLine("Please try your incorrect username or password again");
            }
        }
    }
}