using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Interfaces.Services
{
    public interface IMenuService
    {
        Task Create();
        Task ShowAll();
        Task Search();
    }
}
