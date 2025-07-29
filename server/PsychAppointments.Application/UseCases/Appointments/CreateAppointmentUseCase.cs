using PsychAppointments.Application.Interfaces;
using PsychAppointments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychAppointments.Application.UseCases.Appointments
{
    public class CreateAppointmentUseCase
    {
        private readonly IAppointmentRepository _repository;

        public CreateAppointmentUseCase(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Appointment appointment)
        {
            await _repository.AddAsync(appointment);
        }
    }
}
