using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<PlayerGame> PlayerGames { get; set; }
        [Display(Name = "Number of Players")]
        [Range(minimum: GnosticaParameters.MIN_PLAYERS_PER_GAME, maximum: GnosticaParameters.MAX_PLAYERS_PER_GAME)]
        public byte NumPlayers { get; set; }
        public CardList Deck { get; set; }
        public CardList Discards { get; set; }
        public List<Card> Board { get; set; }
        public byte Turn { get; set; }
        public ushort Round { get; set; }
        public ushort? VictoryDeclaredRound { get; set; }
        public byte? VictoryDeclaredTurn { get; set; }
        public Player VictoryDeclaredPlayer { get; set; }
        public bool VictoryDeclared => VictoryDeclaredPlayer != null;

        public void Initialize(byte players = GnosticaParameters.MIN_PLAYERS_PER_GAME)
        {
            Deck = new CardList(empty: false);
            Deck.Shuffle();
            Discards = new CardList(empty: true);
            NumPlayers = players;
            PlayerGames = new List<PlayerGame>(players);
            for(int playerNum = 0; playerNum != NumPlayers; playerNum++)
            {
                PlayerGames.Add(new PlayerGame());
                PlayerGames[playerNum].Hand = new List<CardInCardList>(capacity: GnosticaParameters.HAND_SIZE);
            }
            Board = new List<Card>(GnosticaParameters.MAX_EXPECTED_BOARD_SIZE);
            Turn = 0;
            Round = 0;
            VictoryDeclaredRound = null;
            VictoryDeclaredTurn = null;
            VictoryDeclaredPlayer = null;
        }

        public void CreateBoard()
        {
            for(sbyte x = -1; x != 2; x++)
            {
                for(sbyte y = -1; y != 2; y++)
                {
                    var card = Deck.Draw();
                    card.Location = new Location();
                    card.Location.cardLocation = Location.CardLocation.Board;
                    card.Location.X = x;
                    card.Location.Y = y;
                    Board.Add(card);
                }
            }
        }
     }
}
