using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAPI.ViewModels
{
    public class RegistrationViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string userName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
    }
}
