using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebAPI.ViewModels;
using FluentValidation.Attributes;
using TodoWebAPI.ViewModels.Validations;

namespace TodoWebAPI.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
