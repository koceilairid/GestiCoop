using System.Windows;

namespace GestiCoop.UI.Views;

public partial class TableauDeBord : Window
{
    public TableauDeBord()
    {
        InitializeComponent();
    }

    // ouvre la liste des offres de stage (TP4)
    private void Offres_Click(object sender, RoutedEventArgs e)
    {
        var fenetre = new MainWindow
        {
            Owner = this
        };

        fenetre.ShowDialog();
    }

    // ouvre la liste des étudiants (examen blanc)
    private void Etudiants_Click(object sender, RoutedEventArgs e)
    {
        var fenetre = new EtudiantsView
        {
            Owner = this
        };

        fenetre.ShowDialog();
    }
    // ouvre la liste des entreprises
    private void Entreprises_Click(object sender, RoutedEventArgs e)
    {
        var fenetre = new EntreprisesView
        {
            Owner = this
        };

        fenetre.ShowDialog();
    }
    // ouvre la liste des candidatures
    private void Candidatures_Click(object sender, RoutedEventArgs e)
    {
        var fenetre = new CandidaturesView
        {
            Owner = this
        };

        fenetre.ShowDialog();
    }
}