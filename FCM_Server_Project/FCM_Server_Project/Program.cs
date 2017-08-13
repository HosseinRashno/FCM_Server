using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM_Server_Project
{
    class Program
    {
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
                        // TODO : Get information about message and send that to selected device id
                        break;
                    case "id":
                        // TODO : Get information about message and send that to selected topic
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Your input was not correct! Try another one.");
                        break;
                }
            }
        }
    }
}
