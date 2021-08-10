using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GissaWeb.Models.ViewModel
{
    public class UserRegister :User
    {
        public ICollection<Phone> Phones { get; set; }
    }
}
