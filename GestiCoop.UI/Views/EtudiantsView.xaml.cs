using System.Windows;

namespace GestiCoop.UI.Views;

public partial class EtudiantsView : Window
{
    public EtudiantsView()
    {
        InitializeComponent();
        DataContext = new EtudiantsViewModel();
    }
}