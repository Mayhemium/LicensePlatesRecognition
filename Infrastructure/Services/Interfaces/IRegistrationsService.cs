using System.Collections.Generic;

namespace Infrastructure.Services.Interfaces
{
    public interface IRegistrationsService
    {
        IEnumerable<string> GetRegistrations();
        void AddRegistration(string code);
        void DeleteRegistration(string code);
        bool Exists(string code);
    }
}