using Sporganize.DTO.Responses;
using Sporganize.Models;

namespace Sporganize.DTO
{
    public static class ConvertToDto
    {
        public static UserResponse ToUserResponse(User user)
        {
            return new UserResponse()
            {
                Id= user.Id,
                Username = user.Username,
                Role = user.Role,
                Email = user.Email,
                Phone = user.Phone,
                FirstName= user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Gender = user.Gender
            };
        }

    }

}
