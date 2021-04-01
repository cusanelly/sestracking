using System;
using System.Collections.Generic;
using System.Text;

namespace ClickOpenSES.Models
{
    public interface IMessageProperty
    {
        string EventType { get; set; }
        Mail Mail { get; set; }
        
    }
}
