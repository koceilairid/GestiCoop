using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GestiCoop.UI;

public class AjouterOffreVM : ViewModelBase
{
    private string _titre = string.Empty;
    public string Titre
    {
        get => _titre;
        set => Set(ref _titre, value);
    }

    private string? _secteur;
    public string? Secteur
    {
        get => _secteur;
        set => Set(ref _secteur, value);
    }

    private int _dureeSemaines = 12;
    public int DureeSemaines
    {
        get => _dureeSemaines;
        set => Set(ref _dureeSemaines, value);
    }

    private DateTime? _dateLimite = DateTime.Today.AddMonths(1);
    public DateTime? DateLimite
    {
        get => _dateLimite;
        set => Set(ref _dateLimite, value);
    }

    private decimal _remuneration;
    public decimal Remuneration
    {
        get => _remuneration;
        set => Set(ref _remuneration, value);
    }

    private bool _estOuvert = true;
    public bool EstOuvert
    {
        get => _estOuvert;
        set => Set(ref _estOuvert, value);
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set => Set(ref _description, value);
    }

    public ObservableCollection<string> Secteurs { get; }
        = new ObservableCollection<string> { "Technologie", "Santé", "Finance", "Éducation", "Autre" };

    public OffreStage? Resultat { get; private set; }

    public ICommand EnregistrerCommand { get; }

    public AjouterOffreVM()
    {
        EnregistrerCommand = new RelayCommand(
            execute: p => Enregistrer(p as Window),
            canExecute: _ => PeutEnregistrer());
    }

    private bool PeutEnregistrer()
        => !string.IsNullOrWhiteSpace(Titre)
        && !string.IsNullOrEmpty(Secteur)
        && DateLimite != null
        && DateLimite >= DateTime.Today
        && Remuneration >= 0;

    private void Enregistrer(Window? fenetre)
    {
        Resultat = new OffreStage
        {
            Titre = Titre.Trim(),
            Secteur = Secteur ?? "",
            DureeSemaines = DureeSemaines,
            DateLimite = DateLimite ?? DateTime.Today,
            Remuneration = Remuneration,
            Statut = EstOuvert ? "Ouvert" : "Fermé",
            Description = Description.Trim()
        };
        if (fenetre != null)
            fenetre.DialogResult = true;
    }
}