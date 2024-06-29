using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.core.Entity
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
