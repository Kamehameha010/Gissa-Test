using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GissaWeb.Models.ViewModel
{
    public class UserRegister :TestUser
    {
        public ICollection<TestPhone> Phones { get; set; }
    }
}
