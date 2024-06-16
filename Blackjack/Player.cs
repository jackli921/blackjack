namespace Blackjack;

public class Player
{
    public string Name { get; private set; }
    public Hand Hand { get; private set; }
    public bool IsDealer { get; private set; }

    public virtual void Hit(Card card) => Hand.AddCard(card);

    public virtual void Stand() => Console.WriteLine($"Player: {Name} chose to stand.");

    public Player(string name, bool isDealer)
    {
        Name = name;
        Hand = new Hand();
        IsDealer = isDealer;

    }

    public void TakeTurn(Deck deck)
    {
        while (Hand.CalculateValue() < 17)
        {
            Hand.AddCard(deck.Draw());
        }
    }
}