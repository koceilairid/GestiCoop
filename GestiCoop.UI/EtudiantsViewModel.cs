using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GestiCoop.UI;

public class EtudiantsViewModel : ViewModelBase
{
    private readonly List<Etudiant> _tous = new List<Etudiant>();

    public ObservableCollection<Etudiant> Etudiants { get; }
        = new ObservableCollection<Etudiant>();

    public ObservableCollection<string> Programmes { get; }
        = new ObservableCollection<string>
        {
            "Tous les programmes", "Informatique", "Génie logiciel", "Cybersécurité"
        };

    private string _programmeFiltre = "Tous les programmes";
    public string ProgrammeFiltre
    {
        get => _programmeFiltre;
        set { if (Set(ref _programmeFiltre, value)) AppliquerFiltre(); }
    }

    private string _recherche = string.Empty;
    public string Recherche
    {
        get => _recherche;
        set { if (Set(ref _recherche, value)) AppliquerFiltre(); }
    }

    public int NombreTotal => _tous.Count;

    public ICommand AjouterCommand { get; }
    public ICommand ModifierCommand { get; }
    public ICommand SupprimerCommand { get; }

    public EtudiantsViewModel()
    {
        _tous.Add(new Etudiant { Nom = "Tremblay", Prenom = "Sophie", Programme = "Informatique", Courriel = "s.tremblay@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Nguyen", Prenom = "Minh", Programme = "Informatique", Courriel = "m.nguyen@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Dubois", Prenom = "Élodie", Programme = "Génie logiciel", Courriel = "e.dubois@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Okonkwo", Prenom = "Chidi", Programme = "Cybersécurité", Courriel = "c.okonkwo@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Lavoie", Prenom = "Xavier", Programme = "Informatique", Courriel = "x.lavoie@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Gagnon", Prenom = "Julie", Programme = "Génie logiciel", Courriel = "j.gagnon@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Roy", Prenom = "Marc", Programme = "Cybersécurité", Courriel = "m.roy@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Côté", Prenom = "Amélie", Programme = "Informatique", Courriel = "a.cote@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Diallo", Prenom = "Aminata", Programme = "Génie logiciel", Courriel = "a.diallo@etud.lacite.ca" });
        _tous.Add(new Etudiant { Nom = "Bouchard", Prenom = "Louis", Programme = "Cybersécurité", Courriel = "l.bouchard@etud.lacite.ca" });

        AjouterCommand = new RelayCommand(_ => Ajouter());
        ModifierCommand = new RelayCommand(p => Modifier(p as Etudiant));
        SupprimerCommand = new RelayCommand(p => Supprimer(p as Etudiant));

        AppliquerFiltre();
    }

    private void AppliquerFiltre()
    {
        Etudiants.Clear();
        foreach (var e in _tous)
        {
            bool bonProgramme = ProgrammeFiltre == "Tous les programmes"
                                || e.Programme == ProgrammeFiltre;
            bool bonneRecherche = string.IsNullOrWhiteSpace(Recherche)
                || e.Nom.Contains(Recherche, StringComparison.OrdinalIgnoreCase)
                || e.Prenom.Contains(Recherche, StringComparison.OrdinalIgnoreCase);

            if (bonProgramme && bonneRecherche)
                Etudiants.Add(e);
        }
    }

    private void Ajouter()
    {
        var fenetre = new Views.AjouterEtudiantWindow();
        fenetre.Owner = Application.Current.MainWindow;

        if (fenetre.ShowDialog() == true && fenetre.Resultat != null)
        {
            _tous.Add(fenetre.Resultat);
            AppliquerFiltre();
            OnPropertyChanged(nameof(NombreTotal));
        }
    }

    private void Modifier(Etudiant? e)
    {
        // Non demandé dans l'énoncé pour l'instant
    }

    private void Supprimer(Etudiant? e)
    {
        if (e == null) return;
        _tous.Remove(e);
        Etudiants.Remove(e);
        OnPropertyChanged(nameof(NombreTotal));
    }
}