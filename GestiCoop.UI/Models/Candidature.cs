namespace GestiCoop.UI;

public class Candidature
{
    public Etudiant Etudiant { get; set; } = new Etudiant();
    public OffreStage Offre { get; set; } = new OffreStage();
    public DateTime DateCandidature { get; set; } = DateTime.Today;
    public string Statut { get; set; } = "En attente";   // En attente, Acceptée ou Refusée
}