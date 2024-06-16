namespace Blackjack;

public class Game
{
    private List<Player> players;
    private Deck deck;

    public Game()
    {
        players = new List<Player>
        {
            new Player("Player 1", false),
            new Player("Dealer", true)
        };
        deck = new Deck();
        deck.Shuffle();
    }

    public void StartGame()
    {
        DealInitialCards();
        foreach (Player player in players)
        {
            if (!player.IsDealer)
            {
                // add player interaction logic 
            }
        }
        foreach (Player player in players.Where(p => p.IsDealer))
        {
            player.TakeTurn(deck);
        }
        this.CheckForWinners();
    }

    private void DealInitialCards()
    {
        foreach (Player player in players)
        {
            player.Hand.AddCard(deck.Draw());
            player.Hand.AddCard(deck.Draw());
        }
    }

    private void CheckForWinners()
    {
        foreach (Player player in players)
        {
            Console.WriteLine($"{player.Name} has {player.Hand} with a value of {player.Hand.CalculateValue()}");
        }
        
    }
}