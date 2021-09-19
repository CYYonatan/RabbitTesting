using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Security.Authentication;
using System.Net.Security;

namespace RabbitConnector
{
    class Program
    {
        static void Main(string[] args)
        {            
            string RabbitMqServerHostname = ConfigurationManager.AppSettings.Get("Host");

            Console.WriteLine(RabbitMqServerHostname);
            Console.WriteLine(ConfigurationManager.AppSettings.Get("UserName"));
            Console.WriteLine(ConfigurationManager.AppSettings.Get("Password"));
            Console.WriteLine(ConfigurationManager.AppSettings.Get("Port"));         

            var factory = new ConnectionFactory();            
            factory.HostName = ConfigurationManager.AppSettings["Host"];                                   
            factory.Ssl.Enabled = true;
            // Make sure TLS 1.2 is supported & enabled by your operating system
            factory.Ssl.Version = SslProtocols.Tls12;
            // This is the default RabbitMQ secure port
            factory.Port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));
            factory.VirtualHost = "/";
            // Standard RabbitMQ authentication (if not using ExternalAuthenticationFactory)
            factory.UserName = ConfigurationManager.AppSettings["UserName"];
            factory.Password = ConfigurationManager.AppSettings["Password"];            
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    Console.WriteLine("test");
                }
            }
        }
    }
}
