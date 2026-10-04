namespace GestiCoop.UI;

public class OffreStage
{
    public string Titre { get; set; } = string.Empty;
    public string Secteur { get; set; } = string.Empty;
    public int DureeSemaines { get; set; }
    public DateTime DateLimite { get; set; }
    public decimal Remuneration { get; set; }
    public string Statut { get; set; } = "Ouvert";
    public string Description { get; set; } = string.Empty;
}