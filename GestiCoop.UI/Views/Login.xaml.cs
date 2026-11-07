using System.Windows;

namespace GestiCoop.UI.Views;

public partial class Login : Window
{
    public Login()
    {
        InitializeComponent();
    }

    // entre dans l'application : ouvre le tableau de bord et ferme la connexion
    private void SeConnecter_Click(object sender, RoutedEventArgs e)
    {
        var tableau = new TableauDeBord();
        Application.Current.MainWindow = tableau;
        tableau.Show();
        Close();
    }
}