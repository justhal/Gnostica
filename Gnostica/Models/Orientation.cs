using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class Orientation
    {
        public Direction direction { get; set; }
        public enum Direction
        {
            North = 1,
            South = 2,
            East = 3,
            West = 4,
            Up = 5
        }
    }
}
