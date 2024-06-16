﻿namespace Blackjack;


public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

public enum Value
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
    Jack = 10,
    Queen = 10,
    King = 10,
    Ace = 11
}

public class Card
{
    public Suit Suit { get; private set; }
    public Value Value { get; private set; }

    public Card(Suit suit, Value value)
    {
        Suit = suit;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}