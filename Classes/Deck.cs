using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeketeJános.Classes {
    public class Deck {
        private List<Card> cards;
        private Random rng;

        public Deck() {
            rng = new Random();
            cards = new List<Card>();

            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string suit in suits) {
                foreach (string rank in ranks) {
                    int value;

                    switch (rank) {
                        case "J":
                        case "Q":
                        case "K":
                            value = 10;
                            break;
                        case "A":
                            value = 11;
                            break;
                        default:
                            value = int.Parse(rank);
                            break;
                    }

                    cards.Add(new Card {
                        Suit = suit,
                        Rank = rank,
                        Value = value
                    });
                }
            }

            Shuffle();
        }

        public void Shuffle() {
            for (int i = cards.Count - 1; i > 0; i--) {
                int j = rng.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card Draw() {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }

}
