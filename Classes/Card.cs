using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeketeJános.Classes {
    public class Card {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; }

        public override string ToString() {
            return Rank + Suit;
        }
    }
}

