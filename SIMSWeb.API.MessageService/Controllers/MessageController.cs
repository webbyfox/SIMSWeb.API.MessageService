using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;
using SIMSWeb.API.MessageService.Models;

using MessageBird;
using MessageBird.Exceptions;
using MessageBird.Net.ProxyConfigurationInjector;
using MessageBird.Objects;


namespace SIMSWeb.API.MessageService.Controllers
{
    public class MessageController : ApiController
    {
    
        const string MBAccessKey = Constants.MbAccessKey;

        [HttpGet]
        [Route("")]
        public string[] Hello()
        {
            return new[]
            {
                "Hello, World!",
                "This is SIMS Message Service Project."
            };
        }


        [HttpGet]
        [Route("api/Message/TestingOnly/")]
        public bool TestingOnly()
        {
            var recipients = new Recipients();

            recipients.AddRecipient(447412218887);

            var Message = new Message("RCS", "Hello from Riz", recipients);

            var responseMessage = SendMessage(Message);

            return responseMessage;
        }

        [HttpPost]
        [Route("api/Message/SendMessage/")]
        public static bool SendMessage(Message ClientMessage)
        {
            //api/Message/SendMessage/var Body = ClientMessage.Body;
            var Body = "Hello from Riz";
            const long msisdn = 447412218887;

                 

            var recipients = ClientMessage.Recipients.Items;
            //recipients.AddRecipient(31612345678);
            //recipients.AddRecipient(List<Recipient> message.Recipients.Items);

            IProxyConfigurationInjector proxyConfigurationInjector = null; // for no web proxies, or web proxies not requiring authentication
            //proxyConfigurationInjector = new InjectDefaultCredentialsForProxiedUris(); // for NTLM based web proxies
            //proxyConfigurationInjector = new InjectCredentialsForProxiedUris(new NetworkCredential("username", "password")); // for username/password based web proxies

            Client client = Client.CreateDefault(MBAccessKey, proxyConfigurationInjector);

            try
            {
            //Recipients PhoneNumbers = message.Recipients; 
                MessageBird.Objects.Message message = client.SendMessage(Constants.Originator, Body, new [] { msisdn} );
                return true;
            }
            catch (ErrorException e)
            {
                throw e;
                //TODO SIMS logging
                return false;
            }

        }
    }
}