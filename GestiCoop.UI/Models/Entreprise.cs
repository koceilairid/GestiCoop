namespace GestiCoop.UI;

public class Entreprise
{
    // Identification
    public string Nom { get; set; } = string.Empty;
    public string SiteWeb { get; set; } = string.Empty;
    public string Secteur { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;

    // Personne-contact
    public string ContactNom { get; set; } = string.Empty;
    public string ContactCourriel { get; set; } = string.Empty;
    public string ContactTelephone { get; set; } = string.Empty;
    public string ContactTitre { get; set; } = string.Empty;

    // Offres de stage
    public int PostesOfferts { get; set; } = 1;
    public DateTime DateLimite { get; set; } = DateTime.Today.AddMonths(1);
    public string Statut { get; set; } = "Active";   // Active ou Archivée
}