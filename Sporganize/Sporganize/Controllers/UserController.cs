using Microsoft.AspNetCore.Mvc;
using Sporganize.DTO;
using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Repositories;
using Sporganize.Services;

namespace Sporganize.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/users-without-details")]
        public List<UserResponse> GetUsersWithoutDetails()
        {
            return _userService.GetWithoutDetails();
        }

        [HttpGet("/users/{id}")]
        public UserResponse GetUserById(int id)
        {
            return _userService.GetById(id);
        }

        [HttpGet("/users/friends/{id}")]
        public List<UserResponse> GetFriends(int id)
        {
            return _userService.GetFriends(id);
        }

        [HttpGet("/users/teams/{id}")]
        public List<TeamResponse> GetTeams(int id)
        {
            return _userService.GetTeams(id);
        }

        [HttpGet("/users/appointments/{id}")]
        public List<AppointmentResponse> GetAppointments(int id)
        {
            return _userService.GetAppointments(id);
        }

        [HttpPut("/users/{id}")]
        public UserResponse Update([FromForm] UserRequest request, int id)
        {
            return _userService.Update(request, id);
        }

    }

}
