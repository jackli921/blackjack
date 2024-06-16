namespace Blackjack;

public class Deck
{
    private List<Card> _cards = new List<Card>();
    private readonly Random random = new Random();
    public Deck()
    {
        this.Reset();
    }

    public void Reset()
    {
        _cards.Clear();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank value in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new Card(suit, value));
            }
        }
    }

    public void Shuffle()
    {
        _cards = _cards.OrderBy(c => random.Next()).ToList();
    }
    
    public Card DrawCard()
    {
        if (_cards.Count == 0) throw new InvalidOperationException("Deck is empty.");
        Card card = _cards[^1];
        _cards.RemoveAt(_cards.Count - 1);
        return card;
    }
}