using ConsoleApplication10_09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Interfaces.Services
{
    public interface IPersonService
    {
        Task Add(string name, string surname, string phone, string mail);
        Task<ICollection<Person>> GetPeopleAsync(string search = null);
        Task<bool> Remove(int id);

    }
}
