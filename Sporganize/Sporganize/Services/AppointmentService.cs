using Sporganize.DTO;
using Sporganize.DTO.Requests;
using Sporganize.DTO.Responses;
using Sporganize.Models;
using Sporganize.Repositories;

namespace Sporganize.Services
{
    public class AppointmentService : IAppointmentService
    {
        public readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<AppointmentResponse> GetAppointments()
        {
            List<AppointmentResponse> appointmentResponses= new List<AppointmentResponse>();
            foreach (var appointment in _appointmentRepository.GetAll())
            {
                appointmentResponses.Add(new AppointmentResponse(appointment));
            }

            return appointmentResponses;
        }

        public AppointmentResponse Add(AppointmentRequest request)
        {
            Appointment appointment = new Appointment()
            {
                Title = request.Title,
                Description = request.Description,
                PostTime = DateTime.Now,
                Branch = request.Branch,
                StreetId = request.StreetId,
                UserId = request.UserId
            };

            int id = _appointmentRepository.Add(appointment).Id;

            return new AppointmentResponse(_appointmentRepository.GetById(id));
        }


    }
}
