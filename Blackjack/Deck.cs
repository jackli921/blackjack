namespace Blackjack;

public class Deck
{
    private List<Card> _cards;

    public Deck()
    {
        _cards = new List<Card>();
        this.Reset();
    }

    public void Shuffle()
    {
        Random rng = new Random();
        _cards = _cards.OrderBy(c => rng.Next()).ToList();
    }

    public void Reset()
    {
        _cards.Clear();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Value value in Enum.GetValues(typeof(Value)))
            {
                _cards.Add(new Card(suit, value));
            }
        }
    }
    
    public Card Draw()
    {
        if (_cards.Count == 0) throw new InvalidOperationException("Deck is empty.");
        Card card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }
}