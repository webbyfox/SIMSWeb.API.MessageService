using System;
using MessageBird;
using MessageBird.Exceptions;
using MessageBird.Net.ProxyConfigurationInjector;
using MessageBird.Objects;
using System.Net;

namespace Examples.Message
{
    class CreateMessage
    {
        const string YourAccessKey = "n9343BVmEU3wIm3MROXoVOzls"; // your access key here.
        const long Msisdn = 447412218887; // your phone number here.

        static void Main(string[] args)
        {
            IProxyConfigurationInjector proxyConfigurationInjector = null; // for no web proxies, or web proxies not requiring authentication
            //proxyConfigurationInjector = new InjectDefaultCredentialsForProxiedUris(); // for NTLM based web proxies
            //proxyConfigurationInjector = new InjectCredentialsForProxiedUris(new NetworkCredential("rcs-ulm-cluster\rmansuri", "C0mput3r")); // for username/password based web proxies

            Client client = Client.CreateDefault(YourAccessKey, proxyConfigurationInjector);

            try
            {
                MessageBird.Objects.Message message = client.SendMessage("MessageBird", "Welcome to SIMS API Message Services", new[] { Msisdn });
                Console.WriteLine("{0}", message);
            }
            catch (ErrorException e)
            {
                // Either the request fails with error descriptions from the endpoint.
                if (e.HasErrors)
                {
                    foreach (Error error in e.Errors)
                    {
                        Console.WriteLine("code: {0} description: '{1}' parameter: '{2}'", error.Code, error.Description, error.Parameter);
                    }
                }
                // or fails without error information from the endpoint, in which case the reason contains a 'best effort' description.
                if (e.HasReason)
                {
                    Console.WriteLine(e.Reason);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
