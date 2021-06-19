using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class Piece : Target
    {
        public int ID { get; set; }
        public Orientation Orientation { get; set; }
    }
}
