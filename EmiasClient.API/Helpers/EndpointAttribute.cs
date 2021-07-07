using System;

namespace EmiasClient.API.Helpers
{
    public class EndpointAttribute : Attribute
    {
        public string Endpoint { get; set; }
        
        public EndpointAttribute(string endpoint)
        {
            Endpoint = endpoint;
        }
    }
}