using System.Windows;

namespace GestiCoop.UI.Views;

public partial class AjouterEtudiantWindow : Window
{
    public Etudiant? Resultat { get; private set; }

    public AjouterEtudiantWindow()
    {
        InitializeComponent();
        cboProgramme.ItemsSource = new List<string>
        {
            "Informatique", "Génie logiciel", "Cybersécurité"
        };
        cboProgramme.SelectedIndex = 0;
        txtNom.Focus();
    }

    private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
    {
        var erreurs = new List<string>();
        if (string.IsNullOrWhiteSpace(txtNom.Text))
            erreurs.Add("Nom requis.");
        if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            erreurs.Add("Prénom requis.");
        if (cboProgramme.SelectedItem == null)
            erreurs.Add("Programme requis.");
        if (!txtCourriel.Text.Contains("@"))
            erreurs.Add("Courriel invalide.");

        if (erreurs.Count > 0)
        {
            MessageBox.Show(string.Join("\n", erreurs), "Validation",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        Resultat = new Etudiant
        {
            Nom = txtNom.Text.Trim(),
            Prenom = txtPrenom.Text.Trim(),
            Programme = cboProgramme.SelectedItem?.ToString() ?? "",
            Courriel = txtCourriel.Text.Trim()
        };
        DialogResult = true;
    }

    private void btnAnnuler_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}