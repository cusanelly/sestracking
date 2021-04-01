using System;
using System.Collections.Generic;
using System.Text;

namespace ClickOpenSES.Models
{
    public class SetMessageModel
    {
        public string Body { get; set; }
        public string SourceEmail { get; set; }
        public string Subject { get; set; }
        public string RecipientEmail { get; set; }
    }
}
