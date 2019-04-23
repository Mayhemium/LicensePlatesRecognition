using System.Collections.Generic;
using System.Linq;
using Core;
using Infrastructure.Context;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.Services
{
    public class RegistrationsService : IRegistrationsService
    {
        private readonly RegistrationContext _context;

        public RegistrationsService(RegistrationContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetRegistrations()
        {
            return _context.RegistrationPlate.Select(i=>i.Code).ToArray();
        }

        public void AddRegistration(string code)
        {
            var plate = new RegistrationPlate()
            {
                Code = code
            };
            _context.RegistrationPlate.Add(plate);
            _context.SaveChanges();
        }

        public void DeleteRegistration(string code)
        {
            _context.RegistrationPlate.Remove(_context.RegistrationPlate.Single(a=>a.Code == code));
            _context.SaveChanges();
        }

        public bool Exists(string code)
        {
            return _context.RegistrationPlate.Any(a=>a.Code == code);
        }
    }
}