using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestiCoop.UI;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(
        [CallerMemberName] string? nomPropriete = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
    }

    protected bool Set<T>(ref T champ, T valeur,
        [CallerMemberName] string? nomPropriete = null)
    {
        if (Equals(champ, valeur)) return false;
        champ = valeur;
        OnPropertyChanged(nomPropriete);
        return true;
    }
}