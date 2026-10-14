using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestiCoop.UI;

public class OffreListeViewModel : ViewModelBase
{
    public ObservableCollection<OffreStage> Offres { get; }
        = new ObservableCollection<OffreStage>();

    private OffreStage? _offreSelectionnee;
    public OffreStage? OffreSelectionnee
    {
        get => _offreSelectionnee;
        set => Set(ref _offreSelectionnee, value);
    }

    public ICommand AjouterCommand { get; }
    public ICommand SupprimerCommand { get; }

    public OffreListeViewModel()
    {
        // Quelques offres de départ (celles de la maquette)
        Offres.Add(new OffreStage { Titre = "Développeur WPF", Secteur = "Informatique", Statut = "Ouvert" });
        Offres.Add(new OffreStage { Titre = "Analyste données", Secteur = "Finance", Statut = "Fermé" });
        Offres.Add(new OffreStage { Titre = "Designer UX", Secteur = "Design", Statut = "Ouvert" });
        Offres.Add(new OffreStage { Titre = "Technicien réseau", Secteur = "TI", Statut = "En cours" });

        AjouterCommand = new RelayCommand(
            execute: _ => Ajouter());

        SupprimerCommand = new RelayCommand(
            execute: _ => Supprimer(),
            canExecute: _ => OffreSelectionnee != null);
    }

    private void Ajouter()
    {
        var nouvelle = new OffreStage { Titre = "Nouvelle offre", Secteur = "À préciser" };
        Offres.Add(nouvelle);
        OffreSelectionnee = nouvelle;
    }

    private void Supprimer()
    {
        if (OffreSelectionnee != null)
            Offres.Remove(OffreSelectionnee);
    }
}