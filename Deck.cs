using System.Globalization;
using System.Linq.Expressions;
using System.Net;
using System.Net.Security;

namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };


        // Create a public int property Count that returns the Count value from the private collection _cards
        public int Count
        {
            get { return _cards.Count; }
        }

        // Create a private field _cards that is a List<Card>
        private List<Card> _cards;

        // Create a public constructor that takes two parameter: a List<card> called cards and a boolean value called isEmptyDeck
        // If cards is not null and has elements in it, assign it to _cards and be done
        // If cards is null or empty:
        //     _cards should be initialized as an empty List<Card>
        //     InitializeDeck() should be called if and only if isEmptyDeck is false
        public Deck(List<Card> cards, bool isEmptyDeck)
        {
            if (cards != null && cards.Count > 0)
            {
                _cards = cards;
            }
            else
            {
                _cards = new List<Card>();
                if (!isEmptyDeck)
                {
                    InitializeDeck();
                }
            }

        }

        // Create a private void method called InitializeDeck() which does the following:
        // Use RankNames and Suits in nested loops to generate all 52 combinations of rank and suit and add them to _cards
        private void InitializeDeck()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card newCard = new Card(Suits[j], i);
                    _cards.Add(newCard);
                    //fixed it, long story short im an idiot.
                }
            }
        }

        // Create a public void method called Shuffle() which shuffles (rearranges) the cards in _cards
        public void Shuffle()
        {
            Random randomCard = new Random();
            for (int i = 0; i < _cards.Count - 1; i++)
            {
                int j = randomCard.Next(0, _cards.Count);

                Card temp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = temp;
            }
        }

        // Create a public method CardAtIndex which takes an int parameter for the index of a card and
        // returns the card at the index specified, or throws IndexOutOfRangeException if index is too large or too small
        public Card CardAtIndex(int cardIndex)
        {
            if (cardIndex < 0 || cardIndex > _cards.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Card card = _cards[cardIndex];
                return card;
            }
        }

        // Create a public method PullCardAtIndex which does exactly the same thing as CardAtIndex
        // with the additional feature that it _removes_ the card from the deck
        public Card PullCardAtIndex(int cardIndex)
        {
             if (cardIndex < 0 || cardIndex > _cards.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Card card = _cards[cardIndex];
                _cards.RemoveAt(cardIndex);
                return card;
            }
        }

        // Create a public method PullAllCards that returns a list of all of the cards in the deck
        // and removes them all from the deck, leaving it empty
        public List<Card> PullAllCards()
        {
            List<Card> pulledCards = new List<Card>();
            for (int i = 0; i < _cards.Count; i++)
            {
                pulledCards.Add(_cards[i]);
            }
            _cards.Clear();
            return pulledCards;
        }

        // Create a public method PushCard that accepts a Card as a parameter and adds it to _cards
        public void PushCard(Card card)
        {
            _cards.Add(card);
        }

        // Create a public method PushCards that accepts a List<Card> as a parameter and adds the list to _cards
        // Be sure to use AddRange and not Add
        public void PushCards(List<Card> listOfCards)
        {
            _cards.AddRange(listOfCards);
        }

        // Create a public method Deal that accepts an integer representing the number of cards to deal
        // and then removes that many cards from the deck, returning them as a List<Card>
        // Be sure to check the size of _cards against the number of cards requested so you don't go out
        // of bounds
        public List<Card> Deal(int cardsToDeal)
        {
            if (cardsToDeal > _cards.Count)
            {
                throw new IndexOutOfRangeException();
            }
            List<Card> deltCards = new List<Card>();
            for (int i = 0; i < cardsToDeal; i++)
            {
                deltCards.Add(_cards[i]);
                _cards.RemoveAt(0);
            }
            return deltCards;
        }
    }
}




