using System.Runtime.CompilerServices;
using GameOfWar;

// Create an instance of the GameState class
GameState newGame = new GameState();
// Shuffle CardDeck within your instance
newGame.CardDeck.Shuffle();
// Deal 26 cards each from CardDeck to your instance's PlayerDeck and ComputerDeck
newGame.PlayerDeck.PushCards(newGame.CardDeck.Deal(26));
newGame.ComputerDeck.PushCards(newGame.CardDeck.Deal(26));


// Create a function with the signature: static bool PlayCards(GameState state, int playerCardIndex)
// The function should:
//     Pull the card at playerCardIndex from state.PlayerDeck
//     Pull the card at index 0 from state.ComputerDeck
//     Compare the two cards
//         If the player card is higher, the player gets both cards along with any in state.TableDeck
//         If the computer card is higher, the computer gets both cards along with any in state.TableDeck
//         If the player and computer cards are the same, both cards go into state.TableDeck
//     Check whether either state.PlayerDeck or state.ComputerDeck are empty
//         If the computer deck is empty, the player wins and state.Winner should be set to "Computer"
//         If the player deck is empty, the computer wins and state.Winner should be set to "Player"
//     return true
static bool PlayCards(GameState state, int PlayerCardIndex)
{
    Card playerCard = state.PlayerDeck.PullCardAtIndex(PlayerCardIndex);
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);

    List<Card> roundCards = new List<Card>();
    roundCards.Add(playerCard);
    roundCards.Add(computerCard);

    if (playerCard > computerCard)
    {
        roundCards.AddRange(state.TableDeck.PullAllCards());

        state.PlayerDeck.PushCards(roundCards);
    }
    else if (computerCard > playerCard)
    {
        roundCards.AddRange(state.TableDeck.PullAllCards());

        state.ComputerDeck.PushCards(roundCards);
    }
    else
    {
        state.TableDeck.PushCard(playerCard);
        state.TableDeck.PushCard(computerCard);
    }
    if (state.ComputerDeck.Count == 0)
    {
        state.Winner = "Player";
    }
    if (state.PlayerDeck.Count == 0)
    {
        state.Winner = "Computer";
    }
    return true;

}


// Call Lib.RunGame(), passing two parameters: the state object you instantiated above and the name of your PlayCards function
Lib.RunGame(newGame, PlayCards);

namespace GameOfWar
{
    public class GameState
    {
        // Create a public Deck property called CardDeck
        public Deck CardDeck { get; set; }

        // Create a public Deck property called PlayerDeck
        public Deck PlayerDeck { get; set; }

        // Create a public Deck property called ComputerDeck
        public Deck ComputerDeck { get; set; }

        // Create a public Deck property called TableDeck
        public Deck TableDeck { get; set; }

        // Create a public string property called Winner
        public string Winner { get; set; }

        // Create a public constructor that accepts no parameters. It should:
        //    Initialize Winner to be empty (not null)
        //    Initialize CardDeck to be a new, fresh deck of 52 cards
        //    Initialize PlayerDeck, ComputerDeck, and TableDeck to be empty Deck objects (no cards)
        public GameState()
        {
            Winner = string.Empty;
            CardDeck = new Deck(null, false);
            PlayerDeck = new Deck(null, true);
            ComputerDeck = new Deck(null, true);
            TableDeck = new Deck(null, true);
        }
    }
}