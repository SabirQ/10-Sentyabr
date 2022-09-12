using ConsoleApplication10_09.Interfaces.Repositories;
using ConsoleApplication10_09.Interfaces.Services;
using ConsoleApplication10_09.Models;
using ConsoleApplication10_09.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Services
{
    public class MenuService:IMenuService
    {
        private readonly IPersonService _service;

        public MenuService()
        {
            
            _service = new PersonService();
        }
        public async Task Create()
        {
            Console.Clear();
        Name:
            Console.WriteLine("Main menu   (m)\n\nPlease,enter name:");
            string name = Console.ReadLine().Trim().ToLower();
            if (name == "m") return;
            if (!ValueValidate.CheckName(ref name))
            {
                Console.Clear();
                Console.WriteLine("Name is not valid\n");
                goto Name;
            }
        Surname:
            Console.WriteLine("Main menu   (m)\n\nPlease,enter surname:");
            string surname = Console.ReadLine().Trim().ToLower();
            if (name == "m") return;
            if (!ValueValidate.CheckName(ref surname))
            {
                Console.Clear();
                Console.WriteLine("Surname is not valid\n");
                goto Surname;
            }
        Phone:
            Console.WriteLine("Main menu   (m)\n\nPlease,enter phone number:");
            string phone = Console.ReadLine().Trim().ToLower();
            if (phone == "m") return;
            if (!ValueValidate.CheckPhone(phone))
            {
                Console.Clear();
                Console.WriteLine("Phone number is not valid\n");
                goto Phone;
            }
        Email:
            Console.WriteLine("Main menu   (m)\n\nPlease,enter email:");
            string email = Console.ReadLine().Trim().ToLower();
            if (email == "m") return;
            if (!ValueValidate.CheckMail(email))
            {
                Console.Clear();
                Console.WriteLine("Email is not valid\n");
                goto Email;
            }
        Save:
            Console.Clear();
            Console.WriteLine("Would you like to save?   (y/n)");
            string answer = Console.ReadLine().Trim().ToLower();
            if (answer == "y")
            {
                await _service.Add(name, surname, phone, email);
                Console.Clear();
                Console.WriteLine("Successfully added");
                return;
            }
            else if (answer == "n")
            {
                Console.Clear();
                Console.WriteLine("Operation canceled");
                return;
            }
            else goto Save;
        }
        public async Task ShowAll()
        {
           var people=await _service.GetPeopleAsync();
            Console.Clear();
            if (people==null)
            {
                Console.WriteLine("There is no Person");
                return;
            }
        Answer:
            foreach (var item in people)
            {
                Console.WriteLine($"Id:{item.Id} Name:{item.Name} Surname:{item.Surname} Phone:{item.Phone} Email:{item.Mail}");
            }
            
            Console.WriteLine("\nMain menu  (m)\nDelete a person  (d)");
            string answer=Console.ReadLine().Trim().ToLower();
            if (answer!="m"&&answer!="d")
            {
                Console.Clear();
                goto Answer;
            }

            if (answer == "m") { return; }
            Console.Clear();
            ID:
            Console.WriteLine("\nMain menu(m) \nEnter Id of person you need to delete:");
            answer=Console.ReadLine().Trim().ToLower();
            int num;
            bool result=int.TryParse(answer,out num);
            if (answer == "m") return;
            if (!result)
            {
                Console.Clear();
                Console.WriteLine("Id is not valid\n");
                goto ID;
            }
            var person = people.FirstOrDefault(x => x.Id == num);
            if (person==null)
            {
                Console.Clear();
                Console.WriteLine("Person not found");
                goto ID;
            }

            Sure:
            Console.WriteLine("Are you sure?  (y/n)\nnext person will be deleted:");
            Console.WriteLine($"Id:{person.Id} Name:{person.Name} Surname:{person.Surname} Phone:{person.Phone} Email:{person.Mail}");
            
            answer =Console.ReadLine().Trim().ToLower();
            if (answer == "y")
            {
                await _service.Remove(person.Id);
                Console.Clear();
                Console.WriteLine("Successfully deleted");
                return;
            }
            else if (answer == "n") return;
            else
            {
                Console.Clear();
                goto Sure;
            }


        }
        public async Task Search()
        {
            Console.Clear();
            Search:
            Console.WriteLine("Main menu  (m)\nWhat you would like to search?");
            string answer = Console.ReadLine().Trim().ToLower();
            if (String.IsNullOrEmpty(answer))
            {
                Console.Clear();
                Console.WriteLine("Value is not valid");
                goto Search;
            }
            if (answer == "m") {
                Console.Clear(); 
                return; 
            }
            var people=await _service.GetPeopleAsync(answer);
            if (people==null)
            {
                Console.Clear();
                Console.WriteLine("Not found");
                goto Search;
            }
            Console.Clear();
            foreach (var item in people)
            {
                Console.WriteLine($"Id:{item.Id} Name:{item.Name} Surname:{item.Surname} Phone:{item.Phone} Email:{item.Mail}");
            }
            Console.Write("Press any key to return menu:");
            Console.ReadLine();
            Console.Clear();
            return;
        }
    }
}