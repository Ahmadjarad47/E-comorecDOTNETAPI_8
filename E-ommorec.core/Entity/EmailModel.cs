using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ommorec.core.Entity
{
    public class EmailModel
    {
        public EmailModel(string to, string subject, string from, string content)
        {
            To = to;
            Subject = subject;
            From = from;
            this.content = content;
        }

        public string To { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }

        public string content { get; set; }
    }
}
