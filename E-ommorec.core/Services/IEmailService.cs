using E_ommorec.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ommorec.core.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailModel email);
    }
}
