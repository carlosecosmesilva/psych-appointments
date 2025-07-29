using PsychAppointments.Application.Interfaces;
using PsychAppointments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychAppointments.Application.UseCases.Users
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _repository;

        public RegisterUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(User user)
        {
            var existingUser = await _repository.GetByEmailAsync(user.Email);
            if (existingUser is not null)
                throw new Exception("User already exists.");

            await _repository.AddAsync(user);
        }
    }
}
