namespace Blackjack;

public class Hand
{
    private readonly List<Card> cards = new List<Card>();
    public IReadOnlyList<Card> Cards => cards.AsReadOnly();

    public Hand() => cards = new List<Card>();

    public void AddCard(Card card) => cards.Add(card);

    public bool IsBusted() => this.CalculateValue() > 21;

    public bool IsBlackjack() => cards.Count == 2 && CalculateValue() == 21;

    public int CalculateValue()
    {
        int value = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            value += (int)card.Value;
            if (card.Value == Value.Ace) aceCount++;
        }

        while (value > 21 && aceCount > 0)
        {
            value -= 10;
            aceCount--;
        }
        return value;
    }

    public override string ToString()
    {
        return string.Join(",", cards);
    }
}