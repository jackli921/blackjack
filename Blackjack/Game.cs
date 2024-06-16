namespace Blackjack;

public class Game
{
    private readonly Deck deck = new Deck();
    private readonly Player player;
    private readonly Dealer dealer = new Dealer();

    public Game(Player player)
    {
        this.player = player;
    }

    public Player GetPlayer() => player;
    public Dealer GetDealer() => dealer;
    public void StartNewRound()
    {
        deck.Reset();
        deck.Shuffle();
        
        player.Hand.Clear();
        dealer.Hand.Clear();
        
        this.DealInitialCards();
    }

    private void DealInitialCards()
    {
        player.Hit(deck.DrawCard());
        dealer.Hit(deck.DrawCard());
        player.Hit(deck.DrawCard());
        dealer.Hit(deck.DrawCard());
    }

    public void PlayerTurn(bool wantsToHit)
    {
        if (wantsToHit)
        {
            player.Hit(deck.DrawCard());
        }
        else
        {
            player.Stand();
        }
    }

    public void DealerTurn()
    {
        dealer.RevealHiddenCard();

        while (dealer.Hand.Total < 17)
        {
            dealer.Hit(deck.DrawCard());
        }
    }

    public string DetermineWinner()
    {
        if (player.Hand.IsBusted())
            return "Dealer wins!";

        if (dealer.Hand.IsBusted() || player.Hand.Total > dealer.Hand.Total)
        {
            return "Player wins!";
        }

        if (player.Hand.Total < dealer.Hand.Total)
            return "Dealer wins!";

        return "It's a tie;";
    }
}