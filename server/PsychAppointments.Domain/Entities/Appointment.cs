using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychAppointments.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PsychologistId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime Date { get; set; }

        public User? Psychologist { get; set; }
        public User? Client { get; set; }
    }
}
