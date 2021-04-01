using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClickOpenSES.Models
{
    public class Open : IEventProperty
    {
        public DateTime timestamp { get ; set ; }
        public string userAgent { get ; set ; }
        public string ipAddress { get ; set ; }
    }
}