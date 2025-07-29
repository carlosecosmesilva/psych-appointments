using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychAppointments.Domain.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PsychologistId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public User? Psychologist { get; set; }
    }
}
