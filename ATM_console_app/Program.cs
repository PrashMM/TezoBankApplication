
using Models;

class Program
{
    public static void Main()
    {
        WelcomeMenu();
    }
    public static void WelcomeMenu()
    {
        Console.WriteLine(Constants.welcomeMessage);
        Console.WriteLine(Constants.chooseOperation);

        while (true)
        {

            if (int.TryParse(Console.ReadLine(), out var userInput))
            {

                try
                {
                    switch (MainMenuByInput(userInput))
                    {
                        case MainMenu.OpenAccount:
                            RegisterNewHolder.OpenNewAccount();
                            break;

                        case MainMenu.Login:
                            LoginAndAccountOperation.AccountOperation();
                            break;

                        case MainMenu.Exit:
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                return;
            }

        }
    }

    public static MainMenu MainMenuByInput(int value)
    {
        switch (value)
        {
            case 1:
                return MainMenu.OpenAccount;
            case 2:
                return MainMenu.Login;
            case 3:
                return MainMenu.Exit;
            default:
                return default;
        }
    }
}
