namespace Blackjack;

public class Hand
{
    private readonly List<Card> cards = new List<Card>();
    public IReadOnlyList<Card> Cards => cards.AsReadOnly();

    public int Total
    {
        get
        {
            if (cards.Count == 0) return 0;
            
            int total = cards.Sum(card => card.Value);
            int aces = cards.Count(card => card.Rank == Rank.Ace);

            while (total > 21 && aces > 0)
            {
                total -= 10;
                aces--;
            }

            return total;
        }
    }
    public void AddCard(Card card) => cards.Add(card);

    public bool IsBusted() => Total > 21;

    public bool IsBlackjack() => cards.Count == 2 && Total == 21;

    public void Clear() => cards.Clear();
    public override string ToString()
    {
        return string.Join(",", cards);
    }
}