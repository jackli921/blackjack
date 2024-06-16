﻿namespace Blackjack;


public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

public enum Rank
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack, 
    Queen,
    King,
    Ace
}

public class Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public int Value => Rank <= Rank.Ten ? (int)Rank : (Rank == Rank.Ace ? 11 : 10);

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}