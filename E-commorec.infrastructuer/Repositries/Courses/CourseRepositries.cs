using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.infrastructuer.Data;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.infrastructuer.Repositries.Courses
{
    internal class CourseRepositries : GenericRepositries<Course>, ICourse
    {
        public CourseRepositries(AppDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
        }
    }
}
