

using EFCodeFirstApp.DAL;
using EFCodeFirstApp.Models;
using Microsoft.EntityFrameworkCore;

AppDbContext db = new AppDbContext();

await db.Categories.AddAsync(new Category
{
    CategoryName = "Test",
    Description = "Random text"
});

bool result = await db.SaveChangesAsync() > 0;
System.Console.WriteLine($"{result}");


