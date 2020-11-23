using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.Models
{
    public enum Rank {Ace=1, Two=2, Three=3, Four=4, Five=5, Six=6, Seven=7, Eight=8, Nine=9, Ten=10, Jack=11, Queen=12, King=13};
    public enum Suit {Spades=1, Hearts=2, Clubs=3, Diamonds=4};

    public class Card
    {
        public int CardId { get; set; }
        public Rank CardRank { get; set; }
        public Suit CardSuit { get; set; }
    }

    public class Deck
    {
        public int DeckId { get; set; }
        public Card[] Cards { get; set; }
    }
    
}