using DataAccess.HrModuleEvents.Interfaces;
using Domain.HrModule;
using Microsoft.AspNetCore.Mvc;

namespace EventResourceArchWebApp.Controllers.HrModule
{
    [ApiController]
    [Route("Api/Users/")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public List<User> userData = new List<User>();

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            if(userData.Count == 0)
                userData = _userRepository.RefreshData();
        }
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(userData);
        }
        [HttpGet]
        [Route("RefreshData")]
        public IActionResult RefreshData()
        {
            userData = _userRepository.RefreshData();
            return Ok("Success");
        }
        [HttpPost]
        [Route("CraeteUser")]
        public IActionResult CreateUser(User user)
        {
            _userRepository.AddUser(user);
            return Ok(user);
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
            return Ok(user);
        }
        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            return Ok(user);
        }
    }
}
