using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClickOpenSES.Models
{   
    public class Click : Open
    {
        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("linkTags")]
        public object LinkTags { get; set; }

    }   
}
