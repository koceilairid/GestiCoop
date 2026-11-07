namespace GestiCoop.UI;

public class OffreStage : ViewModelBase
{
    private string _titre = string.Empty;
    public string Titre
    {
        get => _titre;
        set => Set(ref _titre, value);
    }

    private string _secteur = string.Empty;
    public string Secteur
    {
        get => _secteur;
        set => Set(ref _secteur, value);
    }

    private int _dureeSemaines;
    public int DureeSemaines
    {
        get => _dureeSemaines;
        set => Set(ref _dureeSemaines, value);
    }

    private DateTime _dateLimite;
    public DateTime DateLimite
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

    private string _statut = "Ouvert";
    public string Statut
    {
        get => _statut;
        set => Set(ref _statut, value);
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set => Set(ref _description, value);
    }
}