using ConsoleApplication10_09.DAL;
using ConsoleApplication10_09.Interfaces.Repositories;
using ConsoleApplication10_09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {

        }
    }
}
