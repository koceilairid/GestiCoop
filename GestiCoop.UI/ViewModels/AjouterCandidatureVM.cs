using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GestiCoop.UI;

public class AjouterCandidatureVM : ViewModelBase
{
    // Les listes de choix (reçues de la liste des candidatures)
    public ObservableCollection<Etudiant> Etudiants { get; }
    public ObservableCollection<OffreStage> Offres { get; }

    public ObservableCollection<string> Statuts { get; }
        = new ObservableCollection<string> { "En attente", "Acceptée", "Refusée" };

    private Etudiant? _etudiantChoisi;
    public Etudiant? EtudiantChoisi
    {
        get => _etudiantChoisi;
        set => Set(ref _etudiantChoisi, value);
    }

    private OffreStage? _offreChoisie;
    public OffreStage? OffreChoisie
    {
        get => _offreChoisie;
        set => Set(ref _offreChoisie, value);
    }

    private DateTime? _dateCandidature = DateTime.Today;
    public DateTime? DateCandidature
    {
        get => _dateCandidature;
        set => Set(ref _dateCandidature, value);
    }

    private string _statut = "En attente";
    public string Statut
    {
        get => _statut;
        set => Set(ref _statut, value);
    }

    public Candidature? Resultat { get; private set; }

    public ICommand EnregistrerCommand { get; }

    public AjouterCandidatureVM(ObservableCollection<Etudiant> etudiants,
                                ObservableCollection<OffreStage> offres)
    {
        Etudiants = etudiants;
        Offres = offres;

        EnregistrerCommand = new RelayCommand(
            execute: p => Enregistrer(p as Window),
            canExecute: _ => PeutEnregistrer());
    }

    private bool PeutEnregistrer()
        => EtudiantChoisi != null
        && OffreChoisie != null
        && DateCandidature != null;

    private void Enregistrer(Window? fenetre)
    {
        Resultat = new Candidature
        {
            Etudiant = EtudiantChoisi!,
            Offre = OffreChoisie!,
            DateCandidature = DateCandidature ?? DateTime.Today,
            Statut = Statut
        };
        if (fenetre != null)
            fenetre.DialogResult = true;
    }
}