using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace GestiCoop.UI;

public partial class FormulaireOffre : Window
{
    public OffreStage? ResultatOffre { get; private set; }

    public FormulaireOffre()
    {
        InitializeComponent();

        // Peupler le ComboBox
        cboSecteur.ItemsSource = new List<string>
        {
            "Technologie", "Santé", "Finance", "Éducation", "Autre"
        };
        cboSecteur.SelectedIndex = 0;

        // Date par défaut : dans 1 mois
        dpLimite.SelectedDate = DateTime.Today.AddMonths(1);

        // Curseur directement dans le champ Titre
        txtTitre.Focus();
    }

    // Active / désactive Enregistrer selon le titre
    private void txtTitre_TextChanged(object sender, TextChangedEventArgs e)
    {
        btnEnregistrer.IsEnabled = txtTitre.Text.Trim().Length > 0;
    }

    // Met à jour l'affichage de la durée
    private void slDuree_ValueChanged(object sender,
        RoutedPropertyChangedEventArgs<double> e)
    {
        if (lblDuree != null)
            lblDuree.Text = ((int)slDuree.Value).ToString();
    }

    // Réaction au changement de secteur
    private void cboSecteur_SelectionChanged(object sender,
        SelectionChangedEventArgs e)
    {
        // Logique métier si nécessaire (plus tard dans le cours)
    }

    private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
    {
        var erreurs = new List<string>();

        if (string.IsNullOrWhiteSpace(txtTitre.Text))
            erreurs.Add("Titre requis.");
        if (cboSecteur.SelectedItem == null)
            erreurs.Add("Secteur requis.");
        if (dpLimite.SelectedDate == null)
            erreurs.Add("Date limite requise.");
        else if (dpLimite.SelectedDate < DateTime.Today)
            erreurs.Add("La date limite doit être dans le futur.");

        decimal remuneration = 0;
        string texteRem = txtRemuneration.Text.Trim().Replace(',', '.');
        if (texteRem.Length > 0 &&
            (!decimal.TryParse(texteRem, NumberStyles.Number,
                CultureInfo.InvariantCulture, out remuneration)
             || remuneration < 0))
        {
            erreurs.Add("Rémunération invalide : entrez un nombre positif (ex. 18,50).");
        }

        if (erreurs.Count > 0)
        {
            MessageBox.Show(string.Join("\n", erreurs),
                "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        ResultatOffre = new OffreStage
        {
            Titre = txtTitre.Text.Trim(),
            Secteur = cboSecteur.SelectedItem?.ToString() ?? "",
            DureeSemaines = (int)slDuree.Value,
            DateLimite = dpLimite.SelectedDate ?? DateTime.Today,
            Remuneration = remuneration,
            Statut = rbOuvert.IsChecked == true ? "Ouvert" : "Fermé",
            Description = txtDescription.Text.Trim()
        };

        DialogResult = true; // succès : ferme la fenêtre
    }

    private void btnAnnuler_Click(object sender, RoutedEventArgs e)
    {
        if (MessageBox.Show("Annuler la saisie ?", "Confirmation",
                MessageBoxButton.YesNo, MessageBoxImage.Question)
            == MessageBoxResult.Yes)
        {
            DialogResult = false;
        }
    }
}