using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    [Owned]
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
