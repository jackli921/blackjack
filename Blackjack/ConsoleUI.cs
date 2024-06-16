namespace Blackjack;

public class ConsoleUI
{
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to Console Blackjack!");
        Console.WriteLine("----------------------------");
    }

    public static void DisplayPlayerHand(Player player)
    {
        Console.WriteLine($"{player.Name}'s hand:");
        foreach (var card in player.Hand.Cards)
        {
            Console.WriteLine($" {card}");
        }
        Console.WriteLine($"Total: {player.Hand.Total}");
    }

    public static void DisplayDealerHand(Dealer dealer, bool hideCard)
    {
        Console.WriteLine("Dealer's hand:");
        if (hideCard)
        {
            if (dealer.HiddenCard != null)
            {
                Console.WriteLine("  [Hidden]");
            }

            foreach (var card in dealer.Hand.Cards)
            {
                Console.WriteLine($"  {card}");
            }
        }
        else
        {
            if (dealer.HiddenCard != null)
            {
                Console.WriteLine($"  {dealer.HiddenCard}");
            }
            
            foreach (var card in dealer.Hand.Cards)
            {
                Console.WriteLine($"   {card}");
            }
            Console.WriteLine($"Total: {dealer.Hand.Total + (dealer.HiddenCard?.Value ?? 0)} ");
        }
    }

    public static bool GetPlayerchoice()
    {
        while (true)
        {
            Console.WriteLine("Do you want to hit (H) or stand (S)?");
            string choice = Console.ReadLine()?.Trim().ToUpper() ?? "";

            if (choice == "H") return true;
            if (choice == "S") return false;

            Console.WriteLine("Invalid choice. Please enter 'H' to hit or 'S' to stand.");
        }
    }

    public static void DisplayGameResult(string result)
    {
        Console.WriteLine(result);
    }
}