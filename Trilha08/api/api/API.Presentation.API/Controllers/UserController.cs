
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
using  API.Infra.Utils.Response;
using API.Presentation.API.Attributes;
using API.Domain.Permissions;

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
                var user = Mapper.Map<User>(userRequest);
                user.UserId = GetUserId();
                var response = userService.Add(user);

                if(response == true)
                    return StatusCode(201, response.AsSuccessResponse());
            }
            return StatusCode(304, true.AsSuccessResponse()); 
        }

        [HttpGet, Route("index")]
        public IActionResult  Index([FromQuery]int page, [FromQuery]string filter)
        {
            var users = userService.Index(page, filter);

            var response = users.Transform(employee => Mapper.Map<UserReponseViewModel>(employee));

            return Ok(response.AsSuccessResponse());
        }

        [HttpGet]
        public IActionResult  GetAll()
        {
            var users = userService.GetAll();

            var response = users.Select(Mapper.Map<UserReponseViewModel>).ToList();

            return Ok(response.AsSuccessResponse());
        }

        [HttpPut, Route("{id}") /*, ActionAuthorize(ActionRoles.Admin)*/]
        public IActionResult Update(int id, [FromBody]UserRequestViewModel request)
        {
            var user = Mapper.Map<User>(request);
            user.UserId = GetUserId();
            user.Id = id;

            var response = userService.Update(user);

            if(!response)
            {
                return NotFound();
            }

            return Ok();
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
            LoginQuery loginQuery = Mapper.Map<LoginQuery>(login);
            LoginQueryResult result = userService.Authenticate(loginQuery);

            if (result.Succeeded)
            {
                return Ok(result.Token.AsSuccessResponse());
            }

            return BadRequest();
        }
    }
}