using System.Windows;

namespace GestiCoop.UI.Views;

public partial class EntreprisesView : Window
{
    public EntreprisesView()
    {
        InitializeComponent();
        DataContext = new EntreprisesViewModel();
    }
}