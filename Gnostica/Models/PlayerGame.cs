using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SixLabors.ImageSharp;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class PlayerGame
    {
        public int PlayerID { get; set; }
        public Player Player { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
        public List<CardInCardList> Hand { get; set; }
        public List<Piece> Pieces { get; set; }
        [Display(Name = "Piece Color")]
        public Color PieceColor { get; set; }
        public bool Eliminated { get; set; }

        public void Initialize()
        {
            Hand = new List<CardInCardList>(GnosticaParameters.HAND_SIZE);
            Pieces = new List<Piece>(GnosticaParameters.PIECES_PER_PLAYER);
            Eliminated = false;
        }
    }
}
