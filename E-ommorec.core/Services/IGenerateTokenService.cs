using E_commorec.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.Services
{
    public interface IGenerateTokenService
    {
        Task<string> GetAndCreateToken(AppUsers token);

    }
}
