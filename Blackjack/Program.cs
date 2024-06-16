// See https://aka.ms/new-console-template for more information

using Blackjack;

ConsoleUI.DisplayWelcomeMessage();

Console.WriteLine("Enter your name: ");
string playerName = Console.ReadLine() ?? "Player";
Player player = new Player(playerName);

Game game = new Game(player);

bool playAgain = true;

while (playAgain == true)
{
    PlayOneRound(game);

    Console.WriteLine("Do you want to play again? (Y/N): ");
    string response = Console.ReadLine()?.Trim().ToUpper() ?? "N";
    playAgain = (response == "Y");
}

Console.WriteLine("Thanks for playing");
Console.WriteLine("Press any key to exist ...");
Console.ReadKey();

static void PlayOneRound(Game game)
{
    Player player = game.GetPlayer();
    Dealer dealer = game.GetDealer();
    
    game.StartNewRound();
    
    ConsoleUI.DisplayPlayerHand(player);
    ConsoleUI.DisplayDealerHand(dealer, true);

    while (!player.Hand.IsBusted() && ConsoleUI.GetPlayerchoice())
    {
        game.PlayerTurn(true);
        ConsoleUI.DisplayPlayerHand(player);
    }

    if (!player.Hand.IsBusted())
    {
        game.DealerTurn();
        ConsoleUI.DisplayDealerHand(dealer, false);
    }

    string result = game.DetermineWinner();
    ConsoleUI.DisplayGameResult(result);

}