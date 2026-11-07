using System.Windows;
using System.Windows.Input;

namespace GestiCoop.UI;

public class AjouterEntrepriseVM : ViewModelBase
{
    private string _nom = string.Empty;
    public string Nom
    {
        get => _nom;
        set => Set(ref _nom, value);
    }

    private string _secteur = string.Empty;
    public string Secteur
    {
        get => _secteur;
        set => Set(ref _secteur, value);
    }

    private string _siteWeb = string.Empty;
    public string SiteWeb
    {
        get => _siteWeb;
        set => Set(ref _siteWeb, value);
    }

    private string _contactNom = string.Empty;
    public string ContactNom
    {
        get => _contactNom;
        set => Set(ref _contactNom, value);
    }

    private int _postesOfferts = 1;
    public int PostesOfferts
    {
        get => _postesOfferts;
        set => Set(ref _postesOfferts, value);
    }

    public Entreprise? Resultat { get; private set; }

    public ICommand EnregistrerCommand { get; }

    public AjouterEntrepriseVM()
    {
        EnregistrerCommand = new RelayCommand(
            execute: p => Enregistrer(p as Window),
            canExecute: _ => PeutEnregistrer());
    }

    private bool PeutEnregistrer()
        => !string.IsNullOrWhiteSpace(Nom)
        && !string.IsNullOrWhiteSpace(Secteur)
        && PostesOfferts > 0;

    private void Enregistrer(Window? fenetre)
    {
        Resultat = new Entreprise
        {
            Nom = Nom.Trim(),
            Secteur = Secteur.Trim(),
            SiteWeb = SiteWeb.Trim(),
            ContactNom = ContactNom.Trim(),
            PostesOfferts = PostesOfferts
        };
        if (fenetre != null)
            fenetre.DialogResult = true;
    }
}