using System.Windows;

namespace GestiCoop.UI.Views;

public partial class CandidaturesView : Window
{
    public CandidaturesView()
    {
        InitializeComponent();
        DataContext = new CandidaturesViewModel();
    }
}