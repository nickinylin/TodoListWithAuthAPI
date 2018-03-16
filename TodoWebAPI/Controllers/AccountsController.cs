using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebAPI.Data;
using TodoWebAPI.Models.Entities;
using TodoWebAPI.ViewModels;
using TodoWebAPI.Helpers;
using TodoWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace TodoWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {

        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        //POST api/accounts

       [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);


            //Setting the username as the email, so it doesnt fail with no username. 
            userIdentity.UserName = userIdentity.Email;

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.User.AddAsync(new User { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }

        // GET: api/accounts
        [HttpGet]
        public IEnumerable<ElementModel> Get()
        {
            return _appDbContext.Elements;
        }



    }
}