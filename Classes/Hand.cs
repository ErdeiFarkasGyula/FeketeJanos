using FeketeJános.Classes;
using System.Collections.Generic;

public class Hand {
    public List<Card> Cards;

    public Hand() {
        Cards = new List<Card>();
    }

    public int Value {
        get {
            int total = 0;
            int aceCount = 0;

            foreach (Card card in Cards) {
                total += card.Value;

                if (card.Rank == "A") {
                    aceCount++;
                }
            }

            while (total > 21 && aceCount > 0) {
                total -= 10;
                aceCount--;
            }

            return total;
        }
    }

    public bool IsBust {
        get { return Value > 21; }
    }

    public bool IsBlackjack {
        get { return Cards.Count == 2 && Value == 21; }
    }

    public void Add(Card card) {
        Cards.Add(card);
    }
}
