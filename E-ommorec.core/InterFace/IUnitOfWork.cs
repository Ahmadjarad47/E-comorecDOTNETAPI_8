using E_commorec.core.InterFace.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.InterFace
{
    public interface IUnitOfWork
    {
        public IUsers users { get; }
        public IAdminControllingUsers ControllingUsers { get; }
    }
}
