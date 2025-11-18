using Cafe.ConsoleUI.Menus;
using Cafe.Infrastructure.Factories;

class Program
{
    static void Main()
    {
        var mainMenu = new MainMenu(new BeverageFactory());
        mainMenu.Start();
    }
}

