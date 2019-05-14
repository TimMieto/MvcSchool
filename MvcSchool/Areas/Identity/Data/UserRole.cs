using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Areas.Identity.Data
{
    public class UserRole
    {
         public virtual string UserId { get; set; }
         public virtual string RoleId { get; set; }
    }
}
