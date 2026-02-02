using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeketeJános.Classes {
    public class Hand {
        public List<Card> Cards;

        public Hand() {
            Cards = new List<Card>();
        }

        public int Value {
            get {
                int total = 0;
                int aces = 0;

                foreach (Card card in Cards) {
                    total += card.Value;
                    if (card.Rank == "A")
                        aces++;
                }

                while (total > 21 && aces > 0) {
                    total -= 10;
                    aces--;
                }

                return total;
            }
        }

        public void Add(Card card) {
            Cards.Add(card);
        }
    }
}
