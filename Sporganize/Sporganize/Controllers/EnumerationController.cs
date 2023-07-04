using Microsoft.AspNetCore.Mvc;
using Sporganize.Enumerations;

namespace Sporganize.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnumerationController : ControllerBase
    {

        [HttpGet("/branches")]
        public Branch[] GetBranches()
        {
            return (Branch[])Enum.GetValues(typeof(Branch));
        }

        [HttpGet("/genders")]
        public Gender[] GetGenders()
        {
            return (Gender[])Enum.GetValues(typeof(Gender));
        }

        [HttpGet("/roles")]
        public Role[] GetRoles()
        {
            return (Role[])Enum.GetValues(typeof(Role));
        }

    }

}
