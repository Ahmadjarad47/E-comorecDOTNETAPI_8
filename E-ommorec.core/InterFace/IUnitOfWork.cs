using E_ommorec.core.InterFace.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ommorec.core.InterFace
{
    public interface IUnitOfWork
    {
        public IUsers users { get; }
        public IAdminControllingUsers ControllingUsers { get; }
    }
}
