using ConsoleApplication10_09.DAL;
using ConsoleApplication10_09.Interfaces.Repositories;
using ConsoleApplication10_09.Interfaces.Services;
using ConsoleApplication10_09.Models;
using ConsoleApplication10_09.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Services
{
    public class PersonService:IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService()
        {
            _repository = new PersonRepository(new AppDbContext());
        }

        public async Task Add(string name, string surname, string phone, string mail)
        {
            Person person = new Person(name, surname, phone, mail);
            person.CreatedAt=DateTime.Now;
            person.ModifiedAt=DateTime.Now;
            await _repository.AddAsync(person);
        }
        public async Task<ICollection<Person>> GetPeopleAsync(string search=null)
        {
            if (String.IsNullOrEmpty(search)) return await _repository.GetAllAsync();
            search = search.Trim().ToLower();
            return await _repository.GetAllAsync(x => x.Name.ToLower().Contains(search) || x.Surname.ToLower().Contains(search) ||
            x.Phone.Contains(search) || x.Mail.Contains(search) || x.Id.ToString().Contains(search));
        }
        public async Task<bool> Remove(int id)
        {
            Person person = await _repository.GetAsync(id);
            if (person == null) return false;
            await _repository.RemoveAsync(person);
            return true;
        }
    }
}