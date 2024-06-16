namespace Blackjack;

public class Player
{
    public string Name { get; private set; }
    public Hand Hand { get; private set; }

    public Player(string name)
    {
        Name = name;
        Hand = new Hand();
    }

    public virtual void Hit(Card card) => Hand.AddCard(card);

    public virtual void Stand() => Console.WriteLine($"Player: {Name} chose to stand.");
}

public class Dealer : Player
{
    public Dealer(): base("Dealer"){}
    
    public Card? HiddenCard { get; private set; }

    public override void Hit(Card card)
    {
        if (HiddenCard == null)
        {
            HiddenCard = card;
        }
        else
        {
            base.Hit(card);
        }
    }

    public void RevealHiddenCard()
    {
        if (HiddenCard != null)
        {
            Hand.AddCard(HiddenCard);
            HiddenCard = null;
        }
    }
}