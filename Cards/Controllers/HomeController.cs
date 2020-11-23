using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cards.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        

        public ActionResult Index()
        {
            String strMessage = String.Empty;
            
            

            Models.Deck deck = FillDeck();
            foreach (Models.Card c in deck.Cards)
            {
                strMessage += c.CardRank + " of " + c.CardSuit + " /n ";
            }

            @ViewBag.Message = strMessage;

            return View();
        }

        static Models.Rank RandomRank()
        {
            Models.Rank[] values = (Models.Rank[]) Enum.GetValues(typeof(Models.Rank));
            return values[new Random().Next(0, values.Length)];
        }

        static Models.Suit RandomSuit()
        {
            Models.Suit[] values = (Models.Suit[])Enum.GetValues(typeof(Models.Suit));
            return values[new Random().Next(0, values.Length)];
        }

        static Models.Card RandomCard()
        {
            Models.Rank cardRank = RandomRank();
            Models.Suit cardSuit = RandomSuit();

            Models.Card card = new Models.Card();
            card.CardRank = cardRank;
            card.CardSuit = cardSuit;

            return card;
            
        }

        static Models.Deck FillDeck()
        {
            Models.Deck deck = new Models.Deck();

            deck.Cards = new Models.Card[52];

            int count = 0;
            
            foreach(Models.Rank r in (Models.Rank[])Enum.GetValues(typeof(Models.Rank)))
            {
                foreach (Models.Suit s in (Models.Suit[])Enum.GetValues(typeof(Models.Suit)))
                {
                    deck.Cards[count] = new Models.Card();
                    deck.Cards[count].CardRank = r;
                    deck.Cards[count].CardSuit = s;
                    count++;
                }
            }
            

            return deck;
        }

        public Models.Deck ShuffleDeck(Models.Deck deck)
        {
            Models.Deck tempDeck1 = new Models.Deck();
            Models.Deck tempDeck2 = new Models.Deck();

            Models.Card[] c1 = new Models.Card[26];
            Models.Card[] c2 = new Models.Card[26];

            SplitMidPoint<Models.Card>(deck.Cards, out c1, out c2);

            tempDeck1.Cards = c1;
            tempDeck2.Cards = c2;

            //deck.Cards = c1.Union(c2);

            return deck;
        }

        public void Split<T>(T[] array, int index, out T[] first, out T[] second)
        {
            first = array.Take(index).ToArray();
            second = array.Skip(index).ToArray();
        }

        public void SplitMidPoint<T>(T[] array, out T[] first, out T[] second)
        {
            Split(array, array.Length / 2, out first, out second);
        }

        public void Merge<T>(T[] first, T[] second, out T[] array)
        {
            T[] arrayFinal = new T[first.Length + second.Length];

            first.CopyTo(arrayFinal, 0);
            second.CopyTo(arrayFinal, first.Length);

            //arrayFinal.CopyTo(out array, 0);
            
        }

    }

}
