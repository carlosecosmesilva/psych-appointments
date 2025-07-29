using PsychAppointments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychAppointments.Application.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetByPsychologistIdAsync(Guid psychologistId);
        Task<Appointment?> GetByIdAsync(Guid id);
        Task AddAsync(Appointment appointment);
    }
}
