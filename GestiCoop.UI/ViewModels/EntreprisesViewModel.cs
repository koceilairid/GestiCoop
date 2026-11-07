using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestiCoop.UI;

public class EntreprisesViewModel : ViewModelBase
{
    public ObservableCollection<Entreprise> Entreprises { get; }
        = new ObservableCollection<Entreprise>();

    private Entreprise? _entrepriseSelectionnee;
    public Entreprise? EntrepriseSelectionnee
    {
        get => _entrepriseSelectionnee;
        set => Set(ref _entrepriseSelectionnee, value);
    }

    public ICommand AjouterCommand { get; }
    public ICommand SupprimerCommand { get; }

    public EntreprisesViewModel()
    {
        Entreprises.Add(new Entreprise { Nom = "Tech Solutions Inc.", SiteWeb = "techsolutions.ca", Secteur = "Développement logiciel", ContactNom = "Isabelle Roy", PostesOfferts = 3, DateLimite = new DateTime(2025, 11, 30), Statut = "Active" });
        Entreprises.Add(new Entreprise { Nom = "Nexus Corp", SiteWeb = "nexuscorp.com", Secteur = "Infrastructure Cloud", ContactNom = "Marc-André Lepage", PostesOfferts = 2, DateLimite = new DateTime(2025, 12, 15), Statut = "Active" });
        Entreprises.Add(new Entreprise { Nom = "DataViz Labs", SiteWeb = "dataviz.io", Secteur = "Data & Intelligence artificielle", ContactNom = "Sophie Chen", PostesOfferts = 4, DateLimite = new DateTime(2025, 11, 1), Statut = "Active" });
        Entreprises.Add(new Entreprise { Nom = "Innolab", SiteWeb = "innolab.ca", Secteur = "Innovation & R&D", ContactNom = "Julien Lavoie", PostesOfferts = 1, DateLimite = new DateTime(2025, 10, 20), Statut = "Archivée" });
        Entreprises.Add(new Entreprise { Nom = "PixelForge Studio", SiteWeb = "pixelforge.ca", Secteur = "Développement jeux vidéo", ContactNom = "Nathalie Morin", PostesOfferts = 2, DateLimite = new DateTime(2025, 12, 1), Statut = "Active" });
        Entreprises.Add(new Entreprise { Nom = "CloudSync", SiteWeb = "cloudsync.io", Secteur = "SaaS / DevOps", ContactNom = "Alain Bergeron", PostesOfferts = 3, DateLimite = new DateTime(2025, 12, 31), Statut = "Active" });

        AjouterCommand = new RelayCommand(
            execute: _ => Ajouter());

        // p = l'entreprise de la ligne cliquée (envoyée par CommandParameter)
        SupprimerCommand = new RelayCommand(
            execute: p => Supprimer(p as Entreprise ?? EntrepriseSelectionnee),
            canExecute: p => p is Entreprise || EntrepriseSelectionnee != null);
    }

    private void Ajouter()
    {
        var vm = new AjouterEntrepriseVM();
        var fenetre = new Views.AjouterEntrepriseWindow();
        fenetre.DataContext = vm;

        if (fenetre.ShowDialog() == true && vm.Resultat != null)
        {
            Entreprises.Add(vm.Resultat);
            EntrepriseSelectionnee = vm.Resultat;
        }
    }

    private void Supprimer(Entreprise? e)
    {
        if (e != null)
            Entreprises.Remove(e);
    }
}