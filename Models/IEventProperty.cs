using System;
using System.Collections.Generic;
using System.Text;

namespace ClickOpenSES.Models
{
    public interface IEventProperty
    {        
        DateTime timestamp { get; set; }        
        string userAgent { get; set; }        
        string ipAddress { get; set; }
    }
}
