﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;
using System.Web.UI;
using SIMSWeb.API.MessageService.Models;

using MessageBird;
using MessageBird.Exceptions;
using MessageBird.Net.ProxyConfigurationInjector;
using MessageBird.Objects;


namespace SIMSWeb.API.MessageService.Controllers
{
    public class MessageController : ApiController
    {
    
        const string MbAccessKey = Constants.MbAccessKey;

        [HttpGet]
        [Route("")]
        public string[] Hello()
        {
            return new[]
            {
                "SIMS API",
                "This is SIMS Message Service API."
            };
        }


        [HttpGet]
        [Route("api/Message/TestingOnly/")]
        public bool TestingOnly()
        {
            var recipients = new Recipients();
            recipients.AddRecipient(447412218887);
            recipients.AddRecipient(447412218887);
            var Message = new Message("RCS", "Hello from Rizwan", recipients);

            var responseMessage = SendMessage(Message);

            return responseMessage;
        }

        [HttpPost]
        [Route("api/Message/SendMessage/")]
        public static bool SendMessage([FromBody] Message message)
        {
            
            IProxyConfigurationInjector proxyConfigurationInjector = null; 

            var client = Client.CreateDefault(MbAccessKey, proxyConfigurationInjector);

            try
            {
                var Phonelist = message.Recipients.Items.ToList();
                foreach (var item in Phonelist)
                {
                    var msisdn = item.Msisdn;
                    client.SendMessage(message.Originator, message.Body, new[] { msisdn });
                }
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