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
    public partial class ResultWindow : Window {
        public ResultWindow(string result, Hand player, Hand dealer) {
            InitializeComponent();

            ResultText.Text = result;
            FinalHands.Text =
                $"Player ({player.Value}): {string.Join(", ", player.Cards)}\n" +
                $"Dealer ({dealer.Value}): {string.Join(", ", dealer.Cards)}";
        }

        private void Menu_Click(object sender, RoutedEventArgs e) {
            MainWindow menu = new MainWindow();
            menu.Show();
            Close();
        }

    }
}
