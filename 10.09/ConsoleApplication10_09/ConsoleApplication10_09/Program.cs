


using ConsoleApplication10_09.DAL;
using ConsoleApplication10_09.Interfaces.Repositories;
using ConsoleApplication10_09.Interfaces.Services;
using ConsoleApplication10_09.Repositories;
using ConsoleApplication10_09.Services;
using ConsoleApplication10_09.Utilities;


IMenuService menu = new MenuService();
Console:
Console.WriteLine("Add Contact    (a)\nList Contacts (l)\nSearch Contacts     (s)\n\nÇıkış(e)");
string str=Console.ReadLine().Trim().ToLower();
switch (str)
{
    case "a":
        await menu.Create();
        goto Console;
    case "l":
        await menu.ShowAll();
        goto Console;

    case "s":
        await menu.Search();
        goto Console;
    case "e":
        return;
    default:
        Console.Clear();
        goto Console;
}



