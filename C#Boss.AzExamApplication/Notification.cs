using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Boss.AzExamApplication
{
    public class Notification
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        public Notification() { }
        public Notification(string message, DateTime timestamp, bool isRead)
        {
            Id = ++NotificationId;
            Message = message;
            Timestamp = timestamp;
            IsRead = isRead;
        }

        public override string ToString()
        {
            return $"ID: {Id},\n Message: {Message},\n Timestamp: {Timestamp},\n Is Read: {IsRead}";
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }

        public void DisplayNotification()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("= > = > Notification Info < = < =");
            Console.WriteLine($"ID: {Id}");
            Console.ResetColor();
            Console.WriteLine($"Message: {Message}");
            Console.WriteLine($"Timestamp: {Timestamp}");
            Console.WriteLine($"Is Read: {IsRead}");
        }
    }
}
