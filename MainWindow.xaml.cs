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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace JP
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int number { get; set; } // Nombre entré par l'utilisateur
        delegate void Delegate(int nbr);
        event Delegate Evenement; // Evénement
        public MainWindow()
        {
        InitializeComponent();
        DataContext = this;
        // Déclaration du nombre aléatoire entre 1 & 50
        Random random = new Random();
        int random_number = random.Next(1,50);
        int tries = 0; // Initialisation du nombre d'essais
            // Déclaration de l'événement
            Evenement += (nbr) =>{
                // Boucle if
                if (number < 1 || number > 50) // Si le nombre n'est pas compris entre 1 & 50
                {
                label.Content = "Vous devez saisir un nombre entre 1 et 50 ...";
                }
                else
                {
                    if (number < random_number)
                    {
                    label.Content = "C'est plus, le nombre a deviner est plus grand...";
                    ++tries;
                    }
                    else if (number > random_number)
                    {
                    label.Content = "C'est moins, le nombre a deviner est plus petit...";
                    ++tries;
                    }
                    else
                    {
                    label.Content = "Bravo vous avez gagné et deviné le nombre en : " + tries + " essai(s)...";
                    }
                }
        };
        }
        private void Bouton_Click(object sender, RoutedEventArgs e)
        {
        Evenement(number);
        }
    }
}