using FeketeJános.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FeketeJános.Windows {
    public partial class GameWindow : Window {
        Deck deck = new Deck();
        Hand player = new Hand();
        Hand dealer = new Hand();

        public GameWindow() {
            InitializeComponent();

            player.Add(deck.Draw());
            player.Add(deck.Draw());

            dealer.Add(deck.Draw());
            dealer.Add(deck.Draw());

            UpdateUI();
        }

        void UpdateUI() {
            AdatGrid.Items.Add(new TablazatSor("Te", string.Join(", ", player.Cards), player.Value.ToString()));
            AdatGrid.Items.Add(new TablazatSor("AI©", dealer.Cards[0] + ", [Hidden]", "Számold csak ki"));
        }

        private void Hit_Click(object sender, RoutedEventArgs e) {
            player.Add(deck.Draw());
            UpdateUI();

            if (player.Value > 21) {
                EndGame("Bust! Dealer wins.");
            }
        }

        private void Stand_Click(object sender, RoutedEventArgs e) {
            while (dealer.Value < 17)
                dealer.Add(deck.Draw());

            string result;

            if (dealer.Value > 21 || player.Value > dealer.Value)
                result = "You win!";
            else if (player.Value < dealer.Value)
                result = "Dealer wins!";
            else
                result = "Push!";

            EndGame(result);
        }

        void EndGame(string message) {
            ResultWindow resultWindow = new ResultWindow(message, player, dealer);
            resultWindow.Show();
            Close();
        }

        public class TablazatSor {
            public string nev { get; set; }
            public string cards { get; set; }
            public string value { get; set; }

            public TablazatSor(string nev, string cards, string value) {
                this.nev = nev;
                this.cards = cards;
                this.value = value;
            }
        }

    }
}
