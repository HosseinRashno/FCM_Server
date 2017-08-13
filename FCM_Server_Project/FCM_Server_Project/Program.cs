using FCM_Server_Project.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM_Server_Project
{
    class Program
    {
        public const string SERVER_KEY = "YOUR_SERVER_KEY";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Type one of these commands: Topic/Id/Exit");
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "topic":
                        NotificationClass messageForTopic = GetTheMessage();
                        SendMessageToTopic(messageForTopic);
                        break;
                    case "id":
                        NotificationClass messageForId = GetTheMessage();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Your input was not correct! Try another one.");
                        break;
                }
            }
        }

        private static NotificationClass GetTheMessage()
        {
            NotificationClass message = new NotificationClass();

            Console.WriteLine("Insert the title:");
            message.title = Console.ReadLine();

            Console.WriteLine("Insert the body");
            message.body = Console.ReadLine();

            return message;
        }

        private static void SendMessageToTopic(NotificationClass message)
        {
            Console.WriteLine("Insert the topic name");
            string topicName = Console.ReadLine();

            RequestClass req = new RequestClass();
            req.to = StaticHelper.TOPIC_NAME_FORMAT+topicName;
            req.notification.title = message.title;
            req.notification.body = message.body;

            ResponseForTopic response = StaticHelper.SendMessageToTopic(req);

            if (response.ErrorCode == null && response.error == null)
                Console.Write("Message sent successfully.");
            else
                Console.Write("Failed to send message");
        }
    }
}
