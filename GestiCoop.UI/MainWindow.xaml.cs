using System.Windows;

namespace GestiCoop.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnNouvelleOffre_Click(object sender, RoutedEventArgs e)
    {
        var formulaire = new FormulaireOffre();
        formulaire.Owner = this;

        if (formulaire.ShowDialog() == true && formulaire.ResultatOffre != null)
        {
            OffreStage offre = formulaire.ResultatOffre;
            lblStatut.Text =
                $"Offre enregistrée : {offre.Titre} — {offre.Secteur}, " +
                $"{offre.DureeSemaines} sem., {offre.Remuneration:C}, " +
                $"limite {offre.DateLimite:yyyy-MM-dd}, {offre.Statut}";
        }
        else
        {
            lblStatut.Text = "Saisie annulée.";
        }
    }
}