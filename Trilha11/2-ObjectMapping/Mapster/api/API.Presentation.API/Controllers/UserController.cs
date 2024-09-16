
using System.Linq;
using API.Domain.Entities;
using API.Domain.Queries.Login;
using API.Domain.Queries.Login.Results;
using API.Domain.Services;
using API.Presentation.API.Controllers.Base;
using API.Presentation.API.ViewModels.Login;
using API.Presentation.API.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using  API.CrossCutting.Utils.Response;
using API.Presentation.API.Attributes;
using API.Domain.Permissions;
using Mapster;

namespace API.Presentation.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("users")]
    public class UserController : BaseController
    {
        readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost /*, ActionAuthorize(ActionRoles.Admin)*/]
        public IActionResult CreateUser([FromBody]UserRequestViewModel userRequest)
        {
            if(ModelState.IsValid)
            {
                var user = userRequest.Adapt<User>();

                user.UserId = GetUserId();
                
                userService.Add(user);

                return StatusCode(201, true.AsSuccessResponse());
            }

            return StatusCode(304, true.AsSuccessResponse()); 
        }

        [HttpGet, Route("index")]
        public IActionResult  Index([FromQuery]int page, [FromQuery]string filter)
        {
            var users = userService.Index(page, filter);

            var response = users.Transform(employee => employee.Adapt<UserReponseViewModel>());

            return Ok(response.AsSuccessResponse());
        }

        [HttpGet]
        public IActionResult  GetAll()
        {
            var users = userService.GetAll();

            var response = users.Select(x => x.Adapt<UserReponseViewModel>()).ToList();

            return Ok(response.AsSuccessResponse());
        }

        [HttpPut, Route("{id}") /*, ActionAuthorize(ActionRoles.Admin)*/]
        public IActionResult Update(int id, [FromBody]UserRequestViewModel request)
        {
            var user = request.Adapt<User>();
        
            user.UserId = GetUserId();
            user.Id = id;

            userService.Update(user);

            return Ok(true.AsSuccessResponse());
        }

        [HttpDelete, Route("{id}") /*, ActionAuthorize(ActionRoles.Admin)*/]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);

            return StatusCode(204); 
        }

        [HttpPost, AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            LoginQuery loginQuery = login.Adapt<LoginQuery>();
            
            LoginQueryResult result = userService.Authenticate(loginQuery);

            if (result.Succeeded)
            {
                return Ok(result.Token.AsSuccessResponse());
            }

            return BadRequest();
        }
    }
}