using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;

namespace Sporganize.Services
{
    public interface IAppointmentService
    {
        public List<AppointmentResponse> GetAppointments();
        public AppointmentResponse Add(AppointmentRequest request);

    }

}
