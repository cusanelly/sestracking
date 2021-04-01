using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClickOpenSES.Models
{
    public interface ISesEvent : IMessageProperty {        

        [JsonPropertyName("open")]
        Open Open { get; set; }

        [JsonPropertyName("click")]
        Click Click { get; set; }
    }

    public class SesEvent : ISesEvent
    {
        [JsonPropertyName("eventType")]
        public string EventType { get; set; }     
       
        [JsonPropertyName("mail")]
        public Mail Mail { get; set; }

        [JsonPropertyName("open")]
        public Open Open { get; set; }

        [JsonPropertyName("click")]
        public Click Click { get; set; }
    }
    
    public class Header
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
    public class CommonHeaders
    {
        [JsonPropertyName("from")]
        public List<string> From { get; set; }

        [JsonPropertyName("to")]
        public List<string> To { get; set; }

        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }
    }

    public class Tags
    {
        [JsonPropertyName("ses:operation")]
        public List<string> SesOperation { get; set; }

        [JsonPropertyName("ses:configuration-set")]
        public List<string> SesConfigurationSet { get; set; }
        [JsonPropertyName("email")]
        public List<string> Email { get; set; }

        [JsonPropertyName("ses:source-ip")]
        public List<string> SesSourceIp { get; set; }

        [JsonPropertyName("ses:from-domain")]
        public List<string> SesFromDomain { get; set; }

        [JsonPropertyName("ses:caller-identity")]
        public List<string> SesCallerIdentity { get; set; }
    }

    public class Mail
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("sendingAccountId")]
        public string SendingAccountId { get; set; }

        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        [JsonPropertyName("destination")]
        public List<string> Destination { get; set; }

        [JsonPropertyName("headersTruncated")]
        public bool HeadersTruncated { get; set; }

        [JsonPropertyName("headers")]
        public List<Header> Headers { get; set; }

        [JsonPropertyName("commonHeaders")]
        public CommonHeaders CommonHeaders { get; set; }

        [JsonPropertyName("tags")]
        public Tags Tags { get; set; }
    }
}
