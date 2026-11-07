using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestiCoop.UI;

public class CandidaturesViewModel : ViewModelBase
{
    public ObservableCollection<Candidature> Candidatures { get; }
        = new ObservableCollection<Candidature>();

    // Listes utilisées par le formulaire (choix de l'étudiant et de l'offre)
    public ObservableCollection<Etudiant> Etudiants { get; }
        = new ObservableCollection<Etudiant>();
    public ObservableCollection<OffreStage> Offres { get; }
        = new ObservableCollection<OffreStage>();

    private Candidature? _candidatureSelectionnee;
    public Candidature? CandidatureSelectionnee
    {
        get => _candidatureSelectionnee;
        set => Set(ref _candidatureSelectionnee, value);
    }

    public ICommand AjouterCommand { get; }
    public ICommand SupprimerCommand { get; }

    public CandidaturesViewModel()
    {
        // Quelques étudiants et offres d'exemple
        Etudiants.Add(new Etudiant { Nom = "Tremblay", Prenom = "Sophie", Programme = "Informatique" });
        Etudiants.Add(new Etudiant { Nom = "Nguyen", Prenom = "Minh", Programme = "Informatique" });
        Etudiants.Add(new Etudiant { Nom = "Dubois", Prenom = "Élodie", Programme = "Génie logiciel" });

        Offres.Add(new OffreStage { Titre = "Développeur WPF", Secteur = "Informatique", Statut = "Ouvert" });
        Offres.Add(new OffreStage { Titre = "Designer UX", Secteur = "Design", Statut = "Ouvert" });

        // Quelques candidatures d'exemple
        Candidatures.Add(new Candidature { Etudiant = Etudiants[0], Offre = Offres[0], Statut = "En attente" });
        Candidatures.Add(new Candidature { Etudiant = Etudiants[1], Offre = Offres[1], Statut = "Acceptée" });

        AjouterCommand = new RelayCommand(
            execute: _ => Ajouter());

        SupprimerCommand = new RelayCommand(
            execute: _ => Supprimer(),
            canExecute: _ => CandidatureSelectionnee != null);
    }

    private void Ajouter()
    {
        var vm = new AjouterCandidatureVM(Etudiants, Offres);
        var fenetre = new Views.AjouterCandidatureWindow();
        fenetre.DataContext = vm;

        if (fenetre.ShowDialog() == true && vm.Resultat != null)
        {
            Candidatures.Add(vm.Resultat);
            CandidatureSelectionnee = vm.Resultat;
        }
    }

    private void Supprimer()
    {
        if (CandidatureSelectionnee != null)
            Candidatures.Remove(CandidatureSelectionnee);
    }
}