using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace GestiCoop.UI;

public class AjouterEtudiantVM : ViewModelBase
{
    private string _nom = string.Empty;
    public string Nom
    {
        get => _nom;
        set => Set(ref _nom, value);
    }

    private string _prenom = string.Empty;
    public string Prenom
    {
        get => _prenom;
        set => Set(ref _prenom, value);
    }

    private string _courriel = string.Empty;
    public string Courriel
    {
        get => _courriel;
        set { if (Set(ref _courriel, value)) OnPropertyChanged(nameof(CourrielInvalide)); }
    }

    private string? _programme;
    public string? Programme
    {
        get => _programme;
        set => Set(ref _programme, value);
    }

    private string _numero = string.Empty;
    public string Numero
    {
        get => _numero;
        set { if (Set(ref _numero, value)) OnPropertyChanged(nameof(NumeroInvalide)); }
    }

    public ObservableCollection<string> Programmes { get; }
        = new ObservableCollection<string> { "Informatique", "Génie logiciel", "Cybersécurité" };

    public bool CourrielInvalide => Courriel.Length > 0 && !CourrielValide();
    public bool NumeroInvalide => Numero.Length > 0 && !Regex.IsMatch(Numero, @"^\d{7}$");

    public Etudiant? Resultat { get; private set; }

    public ICommand EnregistrerCommand { get; }

    public AjouterEtudiantVM()
    {
        EnregistrerCommand = new RelayCommand(
            execute: p => Enregistrer(p as Window),
            canExecute: _ => PeutEnregistrer());
    }

    private bool CourrielValide()
        => Regex.IsMatch(Courriel, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    private bool PeutEnregistrer()
        => !string.IsNullOrWhiteSpace(Nom)
        && !string.IsNullOrWhiteSpace(Prenom)
        && CourrielValide()
        && !string.IsNullOrEmpty(Programme)
        && !NumeroInvalide;

    private void Enregistrer(Window? fenetre)
    {
        Resultat = new Etudiant
        {
            Nom = Nom.Trim(),
            Prenom = Prenom.Trim(),
            Courriel = Courriel.Trim(),
            Programme = Programme ?? "",
            Numero = Numero.Trim()
        };
        if (fenetre != null)
            fenetre.DialogResult = true;
    }
}