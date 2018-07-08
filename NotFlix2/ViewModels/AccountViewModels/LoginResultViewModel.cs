using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotFlix2.ViewModels.AccountViewModels
{
    public class LoginResultViewModel
    {
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public bool IsLogged { get; set; }

    }
}
